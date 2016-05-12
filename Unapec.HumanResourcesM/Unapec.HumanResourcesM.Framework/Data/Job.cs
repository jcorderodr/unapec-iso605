using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unapec.HumanResourcesM.Framework.Data
{
    [Table("JobOffers")]
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public float MaxOfferSalary { get; set; }
        public float MixOfferSalary { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        public virtual Department Department { get; set; }
    }
}
