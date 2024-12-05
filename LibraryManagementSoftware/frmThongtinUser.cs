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
    public partial class frmThongtinUser : Form
    {
        DBConnection db = new DBConnection();

        public void LoadThongTin()
        {
            string sql = string.Format("select DOCGIA.* from DOCGIA join TAIKHOAN on TAIKHOAN.MaDocGia = DOCGIA.MaDocGia where TAIKHOAN.Email = {0}",UserIdentify.Instance.email);
            DataTable user = db.ExecuteSelect(sql);
        }

        public frmThongtinUser()
        {
            InitializeComponent();
        }
    }
}
