using System;

namespace Unapec.HumanResourcesM.Models
{
    public class EmployeeViewModel
    {
        public DateTimeOffset RegisteredDate { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneCell { get; set; }
        public string PositionName { get; set; }
        public string DepartmentName { get; set; }
    }
}
