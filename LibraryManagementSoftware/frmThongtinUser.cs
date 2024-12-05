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
    public partial class frmThongtinUser : Form
    {
        DBConnection db = new DBConnection();

        public void LoadThongTin()
        {
            string sql = string.Format("select DOCGIA.* from DOCGIA join TAIKHOAN on TAIKHOAN.MaDocGia = DOCGIA.MaDocGia where TAIKHOAN.Email = '{0}'",UserIdentify.Instance.email);
            DataRow user = db.ExecuteSelect(sql).Rows[0];

            txtMa.Text = user["MaDocGia"].ToString();
            txtTen.Text = user["TenDocGia"].ToString();
            txtSDT.Text = user["SDT"].ToString();
            txtDiaChi.Text = user["DiaChi"].ToString();
            txtCCCD.Text = user["CCCD"].ToString();
        }

        public frmThongtinUser()
        {
            InitializeComponent();
        }

        private void frmThongtinUser_Load(object sender, EventArgs e)
        {
            LoadThongTin();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select DOCGIA.* from DOCGIA join TAIKHOAN on TAIKHOAN.MaDocGia = DOCGIA.MaDocGia where TAIKHOAN.Email = '{0}'", UserIdentify.Instance.email);
            DataRow user = db.ExecuteSelect(sql).Rows[0];


            user["TenDocGia"] = txtTen.Text;
            user["SDT"] = txtSDT.Text;
            user["DiaChi"] = txtDiaChi.Text;
            bool temp = db.Update(user.Table, "select * from docgia");
            if (temp)
                MessageBox.Show("Lưu thành công!");

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select DOCGIA.* from DOCGIA join TAIKHOAN on TAIKHOAN.MaDocGia = DOCGIA.MaDocGia where TAIKHOAN.Email = '{0}'", UserIdentify.Instance.email);
            DataRow user = db.ExecuteSelect(sql).Rows[0];
            lbMa.Text = user["MaDocGia"].ToString();
            lbTen.Text = user["TenDocGia"].ToString();
            lbNgaySinh.Text = DateTime.Parse(user["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
            lbNgayDangKi.Text = DateTime.Parse(user["NgayDangKy"].ToString()).ToString("dd/MM/yyyy");
        }


    }
}
