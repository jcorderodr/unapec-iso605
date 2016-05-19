using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unapec.HumanResourcesM.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void ShowForm<T>() where T : Form, new()
        {
            var form = new T();
            AddOwnedForm(form);

            ActiveMdiChild?.Close();

            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ControlBox = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.MdiParent = this;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
