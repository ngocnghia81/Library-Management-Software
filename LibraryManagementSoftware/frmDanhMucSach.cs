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
    public partial class frmDanhMucSach : Form
    {
        private DBConnection db = new DBConnection();
        public frmDanhMucSach()
        {
            InitializeComponent();
        }

        private void frmDanhMucSach_Load(object sender, EventArgs e)
        {
           string query = @"
                            SELECT tl.MaLoai, tl.TenLoai, s.MaSach, s.TenSach
                            FROM  THELOAISACH tl
                            LEFT JOIN SACH s  ON s.MaLoai = tl.MaLoai
                            ORDER BY tl.MaLoai";


           DataTable dt = db.ExecuteSelect(query);

           PopulateTreeView(dt);
        }


        private void PopulateTreeView(DataTable dt)
        {
            TreeView treeView = treeView1;
            treeView.Nodes.Clear(); 

            TreeNode currentCategoryNode = null;
            string lastCategoryId = null;

            foreach (DataRow row in dt.Rows)
            {
                string maDanhMuc = row["MaLoai"].ToString();
                string tenDanhMuc = row["TenLoai"].ToString();
                string maMonAn = row["MaSach"] != DBNull.Value ? row["MaSach"].ToString() : null;
                string tenMonAn = row["MaSach"] != DBNull.Value ? row["TenSach"].ToString() : null;

                if (lastCategoryId == null || lastCategoryId != maDanhMuc)
                {
                    currentCategoryNode = new TreeNode(tenDanhMuc)
                    {
                        Name = maDanhMuc 
                    };
                    treeView.Nodes.Add(currentCategoryNode);
                    lastCategoryId = maDanhMuc;
                }

                if (!string.IsNullOrEmpty(maMonAn))
                {
                    TreeNode dishNode = new TreeNode(tenMonAn)
                    {
                        Name = maMonAn
                    };
                    currentCategoryNode.Nodes.Add(dishNode);
                }
            }
        }

    }
}
