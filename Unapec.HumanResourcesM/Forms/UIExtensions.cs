﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Unapec.HumanResourcesM.Framework.Entities;
using Unapec.HumanResourcesM.Framework.Helpers;

namespace Unapec.HumanResourcesM.Forms
{
    internal static class UIExtensions
    {

        public static void SetMaskedTextBoxCurrencyFormat(this MaskedTextBox textBox)
        {
            textBox.Mask = "$000,000.00";
            textBox.TextMaskFormat = MaskFormat.IncludeLiterals;
        }

        public static void SetComboBoxDatasource<T>(this ComboBox comboBox, IEnumerable<T> values,
            string propertyToDisplay, bool includeEmptySelection = false)
        {
            var list = values.ToList();
            if (includeEmptySelection)
            {
                var temp = (T)typeof(T).GetConstructors().First().Invoke(null);
                var prop = temp.GetType().GetProperty(propertyToDisplay);
                prop.SetValue(temp, "--");
                list.Insert(0, temp);
            }
            comboBox.DataSource = list;
            comboBox.DisplayMember = propertyToDisplay;
        }

        public static void SetComboBoxDatasourceWithCatalogs(this ComboBox comboBox, IEnumerable<Catalog> values, bool includeEmptySelection = false)
        {
            var list = values.ToList();
            if (includeEmptySelection)
            {
                var temp = new Catalog { Value = "--" };
                list.Insert(0, temp);
            }
            comboBox.DataSource = list;
            comboBox.DisplayMember = "Value";
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

        public static void SetDateTimePickerFormat(this DateTimePicker dateTimePicker)
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = FormatHelper.DATE_TIME_FULL_FORMAT;
            dateTimePicker.Value = DateTime.Now;
        }

        public static void SetDateDataGridViewTextBoxColumnFormat(this DataGridViewTextBoxColumn dateColumn)
        {
            dateColumn.ValueType = typeof(DateTime);
            dateColumn.DefaultCellStyle.Format = "D";
        }

        public static void SetFullDateStringDataGridViewTextBoxColumnFormat(this DataGridViewTextBoxColumn dateColumn)
        {
            dateColumn.ValueType = typeof(DateTime);
            dateColumn.DefaultCellStyle.Format = "f";
        }

        public static Form ShowFormWithParent<T>(this Form parentForm, bool showAsDialog = false) where T : Form, new()
        {
            var form = new T();
            return ShowFormWithParent(parentForm, form, showAsDialog);
        }

        public static Form ShowFormWithParent(this Form parentForm, Form form, bool showAsDialog = false)
        {
            parentForm.AddOwnedForm(form);

            form.MdiParent = parentForm;
            form.StartPosition = FormStartPosition.CenterParent;
            if (!showAsDialog)
                form.Show();
            else
                form.ShowDialog(parentForm);

            return form;
        }

    }
}
