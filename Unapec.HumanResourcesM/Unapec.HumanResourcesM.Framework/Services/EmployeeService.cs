using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unapec.HumanResourcesM.Framework.Data;

namespace Unapec.HumanResourcesM.Framework.Services
{
    public class EmployeeService
    {

        private readonly DataContext _context;

        public EmployeeService()
        {
            _context = new DataContext();
        }

        public Applicant Create(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            _context.SaveChanges();
            return applicant;
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
            var jobOffer = _context.JobOffers.SingleOrDefault(p => p.Id == jobOfferId);

            if (jobOffer == null) return null;
            var employee = TransformApplicantToEmployee(applicant);
            DiscardApplicantsByJobOffer(jobOffer.Id);

            return employee;
        }

        public void DiscardApplicantsByJobOffer(int jobOfferId)
        {
            var applicants = _context.Applicants.Where(p => p.JobOffer.Id == jobOfferId).ToArray();
            foreach (var p in applicants)
                p.Status = EmployeeStatus.Rejected;
            _context.Set<Applicant>().AddOrUpdate(applicants);
            _context.SaveChanges();
        }

        public Employee Create(Employee employee)
        {
            employee.Code = String.Format("{0:00000}", _context.Employees.LastOrDefault().Id++);
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee Update(Employee employee)
        {
            _context.Employees.AddOrUpdate(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee TransformApplicantToEmployee(Applicant applicant)
        {
            applicant = _context.Applicants.SingleOrDefault(p => p.Id == applicant.Id);
            if (applicant == null) return null;

            applicant.Status = EmployeeStatus.Normal;
            _context.Applicants.AddOrUpdate(applicant);

            var employee = new Employee
            {
                Username = applicant.Username,
                Name = applicant.Name,

                Department = applicant.JobOffer.Department
            };
            employee.Password = "-new-";
            return Create(employee);
        }

        public IEnumerable<Employee> GetEmployeesByDepartment(int departmentId)
        {
            return _context.Employees.Where(p => p.DepartmentId == departmentId).ToList();
        }

        public EmployeePosition Create(EmployeePosition position)
        {
            _context.EmployeePositions.AddOrUpdate(position);
            _context.SaveChanges();
            return position;
        }


    }
}
