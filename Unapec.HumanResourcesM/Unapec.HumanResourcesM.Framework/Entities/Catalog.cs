using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unapec.HumanResourcesM.Framework.Entities
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
        [StringLength(500)]
        public string Value { get; set; }

        public const String GRADE_LVL = "GRADE_LVL";
        public const String LANGUAGE = "LANGUAGE";
        public const String SKILL_LVL = "SKILL_LVL";
        public const String COMPETENCES = "COMPETENCE";

        public const String Prop = "LANG_LVL";

    }
}
