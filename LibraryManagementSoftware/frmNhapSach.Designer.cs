namespace LibraryManagementSoftware
{
    partial class frmNhapSach
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvNCC = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbThanhTien = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbNCC = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvChiTiet = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbSach = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbNCC = new System.Windows.Forms.ComboBox();
            this.btnLuuCT = new LibraryManagementSoftware.RoundedButton();
            this.btnDoi = new LibraryManagementSoftware.RoundedButton();
            this.btnSuaCT = new LibraryManagementSoftware.RoundedButton();
            this.btnXoaCT = new LibraryManagementSoftware.RoundedButton();
            this.btnAddCT = new LibraryManagementSoftware.RoundedButton();
            this.btnTaoMa = new LibraryManagementSoftware.RoundedButton();
            this.btnLuu = new LibraryManagementSoftware.RoundedButton();
            this.btnSua = new LibraryManagementSoftware.RoundedButton();
            this.btnXoa = new LibraryManagementSoftware.RoundedButton();
            this.btnThem = new LibraryManagementSoftware.RoundedButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNCC)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên NCC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã NCC";
            // 
            // dgvNCC
            // 
            this.dgvNCC.AllowUserToAddRows = false;
            this.dgvNCC.AllowUserToDeleteRows = false;
            this.dgvNCC.AllowUserToResizeColumns = false;
            this.dgvNCC.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvNCC.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNCC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNCC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNCC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNCC.ColumnHeadersHeight = 40;
            this.dgvNCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNCC.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNCC.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNCC.Location = new System.Drawing.Point(495, 39);
            this.dgvNCC.Name = "dgvNCC";
            this.dgvNCC.ReadOnly = true;
            this.dgvNCC.RowHeadersVisible = false;
            this.dgvNCC.RowHeadersWidth = 51;
            this.dgvNCC.RowTemplate.Height = 24;
            this.dgvNCC.Size = new System.Drawing.Size(332, 133);
            this.dgvNCC.TabIndex = 2;
            this.dgvNCC.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNCC.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvNCC.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvNCC.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvNCC.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvNCC.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvNCC.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNCC.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvNCC.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvNCC.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvNCC.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvNCC.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvNCC.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvNCC.ThemeStyle.ReadOnly = true;
            this.dgvNCC.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNCC.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNCC.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvNCC.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvNCC.ThemeStyle.RowsStyle.Height = 24;
            this.dgvNCC.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNCC.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvNCC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNCC_CellClick);
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Enabled = false;
            this.txtMaNCC.Location = new System.Drawing.Point(176, 33);
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(166, 38);
            this.txtMaNCC.TabIndex = 3;
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(176, 77);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(298, 38);
            this.txtTenNCC.TabIndex = 4;
            this.txtTenNCC.TextChanged += new System.EventHandler(this.txtTenNCC_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Wheat;
            this.groupBox1.Controls.Add(this.lbThanhTien);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lbNCC);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnLuuCT);
            this.groupBox1.Controls.Add(this.btnDoi);
            this.groupBox1.Controls.Add(this.btnSuaCT);
            this.groupBox1.Controls.Add(this.txtDonGia);
            this.groupBox1.Controls.Add(this.btnXoaCT);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnAddCT);
            this.groupBox1.Controls.Add(this.dgvChiTiet);
            this.groupBox1.Controls.Add(this.txtSL);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbbSach);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbbNCC);
            this.groupBox1.Location = new System.Drawing.Point(30, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1282, 358);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập hàng";
            // 
            // lbThanhTien
            // 
            this.lbThanhTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbThanhTien.Location = new System.Drawing.Point(1013, 98);
            this.lbThanhTien.Name = "lbThanhTien";
            this.lbThanhTien.Size = new System.Drawing.Size(263, 32);
            this.lbThanhTien.TabIndex = 21;
            this.lbThanhTien.Text = "0";
            this.lbThanhTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(870, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 32);
            this.label9.TabIndex = 20;
            this.label9.Text = "Thành tiền";
            // 
            // lbNCC
            // 
            this.lbNCC.AutoSize = true;
            this.lbNCC.Location = new System.Drawing.Point(755, 98);
            this.lbNCC.Name = "lbNCC";
            this.lbNCC.Size = new System.Drawing.Size(0, 32);
            this.lbNCC.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(560, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(212, 32);
            this.label7.TabIndex = 18;
            this.label7.Text = "Đơn nhập sách ";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Enabled = false;
            this.txtDonGia.Location = new System.Drawing.Point(143, 244);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(166, 38);
            this.txtDonGia.TabIndex = 16;
            this.txtDonGia.TextChanged += new System.EventHandler(this.txtTenNCC_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 32);
            this.label6.TabIndex = 15;
            this.label6.Text = "Đơn giá";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AllowUserToResizeColumns = false;
            this.dgvChiTiet.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvChiTiet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvChiTiet.ColumnHeadersHeight = 40;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTiet.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvChiTiet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChiTiet.Location = new System.Drawing.Point(566, 147);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.RowTemplate.Height = 24;
            this.dgvChiTiet.Size = new System.Drawing.Size(710, 193);
            this.dgvChiTiet.TabIndex = 11;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvChiTiet.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChiTiet.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvChiTiet.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvChiTiet.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvChiTiet.ThemeStyle.ReadOnly = true;
            this.dgvChiTiet.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChiTiet.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvChiTiet.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvChiTiet.ThemeStyle.RowsStyle.Height = 24;
            this.dgvChiTiet.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChiTiet.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvChiTiet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTiet_CellClick);
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(143, 196);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(166, 38);
            this.txtSL.TabIndex = 12;
            this.txtSL.TextChanged += new System.EventHandler(this.txtTenNCC_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 32);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tên Sách";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 32);
            this.label5.TabIndex = 11;
            this.label5.Text = "Số lượng";
            // 
            // cbbSach
            // 
            this.cbbSach.FormattingEnabled = true;
            this.cbbSach.Location = new System.Drawing.Point(143, 144);
            this.cbbSach.Name = "cbbSach";
            this.cbbSach.Size = new System.Drawing.Size(389, 39);
            this.cbbSach.TabIndex = 13;
            this.cbbSach.SelectedIndexChanged += new System.EventHandler(this.cbbSach_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 32);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tên NCC";
            // 
            // cbbNCC
            // 
            this.cbbNCC.FormattingEnabled = true;
            this.cbbNCC.Location = new System.Drawing.Point(143, 49);
            this.cbbNCC.Name = "cbbNCC";
            this.cbbNCC.Size = new System.Drawing.Size(389, 39);
            this.cbbNCC.TabIndex = 0;
            this.cbbNCC.SelectedIndexChanged += new System.EventHandler(this.cbbNCC_SelectedIndexChanged);
            // 
            // btnLuuCT
            // 
            this.btnLuuCT.BackColor = System.Drawing.Color.IndianRed;
            this.btnLuuCT.FlatAppearance.BorderSize = 0;
            this.btnLuuCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuCT.ForeColor = System.Drawing.Color.White;
            this.btnLuuCT.Location = new System.Drawing.Point(371, 302);
            this.btnLuuCT.Name = "btnLuuCT";
            this.btnLuuCT.Size = new System.Drawing.Size(96, 38);
            this.btnLuuCT.TabIndex = 17;
            this.btnLuuCT.Text = "Đặt";
            this.btnLuuCT.UseVisualStyleBackColor = false;
            this.btnLuuCT.Click += new System.EventHandler(this.btnLuuCT_Click);
            // 
            // btnDoi
            // 
            this.btnDoi.BackColor = System.Drawing.Color.IndianRed;
            this.btnDoi.Enabled = false;
            this.btnDoi.FlatAppearance.BorderSize = 0;
            this.btnDoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoi.ForeColor = System.Drawing.Color.White;
            this.btnDoi.Location = new System.Drawing.Point(409, 94);
            this.btnDoi.Name = "btnDoi";
            this.btnDoi.Size = new System.Drawing.Size(123, 38);
            this.btnDoi.TabIndex = 11;
            this.btnDoi.Text = "Đổi NCC";
            this.btnDoi.UseVisualStyleBackColor = false;
            this.btnDoi.Click += new System.EventHandler(this.btnDoi_Click);
            // 
            // btnSuaCT
            // 
            this.btnSuaCT.BackColor = System.Drawing.Color.IndianRed;
            this.btnSuaCT.Enabled = false;
            this.btnSuaCT.FlatAppearance.BorderSize = 0;
            this.btnSuaCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaCT.ForeColor = System.Drawing.Color.White;
            this.btnSuaCT.Location = new System.Drawing.Point(246, 302);
            this.btnSuaCT.Name = "btnSuaCT";
            this.btnSuaCT.Size = new System.Drawing.Size(96, 38);
            this.btnSuaCT.TabIndex = 12;
            this.btnSuaCT.Text = "Sửa";
            this.btnSuaCT.UseVisualStyleBackColor = false;
            this.btnSuaCT.Click += new System.EventHandler(this.btnSuaCT_Click);
            // 
            // btnXoaCT
            // 
            this.btnXoaCT.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoaCT.Enabled = false;
            this.btnXoaCT.FlatAppearance.BorderSize = 0;
            this.btnXoaCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaCT.ForeColor = System.Drawing.Color.White;
            this.btnXoaCT.Location = new System.Drawing.Point(130, 302);
            this.btnXoaCT.Name = "btnXoaCT";
            this.btnXoaCT.Size = new System.Drawing.Size(96, 38);
            this.btnXoaCT.TabIndex = 11;
            this.btnXoaCT.Text = "Xoá";
            this.btnXoaCT.UseVisualStyleBackColor = false;
            this.btnXoaCT.Click += new System.EventHandler(this.btnXoaCT_Click);
            // 
            // btnAddCT
            // 
            this.btnAddCT.BackColor = System.Drawing.Color.IndianRed;
            this.btnAddCT.Enabled = false;
            this.btnAddCT.FlatAppearance.BorderSize = 0;
            this.btnAddCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCT.ForeColor = System.Drawing.Color.White;
            this.btnAddCT.Location = new System.Drawing.Point(12, 302);
            this.btnAddCT.Name = "btnAddCT";
            this.btnAddCT.Size = new System.Drawing.Size(96, 38);
            this.btnAddCT.TabIndex = 11;
            this.btnAddCT.Text = "Thêm";
            this.btnAddCT.UseVisualStyleBackColor = false;
            this.btnAddCT.Click += new System.EventHandler(this.btnAddCT_Click);
            // 
            // btnTaoMa
            // 
            this.btnTaoMa.BackColor = System.Drawing.Color.IndianRed;
            this.btnTaoMa.FlatAppearance.BorderSize = 0;
            this.btnTaoMa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoMa.ForeColor = System.Drawing.Color.White;
            this.btnTaoMa.Location = new System.Drawing.Point(351, 32);
            this.btnTaoMa.Name = "btnTaoMa";
            this.btnTaoMa.Size = new System.Drawing.Size(123, 38);
            this.btnTaoMa.TabIndex = 9;
            this.btnTaoMa.Text = "Tạo mã";
            this.btnTaoMa.UseVisualStyleBackColor = false;
            this.btnTaoMa.Click += new System.EventHandler(this.btnTaoMa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.IndianRed;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(378, 134);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(96, 38);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.IndianRed;
            this.btnSua.Enabled = false;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(261, 134);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(96, 38);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoa.Enabled = false;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(146, 134);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(96, 38);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.IndianRed;
            this.btnThem.Enabled = false;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(30, 134);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(96, 38);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmNhapSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1324, 578);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTaoMa);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtTenNCC);
            this.Controls.Add(this.txtMaNCC);
            this.Controls.Add(this.dgvNCC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "frmNhapSach";
            this.Text = "Nhập Sách";
            this.Load += new System.EventHandler(this.frmNCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNCC)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvNCC;
        private System.Windows.Forms.TextBox txtMaNCC;
        private System.Windows.Forms.TextBox txtTenNCC;
        private RoundedButton btnThem;
        private RoundedButton btnXoa;
        private RoundedButton btnSua;
        private RoundedButton btnLuu;
        private RoundedButton btnTaoMa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbNCC;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbSach;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChiTiet;
        private RoundedButton btnSuaCT;
        private System.Windows.Forms.TextBox txtDonGia;
        private RoundedButton btnXoaCT;
        private System.Windows.Forms.Label label6;
        private RoundedButton btnAddCT;
        private RoundedButton btnDoi;
        private RoundedButton btnLuuCT;
        private System.Windows.Forms.Label lbNCC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbThanhTien;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}