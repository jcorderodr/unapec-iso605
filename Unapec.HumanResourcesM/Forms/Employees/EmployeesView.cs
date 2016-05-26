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

namespace Unapec.HumanResourcesM.Forms.Employees
{
    public partial class EmployeesView : FormBase
    {

        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;

        public EmployeesView()
        {
            InitializeComponent();
            this.Text += "Vista de Empleados";
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();
        }

        private void FillComponents()
        {
            var status = EnumHelper.ToList(typeof(EmployeeStatus), true);
            employeeStatusComboBox.DataSource = status;
            employeeStatusComboBox.DisplayMember = "Value";

            var departments = _departmentService.GetDepartments();
            departmentComboBox.SetComboBoxDatasource(departments, "Name", true);
        }

        private void RefreshComponents()
        {
            var department = departmentComboBox.SelectedValue as Department;
            if (department == null)
            {
                jobPositionComboBox.DataSource = null;
                jobPositionComboBox.Items.Clear();
                jobPositionComboBox.Items.Add("--");
            }

            var positions = _departmentService.GetPositions(department.Id);
            jobPositionComboBox.SetComboBoxDatasource(positions, "Description", true);
        }

        private void actionButtonCreateNewEmployee_Click(object sender, EventArgs e)
        {
            var form = new NewEmployeeWizard();
            form.Show(this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
