using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSoftware
{
    public partial class frmAdmin : Form
    {
        private string name;
        public frmAdmin(string name)
        {
            InitializeComponent(); // Đảm bảo gọi InitializeComponent() trước

            this.IsMdiContainer = true; // Đặt frmAdmin làm MDI Container

            // Cập nhật giao diện của label để hiển thị đẹp hơn
            this.name = name;

            // Thiết lập văn bản cho label
            lblName.Text = "Xin chào: " + name;

            // Cải thiện vẻ đẹp của Label
            lblName.Font = new Font("Segoe UI", 16, FontStyle.Bold); // Thay đổi font và cỡ chữ
            lblName.ForeColor = Color.White; // Màu chữ trắng
            lblName.BackColor = Color.DarkBlue; // Màu nền xanh đậm
            lblName.TextAlign = ContentAlignment.MiddleCenter; // Căn giữa văn bản
            lblName.AutoSize = true; // Tự động điều chỉnh kích thước label theo nội dung
            lblName.Padding = new Padding(10); // Thêm khoảng cách lề cho văn bản
            lblName.BorderStyle = BorderStyle.FixedSingle; // Thêm đường viền cho label
        }


        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void thêmSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThemSach());
        }

        private void xemSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmXemSachAdmin());
        }

        private void mượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMuonSach());
        }

        private void xemThôngTinĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDanhSachDocGia());
        }

        private void ngườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new frmNguoiDung()); // Giả sử bạn có form này
        }

        /// <summary>
        /// Hàm chung để mở form con trong MDI Container
        /// </summary>
        /// <param name="childForm">Form cần hiển thị</param>
        private void OpenChildForm(Form childForm)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == childForm.GetType())
                {
                    frm.Activate(); 
                    return;
                }
            }

            childForm.MdiParent = this;
            childForm.Dock = DockStyle.Fill; 
            childForm.Show();
        }

        private void trảSáchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTraSach());
        }

        private void trảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmTraSach frm = new frmTraSach();
            frm.ControlBox = false;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapSach frm = new frmNhapSach();
            frm.ControlBox = false;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }


        private void đơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDonNhap frm = new frmDonNhap();
            frm.ControlBox = false;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void quảnLýĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLichSuMuonSach());

        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKe());

        }

        private void dữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDuLieu());

        }
    }
}
