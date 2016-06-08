using System;
using System.Data;
using System.Linq;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Services;
using Unapec.HumanResourcesM.Models;
using Unapec.HumanResourcesM.Resources;

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
            courseModelBindingSource.DataSource = courses.ToList();

            endDateDataGridViewTextBoxColumn.SetFullDateStringDataGridViewTextBoxColumnFormat();
            startDateDataGridViewTextBoxColumn.SetFullDateStringDataGridViewTextBoxColumnFormat();
        }

        private CourseModel To(Course course)
        {
            return new CourseModel
            {
                Id = course.Id,
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
            var selectedCourse = courseModelBindingSource.Current as CourseModel;

            if (selectedCourse == null) return;

            //TODO: get SelectedRow and open a list of employees
            using (var frm = new Employees.EmployeesView())
            {
                frm.SetSelectionMode();
                var dResult = frm.ShowDialog(this);
                if (dResult == System.Windows.Forms.DialogResult.OK)
                {
                    var empKeys = frm.GetSelection();
                    _courseService.AddQuorum(selectedCourse.Id, empKeys);
                    this.ShowInformationMessage(Strings.Message_FormSubmitSuccess);
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
