using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSoftware
{
    public partial class frmThemTacGia : Form
    {
        private DBConnection db = new DBConnection();

        public frmThemTacGia()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT MAX(CAST(SUBSTRING(MaKe, 3, LEN(MaKe)-2) AS INT)) AS MaxMaTacGia FROM KESACH";
            DataTable dt = db.ExecuteSelect(query);

            if (dt.Rows.Count > 0 && dt.Rows[0]["MaxMaTacGia"] != DBNull.Value)
            {
                int maxAuthorCode = Convert.ToInt32(dt.Rows[0]["MaxMaTacGia"]);

                int newAuthorCode = maxAuthorCode + 1;
                string newAuthorCodeFormatted = "TG" + newAuthorCode.ToString("D4"); 

                guna2TextBox1.Text = newAuthorCodeFormatted;
            }
            else
            {
                guna2TextBox1.Text = "TG0001";
            }
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string maTacGia = guna2TextBox1.Text.Trim();
            string tenTacGia = guna2TextBox2.Text.Trim();

            if (string.IsNullOrEmpty(maTacGia) || string.IsNullOrEmpty(tenTacGia))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin (Mã tác giả, Tên tác giả).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO TACGIA (MaTacGia, TenTacGia) VALUES (@MaTacGia, @TenTacGia)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaTacGia", maTacGia),
        new SqlParameter("@TenTacGia", tenTacGia)
            };

            try
            {
                bool result = db.ExecuteInsert(query, parameters);

                if (result)
                {
                    MessageBox.Show("Thêm tác giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                }
                else
                {
                    MessageBox.Show("Không thể thêm tác giả vào cơ sở dữ liệu. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
