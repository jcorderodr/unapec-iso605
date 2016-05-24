using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Helpers;
using Unapec.HumanResourcesM.Framework.Services;

namespace Unapec.HumanResourcesM.Forms.Candidates
{
    public partial class NewApplicationWizard : FormBase
    {

        private readonly CatalogService _catalogService;
        private readonly JobService _jobService;

        private readonly int lastStep;
        private int presentStep = 0;

        private IList<PersonLinkedGrading> _dataSourceGradingView;


        public NewApplicationWizard()
        {
            InitializeComponent();
            _jobService = new JobService();
            _catalogService = new CatalogService();
            FillComponents();

            lastStep = (wizardTabControl.TabPages.Count - 1);
            _dataSourceGradingView = new List<PersonLinkedGrading>();
        }

        private void FillComponents()
        {
            //  wizardTab1
            var jobOffers = _jobService.GetAvailableJobs();
            wizardTab1_jobOfferComboBox.DataSource = jobOffers;
            wizardTab1_jobOfferComboBox.DisplayMember = "Description";

            //  wizardTab2
            wizardTab2_gradesDataGridView.AutoGenerateColumns = false;
            wizardTab2_gradingLvl.SetComboBoxDatasourceWithCatalogs(_catalogService.Get(Catalog.GRADE_LVL));

            //  wizardTab4
            wizardTab4_LanguageComboBox.SetComboBoxDatasourceWithCatalogs(_catalogService.Get(Catalog.LANGUAGE));
            wizardTab4_LanguageLvlComboBox.SetComboBoxDatasourceWithCatalogs(_catalogService.Get(Catalog.SKILL_LVL));
        }

        private void CheckStepUI(int step)
        {
            btnBack.Visible = step > 0;
            switch (step)
            {
                case 0:
                    btnContinue.Text = "Siguiente";
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
                        if (actionResult == DialogResult.Yes)
                        {
                            if(CheckUIValidations())
                            SaveAndClose();
                        }
                    }
                    break;
            }
            wizardTabControl.SelectedIndex = step;
        }
        
        private bool CheckUIValidations()
        {


            return true;
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
                var gradingCatalog = wizardTab2_gradingLvl.SelectedValue as Catalog;
                application.Details.GradingLvlId = gradingCatalog.SubCategoryId;

                foreach (var grading in _dataSourceGradingView)
                {
                    application.Details.Gradings.Add(grading);
                }
            }

            //  wizardTab3
            {   //  Working Experience
                PersonLinkedWorkingExperience workingExperience = null;
                if (!string.IsNullOrEmpty(wizardTab3_panel1_txtCompany.Text) && !string.IsNullOrEmpty(wizardTab3_panel1_txtJob.Text))
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
            {
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
            //
            wizardTab1_dateTimeBornDate.Format = DateTimePickerFormat.Custom;
            wizardTab1_dateTimeBornDate.CustomFormat = FormatHelper.DATE_FULL_FORMAT;
            //
            wizardTab2_FromDateTimePicker.Format = DateTimePickerFormat.Custom;
            wizardTab2_FromDateTimePicker.CustomFormat = FormatHelper.DATE_FULL_FORMAT;
            wizardTab2_ToDateTimePicker.Format = DateTimePickerFormat.Custom;
            wizardTab2_ToDateTimePicker.CustomFormat = FormatHelper.DATE_FULL_FORMAT;
            //
            wizardTab3_panel1_dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            wizardTab3_panel1_dateTimePickerEnd.CustomFormat = FormatHelper.DATE_FULL_FORMAT;
            wizardTab3_panel1_dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            wizardTab3_panel1_dateTimePickerStart.CustomFormat = FormatHelper.DATE_FULL_FORMAT;
            wizardTab3_panel2_dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            wizardTab3_panel2_dateTimePickerEnd.CustomFormat = FormatHelper.DATE_FULL_FORMAT;
            wizardTab3_panel2_dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            wizardTab3_panel2_dateTimePickerStart.CustomFormat = FormatHelper.DATE_FULL_FORMAT;
            wizardTab3_panel3_dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            wizardTab3_panel3_dateTimePickerEnd.CustomFormat = FormatHelper.DATE_FULL_FORMAT;
            wizardTab3_panel3_dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            wizardTab3_panel3_dateTimePickerStart.CustomFormat = FormatHelper.DATE_FULL_FORMAT;

        }

        private void wizardTabControl_Selected(object sender, TabControlEventArgs e)
        {
            CheckStepUI(presentStep);
        }

        private void wizardTab1_txtIdentification_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(wizardTab1_txtIdentification.Text)
                || string.IsNullOrWhiteSpace(wizardTab1_txtIdentification.Text)
                || wizardTab1_txtIdentification.TextLength != 11)
            {
                this.ShowErrorMessage("Debe indicar una cédula válida de 11 dígitos exactos.");
                wizardTab1_txtIdentification.Focus();
            }
        }

        private void AddGradingToGradingGridView(PersonLinkedGrading grading)
        {
            _dataSourceGradingView.Add(grading);
            wizardTab2_gradesDataGridView.DataSource = _dataSourceGradingView;
        }

        private void RemoveGradingToGradingGridView(int position)
        {
            _dataSourceGradingView.RemoveAt(position);
            wizardTab2_gradesDataGridView.DataSource = _dataSourceGradingView;
        }

        private void wizardTab2_addAcademicInfo_Click(object sender, EventArgs e)
        {
            var grading = new PersonLinkedGrading
            {
                FromDate = wizardTab2_FromDateTimePicker.Value,
                ToDate = wizardTab2_ToDateTimePicker.Value,
                Description = wizardTab2_txtDescription.Text,
                Institution = wizardTab2_Institution.Text
            };

            AddGradingToGradingGridView(grading);
        }

        private void wizardTab2_gradesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != wizardTab2_gradesDataGridView.Columns.Count - 1)
            {
                if (e.RowIndex >= 0)
                    RemoveGradingToGradingGridView(e.RowIndex);
            }
        }

        private void wizardTab4_addLang_Click(object sender, EventArgs e)
        {
            var element = wizardTab4_LanguageComboBox.SelectedValue as Catalog;
            var lvl = wizardTab4_LanguageLvlComboBox.SelectedValue as Catalog;

            var personDetail = new PersonLinkedDetail
            {
                Category = element.Category,
                SubCategoryId = element.SubCategoryId,
                Type = PersonLinkedType.Candidate,
                LevelSubCategoryId = lvl.SubCategoryId
            };
            var listItem = new ListViewItem
            {
                Tag = personDetail,
                Text = string.Format("{0} [{1}]", element.Value, lvl.Value)
            };
            wizardTab4_languageListView.Items.Add(listItem);
        }


    }
}
