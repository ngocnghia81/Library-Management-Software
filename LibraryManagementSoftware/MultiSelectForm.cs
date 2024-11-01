using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSoftware
{
    public partial class MultiSelectForm : Form
    {
        private CheckedListBox checkedListBoxAuthors;

        public List<string> SelectedAuthors { get; private set; } = new List<string>();

        public MultiSelectForm(DataTable authors)
        {
            InitializeComponent();
            foreach (DataRow row in authors.Rows)
            {
                checkedListBoxAuthors.Items.Add(new AuthorItem
                {
                    Name = row["TenTacGia"].ToString(),
                    Id = row["MaTacGia"].ToString()
                });
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedAuthors.Clear();
            foreach (AuthorItem item in checkedListBoxAuthors.CheckedItems)
            {
                SelectedAuthors.Add(item.Id);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InitializeComponent()
        {
            this.checkedListBoxAuthors = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // checkedListBoxAuthors
            // 
            this.checkedListBoxAuthors.FormattingEnabled = true;
            this.checkedListBoxAuthors.Location = new System.Drawing.Point(22, 13);
            this.checkedListBoxAuthors.Name = "checkedListBoxAuthors";
            this.checkedListBoxAuthors.Size = new System.Drawing.Size(292, 259);
            this.checkedListBoxAuthors.TabIndex = 0;
            // 
            // MultiSelectForm
            // 
            this.ClientSize = new System.Drawing.Size(336, 289);
            this.Controls.Add(this.checkedListBoxAuthors);
            this.Name = "MultiSelectForm";
            this.ResumeLayout(false);

        }
    }

    public class AuthorItem
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}