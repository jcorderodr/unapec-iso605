using System;
using System.Collections.Generic;
using System.Linq;
using Unapec.HumanResourcesM.Framework.Data;
using Unapec.HumanResourcesM.Framework.Entities;

namespace Unapec.HumanResourcesM.Framework.Services
{

    public class JobService
    {

        private readonly DataContext _context;
        private EmployeeService _employeeService;

        public JobService()
        {
            _context = new DataContext();
        }

        public Job Create(Job job)
        {
            job.RegisteredDate = DateTimeOffset.Now;
            _context.JobOffers.Add(job);
            _context.SaveChanges();
            return job;
        }

        public Applicant Create(Applicant applicant)
        {
            applicant.ApplicationDate = DateTimeOffset.Now;
            applicant.Status = PersonStatus.Applicant;
            _context.Applicants.Add(applicant);
            _context.SaveChanges();
            //
            applicant.Details.ApplicantId = applicant.Id;
            _context.ApplicantDetails.Add(applicant.Details);
            _context.SaveChanges();
            return applicant;
        }

        public IEnumerable<Job> GetAvailableJobs()
        {
            return _context.JobOffers.Where(p=> p.Status == JobStatus.Open).ToList();
        }

        public IEnumerable<Applicant> GetApplicantsByJob(int jobOfferId)
        {
            var entities = _context.Applicants.Where(p => p.Status == PersonStatus.Applicant && p.JobOffer.Id == jobOfferId).ToList();
            foreach (var p in entities)
            {
                p.Details = _context.ApplicantDetails.SingleOrDefault(i => i.ApplicantId == p.Id);
            }
            return entities;
        }

        public int GetApplicantsCountForJob(int jobId)
        {
            return _context.Applicants.Where(p => p.JobOffer.Id == jobId && p.Status == PersonStatus.Applicant).Count();
        }

        public IEnumerable<Applicant> DoApplicantsSearch(string name, int jobOfferId)
        {
            return _context.Applicants.Where(p => p.Name.Contains(name) && p.JobOffer.Id == jobOfferId).ToList();
        }

        public void CloseJobOffer(IEnumerable<int> selectedApplicants, int jobOfferId)
        {
            var transaction = _context.Database.BeginTransaction();

            // 1.- Update candidates
            var applicants = _context.Applicants.Where(p => selectedApplicants.Contains(p.Id)).ToList();
            
            foreach (var app in applicants)
            {
                app.Status = PersonStatus.Normal;
                _context.Entry(app).State = System.Data.Entity.EntityState.Modified;
            }
            _context.SaveChanges();
            
            // 2.- Discard others
            var applicantsToReject = _context.Applicants.Where(p => p.Status == PersonStatus.Applicant && p.JobOffer.Id == jobOfferId).Select(p => p.Id);
            DiscardApplicantsByJobOffer(applicantsToReject, jobOfferId);

            // 3.- Create new Employees
            {
                _employeeService = new EmployeeService();
                applicants.ForEach(app =>
                {
                    app.Details = _context.ApplicantDetails.SingleOrDefault(p => p.ApplicantId == app.Id);
                    
                });
                _employeeService.TransformApplicantToEmployee(applicants, transaction);
            }
            
            // 4.- Close Job
            var jobOffer = _context.JobOffers.SingleOrDefault(p => p.Id == jobOfferId);
            jobOffer.Status = JobStatus.Close;

            _context.SecureSave();
            transaction.Commit();
        }

        public void DiscardApplicantsByJobOffer(IEnumerable<int> selectedApplicants, int jobOfferId)
        {
            var applicants = _context.Applicants.Where(p => selectedApplicants.Contains(p.Id)).ToList();

            foreach (var app in applicants)
            {
                app.Status = PersonStatus.Rejected;
                _context.Entry(app).State = System.Data.Entity.EntityState.Modified;
            }
            
            _context.SaveChanges();
        }

    }
}
