using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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


        private Form ShowForm<T>() where T : Form, new()
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
            return form;
        }

        private void LoadPermissions()
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadPermissions();
        }

        private void txtGlobalSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((Keys)e.KeyChar == Keys.Enter)
            {
                var form = ShowForm<Utilities.GlobalSearch>() as Utilities.GlobalSearch;
                form.SetInitialSearch(txtGlobalSearch.Text);
            }
        }

        private void jobsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<Jobs.NewJobOffer>();
        }

        private void employeesViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<Employees.EmployeesView>();
        }

        private void candidatesViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<Candidates.CandidatesView>();
        }

        private void registerEmployeeFromCandidateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<Candidates.EmployeeSelectionFromCandidate>();
        }

        private void availableCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<Learning.NewLearningOffer>();
        }

        private void permissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<Security.UsersPermissions>();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<Security.UsersView>();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<Utilities.Options>();
        }
    }
}
