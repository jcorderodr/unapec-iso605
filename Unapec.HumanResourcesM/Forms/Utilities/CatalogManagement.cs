using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Services;
using Unapec.HumanResourcesM.Resources;

namespace Unapec.HumanResourcesM.Forms.Utilities
{
    public partial class CatalogManagement : FormBaseUtility
    {

        private readonly CatalogService _catalogService;

        private string _editingCategory;

        public CatalogManagement()
        {
            InitializeComponent();
            this.Text = "Panel de Administración";
            _catalogService = new CatalogService();
        }


        private void FillComponents()
        {
            catalogBindingSource.Clear();
            catalogBindingSource.DataSource = _catalogService.Get(_editingCategory);
        }

        public void SetTitle(string title)
        {
            this.Text = $"Panel de Administración de {title}";
            this.valueDataGridViewTextBoxColumn.HeaderText = title;
        }

        public void LoadCategory(string catalogName)
        {
            _editingCategory = catalogName;
            FillComponents();
        }

        private bool IsInvalid()
        {
            return false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            var dResult = this.ShowQuestionMessage(Strings.Question_CreationFormSubmit);
            if (dResult != DialogResult.Yes) return;

            if (IsInvalid()) return;

            var bindingSource = catalogBindingSource.List as List<Catalog>;
            bindingSource.ForEach(p => p.Category = _editingCategory);
            _catalogService.Create(bindingSource);

            this.ShowInformationMessage(Strings.Message_FormSubmitSuccess);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void catalogDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColumnDelete.Index)
            {
                catalogBindingSource.RemoveAt(e.RowIndex);
            }
        }
    }
}
