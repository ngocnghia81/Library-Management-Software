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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbMoTa = new System.Windows.Forms.Label();
            this.lbNXB = new System.Windows.Forms.Label();
            this.lbTheLoai = new System.Windows.Forms.Label();
            this.lbTacGia = new System.Windows.Forms.Label();
            this.lbTen = new System.Windows.Forms.Label();
            this.pictureChiTiet = new System.Windows.Forms.PictureBox();
            this.flowLayOutSach.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayOutSach
            // 
            this.flowLayOutSach.AutoScroll = true;
            this.flowLayOutSach.BackColor = System.Drawing.Color.IndianRed;
            this.flowLayOutSach.Controls.Add(this.panel1);
            this.flowLayOutSach.Location = new System.Drawing.Point(8, 46);
            this.flowLayOutSach.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayOutSach.Name = "flowLayOutSach";
            this.flowLayOutSach.Size = new System.Drawing.Size(783, 739);
            this.flowLayOutSach.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 716);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayOutSach);
            this.groupBox1.Location = new System.Drawing.Point(4, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(806, 796);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Toàn bộ sách";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.lbMoTa);
            this.groupBox2.Controls.Add(this.lbNXB);
            this.groupBox2.Controls.Add(this.lbTheLoai);
            this.groupBox2.Controls.Add(this.lbTacGia);
            this.groupBox2.Controls.Add(this.lbTen);
            this.groupBox2.Controls.Add(this.pictureChiTiet);
            this.groupBox2.Location = new System.Drawing.Point(828, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(706, 796);
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
            this.lbMoTa.Size = new System.Drawing.Size(61, 24);
            this.lbMoTa.TabIndex = 5;
            this.lbMoTa.Text = "Mô tả:";
            // 
            // lbNXB
            // 
            this.lbNXB.AutoSize = true;
            this.lbNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbNXB.Location = new System.Drawing.Point(30, 591);
            this.lbNXB.Name = "lbNXB";
            this.lbNXB.Size = new System.Drawing.Size(127, 24);
            this.lbNXB.TabIndex = 4;
            this.lbNXB.Text = "Nhà xuất bản:";
            // 
            // lbTheLoai
            // 
            this.lbTheLoai.AutoSize = true;
            this.lbTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTheLoai.Location = new System.Drawing.Point(30, 496);
            this.lbTheLoai.Name = "lbTheLoai";
            this.lbTheLoai.Size = new System.Drawing.Size(83, 24);
            this.lbTheLoai.TabIndex = 3;
            this.lbTheLoai.Text = "Thể loại:";
            // 
            // lbTacGia
            // 
            this.lbTacGia.AutoSize = true;
            this.lbTacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTacGia.Location = new System.Drawing.Point(30, 545);
            this.lbTacGia.Name = "lbTacGia";
            this.lbTacGia.Size = new System.Drawing.Size(77, 24);
            this.lbTacGia.TabIndex = 2;
            this.lbTacGia.Text = "Tác giả:";
            // 
            // lbTen
            // 
            this.lbTen.AutoSize = true;
            this.lbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTen.Location = new System.Drawing.Point(30, 444);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(94, 24);
            this.lbTen.TabIndex = 1;
            this.lbTen.Text = "Tên sách:";
            // 
            // pictureChiTiet
            // 
            this.pictureChiTiet.Location = new System.Drawing.Point(177, 46);
            this.pictureChiTiet.Name = "pictureChiTiet";
            this.pictureChiTiet.Size = new System.Drawing.Size(389, 382);
            this.pictureChiTiet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureChiTiet.TabIndex = 0;
            this.pictureChiTiet.TabStop = false;
            // 
            // frmXemSach
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmXemSach";
            this.Text = "frmXemSach";
            this.Load += new System.EventHandler(this.frmXemSach_Load);
            this.flowLayOutSach.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayOutSach;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureChiTiet;
        private System.Windows.Forms.Label lbTen;
        private System.Windows.Forms.Label lbTacGia;
        private System.Windows.Forms.Label lbTheLoai;
        private System.Windows.Forms.Label lbNXB;
        private System.Windows.Forms.Label lbMoTa;
    }
}