using System;
using System.ComponentModel;

namespace Unapec.HumanResourcesM.Models
{
    public class JobsViewModel
    {
        public string Name { get; set; }
        public string State { get; set; }
        public DateTime CreationDate { get; set; }
        public int TotalApplicants { get; set; }

    }
}
