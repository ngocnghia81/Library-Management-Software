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
using static System.Net.Mime.MediaTypeNames;

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

        string LayMaDocGiaLonNhat()
        {
            if (db == null)
            {
                throw new InvalidOperationException("Database connection is not initialized.");
            }
            return db.ExecuteFunction("func_LayMaDocGiaLonNhat").ToString();
        }

        string ThemMaDocGia()
        {
            string prefix = "DG";
            int currentNumber;
            int lengthOfNumberPart = 3;
            string maxID = LayMaDocGiaLonNhat();
            // Tách phần số từ mã, ví dụ: lấy '020' từ 'DG020'
            string numberPart = maxID.Substring(prefix.Length);

            // Chuyển phần số sang int, ví dụ: '020' -> 20
            currentNumber = int.Parse(numberPart) + 1;

            return string.Format("{0}{1}", prefix, currentNumber.ToString().PadLeft(lengthOfNumberPart, '0'));
        }

        bool ThemDocGia()
        {
            dateTime.Format = DateTimePickerFormat.Custom;
            dateTime.CustomFormat = "yyyy-MM-dd"; // Định dạng năm-tháng-ngày

            string query = "INSERT INTO DocGia (MaDocGia, TenDocGia, NgaySinh, SDT, DiaChi, NgayDangKy, CapThanhVien) VALUES (@MaDocGia,@TenDocGia,@NgaySinh,@SDT,'',Getdate(),'')";

            // Define parameters
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaDocGia", ThemMaDocGia()),
                new SqlParameter("@TenDocGia", txtHoTen.Text),
                new SqlParameter("@NgaySinh", dateTime.Text),
                new SqlParameter("@SDT", txtSDT.Text),
            };
            bool isInserted = db.ExecuteInsert(query, parameters);
            //txtHoTen.Text = query;
            if (isInserted)
            {
                MessageBox.Show("User inserted successfully!");
                return true;
            }
            else
            {
                MessageBox.Show("Failed to insert user.");
                return false;
            }

        }

        public frmDangKi()
        {
            InitializeComponent();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();

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
            DialogResult dialog = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK) return;
            e.Cancel = true;
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
            string query = "INSERT INTO TAIKHOAN (Email,HashedPassword,MaDocGia) VALUES (@Email, @Password, @MaDocGia)";

            // Chèn thông tin độc giả
            bool isDocGiaInserted = ThemDocGia();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Email", txtEmail.Text),
                new SqlParameter("@Password", txtPassword.Text),
                new SqlParameter("@MaDocGia", LayMaDocGiaLonNhat())
            };

            // Thực hiện chèn dữ liệu vào bảng TAIKHOAN
            bool isInserted = db.ExecuteInsert(query, parameters);

            // Kiểm tra kết quả
            if (isInserted && isDocGiaInserted)
            {
                MessageBox.Show("Account inserted successfully!");
            }
            else
            {
                MessageBox.Show("Failed to insert account.");
            }
        }

        private void frmDangKi_Load(object sender, EventArgs e)
        {
            
        }
    }
}
