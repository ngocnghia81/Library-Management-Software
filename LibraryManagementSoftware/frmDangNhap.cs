﻿using System;
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
    }
}
