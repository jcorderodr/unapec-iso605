using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Services;

namespace Unapec.HumanResourcesM.Forms.Candidates
{
    public partial class NewApplicationWizard : FormBase
    {

        private readonly CatalogService _catalogService;
        private readonly JobService _jobService;

        private readonly int lastStep;
        private int presentStep = 0;
        

        public NewApplicationWizard()
        {
            InitializeComponent();
            _jobService = new JobService();
            _catalogService = new CatalogService();
            FillComponents();
            lastStep = (wizardTabControl.TabPages.Count - 1);
        }

        private void FillComponents()
        {
            //  wizardTab1
            var jobOffers = _jobService.GetAvailableJobs();
            wizardTab1_jobOfferComboBox.DataSource = jobOffers;
            wizardTab1_jobOfferComboBox.DisplayMember = "Description";

            //  wizardTab4
            wizardTab4_LanguageComboBox.SetComboBoxDatasourceWithCatalogs(_catalogService.Get(Catalog.LANGUAGE));
            wizardTab4_LanguageLvlComboBox.SetComboBoxDatasourceWithCatalogs(_catalogService.Get(Catalog.LANGUAGE_LVL));

        }

        private void CheckStepUI(int step)
        {
            btnBack.Visible = step > 0;
            switch (step)
            {
                case 0:

                    break;
                default:
                    if (step == lastStep)
                    {
                        //  is the last one
                        btnContinue.Text = "Finalizar";
                    }
                    if (step > lastStep) // finish and save
                    {
                        var actionResult = this.ShowQuestionMessage(Resources.Strings.Question_WizardNewApplicationSubmit);
                        if(actionResult == DialogResult.Yes)
                        {
                            SaveAndClose();
                        }
                    }
                    break;
            }
            wizardTabControl.SelectedIndex = step;
        }

        private void SaveAndClose()
        {
            var application = new Applicant();

            #region Extract data

            //  wizardTab1

            {   //  Personal
                application.ApplicationDate = DateTime.Now;
                application.BirthDate = wizardTab1_dateTimeBornDate.Value;
                application.Sex = wizardTab1_radioButton1.Checked ? 2 : 1;
                application.BirthPlace = wizardTab1_txtBornPlace.Text;
                application.Name = wizardTab1_txtFirstName.Text;
                application.LastName = wizardTab1_txtLastName.Text;
                application.Username = wizardTab1_txtIdentification.Text;
                application.Address = wizardTab1_txtAddress.Text;
                application.PhoneHouse = wizardTab1_txtPhoneHouse.Text;
                application.PhoneCell = wizardTab1_txtPhoneCell.Text;

                var jobOffer = wizardTab1_jobOfferComboBox.SelectedValue as Job;
                application.JobOffer = jobOffer;

            }

            //  wizardTab2

            {   //  Education
                var gradingLvl = (int) wizardTab2_gradingLvl.SelectedValue;
                application.Details.GradingLvlId = gradingLvl;

                foreach (var row in wizardTab2_gradesDtaGridView.Rows.OfType<DataRowView>())
                {
                    var grading = new PersonLinkedGrading
                    {
                        
                    };

                    application.Details.Gradings.Add(grading);
                }
            }

            //  wizardTab3
            {   //  Working Experience
                PersonLinkedWorkingExperience workingExperience = null;
                if(!string.IsNullOrEmpty(wizardTab3_panel1_txtCompany.Text) && !string.IsNullOrEmpty(wizardTab3_panel1_txtJob.Text))
                {
                    workingExperience = new PersonLinkedWorkingExperience
                    {
                        CompanyName = wizardTab3_panel1_txtCompany.Text,
                        Description = wizardTab3_panel1_txtJob.Text,
                        FromDate = wizardTab3_panel1_dateTimePickerStart.Value,
                        ToDate = wizardTab3_panel3_dateTimePickerEnd.Value
                    };
                    application.Details.WorkingExperience.Add(workingExperience);
                }
                if (!string.IsNullOrEmpty(wizardTab3_panel2_txtCompany.Text) && !string.IsNullOrEmpty(wizardTab3_panel2_txtJob.Text))
                {
                    workingExperience = new PersonLinkedWorkingExperience
                    {
                        CompanyName = wizardTab3_panel2_txtCompany.Text,
                        Description = wizardTab3_panel2_txtJob.Text,
                        FromDate = wizardTab3_panel2_dateTimePickerStart.Value,
                        ToDate = wizardTab3_panel2_dateTimePickerEnd.Value
                    };
                    application.Details.WorkingExperience.Add(workingExperience);
                }
                if (!string.IsNullOrEmpty(wizardTab3_panel3_txtCompany.Text) && !string.IsNullOrEmpty(wizardTab3_panel3_txtJob.Text))
                {
                    workingExperience = new PersonLinkedWorkingExperience
                    {
                        CompanyName = wizardTab3_panel3_txtCompany.Text,
                        Description = wizardTab3_panel3_txtJob.Text,
                        FromDate = wizardTab3_panel3_dateTimePickerStart.Value,
                        ToDate = wizardTab3_panel3_dateTimePickerEnd.Value
                    };
                    application.Details.WorkingExperience.Add(workingExperience);
                }
            }

            //  wizardTab4
            var listItems = wizardTab4_languageListView.Items.OfType<ListViewItem>();
            foreach (var lang in listItems)
            {
                var value = lang.Tag as Catalog;
                application.Details.Languages.Add(new PersonLinkedDetail
                {
                    Category = value.Category,
                    SubCategoryId = value.SubCategoryId,
                    PersonId = application.Id,
                    Type = PersonLinkedType.Candidate
                });
            }

            #endregion


            //
            application = _jobService.Create(application);
            //
            this.Close();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            presentStep++;
            CheckStepUI(presentStep);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            presentStep--;
            CheckStepUI(presentStep);
        }

        private void cancelAndClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewApplicationWizard_Load(object sender, EventArgs e)
        {
            btnBack.Visible = false;
        }

        private void wizardTabControl_Selected(object sender, TabControlEventArgs e)
        {
            CheckStepUI(presentStep);
        }

        private void wizardTab1_txtIdentification_Validated(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(wizardTab1_txtIdentification.Text) 
                || string.IsNullOrWhiteSpace(wizardTab1_txtIdentification.Text)
                || wizardTab1_txtIdentification.TextLength != 11)
            {
                this.ShowErrorMessage("Debe indicar una cédula válida de 11 dígitos exactos.");
                wizardTab1_txtIdentification.Focus();
            }
        }

        private void wizardTab4_addLang_Click(object sender, EventArgs e)
        {

        }


    }
}
