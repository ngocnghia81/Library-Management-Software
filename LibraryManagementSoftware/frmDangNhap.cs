using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace LibraryManagementSoftware
{
    public partial class frmDangNhap : Form
    {
        DBConnection db = new DBConnection();

        bool KiemTraMatKhauTuGmail()
        {
            string query = string.Format("select HashedPassword from TaiKhoan Where Email = '{0}'",txtEmail.Text);

            string password = db.ExecuteScalar(query).ToString();

            if(password != txtPassword.Text) return false;

            return true;
        }
        bool KiemTraAdmin()
        {
            string query = string.Format("select VaiTro from TaiKhoan Where Email = '{0}'",txtEmail.Text);

            string vaitro = db.ExecuteScalar(query).ToString();

            if (vaitro != "admin") return false;

            return true;
        }

        void ChaoTaiKhoan()
        {
            string query = string.Format("select DG.TenDocGia from DocGia DG, TaiKhoan TK where DG.MaDocGia = TK.MaDocGia AND TK.Email = '{0}'",txtEmail.Text);
            string ten = db.ExecuteScalar(query).ToString();

            if (KiemTraAdmin())
                ten = "Admin " + ten;

            MessageBox.Show(string.Format("Chào {0}",ten));
        }

        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text != "Email") return;
            txtEmail.ForeColor = Color.Black;
            txtEmail.Text = "";
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            
            if (txtEmail.Text != "") return;
            txtEmail.ForeColor = Color.LightGray;
            txtEmail.Text = "Email";
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text != "Password") return;
            txtPassword.PasswordChar = '*';
            txtPassword.ForeColor = Color.Black;
            txtPassword.Text = "";
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text != "") return;
            txtPassword.PasswordChar = '\0';
            txtPassword.ForeColor = Color.LightGray;
            txtPassword.Text = "Password";
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            frmDangKi frmDangKi = new frmDangKi();
            frmDangKi.Show();
            this.Hide();
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Visible) return;
            DialogResult dialog = MessageBox.Show("Bạn có muốn thoát không?","Thoát",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (dialog == DialogResult.OK) return;
            e.Cancel = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            frmQuenMatKhau frmQuenMatKhau = new frmQuenMatKhau();
            frmQuenMatKhau.Show();
            this.Hide();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Sử dụng ValidationHelper để kiểm tra email
            if (!ValidationHelper.IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Định dạng email không hợp lệ", "Nhập liệu sai", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!KiemTraMatKhauTuGmail())
            {
                MessageBox.Show("Email hoặc mật khẩu đăng nhập không hợp lệ", "Nhập liệu sai", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ChaoTaiKhoan();

            if (KiemTraAdmin())
            {
                frmAdmin frmAdmin = new frmAdmin();
                frmAdmin.Show();
                this.Hide();
            }    

            
        }
    }
}
