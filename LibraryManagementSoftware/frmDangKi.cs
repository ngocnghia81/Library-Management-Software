using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Net.Mime.MediaTypeNames;

namespace LibraryManagementSoftware
{
    public partial class frmDangKi : Form
    {

        DBConnection db = new DBConnection();

        void FormatInputEnter(TextBox txt, string placeholder, bool isPassword)
        {
            if (txt.Text != placeholder) return;
            txt.ForeColor = Color.Black;
            txt.Text = "";
            if (!isPassword) return;
            txtPassword.PasswordChar = '*';
        }

        void FormatInputLeave(TextBox txt, string placeholder, bool isPassword)
        {
            if (txt.Text != "") return;
            txt.ForeColor = Color.LightGray;
            txt.Text = placeholder;
            if (!isPassword) return;
            txtPassword.PasswordChar = '\0';
        }

        bool XacNhanPassword()
        {
            if (txtNhapLai.Text == txtPassword.Text) return true;
            MessageBox.Show("Mật khẩu không giống nhau");
            return false;
        }

        bool ThemDocGia(string madg)
        {
            string sql = string.Format("SELECT dbo.fn_CheckDuplicate('{0}', '{1}', '{2}');", txtSDT.Text, txtEmail.Text, txtCCCD.Text);
            string message = db.ExecuteScalar(sql).ToString();
            if (message != "")
            {
                MessageBox.Show(message);
                return false;
            }

            string query = "INSERT INTO DocGia (MaDocGia, TenDocGia, NgaySinh, SDT, DiaChi, NgayDangKy, CCCD, GioiTinh) VALUES (@MaDocGia,@TenDocGia,Getdate(),@SDT,'',Getdate(),@CCCD,@gt)";
            string gt = "";
            if (radioButton1.Checked)
            {
                gt = "Nam";
            }
            else gt = "Nữ";
            // Define parameters
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaDocGia", madg),
                new SqlParameter("@TenDocGia", txtHoTen.Text),
                new SqlParameter("@CCCD", txtCCCD.Text),
                new SqlParameter("@SDT", txtSDT.Text),
                new SqlParameter("@gt", gt)
            };
            bool isInserted = db.ExecuteInsert(query, parameters);
            //txtHoTen.Text = query;
            if (isInserted)
            {
                
                return true;
            }
            else
            {
                
                return false;
            }

        }

        public frmDangKi()
        {
            InitializeComponent();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                System.Windows.Forms.Application.Exit();
            }

            

        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            FormatInputEnter(txt, txt.Tag.ToString(), false);

        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            FormatInputLeave(txt,txt.Tag.ToString(), false);
            
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.Show();
            this.Close();
        }

        private void frmDangKi_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã nhập đủ thông tin chưa
            if (txtEmail.Text == "Email" || txtPassword.Text == "Password" || txtNhapLai.Text == "Nhập lại password" || txtHoTen.Text == "Họ Tên" || txtSDT.Text == "SDT")
            {
                MessageBox.Show("Nhập đầy đủ thông tin", "Nhập liệu sai", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sử dụng ValidationHelper để kiểm tra email
            if (!ValidationHelper.IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Định dạng email không hợp lệ", "Nhập liệu sai", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sử dụng ValidationHelper để kiểm tra số điện thoại
            if (!ValidationHelper.IsValidPhoneNumber(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Nhập liệu sai", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xác nhận mật khẩu
            if (!XacNhanPassword()) return;

            // Kiểm tra độ mạnh của mật khẩu bằng ValidationHelper
            if (!ValidationHelper.IsValidPassword(txtPassword.Text))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự", "Nhập liệu sai", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Define your SQL INSERT query
            string query = "INSERT INTO TAIKHOAN VALUES (@Email, @Password, @MaDocGia,N'Vai Trò',0)";
            string madg = TienIch.TaoMa("DG", "MaDocGia", "DocGia"); 
            // Chèn thông tin độc giả
            bool isDocGiaInserted = ThemDocGia(madg);

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Email", txtEmail.Text),
                new SqlParameter("@Password", txtPassword.Text),
                new SqlParameter("@MaDocGia", madg)
            };

            // Thực hiện chèn dữ liệu vào bảng TAIKHOAN
            bool isInserted = db.ExecuteInsert(query, parameters);

            // Kiểm tra kết quả
            if (isInserted && isDocGiaInserted)
            {
                MessageBox.Show("Đăng kí thành công!");
                frmDangNhap frmDangNhap = new frmDangNhap();
                frmDangNhap.Show();
                this.Close();
 
            }
            else
            {
                MessageBox.Show("Đăng kí thất bại");
            }
        }

        private void frmDangKi_Load(object sender, EventArgs e)
        {
            
        }
    }
}
