using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LibraryManagementSoftware
{
    public partial class frmXemSachAdmin : Form
    {
        private DBConnection db = new DBConnection();
        private Timer _searchTimer; // Khai báo Timer

        public frmXemSachAdmin()
        {
            InitializeComponent();
            _searchTimer = new Timer();
            _searchTimer.Interval = 500; 
            _searchTimer.Tick += SearchTimer_Tick;
            LoadAllBooks();
            LoadLoaiSach();
            LoadKeSach();
            LoadNXB();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewSach.SelectedRows.Count > 0)
            {
                try
                {
                    // Lấy mã sách từ dòng được chọn
                    DataGridViewRow selectedRow = dataGridViewSach.SelectedRows[0];
                    string maSach = selectedRow.Cells["MaSach"].Value.ToString();

                    // Hiển thị thông báo xác nhận
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sách này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Câu lệnh cập nhật trường DaXoa thành 1
                        string query = "UPDATE SACH SET DaXoa = 1 WHERE MaSach = @MaSach";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                    new SqlParameter("@MaSach", maSach)
                        };

                        // Thực thi lệnh cập nhật
                        bool rowsAffected = db.ExecuteUpdate(query, parameters);

                        if (rowsAffected)
                        {
                            MessageBox.Show("Xóa sách thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAllBooks(); // Tải lại danh sách sách
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa sách. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop(); // Dừng timer trước khi bắt đầu tìm kiếm mới
            _searchTimer.Start(); // Bắt đầu lại timer
        }

        // Sự kiện Timer khi hết thời gian chờ
        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            _searchTimer.Stop(); // Dừng timer khi tick
            string searchKeyword = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(searchKeyword))
            {
                LoadAllBooks();
            }
            else
            {
                SearchBooks(searchKeyword);
            }
        }

        // Tìm kiếm sách theo từ khóa
        private void SearchBooks(string keyword)
        {
            string sql = "SELECT [MaSach], [TenSach], [HinhAnh], [MaNXB], [MaLoai], [MoTa], [SoLuongKho], [TongSoLuong], [MaKe] , [DaXoa] " +
                         "FROM [SACH] WHERE [TenSach] LIKE @keyword";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@keyword", "%" + keyword + "%")
            };

            // Lấy dữ liệu từ cơ sở dữ liệu

            DataTable dt = db.ExecuteSelect(sql, parameters);
            if (!dt.Columns.Contains("TrangThai"))
            {
                dt.Columns.Add("TrangThai", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    bool daXoa = Convert.ToBoolean(row["DaXoa"]);
                    row["TrangThai"] = daXoa ? "Đã Xóa" : "Khả Dụng";
                }
            }

            dataGridViewSach.DataSource = dt;

            dataGridViewSach.Columns["DaXoa"].Visible = false;

            dataGridViewSach.Columns["TrangThai"].HeaderText = "Trạng Thái";
            dataGridViewSach.Columns["TrangThai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            FormatDataGridView();
        }

        private void LoadAllBooks()
        {
            string sql = "SELECT [MaSach], [TenSach], [HinhAnh], [MaNXB], [MaLoai], [MoTa], [SoLuongKho], [TongSoLuong], [MaKe], [DaXoa] FROM [SACH]";
            DataTable dt = db.ExecuteSelect(sql);

            // Thêm cột hiển thị trạng thái văn bản
            if (!dt.Columns.Contains("TrangThai"))
            {
                dt.Columns.Add("TrangThai", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    bool daXoa = Convert.ToBoolean(row["DaXoa"]);
                    row["TrangThai"] = daXoa ? "Đã Xóa" : "Khả Dụng";
                }
            }

            dataGridViewSach.DataSource = dt;

            dataGridViewSach.Columns["DaXoa"].Visible = false;

            dataGridViewSach.Columns["TrangThai"].HeaderText = "Trạng Thái";
            dataGridViewSach.Columns["TrangThai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            FormatDataGridView();
        }


        private void FormatDataGridView()
        {
            dataGridViewSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSach.AllowUserToAddRows = false;
            dataGridViewSach.AllowUserToDeleteRows = false; 
            dataGridViewSach.ReadOnly = true; 

            dataGridViewSach.Font = new Font("Arial", 10, FontStyle.Regular);
            dataGridViewSach.ForeColor = Color.Black;
            dataGridViewSach.BackgroundColor = Color.WhiteSmoke;

            dataGridViewSach.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewSach.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dataGridViewSach.Columns["MaSach"].HeaderText = "Mã Sách";
            dataGridViewSach.Columns["TenSach"].HeaderText = "Tên Sách";
            dataGridViewSach.Columns["HinhAnh"].HeaderText = "Hình Ảnh";
            dataGridViewSach.Columns["MaNXB"].HeaderText = "Mã Nhà Xuất Bản";
            dataGridViewSach.Columns["MaLoai"].HeaderText = "Mã Loại";
            dataGridViewSach.Columns["MoTa"].HeaderText = "Mô Tả";
            dataGridViewSach.Columns["SoLuongKho"].HeaderText = "Số Lượng Kho";
            dataGridViewSach.Columns["TongSoLuong"].HeaderText = "Tổng Số Lượng";
            dataGridViewSach.Columns["MaKe"].HeaderText = "Mã Kệ";
            dataGridViewSach.Columns["DaXoa"].HeaderText = "Trạng thái";

            foreach (DataGridViewColumn column in dataGridViewSach.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dataGridViewSach.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dataGridViewSach.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(47, 62, 70);
            dataGridViewSach.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Cài đặt màu sắc cho các dòng khi chọn
            dataGridViewSach.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridViewSach.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void frmXemSachAdmin_Load(object sender, EventArgs e)
        {
            LoadAllBooks();
        }

        private void dataGridViewSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewSach.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewSach.SelectedRows[0];

                txtTenSach.Text = selectedRow.Cells["TenSach"].Value.ToString();
                txtMoTa.Text = selectedRow.Cells["MoTa"].Value.ToString();
                txtSLKho.Text = selectedRow.Cells["SoLuongKho"].Value.ToString();
                txtTongSL.Text = selectedRow.Cells["TongSoLuong"].Value.ToString();
                string maNXB = selectedRow.Cells["MaNXB"].Value.ToString();

                SelectNXB(maNXB);


                string imageFileName = selectedRow.Cells["HinhAnh"].Value.ToString();

                string projectDirectory = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\"));

                string imagePath = Path.Combine(projectDirectory, "images", "Sách", imageFileName);

                if (imagePath.Contains("bin\\"))
                {
                    imagePath = imagePath.Replace("bin\\", "");
                }

                if (File.Exists(imagePath))
                {
                    pictureBox2.Image = Image.FromFile(imagePath);
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage; 
                }
                else
                {
                    pictureBox2.Image = null;
                }

                string maSach = selectedRow.Cells["MaSach"].Value.ToString();

                GetAuthorsForBook(maSach);
                string maLoai = selectedRow.Cells["MaLoai"].Value.ToString();
                SetLoaiSachInComboBox(maLoai);
                string maKe = selectedRow.Cells["MaKe"].Value.ToString();
                SetKeSachInComboBox(maKe);
                txtFilePath.Text = selectedRow.Cells["HinhAnh"].Value.ToString();

                bool daXoa = (bool)selectedRow.Cells["DaXoa"].Value;
                button1.Enabled = daXoa;
                button1.Visible = daXoa;
            }
        }

        private void GetAuthorsForBook(string maSach)
        {
            string query = @"
            SELECT t.MaTacGia, t.TenTacGia
            FROM TACGIA t
            INNER JOIN THAMGIA tg ON t.MaTacGia = tg.MaTacGia
            WHERE tg.MaSach = @MaSach";

            var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MaSach", maSach)
                };

                try
                {
                    DataTable dt = db.ExecuteSelect(query, parameters.ToArray());

                    listBoxTg.Items.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        string maTacGia = row["MaTacGia"].ToString();
                        string tenTacGia = row["TenTacGia"].ToString();
                        string authorInfo = $"{maTacGia} - {tenTacGia}"; 
                        listBoxTg.Items.Add(authorInfo);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy danh sách tác giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void SetKeSachInComboBox(string maKe)
        {
            foreach (DataRowView row in cbbKe.Items)
            {
                string value = row["MaKe"].ToString();
                if (value == maKe)
                {
                    cbbKe.SelectedItem = row;
                    break;
                }
            }
        }

        private void SetLoaiSachInComboBox(string maLoai)
        {
            foreach (DataRowView row in cbbLoaiSach.Items)
            {
                string value = row["MaLoai"].ToString();
                if (value == maLoai)
                {
                    cbbLoaiSach.SelectedItem = row;
                    break;
                }
            }
        }

        private void LoadKeSach()
        {
            string query = "SELECT * FROM KESACH";

            try
            {
                DataTable dt = db.ExecuteSelect(query);

                cbbKe.DataSource = dt;
                cbbKe.DisplayMember = "TenKe"; 
                cbbKe.ValueMember = "MaKe";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy kệ sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SelectNXB(string maNXB)
        {
            foreach (DataRowView item in cbbNXB.Items)
            {
                if (item["MaNXB"].ToString() == maNXB)
                {
                    cbbNXB.SelectedItem = item;
                    break;
                }
            }
        }
        private void LoadLoaiSach()
        {
            string query = "SELECT * FROM THELOAISACH";

            try
            {
                DataTable dt = db.ExecuteSelect(query);

                cbbLoaiSach.DataSource = dt;
                cbbLoaiSach.DisplayMember = "TenLoai";
                cbbLoaiSach.ValueMember = "MaLoai";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy loại sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string maSach = dataGridViewSach.SelectedRows[0].Cells["MaSach"].Value.ToString();
            string tenSach = txtTenSach.Text.Trim();
            string maNXB = cbbNXB.SelectedValue.ToString().Trim();
            string moTa = txtMoTa.Text.Trim();
            string soLuongKho = txtSLKho.Text.Trim();
            string tongSoLuong = txtTongSL.Text.Trim();
            string maLoai = cbbLoaiSach.SelectedValue.ToString();
            string maKe = cbbKe.SelectedValue.ToString();

            string hinhAnh = Path.GetFileName(txtFilePath.Text);

            // Kiểm tra tính hợp lệ của các trường
            if (string.IsNullOrEmpty(tenSach) || string.IsNullOrEmpty(maNXB) || string.IsNullOrEmpty(moTa) ||
                string.IsNullOrEmpty(soLuongKho) || string.IsNullOrEmpty(tongSoLuong) || string.IsNullOrEmpty(maLoai) ||
                string.IsNullOrEmpty(maKe))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
                    UPDATE SACH
                    SET TenSach = @TenSach, 
                        MaNXB = @MaNXB, 
                        MoTa = @MoTa, 
                        SoLuongKho = @SoLuongKho, 
                        TongSoLuong = @TongSoLuong, 
                        MaLoai = @MaLoai, 
                        MaKe = @MaKe, 
                        HinhAnh = @HinhAnh
                    WHERE MaSach = @MaSach";

                            SqlParameter[] parameters = new SqlParameter[]
                            {
                        new SqlParameter("@MaSach", maSach),
                        new SqlParameter("@TenSach", tenSach),
                        new SqlParameter("@MaNXB", maNXB),
                        new SqlParameter("@MoTa", moTa),
                        new SqlParameter("@SoLuongKho", soLuongKho),
                        new SqlParameter("@TongSoLuong", tongSoLuong),
                        new SqlParameter("@MaLoai", maLoai),
                        new SqlParameter("@MaKe", maKe),
                        new SqlParameter("@HinhAnh", hinhAnh) 
                            };

            try
            {
                // Thực hiện câu lệnh SQL để cập nhật
                db.ExecuteUpdate(query, parameters);

                // Thông báo thành công
                MessageBox.Show("Cập nhật thông tin sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại dữ liệu sách sau khi cập nhật
                LoadAllBooks();
            }
            catch (Exception ex)
            {
                // Thông báo lỗi nếu có
                MessageBox.Show("Lỗi khi cập nhật thông tin sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnHinhMoi_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\"; // Đường dẫn gốc khi mở hộp thoại
                openFileDialog.Filter = "File hình (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif"; // Bộ lọc file
                openFileDialog.Title = "Chọn một hình ảnh";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourceFilePath = openFileDialog.FileName;

                    // Xác định đường dẫn thư mục Images/Sách
                    string destinationFolderPath = Path.Combine(Application.StartupPath, "Images", "Sách");
                    if (destinationFolderPath.Contains("\\bin\\Debug\\"))
                    {
                        destinationFolderPath = destinationFolderPath.Replace("bin\\Debug\\", "");
                    }

                    if (!Directory.Exists(destinationFolderPath))
                    {
                        Directory.CreateDirectory(destinationFolderPath);
                    }

                    string destinationFilePath = Path.Combine(destinationFolderPath, Path.GetFileName(sourceFilePath));

                    try
                    {
                        if (File.Exists(destinationFilePath))
                        {
                            // Lưu tên tệp hình ảnh vào TextBox (để lưu vào cơ sở dữ liệu)
                            txtFilePath.Text = Path.GetFileName(destinationFilePath);

                            // Hiển thị hình ảnh lên PictureBox
                            pictureBox2.Image = Image.FromFile(destinationFilePath);
                            pictureBox2.Visible = true;
                            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            // Sao chép hình ảnh vào thư mục Images/Sách
                            File.Copy(sourceFilePath, destinationFilePath, true);

                            txtFilePath.Text = Path.GetFileName(destinationFilePath);

                            // Hiển thị hình ảnh lên PictureBox
                            pictureBox2.Image = Image.FromFile(destinationFilePath);
                            pictureBox2.Visible = true;
                            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    catch (Exception ex)
                    {
                        pictureBox2.Visible = false;
                        MessageBox.Show("Lỗi khi lưu hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void LoadNXB()
        {
            string query = "SELECT [MaNXB], [TenNXB] FROM [NXB]";

            try
            {
                DataTable dt = db.ExecuteSelect(query);

                // Gán dữ liệu vào ComboBox
                cbbNXB.DataSource = dt;
                cbbNXB.DisplayMember = "TenNXB";  // Hiển thị tên NXB
                cbbNXB.ValueMember = "MaNXB";     // Lưu trữ mã NXB
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu NXB: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewSach.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewSach.SelectedRows[0];
                string maSach = selectedRow.Cells["MaSach"].Value.ToString();

                bool isDeleted = (bool)selectedRow.Cells["DaXoa"].Value;

                if (!isDeleted)
                {
                    MessageBox.Show("Sách này đang khả dụng, không cần khôi phục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string sql = "UPDATE SACH SET DaXoa = 0 WHERE MaSach = @MaSach";

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@MaSach", maSach)
                };

                try
                {
                    bool result = db.ExecuteUpdate(sql, parameters);

                    if (result)
                    {
                        MessageBox.Show("Khôi phục sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllBooks(); // Tải lại danh sách sách
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sách để khôi phục.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi khôi phục sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sách để khôi phục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
