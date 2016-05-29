using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Helpers;
using Unapec.HumanResourcesM.Framework.Services;

namespace Unapec.HumanResourcesM.Forms.Learning
{
    public partial class NewLearningOffer : FormBase
    {

        private readonly CourseService _courseService;

        public NewLearningOffer()
        {
            InitializeComponent();
            _courseService = new CourseService();
            FillComponents();
        }

        private void FillComponents()
        {
            
        }

        private void CleanComponents()
        {
            txtBoxCapacity.ResetText();
            txtBoxDescription.Clear();
            txtBoxName.Clear();
            dateTimePickerStartDate.Value = DateTime.Now;
            dateTimePickerEndDate.Value = DateTime.Now;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            var course = new Course
            {
                Capacity = txtBoxCapacity.Value.As<int>(),
                Description = txtBoxDescription.Text,
                Name = txtBoxName.Text,
                StartDate = dateTimePickerStartDate.Value,
                EndDate = dateTimePickerEndDate.Value
            };
            _courseService.Create(course);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
