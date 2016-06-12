using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Services;
using Unapec.HumanResourcesM.Models;
using Unapec.HumanResourcesM.Resources;

namespace Unapec.HumanResourcesM.Forms.Candidates
{
    public partial class EmployeeSelectionFromCandidate : FormBase
    {


        private readonly JobService _jobService;
        private readonly EmployeeService _employeeService;
        private readonly CatalogService _catalogService;

        public EmployeeSelectionFromCandidate()
        {
            InitializeComponent();
            this.Text = "Selección de Candidatos para Vacante";
            _jobService = new JobService();
            _catalogService = new CatalogService();
            FormatComponents();
            FillComponents();
        }

        private void FormatComponents()
        {
            birthDateDataGridViewTextBoxColumn.SetDateDataGridViewTextBoxColumnFormat();
            applicationDateDataGridViewTextBoxColumn.SetFullDateStringDataGridViewTextBoxColumnFormat();
            applicationDateDataGridViewTextBoxColumn.SetDateDataGridViewTextBoxColumnFormat();
        }

        private void FillComponents()
        {
            var jobOffers = _jobService.GetAvailableJobs();
            jobOfferComboBox.SetComboBoxDatasource(jobOffers, "Name", false);
        }

        private ApplicantModel To(Applicant applicant)
        {
            var gradingLevel = _catalogService.Get(Catalog.GRADE_LVL, applicant.Details.GradingLvlId);
            var entity = new ApplicantModel
            {
                ApplicantId = applicant.Id,
                ApplicationDate = applicant.ApplicationDate,
                BirthDate = applicant.BirthDate,
                Identification = applicant.Username,
                LastName = applicant.LastName,
                Name = applicant.Name,
                PhoneCell = applicant.PhoneCell,
                PhoneHouse = applicant.PhoneHouse,
                GradingLevel = gradingLevel.Value
            };

            return entity;
        }

        private void jobOfferComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var jobOffer = jobOfferComboBox.SelectedValue as Job;

            var entities = _jobService.GetApplicantsByJob(jobOffer.Id);
            var applicants = entities.Select(To);
            applicantModelBindingSource.DataSource = applicants.ToList();
        }

        private void markAsDiscardedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var jobOffer = jobOfferComboBox.SelectedValue as Job;

            var gridSelection = applicantModelBindingSource.List.Cast<ApplicantModel>().Where(k => k.IsMark);
            var markedKeys = gridSelection.Select(p => p.ApplicantId);
            if (markedKeys.Any())
            {
                _jobService.DiscardApplicantsByJobOffer(markedKeys, jobOffer.Id);
                this.ShowInformationMessage(Strings.Message_ApplicantsDiscarded);

                jobOfferComboBox_SelectedValueChanged(sender, e);
            }
        }

        private void selectApplicantAndCloseJobOfferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var jobOffer = jobOfferComboBox.SelectedValue as Job;

            var gridSelection = applicantModelBindingSource.List.Cast<ApplicantModel>().Where(k => k.IsMark);
            var markedKeys = gridSelection.Select(p => p.ApplicantId);
            if (markedKeys.Any())
            {
                _jobService.CloseJobOffer(markedKeys, jobOffer.Id);
                this.ShowInformationMessage(Strings.Message_EmployeesFromApplicantsCreated);

                FillComponents();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
