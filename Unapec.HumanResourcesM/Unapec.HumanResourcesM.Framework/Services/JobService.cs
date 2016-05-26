using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Unapec.HumanResourcesM.Framework.Data;
using Unapec.HumanResourcesM.Framework.Entities;

namespace Unapec.HumanResourcesM.Framework.Services
{

    public class JobService
    {

        private readonly DataContext _context;

        public JobService()
        {
            _context = new DataContext();
        }

        public Job Create(Job job)
        {
            _context.JobOffers.Add(job);
            _context.SaveChanges();
            return job;
        }

        public Applicant Create(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            _context.ApplicantDetails.Add(applicant.Details);
            _context.SaveChanges();
            var linkedDetails = GetAllLinkedDetailFromApplicationDetail(applicant.Details);
            _context.PersonLinkedDetails.AddRange(linkedDetails);
            _context.SaveChanges();
            return applicant;
        }

        public IEnumerable<Job> GetAvailableJobs()
        {
            return _context.JobOffers.ToList();
        }

        public IEnumerable<Applicant> GetApplicants()
        {
            return _context.Applicants.Where(p => p.Status == EmployeeStatus.Applicant).ToList();
        }

        public IEnumerable<Applicant> GetPreselection()
        {
            return _context.Applicants.Where(p => p.Status == EmployeeStatus.Applicant).ToList();
        }

        public Employee CloseJobOffer(int jobOfferId, Applicant applicant)
        {
            return null;
            //var jobOffer = _context.JobOffers.SingleOrDefault(p => p.Id == jobOfferId);

            //if (jobOffer == null) return null;
            //var employee = TransformApplicantToEmployee(applicant);
            //DiscardApplicantsByJobOffer(jobOffer.Id);

            //return employee;
        }

        public IEnumerable<Applicant> DoApplicantsSearch(string name, int jobOfferId)
        {
            return _context.Applicants.Where(p => p.Name.Contains(name) && p.JobOffer.Id == jobOfferId).ToList();
        }

        public void DiscardApplicantsByJobOffer(int jobOfferId)
        {
            var applicants = _context.Applicants.Where(p => p.JobOffer.Id == jobOfferId).ToArray();
            foreach (var p in applicants)
                p.Status = EmployeeStatus.Rejected;
            _context.Set<Applicant>().AddOrUpdate(applicants);
            _context.SaveChanges();
        }

        private IEnumerable<PersonLinkedDetail> GetAllLinkedDetailFromApplicationDetail(ApplicantDetail detail)
        {
            var result = new List<PersonLinkedDetail>();
            foreach (var item in detail.Languages)
            {
                item.PersonId = detail.Applicant_Id;
                result.Add(item);
            }

            return result;
        }

    }
}
