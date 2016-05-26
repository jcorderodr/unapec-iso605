using System;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Helpers;
using Unapec.HumanResourcesM.Framework.Services;
using Unapec.HumanResourcesM.Resources;

namespace Unapec.HumanResourcesM.Forms.Jobs
{
    public partial class NewJobOffer : FormBaseUtility
    {

        private readonly DepartmentService _departmentService;
        private readonly JobService _jobService;

        public NewJobOffer()
        {
            InitializeComponent();
            this.Text += "Nueva oferta de empleo";
            _jobService = new JobService();
            _departmentService = new DepartmentService();

            FillComponents();
        }

        private void FillComponents()
        {
            var departments = _departmentService.GetDepartments();
            departmentComboBox.SetComboBoxDatasource(departments, "Name", true);
        }

        private bool IsInvalid()
        {
            var department = departmentComboBox.SelectedValue as Department;
            var position = jobPositionComboBox.SelectedValue as EmployeePosition;

            if (department == null || position == null)
            {
                this.ShowErrorMessage(Strings.Message_CreationFormInvalidFields);
                return true; 
            }

            return false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            var dResult = this.ShowQuestionMessage(Strings.Question_CreationFormSubmit);

            if (dResult == System.Windows.Forms.DialogResult.Yes) ;

            if (IsInvalid()) return;

            SaveAndClose();           
        }

        private void SaveAndClose()
        {
            var department = departmentComboBox.SelectedValue as Department;
            var position = jobPositionComboBox.SelectedValue as EmployeePosition;

            decimal max = txtBoxMaxSalary.Text.As<decimal>();
            decimal min = txtBoxMinSalary.Text.As<decimal>();

            var jobOffer = new Job
            {
                Description = txtBoxJobOfferDescription.Text,
                Name = position.Name,
                Position = position,
                MaxOfferSalary = max,
                MixOfferSalary = min
            };
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void departmentComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var department = departmentComboBox.SelectedValue as Department;
            if (department == null)
            {
                jobPositionComboBox.DataSource = null;
                jobPositionComboBox.Items.Clear();
                jobPositionComboBox.Items.Add("--");
                return;
            }
            var positions = _departmentService.GetPositions(department.Id);
            jobPositionComboBox.SetComboBoxDatasource(positions, "Description", true);
        }

        private void jobPositionComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var position = jobPositionComboBox.SelectedValue as EmployeePosition;
            txtBoxJobOfferDescription.Text = position.Description;
            txtBoxMaxSalary.Text = position.PositionMaxSalary.ToString();
            txtBoxMinSalary.Text = position.PositionMinSalary.ToString();
        }
    }
}
