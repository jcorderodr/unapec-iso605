using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Unapec.HumanResourcesM.Framework.Entities;

namespace Unapec.HumanResourcesM.Forms
{
    internal static class UIExtensions
    {

        public static void SetComboBoxDatasourceWithCatalogs(this ComboBox comboBox, IEnumerable<Catalog> values)
        {
            comboBox.DataSource = values.ToList();
            comboBox.DisplayMember = "Value";
            //comboBox.ValueMember = "SubCategoryId";
        }

        public static void SetListViewItemsWithCatalogs(this ListView listView, IEnumerable<Catalog> values)
        {
            listView.Items.Clear();
            foreach (var item in values)
            {
                var listItem = new ListViewItem
                {
                    Text = item.Value,
                    Tag = item
                };
                listView.Items.Add(listItem);
            }
        }

    }
}
