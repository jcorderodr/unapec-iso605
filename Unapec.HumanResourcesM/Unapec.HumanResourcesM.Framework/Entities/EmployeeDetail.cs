using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unapec.HumanResourcesM.Framework.Entities
{
    public class EmployeeDetail
    {
        public EmployeeDetail()
        {
            WorkingExperience = new Collection<PersonLinkedWorkingExperience>();
            Gradings = new Collection<PersonLinkedGrading>();
            LinkedDetails = new Collection<PersonLinkedDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }

        public decimal Salary { get; set; }
        public int GradingLvlId { get; set; }

        public virtual ICollection<PersonLinkedWorkingExperience> WorkingExperience { get; set; }
        public virtual ICollection<PersonLinkedGrading> Gradings { get; set; }
        public virtual ICollection<PersonLinkedDetail> LinkedDetails { get; set; }
    }
}
