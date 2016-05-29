using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unapec.HumanResourcesM.Framework.Entities
{
    public class PersonLinkedWorkingExperience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public PersonLinkedType Type { get; set; }
        public string Description { get; set; }
        [StringLength(50)]
        public string CompanyName { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
    }
}
