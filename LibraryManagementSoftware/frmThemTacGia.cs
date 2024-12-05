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
            // Lấy mã tác giả lớn nhất hiện tại từ cơ sở dữ liệu
            string query = "SELECT MAX(CAST(SUBSTRING(MaTacGia, 3, LEN(MaTacGia)-2) AS INT)) AS MaxMaTacGia FROM TACGIA";
            DataTable dt = db.ExecuteSelect(query);

            if (dt.Rows.Count > 0 && dt.Rows[0]["MaxMaTacGia"] != DBNull.Value)
            {
                // Lấy số lớn nhất từ cột MaxMaTacGia
                int maxAuthorCode = Convert.ToInt32(dt.Rows[0]["MaxMaTacGia"]);

                // Tạo mã tác giả mới, cộng thêm 1 vào giá trị lớn nhất và định dạng lại thành 4 chữ số
                int newAuthorCode = maxAuthorCode + 1;
                string newAuthorCodeFormatted = "TG" + newAuthorCode.ToString("D4"); // Định dạng 4 chữ số

                // Hiển thị mã tác giả mới trong TextBox
                guna2TextBox1.Text = newAuthorCodeFormatted;
            }
            else
            {
                // Nếu không có tác giả nào, tạo mã đầu tiên là TG0001
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
