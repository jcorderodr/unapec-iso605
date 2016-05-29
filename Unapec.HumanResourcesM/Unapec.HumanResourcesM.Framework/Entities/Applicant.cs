using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unapec.HumanResourcesM.Framework.Entities
{
    public class Applicant
    {
        public Applicant()
        {
            Details = new ApplicantDetail();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(11)]
        public string Username { get; set; }
        public EmployeeStatus Status { get; set; }
        public DateTimeOffset ApplicationDate { get; set; }
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

        [StringLength(5)]
        public string ReferencedByEmployeeCode { get; set; }

        public virtual Job JobOffer { get; set; }
        public virtual ApplicantDetail Details { get; set; }
    }
}
