using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Helpers;
using Unapec.HumanResourcesM.Framework.Services;
using Unapec.HumanResourcesM.Resources;

namespace Unapec.HumanResourcesM.Forms.Candidates
{
    public partial class NewApplicationWizard : FormBase
    {

        private readonly JobService _jobService;
        private readonly CatalogService _catalogService;
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;
        private readonly UserService _userService;

        private readonly int lastStep;
        private int presentStep = 0;

        private EmployeePosition _position;

        public NewApplicationWizard()
        {
            InitializeComponent();
            this.Text = "Aplicación de Trabajo para Vacante";
            _jobService = new JobService();
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();
            _userService = new UserService();
            _catalogService = new CatalogService();
            FillComponents();

            lastStep = (wizardTabControl.TabPages.Count - 1);
        }

        private void FillComponents()
        {

            //  wizardTab1
            var jobOffers = _jobService.GetAvailableJobs();

            if (!jobOffers.Any())
            {
                this.ShowErrorMessage("Actualmente no contamos con vacantes disponibles.");
                btnContinue.Enabled = false;
                return;
            }

            wizardTab1_jobOfferComboBox.DataSource = jobOffers;
            wizardTab1_jobOfferComboBox.DisplayMember = "Name";
            wizardTab1_dateTimeBornDate.SetDateTimePickerFormat();

            //  wizardTab2
            wizardTab2_gradesDataGridView.AutoGenerateColumns = false;
            wizardTab2_gradingLvl.SetComboBoxDatasourceWithCatalogs(_catalogService.Get(Catalog.GRADE_LVL));
            wizardTab2_FromDateTimePicker.SetDateTimePickerFormat();
            wizardTab2_ToDateTimePicker.SetDateTimePickerFormat();

            //  wizardTab3
            wizardTab3_panel1_dateTimePickerEnd.SetDateTimePickerFormat();
            wizardTab3_panel1_dateTimePickerStart.SetDateTimePickerFormat();
            wizardTab3_panel2_dateTimePickerEnd.SetDateTimePickerFormat();
            wizardTab3_panel2_dateTimePickerStart.SetDateTimePickerFormat();
            wizardTab3_panel3_dateTimePickerEnd.SetDateTimePickerFormat();
            wizardTab3_panel3_dateTimePickerStart.SetDateTimePickerFormat();

            //  wizardTab4
            var languages = _catalogService.Get(Catalog.LANGUAGE);
            var langLevels = _catalogService.Get(Catalog.SKILL_LVL);

            ColumnLanguageCheckBox.ThreeState = false;
            ColumnLevel.DataSource = langLevels;
            ColumnLevel.ValueType = typeof(Catalog);
            ColumnLevel.ValueMember = "SubCategoryId";
            ColumnLevel.DisplayMember = "Value";
            foreach (var item in languages)
            {
                var row = new DataGridViewRow
                {
                    Tag = item
                };
                var chkBoxCell = ColumnLanguageCheckBox.CellTemplate.Clone() as DataGridViewCell;
                var langCell = ColumnLanguageString.CellTemplate.Clone() as DataGridViewCell;
                langCell.Value = item.Value;
                var lvlCell = ColumnLevel.CellTemplate.Clone() as DataGridViewCell;
                lvlCell.Value = 1;
                row.Cells.AddRange(chkBoxCell, langCell, lvlCell);
                wizardTab4_languageDataGridView.Rows.Add(row);
            }

            competencesBindingSource.DataSource = _catalogService.Get(Catalog.COMPETENCES);
        }

        private void CheckStepUI(int step)
        {
            btnBack.Visible = step > 0;
            btnContinue.Text = step == lastStep ? "Finalizar" : "Siguiente";

            if (step > lastStep) // finish and save
            {
                var actionResult = this.ShowQuestionMessage(Strings.Question_WizardNewApplicationSubmit);
                if (actionResult == DialogResult.Yes)
                {
                    if (CheckUIValidations())
                    {
                        SaveAndClose();
                        this.ShowInformationMessage(Strings.Message_ApplicationWizardConfirmation);
                        this.Close();
                        return;
                    }
                }
            }

            wizardTabControl.SelectedIndex = step;
        }

