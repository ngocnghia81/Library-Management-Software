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
    public partial class frmDonNhap : Form
    {
        DBConnection db = new DBConnection();

        public frmDonNhap()
        {
            InitializeComponent();
        }

        private void frmDonNhap_Load(object sender, EventArgs e)
        {
            LoadDonNhap();
        }

        private void LoadDonNhap()
        {
            string query = @"
        SELECT 
            n.MaNhap,
            n.NgayNhap,
            n.ThanhTien,
            NCC.TenNCC
        FROM 
            NHAPSACH n
        JOIN 
            NCC ON n.MaNCC = NCC.MaNCC
        ORDER BY 
            n.NgayNhap DESC";

            // Thực thi truy vấn và lấy dữ liệu
            DataTable dt = db.ExecuteSelect(query);
            guna2DataGridViewDonNhap.DataSource = dt;

            // Thiết lập font chữ cho toàn bộ DataGridView
            guna2DataGridViewDonNhap.DefaultCellStyle.Font = new Font("Arial", 16);
            guna2DataGridViewDonNhap.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16);  // Header


            // Thiết lập chiều cao của các cột (cell height)
            foreach (DataGridViewColumn col in guna2DataGridViewDonNhap.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa nội dung các cột
                guna2DataGridViewDonNhap.RowTemplate.Height = 40;  // Thiết lập chiều cao dòng

                // Đổi tên header sang có dấu
                switch (col.Name)
                {
                    case "MaNhap":
                        col.HeaderText = "Mã Nhập";
                        break;
                    case "NgayNhap":
                        col.HeaderText = "Ngày Nhập";
                        break;
                    case "ThanhTien":
                        col.HeaderText = "Thành Tiền";
                        break;
                    case "TenNCC":
                        col.HeaderText = "Tên Nhà Cung Cấp";
                        break;
                    // Nếu có thêm cột nào cần đổi tên, bạn có thể thêm vào đây
                }

                // Căn giữa tiêu đề của các cột (header)
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa header
            }


            guna2DataGridViewDonNhap.ColumnHeadersHeight = 40; // Chiều cao của header cột
        }

        private void guna2DataGridViewDonNhap_SelectionChanged(object sender, EventArgs e)
        {
            if (guna2DataGridViewDonNhap.SelectedRows.Count > 0)
            {
                string maNhap = guna2DataGridViewDonNhap.SelectedRows[0].Cells["MaNhap"].Value.ToString();

                string query = @"
                    SELECT 
                        c.MaCTNS,
                        c.MaSach,
                        s.TenSach,
                        c.DonGia,
                        c.SoLuong,
                        (c.DonGia * c.SoLuong) AS ThanhTien
                    FROM 
                        CHITIETNHAPSACH c
                    JOIN 
                        SACH s ON c.MaSach = s.MaSach
                    WHERE 
                        c.MaNhap = @MaNhap";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MaNhap", maNhap)
                };

                DataTable dtChiTiet = db.ExecuteSelect(query, parameters.ToArray());

                ClearDataGridViewRows();
                guna2DataGridViewChiTietDonNhap.DataSource = dtChiTiet;

                ConfigureDataGridView();
            }
            else
            {
                guna2DataGridViewChiTietDonNhap.DataSource = null; 
            }
        }


        private void ConfigureDataGridView()
        {
            guna2DataGridViewChiTietDonNhap.AutoGenerateColumns = false;
            guna2DataGridViewChiTietDonNhap.AllowUserToAddRows = false; // Không cho phép thêm hàng
            guna2DataGridViewChiTietDonNhap.AllowUserToDeleteRows = false; // Không cho phép xóa hàng
            guna2DataGridViewChiTietDonNhap.AllowUserToResizeColumns = true; // Cho phép thay đổi kích thước cột
            guna2DataGridViewChiTietDonNhap.AllowUserToResizeRows = false; // Không cho phép thay đổi kích thước hàng
            guna2DataGridViewChiTietDonNhap.RowTemplate.Height = 40; // Chiều cao của hàng

            // Thiết lập font chữ cho header và data
            guna2DataGridViewChiTietDonNhap.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Bold);
            guna2DataGridViewChiTietDonNhap.DefaultCellStyle.Font = new Font("Arial", 14);
            guna2DataGridViewChiTietDonNhap.ColumnHeadersHeight = 40; // Chiều cao header
            guna2DataGridViewChiTietDonNhap.RowTemplate.Height = 40; // Chiều cao mỗi hàng

            // Căn giữa các cột header
            guna2DataGridViewChiTietDonNhap.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Căn giữa dữ liệu trong các ô
            guna2DataGridViewChiTietDonNhap.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in guna2DataGridViewChiTietDonNhap.Columns)
            {
                // Căn giữa nội dung các cột
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Đổi tên header sang có dấu
                switch (col.Name)
                {
                    case "MaCTNS":
                        col.HeaderText = "Mã CTNS";
                        col.Width = 80; 
                        break;
                    case "MaSach":
                        col.HeaderText = "Mã Sách";
                        col.Width = 80; 
                        break;
                    case "TenSach":
                        col.HeaderText = "Tên Sách";
                        col.Width = 180; 
                        break;
                    case "DonGia":
                        col.HeaderText = "Đơn Giá";
                        col.Width = 100; 
                        break;
                    case "SoLuong":
                        col.HeaderText = "Số Lượng";
                        col.Width = 100; 
                        break;
                    case "ThanhTien":
                        col.HeaderText = "Thành Tiền";
                        col.Width = 100; 
                        break;
                }
            }
        }

        private void ClearDataGridViewRows()
        {
            guna2DataGridViewChiTietDonNhap.DataSource = null;
        }

        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            string maNhap = guna2DataGridViewDonNhap.SelectedRows[0].Cells["MaNhap"].Value.ToString();

            List<SqlParameter> parameters = new List<SqlParameter> { new SqlParameter("@MaNhap", maNhap) };

            frmInChiTietNhapSach reportForm = new frmInChiTietNhapSach(parameters);

            reportForm.Show(); 
        }


        private void OpenChildForm(Form childForm)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == childForm.GetType())
                {
                    frm.Activate();
                    return;
                }
            }

            childForm.Dock = DockStyle.Fill;
            childForm.Show();
        }
    }
}
