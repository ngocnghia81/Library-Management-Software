using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSoftware
{
    public class RoundedButton : Button
    {
        public RoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat; // Loại bỏ hiệu ứng nổi
            this.BackColor = Color.IndianRed; // Màu nền
            this.ForeColor = Color.White; // Màu chữ
            this.FlatAppearance.BorderSize = 0; // Ẩn viền mặc định
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20; // Độ bo góc
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90); // Bo góc trên trái
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90); // Bo góc trên phải
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90); // Bo góc dưới phải
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90); // Bo góc dưới trái
            path.CloseFigure();

            this.Region = new Region(path); // Thiết lập vùng nút
            base.OnPaint(pevent); // Vẽ nội dung nút
        }
    }
    public class RoundedPanel : Panel
    {
        public RoundedPanel()
        {       
            
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20; // Độ bo góc
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90); // Bo góc trên trái
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90); // Bo góc trên phải
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90); // Bo góc dưới phải
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90); // Bo góc dưới trái
            path.CloseFigure();

            this.Region = new Region(path); // Thiết lập vùng nút
            base.OnPaint(pevent); // Vẽ nội dung nút
        }
    }
}
