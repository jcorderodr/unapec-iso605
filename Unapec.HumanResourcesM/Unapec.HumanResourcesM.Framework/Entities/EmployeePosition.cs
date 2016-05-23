using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unapec.HumanResourcesM.Framework.Entities
{
    public class EmployeePosition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public decimal PositionMaxSalary { get; set; }
        public decimal PositionMixSalary { get; set; }
        public virtual Department Department { get; set; }

    }
}
