using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unapec.HumanResourcesM.Framework.Entities
{
    public class ApplicantDetail
    {

        public ApplicantDetail()
        {
            WorkingExperience = new Collection<PersonLinkedWorkingExperience>();
            Gradings = new Collection<PersonLinkedGrading>();
            LinkedDetails = new Collection<PersonLinkedDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApplicantId { get; set; }

        public int GradingLvlId { get; set; }
        public decimal ExpectedSalary { get; set; }

        public ICollection<PersonLinkedWorkingExperience> WorkingExperience { get; set; }
        public ICollection<PersonLinkedGrading> Gradings { get; set; }
        public ICollection<PersonLinkedDetail> LinkedDetails { get; set; }

    }
}
