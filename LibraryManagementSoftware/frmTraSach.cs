﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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

        public string TaoMaPT()
        {
            string ma = db.ExecuteScalar("select max(maphieutra) from  phieutra").ToString();
            int phanSo = int.Parse(ma.Substring(2));
            phanSo++;
            ma = "PT" + phanSo.ToString("D3");
            return ma;
        }

        float TinhLePhi(string ngaymuon)
        {
            DateTime _ngaymuon = DateTime.Parse(ngaymuon);
            int songaymuon = (DateTime.Now- _ngaymuon).Days;
            if (songaymuon <= 7)
                return 0;
            if (songaymuon <= 15)
                return 10000;
            return 50000;
        }
        void LoadDocGia()
        {
            string query = "select * from DocGia";
            DataTable dt = db.ExecuteSelect(query);
            DataRow row = dt.NewRow();
            row["MaDocGia"] = "";
            row["TenDocGia"] = "Tất cả độc giả";
            dt.Rows.InsertAt(row, 0);
            cbbDocGias.DataSource = dt;          
            cbbDocGias.DisplayMember = "TenDocGia";
            cbbDocGias.ValueMember = "MaDocGia";
        }

        public void LoadSach()
        {
            string query = "select * from Sach";
            DataTable dt = db.ExecuteSelect(query);
            DataRow row = dt.NewRow();
            row["MaSach"] = "";
            row["TenSach"] = "Tất cả sách";
            dt.Rows.InsertAt(row, 0);
            cbbSach.DataSource = dt;
            cbbSach.DisplayMember = "TenSach";
            cbbSach.ValueMember = "MaSach";
        }
        void LoadDgv(string madg = null,string masach = null)
        {
            if (madg == null || madg == "")
                madg = "null"; 
            else madg = "'" + madg + "'";

            if (masach == null || masach == "")
                masach = "null";
            else masach = "'" + masach + "'";

            string sql = string.Format("select * from dbo.DANHSACHMUONTRA({0},{1}) where TinhTrang = 0",madg,masach);

            DataTable dt = db.ExecuteSelect(sql); 


            dgv1.DataSource = dt;
            dgv1.Columns["MaDG"].HeaderText = "Mã độc giả";
            dgv1.Columns["TenDG"].HeaderText = "Tên độc giả";
            dgv1.Columns["TenSach"].HeaderText = "Sách";
            dgv1.Columns["MaPhieuMuon"].HeaderText = "Mã phiếu mượn";
            dgv1.Columns["NgayMuon"].HeaderText = "Ngày mượn";
            dgv1.Columns["TinhTrang"].HeaderText = "Tình trạng";
            dgv1.Columns["MaCTPM"].Visible = false;
            foreach (DataGridViewColumn column in dgv1.Columns)
            {
                if (column.HeaderText != "Tình trạng") // "TinhTrang" là tên cột cần chỉnh sửa
                {
                    column.ReadOnly = true;
                    continue;
                }
            }
            if (dgv1.Columns["TinhTrangBanDau"] == null)
            {
                dgv1.Columns.Add("TinhTrangBanDau", "TinhTrangBanDau"); // Thêm cột
                dgv1.Columns["TinhTrangBanDau"].Visible = false;
            }                
            foreach (DataGridViewRow row in dgv1.Rows)
            {
                row.Cells["TinhTrangBanDau"].Value = row.Cells["TinhTrang"].Value; // Lưu trạng thái ban đầu
            }
            foreach (DataGridViewRow row in dgv1.Rows)
            {
                bool tinhTrang = Convert.ToBoolean(row.Cells["TinhTrang"].Value); // Lấy giá trị cột "Tình trạng"

                if (tinhTrang) // Nếu đã check (true)
                {
                    row.Cells["TinhTrang"].ReadOnly = true;
                }
            }
        }

        public frmTraSach()
        {
            InitializeComponent();
        }

        private void frmTraSach_Load(object sender, EventArgs e)
        {
            LoadSach();
            LoadDocGia();
            LoadDgv();
        
        }

        private void cbbDocGias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDocGias.SelectedValue == null) return;
            if (cbbSach.SelectedValue == null) return;
            string madg = cbbDocGias.SelectedValue.ToString();
            string masach = cbbSach.SelectedValue.ToString();
            LoadDgv(madg,masach);

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv1.Rows)
            {
                if (row.IsNewRow) continue;
               
                bool isChecked = Convert.ToBoolean(row.Cells["TinhTrang"].Value);
                bool bandau = Convert.ToBoolean(row.Cells["TinhTrangBanDau"].Value);

                if (isChecked != bandau && isChecked)
                {                   
                    string maDG = row.Cells["MaDG"].Value.ToString();
                    string maCTPM = row.Cells["MaCTPM"].Value.ToString();

                    string ngaymuon = row.Cells["NgayMuon"].Value.ToString();
                    string sql = "INSERT INTO PhieuTra (MaPhieuTra, NgayTra, LePhi, MaCTPM) VALUES (@MaPhieuTra, GETDATE(), @LePhi, @MaCTPM)";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaPhieuTra", TaoMaPT()),
                        new SqlParameter("@LePhi", TinhLePhi(ngaymuon)),
                        new SqlParameter("@MaCTPM", maCTPM)
                    };
                    db.ExecuteInsert(sql, parameters);

                }
                
            }
            LoadDgv();

        }
    }
}