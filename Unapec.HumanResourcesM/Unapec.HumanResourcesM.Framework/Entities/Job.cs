using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unapec.HumanResourcesM.Framework.Entities
{
    [Table("JobOffers")]
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public decimal MaxOfferSalary { get; set; }
        public decimal MixOfferSalary { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        public virtual EmployeePosition Position { get; set; }
    }
}
