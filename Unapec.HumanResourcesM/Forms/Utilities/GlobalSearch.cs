using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Helpers;
using Unapec.HumanResourcesM.Framework.Services;
using Unapec.HumanResourcesM.Resources;

namespace Unapec.HumanResourcesM.Forms.Utilities
{
    public partial class GlobalSearch : Form
    {

        enum SearchResultType
        {
            Employee = 1,
            Candidate = 2
        }

        class SearchResult
        {
            public string Name { get; set; }
            public string Position { get; set; }
            public SearchResultType Type { get; set; }
            public string TypeText { get; set; }
        }

        private readonly EmployeeService _employeeService;
        private readonly JobService _jobService;

        private IList<SearchResult> _results;

        public GlobalSearch()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _jobService = new JobService();
            //
            searchDataGridView.AutoGenerateColumns = true;
            searchTypeComboBox.DataSource = EnumHelper.ToList(typeof(GlobalSearchMode), true);
        }

        internal void SetInitialSearch(string text)
        {
            txtName.Text = text;
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            var searchType = searchTypeComboBox.SelectedValue;

            var applicantJob = availableJobsComboBox.SelectedValue as Job;
            var candidates = _jobService.DoApplicantsSearch(txtName.Text, applicantJob.Id);
            var emps = _employeeService.DoEmployeeSearch(txtName.Text);
            _results = SetSearchResults(candidates, emps);
            //
            RefreshDataGrid();
        }

        private IList<SearchResult> SetSearchResults(IEnumerable<Applicant> candidates, IEnumerable<Employee> employees)
        {
            var result = new List<SearchResult>();

            result.AddRange(candidates.Select(p =>
            {
                return new SearchResult
                {
                    Name = p.Name,
                    Position = p.JobOffer.Description,
                    Type = SearchResultType.Candidate,
                    TypeText = Strings.Candidate
                };
            }));
            result.AddRange(employees.Select(p =>
            {
                return new SearchResult
                {
                    Name = p.Name,
                    Position = p.Department.Name,
                    Type = SearchResultType.Employee,
                    TypeText = Strings.Employee
                };
            }));

            return result;
        }

        private void RefreshDataGrid()
        {
            searchDataGridView.DataSource = _results;
            searchDataGridView.Columns[0].HeaderText = "Nombre";
            searchDataGridView.Columns[1].HeaderText = "Puesto";
            searchDataGridView.Columns[2].Visible = false;
            searchDataGridView.Columns[3].HeaderText = "Tipo";
        }

        private void GlobalSearch_Load(object sender, EventArgs e)
        {

        }

        private void searchDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selected = searchDataGridView.SelectedRows[0];
            if(selected != null)
            {
                //TODO: Open candidate or employee
            }
        }


    }
}
