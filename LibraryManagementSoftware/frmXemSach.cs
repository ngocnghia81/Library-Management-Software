using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LibraryManagementSoftware
{
    public partial class frmXemSach : Form
    {
        string relativePath;
        string absolutePath;
        bool isLoadCBB = false;
        DBConnection db = new DBConnection();
        List<Sach> saches = new List<Sach>();

        private void ThemSachVaoPanel(FlowLayoutPanel layoutSach,string maSach, string tenSach,string soLuong, string imagePath)
        {
            int width = 180;
            int height = 300;
            Color backColor = Color.IndianRed;
            // Kiểm tra nếu ảnh tồn tại
            if (System.IO.File.Exists(imagePath))
            {
                // Tạo PictureBox cho hình ảnh
                PictureBox pictureBox = new PictureBox
                {
                    Image = Image.FromFile(imagePath),
                    SizeMode = PictureBoxSizeMode.StretchImage, // Để hình ảnh tự động điều chỉnh kích thước
                    Width = width-30,
                    Height = height-130, // Chiều cao của hình ảnh

                };

                // Tạo Label cho tên sách
                Label nameLabel = new Label
                {
                    Text = tenSach,
                    Font = new Font("Arial", 16),
                    Height = TextRenderer.MeasureText(tenSach, new Font("Arial", 16)).Height*2,
                    Width = width,
                    AutoEllipsis=true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    AllowDrop = true,
                };

                Label intLabel = new Label
                {
                    Text = "Số lượng: "+soLuong,
                    Font = new Font("Arial", 16),
                    Height = TextRenderer.MeasureText(tenSach, new Font("Arial", 16)).Height,
                    Width = width,
                    AutoEllipsis = true,
                    TextAlign = ContentAlignment.MiddleCenter // Căn giữa văn bản
                };

                RoundedButton detailButton = new RoundedButton
                {
                    Text = "Chi tiết",
                    BackColor = backColor,      // Màu nền IndianRed
                    ForeColor = Color.White,          // Màu chữ trắng
                    FlatStyle = FlatStyle.Flat,       // Loại bỏ hiệu ứng nổi của nút
                    Width = 100,
                    Height = 40,
                };



                // Tạo một Panel để chứa PictureBox và Label
                RoundedPanel panel = new RoundedPanel()
                {
                    Width = width,
                    Height = height, // Chiều cao tổng thể của panel
                    Margin = new Padding(5),
                };

                // Thêm PictureBox và Label vào Panel
                pictureBox.Left = (panel.Width - pictureBox.Width) / 2;
                pictureBox.Top = 10;

                nameLabel.Top = pictureBox.Bottom;

                intLabel.Top = nameLabel.Bottom;

                detailButton.Top = intLabel.Bottom;
                detailButton.Left = (panel.Width - detailButton.Width) / 2;
                detailButton.Click += (sender, e) =>
                {
                    ChiTietSach(maSach);
                };


                panel.Controls.Add(pictureBox);
                panel.Controls.Add(nameLabel);
                panel.Controls.Add(intLabel);
                panel.Controls.Add(detailButton);

                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.BackColor = Color.White;
                panel.Tag = maSach;
           

                layoutSach.Width = this.Width / 2;
                layoutSach.Controls.Add(panel);
            }
        }

        void ChiTietSach(string maSach)
        {
            string query = string.Format("SELECT * FROM dbo.func_GetChiTietSach('{0}')", maSach);
            DataTable dt = db.ExecuteSelect(query);
            DataRow row = dt.Rows[0];
            string path = Path.Combine(absolutePath, "Sách\\");
            pictureChiTiet.Image = Image.FromFile(path + row["HinhAnh"].ToString());
            lbTen.Text = "Tên sách: " + row["TenSach"].ToString();
            lbNXB.Text = "NXB: " + row["TenNXB"].ToString();
            lbTheLoai.Text = "Thể loại: " + row["TenLoai"].ToString();
            lbMoTa.Text = row["MoTa"].ToString();
            lbTacGia.Text = row["TenTacGia"].ToString();
        }

        void LoadCBB()
        {
            DataTable dt1 = db.ExecuteSelect("select * from TheLoaiSach");
            DataRow row = dt1.NewRow();
            row["MaLoai"] = DBNull.Value;
            row["TenLoai"] = "Tất cả thể loại";
            dt1.Rows.InsertAt(row, 0);
            cbbTheLoai.DataSource = dt1;
            cbbTheLoai.DisplayMember = "TenLoai";
            cbbTheLoai.ValueMember = "MaLoai";
            

            DataTable dt2 = db.ExecuteSelect("select * from TacGia");
            DataRow row2 = dt2.NewRow();
            row2["MaTacGia"] = DBNull.Value;
            row2["TenTacGia"] = "Tất cả tác giả";
            dt2.Rows.InsertAt(row2, 0);
            cbbTG.DataSource = dt2;
            cbbTG.DisplayMember = "TenTacGia";
            cbbTG.ValueMember = "MaTacGia";
            

        }

        void LoadSach(object maTL = null,object maTG = null,object timkiem = null)
        {
            if (maTL == null)
                maTL = DBNull.Value;
            if (maTG == null)
                maTG = DBNull.Value;
            timkiem = timkiem ?? DBNull.Value;
            if (!isLoadCBB) return;
            flowLayOutSach.Controls.Clear();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaTL", SqlDbType.VarChar) { Value = maTL },
                new SqlParameter("@MaTG", SqlDbType.VarChar) { Value = maTG },
                new SqlParameter("@tk", SqlDbType.VarChar) { Value = timkiem }
            };

            DataTable dt = db.ExecuteSelect("select S.* from SACH S join THAMGIA on THAMGIA.MaSach = s.MaSach where (@tk is null or S.TenSach LIKE N'%' + @tk + '%') and (@MaTL is null or S.MaLoai = @MaTL) and (@MaTG is null or THAMGIA.MaTacGia = @MaTG)", parameters);
            

            foreach (DataRow row in dt.Rows)
            {
                string maSach = row["MaSach"].ToString();
                string tenSach = row["TenSach"].ToString();
                string soLuong = row["SoLuongKho"].ToString();
                string hinhAnh = Path.Combine(absolutePath, "Sách", row["HinhAnh"].ToString());

                ThemSachVaoPanel(flowLayOutSach, maSach, tenSach, soLuong, hinhAnh);
            }

        }

        public frmXemSach()
        {
            InitializeComponent();
            relativePath = Path.Combine(Application.StartupPath, @"..\..\images");
            absolutePath = Path.GetFullPath(relativePath);
        }

        private void frmXemSach_Load(object sender, EventArgs e)
        {
            LoadCBB();
            isLoadCBB = true;
            LoadSach();
            
        }

        private void cbbTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSach(cbbTheLoai.SelectedValue, cbbTG.SelectedValue, txtTimKiem.Text.ToString());
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadSach(cbbTheLoai.SelectedValue, cbbTG.SelectedValue,txtTimKiem.Text.ToString());
            
        }
    }
}
