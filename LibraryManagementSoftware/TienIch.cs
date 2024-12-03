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

        public static bool CheckTXT(params TextBox[] txts)
        {
            foreach(TextBox t in txts )
            {
                if (t.Text.ToString().Length <=0)
                    return false;
            }
            return true;
        }

        public static string TaoMa(string prefix,string tenMa, string tenbang)
        {
            DBConnection db = new DBConnection();
            string ma = db.ExecuteScalar(string.Format("select max({0}) from  {1}",tenMa,tenbang)).ToString();
            int phanSo = int.Parse(ma.Substring(prefix.Length+1));
            phanSo++;
            string d = "D" + (prefix.Length + 1).ToString();
            ma = prefix + phanSo.ToString("D3");
            return ma;
        }

    }
}
