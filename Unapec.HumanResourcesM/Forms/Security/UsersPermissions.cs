using System.Collections.Generic;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Services;
using Unapec.HumanResourcesM.Resources;

namespace Unapec.HumanResourcesM.Forms.Security
{
    public partial class UsersPermissions : FormBase
    {

        private readonly UserService _userService;

        private User _user;
        private IEnumerable<Permission> _permissions;

        public UsersPermissions()
        {
            InitializeComponent();
            this.Text += " Asignación de Permisos";
            btnAccept.Text = Strings.Save;
            btnCancel.Text = Strings.Cancel;
            _userService = new UserService();

            _permissions = _userService.GetPermissions();
            foreach (var item in _permissions)
            {
                dataGridView1.Rows.Add(item.Name, false);
            }
        }

        public void LoadUser(Employee employee)
        {
            lblName.Text = string.Format("{0} {1}", employee.Name, employee.LastName);
            lblPosition.Text = employee.Position.Name;
        }

        private void btnAccept_Click(object sender, System.EventArgs e)
        {
            
            //_userService.UpdatePermissions(0, )
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
