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
    public partial class frmDangKi : Form
    {
        public frmDangKi()
        {
            InitializeComponent();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
        private void txtNhapLai_Enter(object sender, EventArgs e)
        {
            if (txtNhapLai.Text != "Nhập lại password") return;
            txtNhapLai.PasswordChar = '*';
            txtNhapLai.ForeColor = Color.Black;
            txtNhapLai.Text = "";
        }

        private void txtNhapLai_Leave(object sender, EventArgs e)
        {
            if (txtNhapLai.Text != "") return;
            txtNhapLai.PasswordChar = '\0';
            txtNhapLai.ForeColor = Color.LightGray;
            txtNhapLai.Text = "Nhập lại password";
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.Show();
            this.Close();
        }

        private void frmDangKi_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK) return;
            e.Cancel = true;
        }
    }
}
