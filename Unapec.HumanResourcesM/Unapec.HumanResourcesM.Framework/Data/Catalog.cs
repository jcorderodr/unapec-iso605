using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unapec.HumanResourcesM.Framework.Data
{
    public class Catalog
    {
        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string Category { get; set; }
        [Key]
        [Column(Order = 2)]
        public int SubCategoryId { get; set; }
        [StringLength(50)]
        public string Value { get; set; }
    }
}
