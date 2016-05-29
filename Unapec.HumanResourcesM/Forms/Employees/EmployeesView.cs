using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unapec.HumanResourcesM.Forms;
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

        public EmployeesView()
        {
            InitializeComponent();
            this.Text = "Vista de Empleados";
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();
            //
            FillComponents();
        }

        private void FillComponents()
        {
            var status = EnumHelper.ToList(typeof(EmployeeStatus), true);
            employeeStatusComboBox.DataSource = status.ToList();
            employeeStatusComboBox.DisplayMember = "Value";

            var departments = _departmentService.GetDepartments();
            departmentComboBox.SetComboBoxDatasource(departments, "Name", true);
            jobPositionComboBox.SetComboBoxDatasource(new EmployeePosition[0], "Name", true);
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
            EmployeeStatus status = 0;

            try
            {
                status = EnumHelper.GetEnum<EmployeeStatus>(statusString.Value);
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
            this.Close();
        }
    }
}
