using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Helpers;
using Unapec.HumanResourcesM.Framework.Services;

namespace Unapec.HumanResourcesM.Forms.Employees
{
    public partial class NewEmployeeWizard : FormBase
    {

        private readonly CatalogService _catalogService;
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;
        private readonly UserService _userService;

        private readonly int lastStep;
        private int presentStep = 0;

        private EmployeePosition _position;

        private IList<PersonLinkedGrading> _dataSourceGradingView;

        public NewEmployeeWizard()
        {
            InitializeComponent();
            this.Text = "Creación de Empleados";
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();
            _userService = new UserService();
            _catalogService = new CatalogService();
            FillComponents();

            lastStep = (wizardTabControl.TabPages.Count - 1);
            _dataSourceGradingView = new List<PersonLinkedGrading>();
        }

        private void FillComponents()
        {
            //  wizardTab1
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

            //  wizardTab5
            var departments = _departmentService.GetDepartments();
            wizardTab5_DepartmentComboBox.SetComboBoxDatasource(departments, "Name", true);
            wizardTab5_jobPositionComboBox.SetComboBoxDatasource(new EmployeePosition[0], "Name", true);
        }

        private void CheckStepUI(int step)
        {
            btnBack.Visible = step > 0;
            btnContinue.Text = step == lastStep ? "Finalizar" : "Siguiente";

            if (step > lastStep) // finish and save
            {
                var actionResult = this.ShowQuestionMessage(Resources.Strings.Question_WizardNewApplicationSubmit);
                if (actionResult == DialogResult.Yes)
                {
                    if (CheckUIValidations())
                        SaveAndClose();
                }
            }

            wizardTabControl.SelectedIndex = step;
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

        private bool CheckUIValidations()
        {


            return true;
        }

        private void SaveAndClose()
        {
            var employee = new Employee();

            #region Extract data

            //  wizardTab1

            {   //  Personal
                employee.RegisteredDate = DateTime.Now;
                employee.BirthDate = wizardTab1_dateTimeBornDate.Value;
                employee.Sex = wizardTab1_radioButton1.Checked ? PersonSexType.Female : PersonSexType.Male;
                employee.BirthPlace = wizardTab1_txtBornPlace.Text;
                employee.Nationality = string.Empty;
                employee.Name = wizardTab1_txtFirstName.Text;
                employee.LastName = wizardTab1_txtLastName.Text;
                employee.Identification = wizardTab1_txtIdentification.Text;
                employee.Address = wizardTab1_txtAddress.Text;
                employee.PhoneHouse = wizardTab1_txtPhoneHouse.Text;
                employee.PhoneCell = wizardTab1_txtPhoneCell.Text;
            }

            //  wizardTab2

            {   //  Education
                var gradingCatalog = wizardTab2_gradingLvl.SelectedValue as Catalog;
                employee.Details.GradingLvlId = gradingCatalog.SubCategoryId;

                foreach (var grading in _dataSourceGradingView)
                {
                    employee.Details.Gradings.Add(grading);
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
                    employee.Details.WorkingExperience.Add(workingExperience);
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
                    employee.Details.WorkingExperience.Add(workingExperience);
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
                    employee.Details.WorkingExperience.Add(workingExperience);
                }
            }

            //  wizardTab4
            {
                var selectedLanguages = wizardTab4_languageDataGridView.Rows.Cast<DataGridViewRow>()
                                                .Where(k => Convert.ToBoolean(k.Cells[ColumnLanguageCheckBox.Name].Value) == true);
                foreach (var row in selectedLanguages)
                {
                    var value = row.Tag as Catalog;
                    employee.Details.LinkedDetails.Add(new PersonLinkedDetail
                    {
                        Category = value.Category,
                        SubCategoryId = value.SubCategoryId,
                        Type = PersonLinkedType.Employee,
                        LevelSubCategoryId = 1
                    });
                }

                var markedCompetences = wizardTab4_competenceDataGridView.Rows.Cast<DataGridViewRow>()
                                                .Where(k => Convert.ToBoolean(k.Cells[ColumnCompetenceMark.Name].Value) == true);
                foreach (var row in markedCompetences)
                {
                    var value = competencesBindingSource[row.Index] as Catalog;
                    employee.Details.LinkedDetails.Add(new PersonLinkedDetail
                    {
                        Category = value.Category,
                        SubCategoryId = value.SubCategoryId,
                        Type = PersonLinkedType.Employee
                    });
                }
            }

            //  wizardTab5
            {
                employee.Details.Salary = wizardTab5_txtBoxSalary.Text.As<decimal>();
            }

            #endregion

            //
            employee = _employeeService.Create(employee);

            //  check for additional parameters
            if (wizardTab5_createInternalUser.Checked)
            {
                var user = new User
                {
                    CreateDate = DateTime.Now,
                    Employee = employee,
                    Name = employee.Fullname,
                };
                _userService.Create(user, employee.Id);
            }
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

            //  wizardTab1
            wizardTab1_dateTimeBornDate.Format = DateTimePickerFormat.Custom;
            wizardTab1_dateTimeBornDate.CustomFormat = FormatHelper.DATE_FULL_FORMAT;
            //  wizardTab2
            wizardTab2_FromDateTimePicker.Format = DateTimePickerFormat.Custom;
            wizardTab2_FromDateTimePicker.CustomFormat = FormatHelper.DATE_FULL_FORMAT;
            wizardTab2_ToDateTimePicker.Format = DateTimePickerFormat.Custom;
            wizardTab2_ToDateTimePicker.CustomFormat = FormatHelper.DATE_FULL_FORMAT;
            //  wizardTab3
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
            //  wizardTab5

        }

        private void wizardTabControl_Selected(object sender, TabControlEventArgs e)
        {
            presentStep = e.TabPageIndex;
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

        private void wizardTab2_addAcademicInfo_Click(object sender, EventArgs e)
        {
            var grading = new PersonLinkedGrading
            {
                FromDate = wizardTab2_FromDateTimePicker.Value,
                ToDate = wizardTab2_ToDateTimePicker.Value,
                Description = wizardTab2_txtDescription.Text,
                Institution = wizardTab2_Institution.Text,
                Type = PersonLinkedType.Employee
            };
            wizardTab2_txtDescription.Clear();
            wizardTab2_Institution.Clear();
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

        private void wizardTab5_DepartmentComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var department = wizardTab5_DepartmentComboBox.SelectedValue as Department;
            if (department == null)
            {
                wizardTab5_jobPositionComboBox.SetComboBoxDatasource(new EmployeePosition[0], "Name", true);
            }

            var positions = _departmentService.GetPositions(department.Id);
            wizardTab5_jobPositionComboBox.SetComboBoxDatasource(positions, "Name", true);
        }

        private void wizardTab5_jobPositionComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            _position = wizardTab5_jobPositionComboBox.SelectedValue as EmployeePosition;

        }

        private void wizardTab5_txtBoxSalary_Validated(object sender, EventArgs e)
        {
            var numberString = Regex.Replace(wizardTab5_txtBoxSalary.Text, "[^0-9.]", "");
            var salary = Convert.ToDecimal(string.IsNullOrEmpty(numberString) ? "0.00M" : numberString);
            if (salary > _position.PositionMaxSalary || salary < _position.PositionMinSalary)
            {
                wizardTab5_txtBoxSalary.Focus();
                errorProvider1.SetError(wizardTab5_txtBoxSalary, $"El rango de salario debe ser válido (${_position.PositionMinSalary} - ${_position.PositionMaxSalary}).");
            }
            else
            {
                errorProvider1.Clear();
            }

        }
    }
}
