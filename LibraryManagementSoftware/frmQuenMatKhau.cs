using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LibraryManagementSoftware
{
    public partial class frmQuenMatKhau : Form
    {
        private DBConnection dbConnection;

        public frmQuenMatKhau()
        {
            InitializeComponent();
            dbConnection = new DBConnection("Server=DESKTOP-7TLHHMR; Database=QL_ThuVien; Trusted_Connection=True;");

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
            this.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            ValidateFields(); // Gọi lại khi văn bản thay đổi
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            ValidateFields(); // Gọi lại khi văn bản thay đổi
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string phone = txtSDT.Text;

            if (CheckLogin(email, phone))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close(); // Ẩn form hiện tại
                //new MainForm().Show(); // Hiện form chính (thay đổi theo tên form của bạn)
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckLogin(string email, string phone)
        {
            string query = "SELECT COUNT(*) FROM TAIKHOAN tk JOIN DOCGIA dg ON tk.MaDocGia = dg.MaDocGia WHERE tk.Email = @Email AND dg.SDT = @Phone";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Email", email),
        new SqlParameter("@Phone", phone)
            };

            int count = (int)dbConnection.ExecuteScalar(query, parameters);
            return count > 0;
        }

    }
}
