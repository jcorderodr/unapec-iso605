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

        private readonly IList<Form> _forms;

        public MainForm()
        {
            InitializeComponent();
            this.Text = Program.AppName;
            this.WindowState = FormWindowState.Maximized;
            _forms = new List<Form>();
        }

        private void CloseChildForm(object s, FormClosedEventArgs args)
        {
            var form = s as Form;
            form = _forms.SingleOrDefault(i => i.CompanyName == form.CompanyName);
            if (form != null)
            {
                _forms.Remove(form);
            };
        }

        private Form ShowForm<T>() where T : Form, new()
        {
            var form = new T();

            if (_forms.Any(i => i.CompanyName == form.CompanyName))
            {
                var tempForm = _forms.Single(i => i.CompanyName == form.CompanyName);
                return form;
            };

            _forms.Add(form);
            form.FormClosed += (s, args) => CloseChildForm(s, args);
            this.ShowFormWithParent(form);
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
            ShowForm<Jobs.JobsView>();
        }

        private void createNewJobToolStripMenuItem_Click(object sender, EventArgs e)
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
