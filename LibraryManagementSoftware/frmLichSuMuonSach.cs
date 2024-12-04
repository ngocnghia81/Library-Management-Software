using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryManagementSoftware
{
    public partial class frmLichSuMuonSach : Form
    {
        DBConnection db = new DBConnection();

        public frmLichSuMuonSach()
        {
            InitializeComponent();
        }

        private void frmLichSuMuonSach_Load(object sender, EventArgs e)
        {
            cbbTrangThai.Items.AddRange(new string[] { "Đã trả", "Chưa trả" });
            cbbTrangThai.SelectedIndex = -1;
            guna2DateTimePicker1.Value = DateTime.Today;
            guna2DateTimePicker2.Value = DateTime.Today;

            LoadAllData();
        }

        private void LoadAllData()
        {
            string searchQuery = @"
                SELECT 
                    PM.MaPhieuMuon, 
                    DG.TenDocGia, 
                    S.TenSach, 
                    PM.NgayMuon, 
                    PM.NgayDaoHan, 
                    PT.NgayTra,
                    CASE 
                        WHEN PT.NgayTra IS NOT NULL THEN N'Đã trả'
                        ELSE N'Chưa trả'
                    END AS TrangThai
                FROM 
                    PHIEUMUON PM
                JOIN 
                    DOCGIA DG ON PM.MaDocGia = DG.MaDocGia
                JOIN 
                    CHITIETPHIEUMUON CTPM ON PM.MaPhieuMuon = CTPM.MaPhieuMuon
                JOIN 
                    SACH S ON CTPM.MaSach = S.MaSach
                LEFT JOIN 
                    PhieuTra PT ON PT.MaCTPM = CTPM.MaCTPM
                ORDER BY 
                    PM.NgayMuon DESC;
            ";

            guna2DataGridView1.RowTemplate.Height = 40;

            DataTable result = db.ExecuteSelect(searchQuery, null);

            guna2DataGridView1.DataSource = result;

            // Cập nhật header của DataGridView
            guna2DataGridView1.Columns["MaPhieuMuon"].HeaderText = "Mã Phiếu Mượn";
            guna2DataGridView1.Columns["TenDocGia"].HeaderText = "Tên Độc Giả";
            guna2DataGridView1.Columns["TenSach"].HeaderText = "Tên Sách";
            guna2DataGridView1.Columns["NgayMuon"].HeaderText = "Ngày Mượn";
            guna2DataGridView1.Columns["NgayDaoHan"].HeaderText = "Ngày đáo hạn";
            guna2DataGridView1.Columns["NgayTra"].HeaderText = "Ngày Trả";
            guna2DataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";


            guna2DataGridView1.ColumnHeadersHeight = 40;
            guna2DataGridView1.ClearSelection();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            // Chuẩn bị danh sách tham số
            List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@StartDate", guna2DateTimePicker1.Checked ? (object)guna2DateTimePicker1.Value.Date : DBNull.Value),
                    new SqlParameter("@EndDate", guna2DateTimePicker2.Checked ? (object)guna2DateTimePicker2.Value.Date : DBNull.Value)
                };
            OpenChildForm(new frmBaoCaoLichSuMuonSach(parameters));
            
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


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string searchQuery = @"
                SELECT PM.MaPhieuMuon, DG.TenDocGia, S.TenSach, PM.NgayMuon, PM.NgayDaoHan, PT.NgayTra,
                    CASE 
                        WHEN PT.NgayTra IS NOT NULL THEN N'Đã trả'
                        ELSE N'Chưa trả'
                    END AS TrangThai
                FROM PHIEUMUON PM
                JOIN DOCGIA DG ON PM.MaDocGia = DG.MaDocGia
                JOIN CHITIETPHIEUMUON CTPM ON PM.MaPhieuMuon = CTPM.MaPhieuMuon
                JOIN SACH S ON CTPM.MaSach = S.MaSach
                LEFT JOIN PhieuTra PT ON PT.MaCTPM = CTPM.MaCTPM
                WHERE PM.NgayMuon BETWEEN @StartDate AND @EndDate
                AND S.TenSach LIKE @search";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@StartDate", guna2DateTimePicker1.Value.Date),    // Lọc theo ngày bắt đầu
                new SqlParameter("@EndDate", guna2DateTimePicker2.Value.Date),      // Lọc theo ngày kết thúc
                new SqlParameter("@search", "%" + guna2TextBoxSearch.Text + "%")   // Tìm kiếm theo tên sách
            };

            if (cbbTrangThai.SelectedIndex != -1)
            {
                string status = cbbTrangThai.SelectedItem.ToString();
                if (status == "Đã trả")
                {
                    searchQuery += @"
                        AND PT.NgayTra IS NOT NULL";
                }
                else if (status == "Chưa trả")
                {
                    searchQuery += @"
                        AND PT.NgayTra IS NULL";
                }
            }

            searchQuery += " ORDER BY PM.NgayMuon DESC";

            DataTable result = db.ExecuteSelect(searchQuery, parameters.ToArray());

            guna2DataGridView1.DataSource = result;
        }

        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                string maPM = guna2DataGridView1.SelectedRows[0].Cells["MaPhieuMuon"].Value.ToString();
                LoadInfo(maPM);
            }
        }

        private void LoadInfo(string maPM)
        {
            string query = @"
                SELECT dg.TenDocGia, tk.Email, dg.SDT, dg.CCCD, pm.NgayMuon, pm.NgayDaoHan, 
                    (SELECT COUNT(*) FROM CHITIETPHIEUMUON WHERE MaPhieuMuon = pm.MaPhieuMuon) as TongSach
                FROM PHIEUMUON pm
                JOIN DOCGIA dg ON dg.MaDocGia = pm.MaDocGia
                JOIN TAIKHOAN tk ON tk.MaDocGia = dg.MaDocGia
                WHERE pm.MaPhieuMuon = @MaPM";

            SqlParameter[] parameters = {
                new SqlParameter("@MaPM", maPM)
            };

            try
            {
                DataTable dt = db.ExecuteSelect(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    guna2HtmlLabelTen.Text = "Tên độc giả: " + row["TenDocGia"].ToString();
                    guna2HtmlLabelEmail.Text = "Email: " + row["Email"].ToString();
                    guna2HtmlLabelSDT.Text = "SĐT: " + row["SDT"].ToString();
                    guna2HtmlLabelCCCD.Text = "CCCD: " + row["CCCD"].ToString();
                    guna2HtmlLabelNM.Text = "Ngày mượn: " + Convert.ToDateTime(row["NgayMuon"]).ToString("dd/MM/yyyy");
                    guna2HtmlLabelNDH.Text = "Ngày đáo hạn: " + Convert.ToDateTime(row["NgayDaoHan"]).ToString("dd/MM/yyyy");
                    guna2HtmlLabelSSM.Text = "Tổng số sách: " + row["TongSach"].ToString();

                    string q2 = @"
                        SELECT TenSach, s.MaSach
                        FROM SACH s 
                        JOIN CHITIETPHIEUMUON ctpm ON s.MaSach = ctpm.MaSach
                        WHERE ctpm.MaPhieuMuon = @MaPM";

                    SqlParameter[] bookParams = { new SqlParameter("@MaPM", maPM) };

                    DataTable bookDt = db.ExecuteSelect(q2, bookParams);

                    if (bookDt != null)
                    {
                        guna2DataGridView2.RowTemplate.Height = 40;
                        guna2DataGridView2.ColumnHeadersHeight = 40;

                        guna2DataGridView2.DataSource = bookDt;

                        guna2DataGridView2.Columns["TenSach"].HeaderText = "Tên Sách";
                        guna2DataGridView2.Columns["MaSach"].HeaderText = "Mã Sách";
                    }

                    guna2DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
                else
                {
                    ClearLabels();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ClearLabels()
        {
            guna2HtmlLabelTen.Text = "Tên độc giả: ";
            guna2HtmlLabelEmail.Text = "Email: ";
            guna2HtmlLabelSDT.Text = "SĐT: ";
            guna2HtmlLabelCCCD.Text = "CCCD: ";
            guna2HtmlLabelNM.Text = "Ngày mượn: ";
            guna2HtmlLabelNDH.Text = "Ngày đáo hạn: ";
            guna2HtmlLabelSSM.Text = "Tổng số sách: ";
            guna2DataGridView2.DataSource = null;
            guna2DataGridView2.Rows.Clear(); 
            guna2DataGridView2.Columns.Clear(); 
        }
    }
}
