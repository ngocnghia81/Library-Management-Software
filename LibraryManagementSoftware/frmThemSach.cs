using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSoftware
{
    public partial class frmThemSach : Form
    {
        private bool isFormLoaded = false; 
        private DBConnection db = new DBConnection();
        public frmThemSach()
        {
            InitializeComponent();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        



        private void label6_Click(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadTacGia()
        {
            // Tác giả
            DataTable dt = db.ExecuteSelect("SELECT * FROM TACGIA");

            DataRow newRow = dt.NewRow();
            newRow["MaTacGia"] = "ADD";
            newRow["TenTacGia"] = "Thêm tác giả mới"; 
            dt.Rows.InsertAt(newRow, 0); 

            comboBoxTacGia.DataSource = dt;
            comboBoxTacGia.DisplayMember = "TenTacGia";
            comboBoxTacGia.ValueMember = "MaTacGia";
            comboBoxTacGia.SelectedIndex = -1;
        }

        private void LoadLoaiSach()
        {
            // Loại sách
            DataTable dt = db.ExecuteSelect("SELECT * FROM THELOAISACH");

            DataRow newRow = dt.NewRow();
            newRow["MaLoai"] = "ADD"; 
            newRow["TenLoai"] = "Thêm loại sách mới"; 
            dt.Rows.InsertAt(newRow, 0); 

            comboBoxLoaiSach.DataSource = dt;
            comboBoxLoaiSach.DisplayMember = "TenLoai";
            comboBoxLoaiSach.ValueMember = "MaLoai";
            comboBoxLoaiSach.SelectedIndex = -1;

            
        }

        private void LoadNXB()
        {
            // NXB
            DataTable dt = db.ExecuteSelect("SELECT * FROM NXB");

            DataRow newRow = dt.NewRow();
            newRow["MaNXB"] = "ADD"; 
            newRow["TenNXB"] = "Thêm nhà xuất bản mới"; 
            dt.Rows.InsertAt(newRow, 0);

            comboBoxNXB.DataSource = dt;
            comboBoxNXB.DisplayMember = "TenNXB";
            comboBoxNXB.ValueMember = "MaNXB";
            comboBoxNXB.SelectedIndex = -1;
        }

        private void LoadKe()
        {
            // Kệ sách
            DataTable dt = db.ExecuteSelect("SELECT * FROM KESACH");

            DataRow newRow = dt.NewRow();
            newRow["MaKe"] = "ADD"; 
            newRow["TenKe"] = "Thêm kệ mới";
            dt.Rows.InsertAt(newRow, 0); 

            comboBoxKe.DataSource = dt;
            comboBoxKe.DisplayMember = "TenKe";
            comboBoxKe.ValueMember = "MaKe";
            comboBoxKe.SelectedIndex = -1;
        }


        private void frmThemSach_Load(object sender, EventArgs e)
        {

            LoadTacGia();
            LoadLoaiSach();
            LoadNXB();
            LoadKe();


            
            TienIch.GoiYComboBox(comboBoxTacGia, "TenTacGia");
            TienIch.GoiYComboBox(comboBoxLoaiSach, "TenLoai");
            TienIch.GoiYComboBox(comboBoxNXB, "TenNXB");
            TienIch.GoiYComboBox(comboBoxKe, "TenKe");

            isFormLoaded = true;
        }

        private void comboBoxAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTacGia.SelectedItem != null && isFormLoaded)
            {
                DataRowView selectedRow = (DataRowView)comboBoxTacGia.SelectedItem;
                string selectedAuthorId = selectedRow["MaTacGia"].ToString();
                string selectedAuthorName = selectedRow["TenTacGia"].ToString();

                string authorDisplayString = string.Format("{0} - {1}", selectedAuthorId, selectedAuthorName);

                bool authorExists = false;
                foreach (string item in listBoxSelectedAuthors.Items)
                {
                    if (item.StartsWith(selectedAuthorId)) 
                    {
                        authorExists = true;
                        break;
                    }
                }

                if (!authorExists)
                {
                    listBoxSelectedAuthors.Items.Add(authorDisplayString);
                }
            }
        }


        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\"; 
                openFileDialog.Filter = "File hình (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif"; // Bộ lọc file
                openFileDialog.Title = "Chọn một hình ảnh"; 

                if (openFileDialog.ShowDialog() == DialogResult.OK) 
                {
                    string sourceFilePath = openFileDialog.FileName; 
                    string destinationFolderPath = Path.Combine(Application.StartupPath, "images"); 
                    if (!Directory.Exists(destinationFolderPath)) 
                    {
                        Directory.CreateDirectory(destinationFolderPath); 
                    }
                    string destinationFilePath = Path.Combine(destinationFolderPath, Path.GetFileName(sourceFilePath)); // Đường dẫn lưu file

                    try
                    {
                        File.Copy(sourceFilePath, destinationFilePath, true); 
                        txtFilePath.Text = destinationFilePath;

                        pictureBoxHinhAnh.Image = Image.FromFile(destinationFilePath); 
                        pictureBoxHinhAnh.Visible = true;
                        pictureBoxHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch (Exception ex)
                    {
                        pictureBoxHinhAnh.Visible = false;
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maSach = TaoMaSach();

            string tenSach = textBoxTenSach.Text.Trim();
            string hinhAnh = txtFilePath.Text.Trim();
            string maNXB = comboBoxNXB.SelectedValue.ToString();
            string maLoai = comboBoxLoaiSach.SelectedValue.ToString();
            string moTa = richTextBox1.Text.Trim();
            int soLuong= int.Parse(textBoxSL.Text.Trim());
            string maKe = comboBoxKe.SelectedValue.ToString();

            if (string.IsNullOrEmpty(tenSach) || string.IsNullOrEmpty(hinhAnh) ||
                string.IsNullOrEmpty(maNXB) || string.IsNullOrEmpty(maLoai) ||
                string.IsNullOrEmpty(moTa) || soLuong < 0 || string.IsNullOrEmpty(maKe))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO SACH (MaSach, TenSach, HinhAnh, MaNXB, MaLoai, MoTa, SoLuongKho, TongSoLuong, MaKe) " +
                           "VALUES (@MaSach, @TenSach, @HinhAnh, @MaNXB, @MaLoai, @MoTa, @SoLuongKho, @TongSoLuong, @MaKe)";

            var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MaSach", maSach),
                    new SqlParameter("@TenSach", tenSach),
                    new SqlParameter("@HinhAnh", Path.GetFileName(hinhAnh)), // Lưu chỉ tên file hình ảnh
                    new SqlParameter("@MaNXB", maNXB),
                    new SqlParameter("@MaLoai", maLoai),
                    new SqlParameter("@MoTa", moTa),
                    new SqlParameter("@SoLuongKho", soLuong),
                    new SqlParameter("@TongSoLuong", soLuong),
                    new SqlParameter("@MaKe", maKe)
                };

            try
            {
                db.ExecuteInsert(query, parameters.ToArray());
                ThemTacGiaVaoSach(maSach);
                MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemTacGiaVaoSach(string maSach)
        {
            foreach (var item in listBoxSelectedAuthors.Items)
            {
                string[] parts = item.ToString().Split(new[] { " - " }, StringSplitOptions.None);
                string maTacGia = parts[0]; 

                string insertQuery = "INSERT INTO THAMGIA (MaTacGia, MaSach) VALUES (@MaTacGia, @MaSach)";
                var insertParameters = new SqlParameter[]
                {
                        new SqlParameter("@MaTacGia", maTacGia),
                        new SqlParameter("@MaSach", maSach)
                };

                try
                {
                    db.ExecuteNonQuery(insertQuery, insertParameters);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm tác giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void ClearForm()
        {
            textBoxTenSach.Clear();
            txtFilePath.Clear();
            pictureBoxHinhAnh.Image = null;
            richTextBox1.Clear();
            textBoxSL.Clear();
            comboBoxNXB.SelectedIndex = -1;
            comboBoxLoaiSach.SelectedIndex = -1;
            comboBoxKe.SelectedIndex = -1;
            listBoxSelectedAuthors.Items.Clear();
        }


        private string TaoMaSach()
        {
            string query = "SELECT dbo.func_LayMaSachLonNhat() AS NextMaSach";

            DataTable dt = db.ExecuteSelect(query);
            if (dt.Rows.Count > 0)
            {
                int nextCode = Convert.ToInt32(dt.Rows[0]["NextMaSach"]);

                return "S" + nextCode.ToString("D3");
            }

            return "S001";
        }

        private void pictureBoxHinhAnh_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSL_TextChanged(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsNumeric(textBoxSL.Text) && textBoxSL.Text != "")
            {
                MessageBox.Show("Vui lòng nhập một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxSL.Clear(); 
                textBoxSL.Focus(); 
            }
        }
    }
}
