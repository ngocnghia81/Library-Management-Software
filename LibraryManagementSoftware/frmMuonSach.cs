using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSoftware
{
    public partial class frmMuonSach : Form
    {
        private DBConnection db = new DBConnection();
        public frmMuonSach()
        {
            InitializeComponent();
            LoadDocGia();
            LoadSach();
        }

        private void LoadDocGia()
        {
            DataTable dt = db.ExecuteSelect("SELECT MaDocGia, TenDocGia FROM DOCGIA");

            cmbMaDocGia.DataSource = dt;

            cmbMaDocGia.DisplayMember = "TenDocGia";
            cmbMaDocGia.ValueMember = "MaDocGia";
        }


        private void LoadSach()
        {
            DataTable dt = db.ExecuteSelect("SELECT MaSach, TenSach FROM SACH WHERE SoLuongKho > 0");

            cmbTenSach.DataSource = dt;
            cmbTenSach.DisplayMember = "TenSach";
            cmbTenSach.ValueMember = "MaSach";
        }

        private void btnMuonSach_Click(object sender, EventArgs e)
        {
            string maDocGia = cmbMaDocGia.SelectedItem.ToString();
            string maSach = (cmbTenSach.SelectedItem).ToString();
            DateTime ngayMuon = dtpNgayMuon.Value;

            //string maPhieuMuon = GenerateMaPhieuMuon();

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
