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
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            frmXemSach frmXemSach = new frmXemSach();
            frmXemSach.WindowState = FormWindowState.Maximized;
            frmXemSach.ControlBox =false;
            frmXemSach.MdiParent = this;
            frmXemSach.Show();
            
        }
    }
}