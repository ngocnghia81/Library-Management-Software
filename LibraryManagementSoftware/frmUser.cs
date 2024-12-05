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
    public partial class frmUser : Form
    {
        public frmUser(string email)
        {
            InitializeComponent();
            UserIdentify.Instance.email = email;
            MessageBox.Show(UserIdentify.Instance.email);
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            frmXemSach frmXemSach = new frmXemSach();
            frmXemSach.WindowState = FormWindowState.Maximized;
            frmXemSach.ControlBox =false;
            frmXemSach.MdiParent = this;
            frmXemSach.Show();
            
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongtinUser frm = new frmThongtinUser();
            frm.WindowState = FormWindowState.Maximized;
            frm.ControlBox = false;
            frm.MdiParent = this;
            frm.Show();
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXemSach frmXemSach = new frmXemSach();
            frmXemSach.WindowState = FormWindowState.Maximized;
            frmXemSach.ControlBox = false;
            frmXemSach.MdiParent = this;
            frmXemSach.Show();
        }

        private void frmUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
