using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSoftware
{
        internal static class TienIch
        {

            public static void GoiYComboBox(ComboBox comboBox, string displayMember)
            {
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                foreach (DataRowView item in comboBox.Items)
                {
                    if (!item.Row.ItemArray[0].ToString().Equals("ADD", StringComparison.OrdinalIgnoreCase))
                    {
                        autoCompleteCollection.Add(item[displayMember].ToString());
                    }
                }

                comboBox.AutoCompleteCustomSource = autoCompleteCollection;
            }
    }
}
