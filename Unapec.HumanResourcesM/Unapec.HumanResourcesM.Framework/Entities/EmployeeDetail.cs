using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unapec.HumanResourcesM.Framework.Entities
{
    public class EmployeeDetail
    {
        public EmployeeDetail()
        {
            WorkingExperience = new PersonLinkedWorkingExperience[0];
            Gradings = new PersonLinkedGrading[0];
            Languages = new PersonLinkedDetail[0];
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Employee_Id { get; set; }

        public decimal Salary { get; set; }
        public int GradingLvlId { get; set; }

        public virtual ICollection<PersonLinkedWorkingExperience> WorkingExperience { get; set; }
        public virtual ICollection<PersonLinkedGrading> Gradings { get; set; }
        public virtual ICollection<PersonLinkedDetail> Languages { get; set; }
    }
}
