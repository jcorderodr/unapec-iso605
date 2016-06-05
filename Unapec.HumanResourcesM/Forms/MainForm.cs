using System;
using System.Collections.Generic;
using System.Linq;
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
            //
            toolStripSignedUserLabel.Text = Program.SignedUser.Name;
        }

        private void CloseChildForm(object s, FormClosedEventArgs args)
        {
            var form = s as Form;
            form = _forms.SingleOrDefault(i => i.Name == form.Name);
            if (form != null)
            {
                _forms.Remove(form);
            };
        }

        private Form ShowForm<T>() where T : Form, new()
        {
            var form = new T();
            
            if (_forms.Any(i => i.Name == form.Name))
            {
                var tempForm = _forms.Single(i => i.Name == form.Name);
                tempForm.Focus();
                return tempForm;
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
            if ((Keys)e.KeyChar == Keys.Enter)
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
            ShowForm<Learning.CoursesView>();
        }

        private void registrarNuevaCapacitaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<Learning.NewLearningOffer>();
        }

        private void courseQuorumToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helpProvider.SetHelpString(this, $"El sistema {Program.AppName} le permite gestión completa de su Departamento de Recursos Humanos.");
            helpProvider.SetShowHelp(this, true);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (var form = new Utilities.AboutBox())
            {
                form.ShowDialog(this);
            }
        }

        private void changeSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var signIn = new Security.SignIn())
            {
                signIn.ShowApplicantFooter = false;
                var signInResult = signIn.ShowDialog();
                if (signInResult == DialogResult.OK)
                {
                    Program.SignedUser = signIn.GetSigned();
                    toolStripSignedUserLabel.Text = Program.SignedUser.Name;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void competencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = ShowForm<Utilities.CatalogManagement>() as Utilities.CatalogManagement;
            form.SetTitle("Competencias");
            form.LoadCategory(Framework.Entities.Catalog.COMPETENCES);
        }

        private void languagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form =  ShowForm<Utilities.CatalogManagement>() as Utilities.CatalogManagement;
            form.SetTitle("Idiomas");
            form.LoadCategory(Framework.Entities.Catalog.LANGUAGE);
        }

        private void rptApplicantHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<Reports.RptApplicantsHistory>();
        }
    }
}