        private bool CheckUIValidations()
        {

            var jobOffer = wizardTab1_jobOfferComboBox.SelectedValue as Job;
            if (jobOffer == null || jobOffer.Id <= 0)
            {
                this.ShowErrorMessage(Strings.Message_InvalidFieldJobOffer);
                wizardTabControl.SelectedTab = wizardTabPage1;
                wizardTab1_jobOfferComboBox.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(wizardTab1_txtIdentification.Text) || FormatHelper.IsInvalidIdentification(wizardTab1_txtIdentification.Text))
            {
                this.ShowErrorMessage(Strings.Message_InvalidFieldIdentification);
                wizardTabControl.SelectedTab = wizardTabPage1;
                wizardTab1_txtIdentification.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(wizardTab1_txtFirstName.Text) || String.IsNullOrEmpty(wizardTab1_txtLastName.Text))
            {
                this.ShowErrorMessage(Strings.Message_InvalidFieldNames);
                wizardTabControl.SelectedTab = wizardTabPage1;
                wizardTab1_txtFirstName.Focus();
                return false;
            }

            if (wizardTab1_dateTimeBornDate.Value > DateTime.Now)
            {
                this.ShowErrorMessage(Strings.Message_InvalidFieldBornDate);
                wizardTabControl.SelectedTab = wizardTabPage1;
                wizardTab1_dateTimeBornDate.Focus();
                return false;
            }

            //We use 14 since the UI control has a mask...
            if (wizardTab1_txtPhoneCell.TextLength != 14  || wizardTab1_txtPhoneHouse.TextLength != 14)
            {
                this.ShowErrorMessage(Strings.Message_InvalidFieldPhoneFields);
                wizardTabControl.SelectedTab = wizardTabPage1;
                wizardTab1_txtPhoneCell.Focus();
                return false;
            }

            var gradingCatalog = wizardTab2_gradingLvl.SelectedValue as Catalog;
            if (gradingCatalog  == null || gradingCatalog.SubCategoryId <= 0)
            {
                this.ShowErrorMessage(Strings.Message_InvalidFieldGrading);
                wizardTabControl.SelectedTab = wizardTabPage2;
                wizardTab2_gradingLvl.Focus();
                return false;
            }
            
            if (txtExpectedSalary.TextLength <= 0)
            {
                this.ShowErrorMessage(Strings.Message_InvalidFieldExpectedSalary);
                wizardTabControl.SelectedTab = wizardTabPage4;
                txtExpectedSalary.Focus();
                return false;
            }

            return true;
        }

        private void SaveAndClose()
        {
            var application = new Applicant();

            #region Extract data

            //  wizardTab1

            {   //  Personal
                application.BirthDate = wizardTab1_dateTimeBornDate.Value;
                application.Sex = wizardTab1_radioButton1.Checked ? PersonSexType.Female : PersonSexType.Male;
                application.BirthPlace = wizardTab1_txtBornPlace.Text;
                application.Nationality = string.Empty;
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

                IList<PersonLinkedGrading> _addedGrades = personLinkedGradingBindingSource.List as IList<PersonLinkedGrading>;
                foreach (var grading in _addedGrades)
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
                var selectedLanguages = wizardTab4_languageDataGridView.Rows.Cast<DataGridViewRow>().Where(j => Convert.ToBoolean(j.Cells[ColumnLanguageCheckBox.Name].Value) == true);
                foreach (var row in selectedLanguages)
                {
                    var value = row.Tag as Catalog;
                    var langLvlColumn = row.Cells[ColumnLevel.Name];
                    application.Details.LinkedDetails.Add(new PersonLinkedDetail
                    {
                        Category = value.Category,
                        SubCategoryId = value.SubCategoryId,
                        Type = PersonLinkedType.Candidate,
                        LevelSubCategoryId = Convert.ToInt32(langLvlColumn.Value)
                    });
                }

                var markedCompetences = wizardTab4_competenceDataGridView.Rows.Cast<DataGridViewRow>().Where(j => Convert.ToBoolean(j.Cells[ColumnCompetenceMark.Name].Value) == true);
                foreach (var row in markedCompetences)
                {
                    var value = competencesBindingSource[row.Index] as Catalog;
                    application.Details.LinkedDetails.Add(new PersonLinkedDetail
                    {
                        Category = value.Category,
                        SubCategoryId = value.SubCategoryId,
                        Type = PersonLinkedType.Candidate
                    });
                }

                application.Details.ExpectedSalary = txtExpectedSalary.Text.As<decimal>();
                application.ReferencedByEmployeeCode = txtEmployeeReferencedBy.Text;
            }

            #endregion

            //
            application = _jobService.Create(application);
        }

        private void AddGradingToGradingGridView(PersonLinkedGrading grading)
        {
            personLinkedGradingBindingSource.Add(grading);
        }

        private void RemoveGradingToGradingGridView(int position)
        {
            personLinkedGradingBindingSource.RemoveAt(position);
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

        private void wizardTabControl_Selected(object sender, TabControlEventArgs e)
        {
            presentStep = e.TabPageIndex;
            CheckStepUI(presentStep);
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
            wizardTab2_txtDescription.Clear();
            wizardTab2_Institution.Clear();
            AddGradingToGradingGridView(grading);
        }

        private void wizardTab2_gradesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColumnActionDelete.Index)
            {
                if (e.RowIndex >= 0)
                    RemoveGradingToGradingGridView(e.RowIndex);
            }
        }

        private void txtExpectedSalary_Validated(object sender, EventArgs e)
        {
            var numberString = System.Text.RegularExpressions.Regex.Replace(txtExpectedSalary.Text, "[^0-9.-]", "");
            txtExpectedSalary.Text = numberString;

           if(numberString.Length > 0)
            {
                var tempSalary = txtExpectedSalary.Text.As<decimal>();
                if (tempSalary <= 0)
                {
                    this.ShowErrorMessage("El Salario indicado no puede ser en valores negativos. Por favor, revise.");
                    wizardTabControl.SelectedTab = wizardTabPage4;
                    txtExpectedSalary.Focus();
                }
            }
        }
    }
}
