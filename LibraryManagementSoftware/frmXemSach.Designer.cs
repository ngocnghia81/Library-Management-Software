namespace LibraryManagementSoftware
{
    partial class frmXemSach
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
            this.flowLayOutSach = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbTG = new System.Windows.Forms.ComboBox();
            this.cbbTheLoai = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbMoTa = new System.Windows.Forms.Label();
            this.lbNXB = new System.Windows.Forms.Label();
            this.lbTheLoai = new System.Windows.Forms.Label();
            this.lbTacGia = new System.Windows.Forms.Label();
            this.lbTen = new System.Windows.Forms.Label();
            this.pictureChiTiet = new System.Windows.Forms.PictureBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayOutSach
            // 
            this.flowLayOutSach.AutoScroll = true;
            this.flowLayOutSach.BackColor = System.Drawing.Color.IndianRed;
            this.flowLayOutSach.Location = new System.Drawing.Point(3, 179);
            this.flowLayOutSach.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayOutSach.Name = "flowLayOutSach";
            this.flowLayOutSach.Size = new System.Drawing.Size(774, 567);
            this.flowLayOutSach.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTimKiem);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbbTG);
            this.groupBox1.Controls.Add(this.cbbTheLoai);
            this.groupBox1.Controls.Add(this.flowLayOutSach);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(12, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(773, 708);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hiện sách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(312, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tác giả";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(19, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Thể loại";
            // 
            // cbbTG
            // 
            this.cbbTG.FormattingEnabled = true;
            this.cbbTG.Location = new System.Drawing.Point(411, 108);
            this.cbbTG.Name = "cbbTG";
            this.cbbTG.Size = new System.Drawing.Size(188, 37);
            this.cbbTG.TabIndex = 7;
            this.cbbTG.SelectedIndexChanged += new System.EventHandler(this.cbbTheLoai_SelectedIndexChanged);
            // 
            // cbbTheLoai
            // 
            this.cbbTheLoai.FormattingEnabled = true;
            this.cbbTheLoai.Location = new System.Drawing.Point(126, 108);
            this.cbbTheLoai.Name = "cbbTheLoai";
            this.cbbTheLoai.Size = new System.Drawing.Size(168, 37);
            this.cbbTheLoai.TabIndex = 6;
            this.cbbTheLoai.SelectedIndexChanged += new System.EventHandler(this.cbbTheLoai_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.lbMoTa);
            this.groupBox2.Controls.Add(this.lbNXB);
            this.groupBox2.Controls.Add(this.lbTheLoai);
            this.groupBox2.Controls.Add(this.lbTacGia);
            this.groupBox2.Controls.Add(this.lbTen);
            this.groupBox2.Controls.Add(this.pictureChiTiet);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F);
            this.groupBox2.Location = new System.Drawing.Point(791, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(577, 708);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết sách";
            // 
            // lbMoTa
            // 
            this.lbMoTa.AutoSize = true;
            this.lbMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbMoTa.Location = new System.Drawing.Point(30, 637);
            this.lbMoTa.Name = "lbMoTa";
            this.lbMoTa.Size = new System.Drawing.Size(78, 29);
            this.lbMoTa.TabIndex = 5;
            this.lbMoTa.Text = "Mô tả:";
            // 
            // lbNXB
            // 
            this.lbNXB.AutoSize = true;
            this.lbNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbNXB.Location = new System.Drawing.Point(30, 591);
            this.lbNXB.Name = "lbNXB";
            this.lbNXB.Size = new System.Drawing.Size(158, 29);
            this.lbNXB.TabIndex = 4;
            this.lbNXB.Text = "Nhà xuất bản:";
            // 
            // lbTheLoai
            // 
            this.lbTheLoai.AutoSize = true;
            this.lbTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTheLoai.Location = new System.Drawing.Point(30, 496);
            this.lbTheLoai.Name = "lbTheLoai";
            this.lbTheLoai.Size = new System.Drawing.Size(107, 29);
            this.lbTheLoai.TabIndex = 3;
            this.lbTheLoai.Text = "Thể loại:";
            // 
            // lbTacGia
            // 
            this.lbTacGia.AutoSize = true;
            this.lbTacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTacGia.Location = new System.Drawing.Point(30, 545);
            this.lbTacGia.Name = "lbTacGia";
            this.lbTacGia.Size = new System.Drawing.Size(99, 29);
            this.lbTacGia.TabIndex = 2;
            this.lbTacGia.Text = "Tác giả:";
            // 
            // lbTen
            // 
            this.lbTen.AutoSize = true;
            this.lbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTen.Location = new System.Drawing.Point(30, 444);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(118, 29);
            this.lbTen.TabIndex = 1;
            this.lbTen.Text = "Tên sách:";
            // 
            // pictureChiTiet
            // 
            this.pictureChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureChiTiet.Location = new System.Drawing.Point(35, 46);
            this.pictureChiTiet.Name = "pictureChiTiet";
            this.pictureChiTiet.Size = new System.Drawing.Size(389, 382);
            this.pictureChiTiet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureChiTiet.TabIndex = 0;
            this.pictureChiTiet.TabStop = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(126, 46);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(473, 34);
            this.txtTimKiem.TabIndex = 8;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(7, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tìm kiếm";
            // 
            // frmXemSach
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1368, 766);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmXemSach";
            this.Text = "frmXemSach";
            this.Load += new System.EventHandler(this.frmXemSach_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayOutSach;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureChiTiet;
        private System.Windows.Forms.Label lbTen;
        private System.Windows.Forms.Label lbTacGia;
        private System.Windows.Forms.Label lbTheLoai;
        private System.Windows.Forms.Label lbNXB;
        private System.Windows.Forms.Label lbMoTa;
        private System.Windows.Forms.ComboBox cbbTG;
        private System.Windows.Forms.ComboBox cbbTheLoai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTimKiem;
    }
}