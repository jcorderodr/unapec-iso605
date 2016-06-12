using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Helpers;
using Unapec.HumanResourcesM.Framework.Services;
using Unapec.HumanResourcesM.Models;
using Unapec.HumanResourcesM.Resources;

namespace Unapec.HumanResourcesM.Forms.Employees
{
    public partial class EmployeesView : FormBase
    {

        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;

        DataGridViewCheckBoxColumn ColumnChkboxEmpSelection;

        public EmployeesView()
        {
            InitializeComponent();
            this.Text = "Vista de Empleados";
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();
            //
            btnAcceptSelection.Visible = false;
            FillComponents();
        }

        public void SetSelectionMode()
        {
            btnAcceptSelection.Visible = true;
            actionButtonCreateNewEmployee.Visible = false;
            ColumnChkboxEmpSelection = new DataGridViewCheckBoxColumn();
            ColumnChkboxEmpSelection.HeaderText = "";
            ColumnChkboxEmpSelection.Name = "ColumnLanguageCheckBox";
            ColumnChkboxEmpSelection.ThreeState = false;
            ColumnChkboxEmpSelection.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            ColumnChkboxEmpSelection.DataPropertyName = "IsMark";
            employeeDataGridView.Columns.Insert(0, ColumnChkboxEmpSelection);
        }

        public IEnumerable<int> GetSelection()
        {
            var selectedEmployees = employeeViewModelBindingSource.List.Cast<EmployeeViewModel>().Where(k => k.IsMark);

            return selectedEmployees.Select(p => p.EmployeeId);
        }

        private void FillComponents()
        {
            var status = EnumHelper.ToList(typeof(PersonStatus), true);
            employeeStatusComboBox.DataSource = status.ToList();
            employeeStatusComboBox.DisplayMember = "Value";

            var departments = _departmentService.GetDepartments();
            departmentComboBox.SetComboBoxDatasource(departments, "Name", true);
            jobPositionComboBox.SetComboBoxDatasource(new EmployeePosition[0], "Name", true);

            registeredDateDataGridViewTextBoxColumn.SetDateDataGridViewTextBoxColumnFormat();
        }

        private void RefreshComponents()
        {
            var department = departmentComboBox.SelectedValue as Department;
            if (department == null)
            {
                jobPositionComboBox.SetComboBoxDatasource(new EmployeePosition[0], "Name", true);
            }

            var positions = _departmentService.GetPositions(department.Id);
            jobPositionComboBox.SetComboBoxDatasource(positions, "Name", true);
        }

        private EmployeeViewModel To(Employee employee)
        {
            return new EmployeeViewModel
            {
                EmployeeId = employee.Id,
                LastName = employee.LastName,
                Name = employee.Name,
                PhoneCell = employee.PhoneCell,
                Status = Strings.ResourceManager.GetString(employee.Status.ToString()),
                RegisteredDate = employee.RegisteredDate,
                DepartmentName = employee.Department.Name,
                PositionName = employee.Position.Name,
            };
        }

        private void departmentComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var department = departmentComboBox.SelectedValue as Department;
            if (department == null)
            {
                jobPositionComboBox.SetComboBoxDatasource(new EmployeePosition[0], "Name", true);
                return;
            }
            var positions = _departmentService.GetPositions(department.Id);
            jobPositionComboBox.SetComboBoxDatasource(positions, "Name", false);
        }

        private void refreshSearchButton_Click(object sender, EventArgs e)
        {
            var department = departmentComboBox.SelectedValue as Department;
            var position = jobPositionComboBox.SelectedValue as EmployeePosition;
            var statusString = (KeyValuePair<int, string>)employeeStatusComboBox.SelectedValue;
            PersonStatus status = 0;

            try
            {
                status = EnumHelper.GetEnum<PersonStatus>(statusString.Value);
            }
            catch { }

            var matches = _employeeService.DoEmployeeSearch(txtBoxName.Text, status, department.Id, position.Id);
            employeeDataGridView.DataSource = matches.Select(To).ToList();
        }

        private void actionButtonCreateNewEmployee_Click(object sender, EventArgs e)
        {
            var form = new NewEmployeeWizard();
            form.ShowDialog(this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAcceptSelection_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void employeeDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (employeeDataGridView.IsCurrentCellDirty)
            {
                employeeDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
