using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Unapec.HumanResourcesM.Framework.Data;
using Unapec.HumanResourcesM.Framework.Entities;

namespace Unapec.HumanResourcesM.Framework.Services
{
    public class DepartmentService
    {

        private readonly DataContext _context;

        public DepartmentService()
        {
            _context = new DataContext();
        }

        public EmployeePosition Create(EmployeePosition position)
        {
            _context.EmployeePositions.AddOrUpdate(position);
            _context.SaveChanges();
            return position;
        }

        public IEnumerable<EmployeePosition> GetPositions(int departmentId)
        {
            return _context.EmployeePositions.Where(p => p.Department.Id == departmentId).ToList();
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments.ToList();
        }

    }
}
