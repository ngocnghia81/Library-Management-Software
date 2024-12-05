namespace LibraryManagementSoftware
{
    partial class frmDuLieu
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxBK = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxR = new System.Windows.Forms.TextBox();
            this.cbbMeThod = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnRes = new LibraryManagementSoftware.RoundedButton();
            this.btnpathRes = new LibraryManagementSoftware.RoundedButton();
            this.btnBak = new LibraryManagementSoftware.RoundedButton();
            this.btnpathBk = new LibraryManagementSoftware.RoundedButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxBK
            // 
            this.textBoxBK.Location = new System.Drawing.Point(22, 62);
            this.textBoxBK.Name = "textBoxBK";
            this.textBoxBK.Size = new System.Drawing.Size(756, 31);
            this.textBoxBK.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbMeThod);
            this.groupBox1.Controls.Add(this.textBoxBK);
            this.groupBox1.Controls.Add(this.btnBak);
            this.groupBox1.Controls.Add(this.btnpathBk);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1105, 229);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Backup";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.textBoxR);
            this.groupBox2.Controls.Add(this.btnRes);
            this.groupBox2.Controls.Add(this.btnpathRes);
            this.groupBox2.Location = new System.Drawing.Point(12, 294);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1105, 209);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Restore";
            // 
            // textBoxR
            // 
            this.textBoxR.Location = new System.Drawing.Point(22, 62);
            this.textBoxR.Name = "textBoxR";
            this.textBoxR.Size = new System.Drawing.Size(756, 31);
            this.textBoxR.TabIndex = 0;
            // 
            // cbbMeThod
            // 
            this.cbbMeThod.FormattingEnabled = true;
            this.cbbMeThod.Location = new System.Drawing.Point(22, 111);
            this.cbbMeThod.Name = "cbbMeThod";
            this.cbbMeThod.Size = new System.Drawing.Size(267, 33);
            this.cbbMeThod.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Lime;
            this.progressBar1.Location = new System.Drawing.Point(22, 110);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(756, 23);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // btnRes
            // 
            this.btnRes.BackColor = System.Drawing.Color.IndianRed;
            this.btnRes.FlatAppearance.BorderSize = 0;
            this.btnRes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRes.ForeColor = System.Drawing.Color.White;
            this.btnRes.Location = new System.Drawing.Point(843, 110);
            this.btnRes.Name = "btnRes";
            this.btnRes.Size = new System.Drawing.Size(158, 40);
            this.btnRes.TabIndex = 0;
            this.btnRes.Text = "Phục hồi";
            this.btnRes.UseVisualStyleBackColor = false;
            this.btnRes.Click += new System.EventHandler(this.btnRes_Click);
            // 
            // btnpathRes
            // 
            this.btnpathRes.BackColor = System.Drawing.Color.IndianRed;
            this.btnpathRes.FlatAppearance.BorderSize = 0;
            this.btnpathRes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpathRes.ForeColor = System.Drawing.Color.White;
            this.btnpathRes.Location = new System.Drawing.Point(843, 45);
            this.btnpathRes.Name = "btnpathRes";
            this.btnpathRes.Size = new System.Drawing.Size(158, 40);
            this.btnpathRes.TabIndex = 0;
            this.btnpathRes.Text = "Đường dẫn";
            this.btnpathRes.UseVisualStyleBackColor = false;
            this.btnpathRes.Click += new System.EventHandler(this.btnpathRes_Click);
            // 
            // btnBak
            // 
            this.btnBak.BackColor = System.Drawing.Color.IndianRed;
            this.btnBak.FlatAppearance.BorderSize = 0;
            this.btnBak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBak.ForeColor = System.Drawing.Color.White;
            this.btnBak.Location = new System.Drawing.Point(843, 127);
            this.btnBak.Name = "btnBak";
            this.btnBak.Size = new System.Drawing.Size(158, 40);
            this.btnBak.TabIndex = 0;
            this.btnBak.Text = "Sao lưu";
            this.btnBak.UseVisualStyleBackColor = false;
            this.btnBak.Click += new System.EventHandler(this.btnBak_Click);
            // 
            // btnpathBk
            // 
            this.btnpathBk.BackColor = System.Drawing.Color.IndianRed;
            this.btnpathBk.FlatAppearance.BorderSize = 0;
            this.btnpathBk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpathBk.ForeColor = System.Drawing.Color.White;
            this.btnpathBk.Location = new System.Drawing.Point(843, 62);
            this.btnpathBk.Name = "btnpathBk";
            this.btnpathBk.Size = new System.Drawing.Size(158, 40);
            this.btnpathBk.TabIndex = 0;
            this.btnpathBk.Text = "Đường dẫn";
            this.btnpathBk.UseVisualStyleBackColor = false;
            this.btnpathBk.Click += new System.EventHandler(this.btnpathBk_Click);
            // 
            // frmDuLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1129, 528);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmDuLieu";
            this.Text = "frmDuLieu";
            this.Load += new System.EventHandler(this.frmDuLieu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private RoundedButton btnpathBk;
        private RoundedButton btnBak;
        private System.Windows.Forms.TextBox textBoxBK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxR;
        private RoundedButton btnRes;
        private RoundedButton btnpathRes;
        private System.Windows.Forms.ComboBox cbbMeThod;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}