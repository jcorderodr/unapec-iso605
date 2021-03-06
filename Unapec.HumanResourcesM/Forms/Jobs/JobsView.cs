﻿using System;
using System.Data;
using System.Linq;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Services;
using Unapec.HumanResourcesM.Models;

namespace Unapec.HumanResourcesM.Forms.Jobs
{
    public partial class JobsView : FormBase
    {

        private readonly JobService _jobService;

        public JobsView()
        {
            InitializeComponent();
            this.Text = "Vacantes disponibles";
            dataGridView1.AutoGenerateColumns = false;
            _jobService = new JobService();
            FormatComponent();
            FillComponents();
        }

        private void FormatComponent()
        {
            var columns = dataGridView1.Columns;
            creationDateDataGridViewTextBoxColumn.SetDateDataGridViewTextBoxColumnFormat();
        }

        private void FillComponents()
        {
            var jobs = _jobService.GetAvailableJobs().Select(ToModel).ToList();
            jobsViewModelBindingSource.DataSource = jobs;
        }

        private JobsViewModel ToModel(Job jobOffer)
        {
            return new JobsViewModel
            {
                Name = jobOffer.Name,
                State = jobOffer.Status == JobStatus.Open ? "Abierta" : "Cerrada",
                CreationDate = jobOffer.RegisteredDate.DateTime,
                TotalApplicants = _jobService.GetApplicantsCountForJob(jobOffer.Id)
            };
        }

        private void createJobOfferButton_Click(object sender, EventArgs e)
        {
            var newJobForm = new NewJobOffer();
            var dResult = newJobForm.ShowDialog(this);
            FillComponents();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
