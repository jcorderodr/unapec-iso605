using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unapec.HumanResourcesM.Framework.Entities
{
    public class ApplicantDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Applicant_Id { get; set; }

        public int GradingLvlId { get; set; }
        public decimal ExpectedSalary { get; set; }

        public virtual ICollection<PersonLinkedWorkingExperience> WorkingExperience { get; set; }
        public virtual ICollection<PersonLinkedGrading> Gradings { get; set; }
        public virtual ICollection<PersonLinkedDetail> Languages { get; set; }

    }
}
