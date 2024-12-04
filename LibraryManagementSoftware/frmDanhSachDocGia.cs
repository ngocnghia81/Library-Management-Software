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
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LibraryManagementSoftware
{
    public partial class frmDanhSachDocGia : Form
    {
        private DBConnection db = new DBConnection();

        public frmDanhSachDocGia()
        {
            InitializeComponent();
        }

        private void frmDanhSachDocGia_Load(object sender, EventArgs e)
        {
            LoadDanhSachDocGia();
        }

        private void LoadDanhSachDocGia()
        {
            string query = "SELECT DOCGIA.[MaDocGia],[TenDocGia],[NgaySinh],[SDT],[DiaChi],[NgayDangKy],[CCCD], Email, TAIKHOAN.DaXoa FROM [QL_ThuVien2].[dbo].[DOCGIA] JOIN TAIKHOAN ON DOCGIA.MaDocGia = TAIKHOAN.MaDocGia";

            DataTable dt = db.ExecuteSelect(query);

            dgvDocGia.DataSource = dt;

            dgvDocGia.DefaultCellStyle.BackColor = Color.AliceBlue; 
            dgvDocGia.DefaultCellStyle.ForeColor = Color.Black; //
            dgvDocGia.DefaultCellStyle.Font = new Font("Arial", 10); 

            dgvDocGia.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgvDocGia.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvDocGia.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);

            dgvDocGia.ColumnHeadersHeight = 40; 

            dgvDocGia.Columns["MaDocGia"].HeaderText = "Mã Độc Giả";
            dgvDocGia.Columns["TenDocGia"].HeaderText = "Tên Độc Giả";
            dgvDocGia.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dgvDocGia.Columns["SDT"].HeaderText = "Số Điện Thoại";
            dgvDocGia.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvDocGia.Columns["NgayDangKy"].HeaderText = "Ngày Đăng Ký";
            dgvDocGia.Columns["CCCD"].HeaderText = "CCCD";
            dgvDocGia.Columns["Email"].HeaderText = "Email";

            dgvDocGia.Columns["DaXoa"].Visible = false;

            dgvDocGia.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            dgvDocGia.ReadOnly = true;

            dgvDocGia.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy"; 
            dgvDocGia.Columns["NgayDangKy"].DefaultCellStyle.Format = "dd/MM/yyyy";  

            dgvDocGia.Columns["MaDocGia"].Width = 100;
            dgvDocGia.Columns["TenDocGia"].Width = 150;
            dgvDocGia.Columns["SDT"].Width = 120;
            dgvDocGia.Columns["DiaChi"].Width = 200;
            dgvDocGia.Columns["CCCD"].Width = 130;
            dgvDocGia.Columns["Email"].Width = 150;

            dgvDocGia.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders; // Điều chỉnh chiều cao dòng
            dgvDocGia.AllowUserToAddRows = false;  
        }


        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvDocGia_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDocGia.SelectedRows.Count > 0)
            {
                string maDocGia = dgvDocGia.SelectedRows[0].Cells["MaDocGia"].Value.ToString();

                string query = @"
                        
                    SELECT 
                        d.TenDocGia, 
                        d.SDT, 
	                    tk.Email,
                        tk.DaXoa,
                        ISNULL(
                            (SELECT COUNT(*) 
                             FROM PHIEUMUON 
                             WHERE MaDocGia = d.MaDocGia), 
                            0
                        ) AS TongSoLanMuon, 
                        ISNULL(
                                (SELECT COUNT(*) 
                                 FROM PHIEUMUON pm JOIN ChiTietPhieuMuon ctpm ON ctpm.MaPhieuMuon = pm.MaPhieuMuon
                                 WHERE MaDocGia = d.MaDocGia), 
                                0
                            ) AS TongSach, 
    
    
                         ISNULL(
                            (SELECT COUNT(*) 
                             FROM CHITIETPHIEUMUON ctpm JOIN PHIEUMUON pm ON pm.MaPhieuMuon = ctpm.MaPhieuMuon
                             LEFT JOIN PHIEUTRA pt ON ctpm.MaCTPM = pt.MaCTPM
                             WHERE pm.MaDocGia = d.MaDocGia AND pt.MaCTPM IS NULL),
                            0
                        ) AS SoSachChuaTra,  
    
                        -- Tính số sách quá hạn chưa trả
                            ISNULL(
                            (SELECT COUNT(*) 
                             FROM PHIEUMUON pm
                             LEFT JOIN CHITIETPHIEUMUON ctp ON pm.MaPhieuMuon = ctp.MaPhieuMuon
                             LEFT JOIN PHIEUTRA pt ON ctp.MaCTPM = pt.MaCTPM
                             WHERE pm.MaDocGia = d.MaDocGia AND pt.MaCTPM IS NULL AND pm.NgayDaoHan < GETDATE()),
                            0
                        ) AS SoSachQuaHan 
    
                    FROM 
                        DOCGIA d JOIN TAIKHOAN tk on d.MaDocGia = tk.MaDocGia
                    WHERE 
                        d.MaDocGia = @MaDocGia;

                    ";

                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@MaDocGia", maDocGia) };

                DataTable dt = db.ExecuteSelect(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtTenKhach.Text = row["TenDocGia"].ToString();  
                    txtSDT.Text = row["SDT"].ToString();  
                    txtEmail.Text = row["Email"].ToString(); 
                    txtTongSoSach.Text = row["TongSach"].ToString(); 
                    txtSoLanMuon.Text = row["TongSoLanMuon"].ToString();       
                    txtSoSachQuaHan.Text = row["SoSachQuaHan"].ToString(); 
                    txtTongSoLanChuaTra.Text = row["SoSachChuaTra"].ToString();
                    bool daXoa = Convert.ToBoolean(row["DaXoa"]);

                    if (daXoa)
                    {
                        txtTrangThai.Text = "Khoá";
                        btnKhoa.Enabled = false;
                        btnKhoa.Visible = false;

                        btnMo.Enabled = true;
                        btnMo.Visible = true;
                    }
                    else
                    {
                        txtTrangThai.Text = "Khả dụng";
                        btnKhoa.Enabled = true;
                        btnKhoa.Visible = true;

                        btnMo.Enabled = false;
                        btnMo.Visible = false;
                    }
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchKeyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT * FROM DocGia WHERE TenDocGia LIKE @Search OR MaDocGia LIKE @Search OR SDT LIKE @Search OR CCCD LIKE @Search";

            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Search", "%" + searchKeyword + "%")  // Tìm kiếm theo kiểu "contains"
                };

            try
            {
                DataTable dt = db.ExecuteSelect(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvDocGia.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy độc giả phù hợp với từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDocGia.DataSource = null; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            if (dgvDocGia.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedAccountId = dgvDocGia.SelectedRows[0].Cells["MaDocGia"].Value.ToString();

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                string query = "UPDATE TAIKHOAN SET DaXoa = 1 WHERE MaDocGia = @MaDocGia";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaDocGia", selectedAccountId)
                };

                try
                {
                    // Thực thi câu lệnh cập nhật
                    bool rowsAffected = db.ExecuteUpdate(query, parameters);

                    if (rowsAffected)
                    {
                        MessageBox.Show("Tài khoản đã được đánh dấu xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachDocGia();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dgvDocGia.SelectedRows.Count > 0)
            {
                string maDocGia = dgvDocGia.SelectedRows[0].Cells["MaDocGia"].Value.ToString();
                string email = dgvDocGia.SelectedRows[0].Cells["Email"].Value.ToString();

                NotifyOverdueBooks(maDocGia, email);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn độc giả để gửi nhắc nhở.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void NotifyOverdueBooks(string maDocGia, string email)
        {
            string query = @"
                SELECT 
                    s.TenSach, 
                    pm.NgayDaoHan, 
                    DATEDIFF(DAY, pm.NgayDaoHan, GETDATE()) AS SoNgayQuaHan,
                    tk.Email, 
                    d.TenDocGia
                FROM 
                    CHITIETPHIEUMUON ctpm
                JOIN 
                    PHIEUMUON pm ON ctpm.MaPhieuMuon = pm.MaPhieuMuon
                JOIN 
                    SACH s ON ctpm.MaSach = s.MaSach
                JOIN 
                    DOCGIA d ON pm.MaDocGia = d.MaDocGia
                JOIN 
                    TAIKHOAN tk ON tk.MaDocGia = d.MaDocGia
                WHERE 
                    pm.MaDocGia = @MaDocGia AND 
                    ctpm.MaCTPM NOT IN (SELECT MaCTPM FROM PHIEUTRA) AND  -- Chưa trả
                    pm.NgayDaoHan < GETDATE();  -- Chỉ lấy sách quá hạn
            ";

            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@MaDocGia", maDocGia) };
            DataTable overdueBooks = db.ExecuteSelect(query, parameters);

            if (overdueBooks != null && overdueBooks.Rows.Count > 0)
            {
                string userName = overdueBooks.Rows[0]["TenDocGia"].ToString(); // Giả sử chỉ có 1 độc giả trong kết quả
                string userEmail = overdueBooks.Rows[0]["Email"].ToString();

                string emailBody = getMailBody(userName, overdueBooks);

                EmailSender emailSender = new EmailSender("smtp.yourserver.com", 587, true, "youremail@example.com", "yourpassword");
                bool emailSent = emailSender.SendEmail(userEmail, "Nhắc nhở trả sách quá hạn", emailBody, true);

                if (emailSent)
                {
                    MessageBox.Show("Email nhắc nhở đã được gửi thành công.");
                }
                else
                {
                    MessageBox.Show("Gửi email thất bại.");
                }
            }
            else
            {
                MessageBox.Show("Không có sách quá hạn cho độc giả này.");
            }

        }


        private string getMailBody(string userName, DataTable overdueBooks)
        {
            // Tạo nội dung HTML cho email
            StringBuilder emailBody = new StringBuilder();
            emailBody.AppendLine(@"
    <html>
    <head>
        <style>
            body {{
                font-family: Arial, sans-serif;
                background-color: #f4f4f4;
                margin: 0;
                padding: 0;
            }}
            .container {{
                max-width: 600px;
                margin: 20px auto;
                background-color: #ffffff;
                padding: 20px;
                border-radius: 8px;
                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            }}
            .header {{
                text-align: center;
                background-color: #4CAF50;
                padding: 10px;
                color: white;
                font-size: 24px;
                border-top-left-radius: 8px;
                border-top-right-radius: 8px;
            }}
            .content {{
                padding: 20px;
                text-align: left;
                line-height: 1.6;
            }}
            .content p {{
                margin: 0;
                padding-bottom: 10px;
            }}
            .content .highlight {{
                color: #4CAF50;
                font-weight: bold;
            }}
            .footer {{
                text-align: center;
                padding: 10px;
                font-size: 12px;
                color: #666666;
            }}
            .button {{
                display: inline-block;
                padding: 10px 20px;
                font-size: 16px;
                color: white;
                background-color: #4CAF50;
                text-decoration: none;
                border-radius: 5px;
            }}
            .button:hover {{
                background-color: #45a049;
            }}
        </style>
    </head>
    <body>
        <div class='container'>
            <div class='header'>
                Hệ thống Quản lý Thư viện
            </div>
            <div class='content'>
                <p>Xin chào <strong>{0}</strong>,</p>
                <p>Chúng tôi muốn thông báo rằng bạn có một số sách đã quá hạn chưa được trả. Dưới đây là danh sách sách quá hạn:</p>
                <ul>");

            // Thêm danh sách sách quá hạn vào email body
            foreach (DataRow row in overdueBooks.Rows)
            {
                string bookTitle = row["TenSach"].ToString();
                int overdueDays = Convert.ToInt32(row["SoNgayQuaHan"]);
                emailBody.AppendLine(string.Format("<li>{0} - Quá hạn {1} ngày</li>",bookTitle,overdueDays));
            }

            emailBody.AppendLine(@"</ul>
                <p>Vui lòng trả sách càng sớm càng tốt để tránh bị phạt.</p>
                <p>Nếu bạn không thể trả sách trong thời gian tới, xin vui lòng liên hệ với chúng tôi để biết thêm thông tin.</p>
                <p>Trân trọng,</p>
                <p>Đội ngũ hỗ trợ</p>
            </div>
            <div class='footer'>
                &copy; 2024 Hệ thống Quản lý Thư viện. Mọi quyền được bảo lưu.
            </div>
        </div>
    </body>
    </html>");

            // Trả về nội dung email đã được định dạng
            return emailBody.ToString();
        }

        private void btnMo_Click(object sender, EventArgs e)
        {
            if (dgvDocGia.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản để mở!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedAccountId = dgvDocGia.SelectedRows[0].Cells["MaDocGia"].Value.ToString();

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn mở tài khoản này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                string query = "UPDATE TAIKHOAN SET DaXoa = 0 WHERE MaDocGia = @MaDocGia";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaDocGia", selectedAccountId)
                };

                try
                {
                    // Thực thi câu lệnh cập nhật
                    bool rowsAffected = db.ExecuteUpdate(query, parameters);

                    if (rowsAffected)
                    {
                        MessageBox.Show("Tài khoản đã được mở.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachDocGia();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản để mở.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
