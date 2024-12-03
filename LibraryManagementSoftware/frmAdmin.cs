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
        public frmAdmin()
        {
            InitializeComponent();
            this.IsMdiContainer = true; // Đặt frmAdmin làm MDI Container
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
    }
}
