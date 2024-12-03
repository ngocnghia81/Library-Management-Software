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
    public partial class frmNhapSach : Form
    {
        DBConnection db = new DBConnection();
        int IndexNCC = -1;
        int IndexCT = -1;
        bool isLoadCBB = false;
        string maNCC;
        int ThanhTien = 0;

        DataRow TimTrongDGV()
        {
            DataTable dt = (DataTable)dgvChiTiet.DataSource;
            foreach (DataRow row in dt.Rows)
            {
                if (cbbSach.Text == row["Sach"].ToString())
                    return row;
            }
            return null;
        }

        void ClearContent()
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
        }

        void updateThanhTien()
        {
            
            int thanhtien = 0;
            DataTable dt = (DataTable)dgvChiTiet.DataSource;
            foreach (DataRow row in dt.Rows)
            {
                int dongia = (int) row["DonGia"];
                int sl = (int)row["SL"];
                thanhtien += dongia * sl;
            }
            ThanhTien = thanhtien;
            lbThanhTien.Text = thanhtien.ToString("C0", new System.Globalization.CultureInfo("vi-VN"));
        }

        void LoadCBBNCC()
        {
            cbbNCC.DataSource = db.ExecuteSelect("select * from NCC");
            cbbNCC.DisplayMember = "TenNCC";
            cbbNCC.ValueMember = "MaNCC";
            cbbNCC.SelectedIndex = -1;
        }

        void LoadCBBSach()
        {
            cbbSach.DataSource = db.ExecuteSelect("select * from Sach");
            cbbSach.DisplayMember = "TenSach";
            cbbSach.ValueMember = "MaSach";
            cbbSach.SelectedIndex = -1;
        }

        void LoadDGVNhap()
        {
            DataTable dt = db.ExecuteSelect("select Sach.TenSach as Sach, CTNS.DonGia as DonGia, CTNS.SoLuong as SL from CHITIETNHAPSACH CTNS join Sach on CTNS.MaSach = Sach.MaSach where CTNS.MaCTNS = 'empty'");
            dgvChiTiet.DataSource = dt;
            dgvChiTiet.Columns["Sach"].HeaderText = "Tên sách";
            dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvChiTiet.Columns["SL"].HeaderText = "Số lượng";
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Gán tỷ lệ cho từng cột
            dgvChiTiet.Columns["Sach"].FillWeight = 70; // 70%
            dgvChiTiet.Columns["DonGia"].FillWeight = 15; // 15%
            dgvChiTiet.Columns["SL"].FillWeight = 15; // 15%
        }


        void LoadDGVNCC()
        {
            dgvNCC.DataSource = db.ExecuteSelect("select * from NCC");
            dgvNCC.Columns["TenNCC"].HeaderText = "Tên NCC";
            dgvNCC.Columns["DaXoa"].HeaderText = "Đã Xoá";
            dgvNCC.Columns["MaNCC"].Visible = false;
        }

        public frmNhapSach()
        {
            InitializeComponent();
        }

        private void btnTaoMa_Click(object sender, EventArgs e)
        {

            string maMax = db.ExecuteSelect("select max(MaNCC) from NCC").Rows[0][0].ToString();

            int max = int.Parse(maMax.Substring(3));
            string newMa = "NCC" + (max + 1).ToString("D3");
            txtMaNCC.Text = newMa;
        }

        private void frmNCC_Load(object sender, EventArgs e)
        {
            LoadDGVNCC();
            LoadCBBNCC();
            LoadCBBSach();
            isLoadCBB = true;
            LoadDGVNhap();
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) return;
            IndexNCC = e.RowIndex;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

            txtMaNCC.Text = dgvNCC.Rows[IndexNCC].Cells["MaNCC"].Value.ToString();
            txtTenNCC.Text = dgvNCC.Rows[IndexNCC].Cells["TenNCC"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaNCC.Text;
            string ten = txtTenNCC.Text;

            DataTable dt = (DataTable)dgvNCC.DataSource;
            DataRow dr = dt.NewRow();
            dr["MaNCC"] = ma;
            dr["TenNCC"] = ten;

            dt.Rows.Add(dr);
            ClearContent();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            ClearContent();
            if (IndexNCC == -1)
            {
                MessageBox.Show("Vui lòng chọn dòng để xoá!");
                return;
            }
            DataTable dt = (DataTable)dgvNCC.DataSource;
            dt.Rows[IndexNCC]["DaXoa"] = true;
            IndexNCC = -1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show
                (
                "Bạn có chắc chắn muốn lưu?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if (result == DialogResult.No) return;
            DataTable dt = (DataTable)dgvNCC.DataSource;
            db.Update(dt, "select * from NCC");
            MessageBox.Show("Đã lưu thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (IndexNCC == -1)
            {
                MessageBox.Show("Vui lòng chọn dòng để sửa!");
                return;
            }
            DataTable dt = (DataTable)dgvNCC.DataSource;
            dt.Rows[IndexNCC]["MaNCC"] = txtMaNCC.Text.ToString();
            dt.Rows[IndexNCC]["TenNCC"] = txtTenNCC.Text.ToString();
            IndexNCC = -1;
        }

        private void btnAddCT_Click(object sender, EventArgs e)
        {
            //string ma = txtMaNCC.Text;
            string ten = cbbSach.Text.ToString();
            string dongia = txtDonGia.Text.ToString();
            string sl = txtSL.Text.ToString();
            DataTable dt = (DataTable)dgvChiTiet.DataSource;
            DataRow dr = TimTrongDGV();
            if (dr == null)
            {
                dr = dt.NewRow();
                dr["SL"] = sl; dr["Sach"] = ten;
                dr["DonGia"] = dongia;
                dt.Rows.Add(dr);
            }
            else
                dr["SL"] = int.Parse(dr["SL"].ToString()) + int.Parse(sl);

            
            updateThanhTien();

            
        }

        private void txtTenNCC_TextChanged(object sender, EventArgs e)
        {
            if (TienIch.CheckTXT(txtTenNCC, txtMaNCC))
            {
                btnThem.Enabled = true;

            }
            else
            {
                btnThem.Enabled = false;
            }

            if (TienIch.CheckTXT(txtSL, txtDonGia))
            {
                btnAddCT.Enabled = true;
            }
            else
            {
                btnAddCT.Enabled = false;
            }

        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) return;

            IndexCT = e.RowIndex;
            btnSuaCT.Enabled = true;
            btnXoaCT.Enabled = true;


            txtDonGia.Text = dgvChiTiet.Rows[IndexCT].Cells["DonGia"].Value.ToString();
            txtSL.Text = dgvChiTiet.Rows[IndexCT].Cells["SL"].Value.ToString();
            cbbSach.Text = dgvChiTiet.Rows[IndexCT].Cells["Sach"].Value.ToString();
        }

        private void cbbSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoadCBB) return;

            string dongia = db.ExecuteSelect(string.Format("select dongia from sach where masach = '{0}'", cbbSach.SelectedValue.ToString())).Rows[0][0].ToString();
            txtDonGia.Text = dongia;
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            if (IndexCT == -1)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng để sửa!");
                return;
            }
            dgvChiTiet.Rows.RemoveAt(IndexCT);
            IndexCT = -1;
            
            updateThanhTien();

        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            if (IndexCT == -1)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng để sửa!");
                return;
            }

            DataTable dt = (DataTable)dgvChiTiet.DataSource;
            dt.Rows[IndexCT]["Sach"] = cbbSach.Text.ToString();
            dt.Rows[IndexCT]["DonGia"] = txtDonGia.Text.ToString();
            dt.Rows[IndexCT]["SL"] = txtSL.Text.ToString();
            updateThanhTien();
            IndexCT = -1;
        }

        private void btnDoi_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show
                (
                "Nếu bạn thay đổi mọi dữ liệu sẽ xoá",
                "Cảnh báo",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
                );
            if (result == DialogResult.Cancel)
            {
                return;
            }
            LoadDGVNhap();
            lbNCC.Text = cbbNCC.Text.ToString();
            maNCC = cbbNCC.SelectedValue.ToString();
            btnLuu.Enabled = true;
        }

        private void btnLuuCT_Click(object sender, EventArgs e)
        {

            if (dgvChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu!");
                return;
            }
            DialogResult result = MessageBox.Show
                (
                "Đặt hàng?",
                "Thông báo",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
                );
            if (result == DialogResult.Cancel)
            {
                return;
            }
            string maNhap = TienIch.TaoMa("NH", "MaNhap", "NhapSach");
            string queryNS = string.Format("Insert into NHAPSACH values ('{0}','{1}',Getdate(),{2})", maNhap, maNCC, ThanhTien);
            db.ExecuteScalar(queryNS);
            
            DataTable dt = (DataTable)dgvChiTiet.DataSource;
            foreach (DataRow row in dt.Rows)
            {
                string masach = db.ExecuteScalar(string.Format("select masach from sach where tensach = N'{0}' ",row["Sach"].ToString())).ToString();
                string maCTNS = TienIch.TaoMa("CTNS", "MaCTNS", "CHITIETNHAPSACH");
                string queryCTNS = string.Format("Insert into ChitietNhapSach values ('{0}','{1}','{2}',{3},{4})", maCTNS, maNhap, masach, (int)row["DonGia"], (int)row["SL"]);
                db.ExecuteScalar(queryCTNS);
            }

            MessageBox.Show("Đã đặt thành công!");
        }

        private void cbbNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbNCC.SelectedIndex !=-1){
                btnDoi.Enabled = true;
            }
        }

    }
}
