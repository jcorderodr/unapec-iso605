using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unapec.HumanResourcesM.Framework.Entities
{


    public class Employee
    {

        public Employee()
        {
            Details = new EmployeeDetail();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(5)]
        public string Code { get; set; }
        public DateTimeOffset RegisteredDate { get; set; }
        public PersonStatus Status { get; set; }
        public int DepartmentId { get; set; }

        [StringLength(11)]
        public string Identification { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string LastName { get; set; }
        [StringLength(200)]
        public string BirthPlace { get; set; }
        [StringLength(50)]
        public string Nationality { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public PersonSexType Sex { get; set; }
        public string Address { get; set; }
        public string PhoneHouse { get; set; }
        public string PhoneCell { get; set; }

        public int PositionId { get; set; }

        public virtual EmployeeDetail Details { get; set; }

        public virtual EmployeePosition Position { get; set; }
        public virtual Department Department { get; set; }

        [NotMapped]
        public string Fullname
        {
            get
            {
                return $"{Name} {LastName}";
            }
        }
    }
}
