namespace LibraryManagementSoftware
{
    partial class frmDangKi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Exit = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDangNhap = new System.Windows.Forms.Label();
            this.btnDangKi = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNhapLai = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.AutoSize = true;
            this.Exit.BackColor = System.Drawing.Color.Red;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Exit.Location = new System.Drawing.Point(310, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(26, 25);
            this.Exit.TabIndex = 17;
            this.Exit.Text = "X";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "ĐĂNG KÍ";
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.AutoSize = true;
            this.btnDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDangNhap.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnDangNhap.Location = new System.Drawing.Point(124, 214);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(125, 16);
            this.btnDangNhap.TabIndex = 15;
            this.btnDangNhap.Text = "Bạn đã có tài khoản";
            this.btnDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnDangKi
            // 
            this.btnDangKi.BackColor = System.Drawing.Color.Beige;
            this.btnDangKi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDangKi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.btnDangKi.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDangKi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDangKi.Location = new System.Drawing.Point(35, 173);
            this.btnDangKi.Name = "btnDangKi";
            this.btnDangKi.Size = new System.Drawing.Size(302, 38);
            this.btnDangKi.TabIndex = 3;
            this.btnDangKi.Text = "Đăng kí";
            this.btnDangKi.UseVisualStyleBackColor = false;
            this.btnDangKi.Click += new System.EventHandler(this.btnDangKi_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtPassword.Location = new System.Drawing.Point(35, 82);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(302, 30);
            this.txtPassword.TabIndex = 12;
            this.txtPassword.Tag = "Password";
            this.txtPassword.Text = "Password";
            this.txtPassword.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // txtEmail
            // 
            this.txtEmail.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtEmail.Location = new System.Drawing.Point(35, 47);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(302, 30);
            this.txtEmail.TabIndex = 11;
            this.txtEmail.Tag = "Email";
            this.txtEmail.Text = "Email";
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(163, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 10;
            // 
            // txtNhapLai
            // 
            this.txtNhapLai.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtNhapLai.Location = new System.Drawing.Point(35, 118);
            this.txtNhapLai.Name = "txtNhapLai";
            this.txtNhapLai.Size = new System.Drawing.Size(302, 30);
            this.txtNhapLai.TabIndex = 18;
            this.txtNhapLai.Tag = "Nhập lại password";
            this.txtNhapLai.Text = "Nhập lại password";
            this.txtNhapLai.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtNhapLai.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel2.Controls.Add(this.txtSDT);
            this.panel2.Controls.Add(this.txtHoTen);
            this.panel2.Controls.Add(this.dateTime);
            this.panel2.Controls.Add(this.Exit);
            this.panel2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Location = new System.Drawing.Point(391, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(339, 243);
            this.panel2.TabIndex = 7;
            // 
            // txtSDT
            // 
            this.txtSDT.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtSDT.Location = new System.Drawing.Point(23, 84);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(302, 30);
            this.txtSDT.TabIndex = 20;
            this.txtSDT.Tag = "Số điện thoại";
            this.txtSDT.Text = "Số điện thoại";
            this.txtSDT.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtSDT.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // txtHoTen
            // 
            this.txtHoTen.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtHoTen.Location = new System.Drawing.Point(23, 48);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(302, 30);
            this.txtHoTen.TabIndex = 19;
            this.txtHoTen.Tag = "Họ Tên";
            this.txtHoTen.Text = "Họ Tên";
            this.txtHoTen.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtHoTen.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // dateTime
            // 
            this.dateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTime.Location = new System.Drawing.Point(23, 120);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(302, 30);
            this.dateTime.TabIndex = 19;
            // 
            // frmDangKi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 239);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtNhapLai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnDangKi);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "frmDangKi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDangKi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDangKi_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Exit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label btnDangNhap;
        private System.Windows.Forms.Button btnDangKi;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNhapLai;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtHoTen;
    }
}