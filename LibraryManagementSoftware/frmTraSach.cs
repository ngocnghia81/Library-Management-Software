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
    public partial class frmTraSach : Form
    {
        DBConnection db = new DBConnection();
        void LoadDocGia()
        {
            string query = "select * from DocGia";
            DataTable dt = db.ExecuteSelect(query);

            cbbDocGias.DataSource = dt;
            cbbDocGias.DisplayMember = "TenDocGia";
            cbbDocGias.ValueMember = "MaDocGia";

            cbbDocGias.SelectedIndex = 0;
        }

        void LoadDgv(string query)
        {

            DataTable dt = db.ExecuteSelect(query);

            DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
            chkColumn.Name = "TinhTrangCheckbox";
            chkColumn.HeaderText = "Tình Trạng";
            chkColumn.TrueValue = true;
            chkColumn.FalseValue = false;

            dgv1.DataSource = dt;

            dgv1.Columns.Add(chkColumn);

            foreach (DataGridViewRow row in dgv1.Rows)
            {
                string tinhTrang = row.Cells["TinhTrang"].Value?.ToString();
                row.Cells["TinhTrangCheckbox"].Value = (tinhTrang == "Đã trả");
            }

            dgv1.Columns.Remove("TinhTrang");

            foreach (DataGridViewColumn column in dgv1.Columns)
            {
                if (column.Name != "TinhTrangCheckbox")
                {
                    column.ReadOnly = true;
                }
            }

            dgv1.Columns["TinhTrangCheckbox"].ReadOnly = false;

        }

        public frmTraSach()
        {
            InitializeComponent();
        }

        private void frmTraSach_Load(object sender, EventArgs e)
        {
            LoadDocGia();
            LoadDgv("select * from ChiTietPhieuMuon");
        }

        private void cbbDocGias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = string.Format("select * from ChiTietPhieuMuon where MaDocGia = '{0}'",cbbDocGias.SelectedValue.ToString());

            //LoadDgv(query);

        }
    }
}
