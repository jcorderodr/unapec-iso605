using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using Unapec.HumanResourcesM.Framework.Data;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Helpers;

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

        public IEnumerable<Employee> DoEmployeeSearch(string name, EmployeeStatus status, int departmentId, int positionId)
        {
            Expression<Func<Employee, bool>> departmentExpr = null;
            if (departmentId > 0)
                departmentExpr = p => p.DepartmentId == departmentId;
            else
                departmentExpr = p => true;

            Expression<Func<Employee, bool>> positionExpr = null;
            if (positionId > 0)
                positionExpr = p => p.PositionId == positionId;
            else
                positionExpr = p => true;

            Expression<Func<Employee, bool>> nameExpr = null;
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                nameExpr = p => true;
            else
                nameExpr = p => p.Name.Contains(name);

            Expression<Func<Employee, bool>> statusExpr = null;
            if (status > 0)
                statusExpr = p => p.Status == status;
            else
                statusExpr = p => true;

            var finalExpr = ExpressionBinder.BuildAndExpression(departmentExpr, positionExpr, nameExpr, statusExpr);
            return _context.Employees.Where(finalExpr);

        }
    }
}
