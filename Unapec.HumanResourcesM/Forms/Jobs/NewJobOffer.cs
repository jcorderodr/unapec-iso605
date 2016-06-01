using System;
using System.Text.RegularExpressions;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Helpers;
using Unapec.HumanResourcesM.Framework.Services;
using Unapec.HumanResourcesM.Resources;

namespace Unapec.HumanResourcesM.Forms.Jobs
{
    public partial class NewJobOffer : FormBase
    {

        private readonly DepartmentService _departmentService;
        private readonly JobService _jobService;

        public NewJobOffer()
        {
            InitializeComponent();
            this.Text = "Nueva oferta de empleo";
            _jobService = new JobService();
            _departmentService = new DepartmentService();

            FillComponents();
        }

        private void FillComponents()
        {
            var departments = _departmentService.GetDepartments();
            departmentComboBox.SetComboBoxDatasource(departments, "Name", true);
            jobPositionComboBox.SetComboBoxDatasource(new EmployeePosition[0], "Name", true);
            txtBoxMaxSalary.SetMaskedTextBoxCurrencyFormat();
            txtBoxMinSalary.SetMaskedTextBoxCurrencyFormat();
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

            if (dResult != System.Windows.Forms.DialogResult.Yes) return;

            if (IsInvalid()) return;

            SaveAndClose();
            this.ShowInformationMessage(Strings.Message_JobOfferCreated);
            FillComponents();
        }

        private void SaveAndClose()
        {
            var department = departmentComboBox.SelectedValue as Department;
            var position = jobPositionComboBox.SelectedValue as EmployeePosition;

            var maxString = Regex.Replace(txtBoxMaxSalary.Text, "[^0-9.]", "");
            var minString = Regex.Replace(txtBoxMinSalary.Text, "[^0-9.]", "");
            decimal max = maxString.As<decimal>();
            decimal min = minString.As<decimal>();

            var jobOffer = new Job
            {
                Description = txtBoxJobOfferDescription.Text,
                Name = position.Name,
                MaxOfferSalary = max,
                MixOfferSalary = min,
                PositionId = position.Id
            };
            _jobService.Create(jobOffer);
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
            jobPositionComboBox.SetComboBoxDatasource(positions, "Name", false);
        }

        private void jobPositionComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var position = jobPositionComboBox.SelectedValue as EmployeePosition;
            if (position == null) return;

            txtBoxJobOfferDescription.Text = position.Description;
            txtBoxMaxSalary.Text = FormatHelper.GetValidCurrencyWithPadding(position.PositionMaxSalary);
            txtBoxMinSalary.Text = FormatHelper.GetValidCurrencyWithPadding(position.PositionMinSalary);
        }
    }
}
