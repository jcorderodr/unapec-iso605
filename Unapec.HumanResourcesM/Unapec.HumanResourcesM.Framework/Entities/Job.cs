using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unapec.HumanResourcesM.Framework.Entities
{

    public enum JobStatus
    {
        Open = 1,
        Close = 2
    }

    [Table("JobOffers")]
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public JobStatus Status { get; set; }
        public int PositionId { get; set; }
        public DateTimeOffset RegisteredDate { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public decimal MaxOfferSalary { get; set; }
        public decimal MixOfferSalary { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        public virtual EmployeePosition Position { get; set; }
    }
}
