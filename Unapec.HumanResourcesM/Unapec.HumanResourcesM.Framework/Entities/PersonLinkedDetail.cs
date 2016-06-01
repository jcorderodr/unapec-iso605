using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unapec.HumanResourcesM.Framework.Entities
{

    public class PersonLinkedDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public PersonLinkedType Type { get; set; }
        [Required]
        [StringLength(10)]
        public string Category { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
        public int? LevelSubCategoryId { get; set; }
    }
}
