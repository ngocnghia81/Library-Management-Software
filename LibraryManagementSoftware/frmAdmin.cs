﻿using System;
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
        }

        private void ngườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            frmThemSach form = new frmThemSach();
            this.Opacity = 0.7; 
            form.ShowDialog();
            this.Opacity = 1.0;
        }

        private void xemSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXemSachAdmin form = new frmXemSachAdmin();
            this.Opacity = 0.7;
            form.ShowDialog();
            this.Opacity = 1.0;
        }

        private void mượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMuonSach frmMuonSach = new frmMuonSach();
            this.Opacity = 0.7;
            frmMuonSach.ShowDialog();
            this.Opacity = 1.0;
        }

        private void xemThôngTinĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhSachDocGia frmDanhSachDocGia = new frmDanhSachDocGia();
            this.Opacity = 0.7;
            frmDanhSachDocGia.ShowDialog();
            this.Opacity = 1.0;
        }
    }
}
