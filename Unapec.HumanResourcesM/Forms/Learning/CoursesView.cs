using System;
using System.Data;
using System.Linq;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Services;
using Unapec.HumanResourcesM.Models;

namespace Unapec.HumanResourcesM.Forms.Learning
{
    public partial class CoursesView : FormBase
    {
        private readonly CourseService _courseService;

        public CoursesView()
        {
            InitializeComponent();
            this.Text = "Capacitaciones";
            _courseService = new CourseService();
            FillComponents();
        }

        private void FillComponents()
        {
            var courses = _courseService.GetCourses().Select(To);
            dataGridView1.DataSource = courses.ToList();

            endDateDataGridViewTextBoxColumn.SetDateDataGridViewTextBoxColumnFormat();
            startDateDataGridViewTextBoxColumn.SetDateDataGridViewTextBoxColumnFormat();
        }

        private CourseModel To(Course course)
        {
            return new CourseModel
            {
                Description = course.Description,
                EndDate = course.EndDate,
                StartDate = course.StartDate,
                Name = course.Name,
                Quorum = _courseService.GetActualQuorum(course.Id),
                Capacity = course.Capacity
            };
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            var formDialog = new NewLearningOffer();
            var dResult = formDialog.ShowDialog(this);
            FillComponents();
        }

        private void addQuorumBUtton_Click(object sender, EventArgs e)
        {
            //TODO: get SelectedRow and open a list of employees

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
