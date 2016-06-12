using System;
using System.Collections.Generic;
using Unapec.HumanResourcesM.Framework.Entities;

namespace Unapec.HumanResourcesM.Models
{

    public class ApplicantModel
    {
        public int ApplicantId { get; set; }
        public bool IsMark { get; set; }
        public string Identification { get; set; }
        public DateTimeOffset ApplicationDate { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string PhoneHouse { get; set; }
        public string PhoneCell { get; set; }

        public string GradingLevel { get; set; }
        public IEnumerable<PersonLinkedWorkingExperience> WorkingExperience { get; set; }
        public IEnumerable<PersonLinkedGrading> Gradings { get; set; }
        public IEnumerable<PersonLinkedDetail> LinkedDetails { get; set; }

    }
}
