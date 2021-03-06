﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            employee.Status = PersonStatus.Normal;
            _context.Employees.Add(employee);
            _context.SaveChanges();
            //
            employee.Details.EmployeeId = employee.Id;
            _context.EmployeeDetails.Add(employee.Details);
            _context.SecureSave();
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

        public IEnumerable<Employee> TransformApplicantToEmployee(IEnumerable<Applicant> applicants, DbContextTransaction dbTransaction = null)
        {
            var result = new List<Employee>();
            foreach (var applicant in applicants)
            {
                var employee = new Employee
                {
                    RegisteredDate = DateTimeOffset.Now,
                    BirthDate = applicant.BirthDate,
                    Identification = applicant.Username,
                    LastName = applicant.LastName,
                    Name = applicant.Name,
                    PhoneCell = applicant.PhoneCell,
                    PhoneHouse = applicant.PhoneHouse,
                    Address = applicant.Address,
                    BirthPlace = applicant.BirthPlace,
                    DepartmentId = applicant.JobOffer.Position.Department.Id,
                    PositionId = applicant.JobOffer.PositionId,
                    Nationality = applicant.Nationality,
                    Sex = applicant.Sex,
                    Status = PersonStatus.Normal,
                    Details = new EmployeeDetail
                    {
                        GradingLvlId = applicant.Details.GradingLvlId,
                        Salary = applicant.JobOffer.MixOfferSalary,
                        Gradings = applicant.Details.Gradings.Select(ToGrading).ToList(),
                        LinkedDetails = applicant.Details.LinkedDetails.Select(ToLinkedDetail).ToList(),
                        WorkingExperience = applicant.Details.WorkingExperience.Select(ToWorkingExperience).ToList()
                    }
                };

                result.Add(Create(employee));
            }
            return result;
        }


        public IEnumerable<Employee> DoEmployeeSearch(string name, PersonStatus status, int departmentId, int positionId)
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
            return _context.Employees.Where(finalExpr).ToList();

        }


        private PersonLinkedWorkingExperience ToWorkingExperience(PersonLinkedWorkingExperience arg)
        {
            return new PersonLinkedWorkingExperience
            {
                CompanyName = arg.CompanyName,
                Description = arg.Description,
                FromDate = arg.FromDate,
                ToDate = arg.ToDate,
            };
        }

        private PersonLinkedDetail ToLinkedDetail(PersonLinkedDetail arg)
        {
            return new PersonLinkedDetail
            {
                Category = arg.Category,
                LevelSubCategoryId = arg.LevelSubCategoryId,
                SubCategoryId = arg.SubCategoryId,
                Type = arg.Type,
            };
        }

        private PersonLinkedGrading ToGrading(PersonLinkedGrading arg)
        {
            return new PersonLinkedGrading
            {
                Institution = arg.Institution,
                Description = arg.Description,
                FromDate = arg.FromDate,
                ToDate = arg.ToDate,
            };
        }
    }
}
