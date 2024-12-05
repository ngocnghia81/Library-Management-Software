﻿using System;
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
    public partial class frmThemNhaXuatBan : Form
    {
        private DBConnection db = new DBConnection();

        public frmThemNhaXuatBan()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Lấy mã NXB lớn nhất hiện tại từ cơ sở dữ liệu
            string query = "SELECT MAX(CAST(SUBSTRING(MaNXB, 4, LEN(MaNXB)-3) AS INT)) AS MaxMaTacGia FROM NXB";
            DataTable dt = db.ExecuteSelect(query);

            if (dt.Rows.Count > 0 && dt.Rows[0]["MaxMaTacGia"] != DBNull.Value)
            {
                // Lấy số lớn nhất từ cột MaxMaTacGia
                int maxAuthorCode = Convert.ToInt32(dt.Rows[0]["MaxMaTacGia"]);

                int newAuthorCode = maxAuthorCode + 1;
                string newAuthorCodeFormatted = "NXB" + newAuthorCode.ToString("D4"); // Định dạng 4 chữ số

                // Hiển thị mã NXB mới trong TextBox
                guna2TextBox1.Text = newAuthorCodeFormatted;
            }
            else
            {
                guna2TextBox1.Text = "NXB0001";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string maTacGia = guna2TextBox1.Text.Trim();
            string tenTacGia = guna2TextBox2.Text.Trim();

            if (string.IsNullOrEmpty(maTacGia) || string.IsNullOrEmpty(tenTacGia))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin (Mã NXB, Tên NXB).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO NXB (MaNXB, TenNXB) VALUES (@MaTacGia, @TenTacGia)";

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
                    MessageBox.Show("Thêm NXB thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                }
                else
                {
                    MessageBox.Show("Không thể thêm NXB vào cơ sở dữ liệu. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
