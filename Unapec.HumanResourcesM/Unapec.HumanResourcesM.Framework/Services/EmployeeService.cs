using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Unapec.HumanResourcesM.Framework.Data;
using Unapec.HumanResourcesM.Framework.Entities;

namespace Unapec.HumanResourcesM.Framework.Services
{
    public class EmployeeService
    {

        private readonly DataContext _context;

        public EmployeeService()
        {
            _context = new DataContext();
        }

        public Employee Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public IEnumerable<Employee> DoEmployeeSearch(string name)
        {
            return _context.Employees.Where(p => p.Name.Contains(name));
        }

        public IEnumerable<Employee> GetEmployeesByDepartment(int departmentId)
        {
            return _context.Employees.Where(p => p.DepartmentId == departmentId).ToList();
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
                Name = applicant.Name,
                Identification = applicant.Username,
            };
           
            return Create(employee);
        }
        

    }
}
