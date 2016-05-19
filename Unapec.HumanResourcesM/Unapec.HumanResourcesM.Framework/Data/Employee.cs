using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unapec.HumanResourcesM.Framework.Data
{

    public enum EmployeeStatus
    {
        Applicant = 1,
        PreSelected = 2,
        Rejected = 3,
        Normal = 5,
        OnVacaction = 6,
        UnderSupervision = 7,
        Canceled = 9
    }

    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(5)]
        public string Code { get; set; }
        [StringLength(20)]
        public string Username { get; set; }
        [StringLength(500)]
        public string Password { get; set; }
        public DateTime RegisteredDate { get; set; }
        public EmployeeStatus Status { get; set; }
        public int DepartmentId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string LastName { get; set; }
        [StringLength(200)]
        public string BirthPlace { get; set; }
        [StringLength(50)]
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        public int GradeLevelId { get; set; }


        public virtual Department Department { get; set; }
        
    }
}
