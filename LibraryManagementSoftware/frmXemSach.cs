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
        DBConnection db = new DBConnection();
        List<Sach> saches = new List<Sach>();

        private void ThemSachVaoPanel(FlowLayoutPanel layoutSach,string maSach, string tenSach,string soLuong, string imagePath)
        {
            int width = 150;
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
                    Font = new Font("Arial", 20),
                    Height = TextRenderer.MeasureText(tenSach, new Font("Arial", 20)).Height,
                    Width = width,
                    AutoEllipsis=true,
                    TextAlign = ContentAlignment.MiddleCenter // Căn giữa văn bản
                };

                Label intLabel = new Label
                {
                    Text = "Số lượng: "+soLuong,
                    Font = new Font("Arial", 20),
                    Height = TextRenderer.MeasureText(tenSach, new Font("Arial", 20)).Height,
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

                RoundedButton cartButton = new RoundedButton
                {
                    Image = Image.FromFile(absolutePath + @"\cart2.png"),
                    Font = new Font("Arial", 20),
                    BackColor = backColor,      // Màu nền IndianRed
                    ForeColor = Color.White,          // Màu chữ trắng
                    FlatStyle = FlatStyle.Flat,       // Loại bỏ hiệu ứng nổi của nút
                    Width = 40,
                    Height = 40,
                };

                // Tạo một Panel để chứa PictureBox và Label
                RoundedPanel panel = new RoundedPanel()
                {
                    Width = width,
                    Height = height, // Chiều cao tổng thể của panel
                    Margin = new Padding(10)
                    
                };

                // Thêm PictureBox và Label vào Panel
                pictureBox.Left = (panel.Width - pictureBox.Width) / 2;
                pictureBox.Top = 10;

                nameLabel.Top = pictureBox.Bottom;

                intLabel.Top = nameLabel.Bottom;

                detailButton.Top = intLabel.Bottom;
                detailButton.Left = (pictureBox.Width - detailButton.Width) / 2;
                detailButton.Click += (sender, e) =>
                {
                    ChiTietSach(maSach);
                };

                cartButton.Left = detailButton.Right+10;
                cartButton.Top = intLabel.Bottom;

                cartButton.Click += (sender, e) =>
                {
                    TuongTacCart(cartButton);                  
                };

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(nameLabel);
                panel.Controls.Add(intLabel);
                panel.Controls.Add(detailButton);
                panel.Controls.Add(cartButton);
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

        void TuongTacCart(Button btn)
        {
            if (btn.Text == "")
            {
                btn.Text = "X";
                btn.Image = null;
            }
            else
            {
                btn.Text = "";
                btn.Image = Image.FromFile(absolutePath + @"\cart2.png");
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

            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true, // Thêm thanh cuộn nếu cần
                WrapContents = true // Cho phép nội dung đổ đầy
            };

            DataTable dt = db.ExecuteSelect("select * from Sach");
       
            foreach (DataRow row in dt.Rows)
            {
                
                //MessageBox.Show(row["TenSach"].ToString());
                string maSach = row["MaSach"].ToString();
                string tenSach = row["TenSach"].ToString();
                string soLuong = row["SoLuongKho"].ToString();
                string hinhAnh = Path.Combine(absolutePath, "Sách",row["HinhAnh"].ToString()) ;

                ThemSachVaoPanel(flowLayOutSach,maSach, tenSach, soLuong, hinhAnh);
            }

        }
    }
}
