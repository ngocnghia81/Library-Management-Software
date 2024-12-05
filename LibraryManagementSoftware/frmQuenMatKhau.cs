using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
//using System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LibraryManagementSoftware
{
    public partial class frmQuenMatKhau : Form
    {
        private DBConnection db = new DBConnection();

        public frmQuenMatKhau()
        {
            InitializeComponent();
           

            txtEmail.Enter += RemovePlaceholder;
            txtEmail.Leave += AddPlaceholder;

            txtSDT.Enter += RemovePlaceholderSDT;
            txtSDT.Leave += AddPlaceholderSDT;

            btnXacNhan.Enabled = false;

            // Thêm chữ mờ vào các trường ban đầu
            AddPlaceholder(this.txtEmail, null);
            AddPlaceholderSDT(this.txtSDT, null);
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void AddPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.Gray;
            }
        }

        private void RemovePlaceholderSDT(object sender, EventArgs e)
        {
            if (txtSDT.Text == "Số điện thoại")
            {
                txtSDT.Text = "";
                txtSDT.ForeColor = Color.Black;
            }
        }

        private void AddPlaceholderSDT(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                txtSDT.Text = "Số điện thoại";
                txtSDT.ForeColor = Color.Gray;
            }
        }


        private void ValidateFields()
        {
            bool isEmailValid = ValidationHelper.IsValidEmail(txtEmail.Text) && txtEmail.Text != "Email";
            bool isPhoneValid = ValidationHelper.IsValidPhoneNumber(txtSDT.Text) && txtSDT.Text != "Số điện thoại";

            btnXacNhan.Enabled = isEmailValid && isPhoneValid;
        }

        private void frmQuenMatKhau_Load(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Placeholder cho click
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Placeholder cho Paint
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            ValidateFields(); // Gọi lại khi văn bản thay đổi
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            ValidateFields(); // Gọi lại khi văn bản thay đổi
        }

        private string GenerateRandomPassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random random = new Random();
            return new string(Enumerable.Repeat(validChars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private bool UpdatePassword(string email, string newPassword)
        {
            string query = "UPDATE TAIKHOAN SET matkhau = @NewPassword WHERE Email = @Email";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NewPassword", newPassword),
                new SqlParameter("@Email", email)
            };

            return db.ExecuteUpdate(query, parameters);
        }



        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string phone = txtSDT.Text;

            if (CheckLogin(email, phone))
            {
                string newPassword = GenerateRandomPassword(8);

                if (UpdatePassword(email, newPassword))
                {
                    EmailSender emailSender = new EmailSender("smtp.gmail.com", 587, true, "dasnn2004@gmail.com", "ckfq pqmc xkll tgcw");

                    string name = LayTenDocGiaTheoSDT(txtSDT.Text);
                    bool emailSent = emailSender.SendEmail(email, "Reset mật khẩu", getMailBody(name,newPassword),true);

                    if (emailSent)
                    {
                        MessageBox.Show("Mật khẩu mới đã được gửi về email của bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Gửi email thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Cập nhật mật khẩu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Email hoặc số điện thoại không đúng. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string LayTenDocGiaTheoSDT(string sdt)
        {
            string query = "SELECT TenDocGia FROM DOCGIA WHERE SDT = @sdt";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@sdt", sdt)
            };
            string tenDocGia = null;

            tenDocGia = db.ExecuteScalar(query,parameters).ToString();

            return tenDocGia;
        }



        private bool CheckLogin(string email, string phone)
        {
            string query = "SELECT COUNT(*) FROM TAIKHOAN tk JOIN DOCGIA dg ON tk.MaDocGia = dg.MaDocGia WHERE tk.Email = @Email AND dg.SDT = @Phone";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Email", email),
                new SqlParameter("@Phone", phone)
            };

            int count = (int)db.ExecuteScalar(query, parameters);
            return count > 0;
        }

        private string getMailBody(string userName, string tempPassword)
        {
            return string.Format(@"
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
                        <p>Chúng tôi đã nhận được yêu cầu đặt lại mật khẩu của bạn. Mật khẩu tạm thời của bạn là:</p>
                        <p class='highlight'>{1}</p>
                        <p>Vì lý do bảo mật, vui lòng thay đổi mật khẩu ngay sau khi đăng nhập.</p>
                        <p>Nếu bạn không yêu cầu thay đổi này, xin vui lòng liên hệ với chúng tôi ngay lập tức.</p>
                        <p>Trân trọng,</p>
                        <p>Đội ngũ hỗ trợ</p>
                    </div>
                    <div class='footer'>
                        &copy; 2024 Hệ thống Quản lý Thư viện. Mọi quyền được bảo lưu.
                    </div>
                </div>
            </body>
            </html>",userName,tempPassword);
        }

    }
}
