using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Services;
using Unapec.HumanResourcesM.Models;

namespace Unapec.HumanResourcesM.Forms.Candidates
{
    public partial class EmployeeSelectionFromCandidate : FormBase
    {


        private readonly JobService _jobService;
        private readonly CatalogService _catalogService;

        public EmployeeSelectionFromCandidate()
        {
            InitializeComponent();
            this.Text = "Selección de Candidatos para Vacante";
            _jobService = new JobService();
            _catalogService = new CatalogService();
            FormatComponents();
            //
            FillComponents();
        }

        private void FormatComponents()
        {
            birthDateDataGridViewTextBoxColumn.SetDateDataGridViewTextBoxColumnFormat();
            applicationDateDataGridViewTextBoxColumn.SetFullDateStringDataGridViewTextBoxColumnFormat();
        }

        private void FillComponents()
        {
            var jobOffers = _jobService.GetAvailableJobs();
            jobOfferComboBox.SetComboBoxDatasource(jobOffers, "Name", false);

            applicationDateDataGridViewTextBoxColumn.SetDateDataGridViewTextBoxColumnFormat();
        }

        private ApplicantModel To(Applicant applicant)
        {
            var gradingLevel = _catalogService.Get(Catalog.GRADE_LVL, applicant.Details.GradingLvlId);
            var entity = new ApplicantModel
            {
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
            dataGridView1.DataSource = applicants.ToList();
        }

        private void markAsDiscardedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var jobOffer = jobOfferComboBox.SelectedValue as Job;

            var markedCompetences = dataGridView1.Rows.Cast<DataGridViewRow>().Where(j => Convert.ToBoolean(j.Cells[ColumnMark.Name].Value) == true);
            var applicantKeys = new List<int>();
            foreach (var row in markedCompetences)
            {
                var value = applicantModelBindingSource[row.Index] as ApplicantModel;
                applicantKeys.Add(value.ApplicantId);
            }
            _jobService.DiscardApplicantsByJobOffer(applicantKeys, jobOffer.Id);
        }

        private void selectApplicantAndCloseJobOfferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var jobOffer = jobOfferComboBox.SelectedValue as Job;

            var markedCompetences = dataGridView1.Rows.Cast<DataGridViewRow>().Where(j => Convert.ToBoolean(j.Cells[ColumnMark.Name].Value) == true);
            var applicantKeys = new List<int>();
            foreach (var row in markedCompetences)
            {
                var value = applicantModelBindingSource[row.Index] as ApplicantModel;
                applicantKeys.Add(value.ApplicantId);
            }
            _jobService.CloseJobOffer(applicantKeys, jobOffer.Id);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


    }
}
