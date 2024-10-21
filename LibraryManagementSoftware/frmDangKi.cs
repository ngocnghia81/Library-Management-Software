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
using static System.Net.Mime.MediaTypeNames;

namespace LibraryManagementSoftware
{
    public partial class frmDangKi : Form
    {

        DBConnection db = new DBConnection("");

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

        string ThemMaDocGia()
        {
            string prefix = "DG";
            int currentNumber;
            int lengthOfNumberPart = 3;

            string maxID = db.ExecuteFunction("func_LayMaDocGiaLonNhat").ToString();

            // Tách phần số từ mã, ví dụ: lấy '020' từ 'DG020'
            string numberPart = maxID.Substring(prefix.Length);

            // Chuyển phần số sang int, ví dụ: '020' -> 20
            currentNumber = int.Parse(numberPart) + 1;

            return $"{prefix}{currentNumber.ToString().PadLeft(lengthOfNumberPart, '0')}";
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
            this.Close();
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
            if (txtEmail.Text == "Email" || txtPassword.Text == "Password" || txtNhapLai.Text == "Nhập lại password" || txtHoTen.Text == "Họ Tên" || txtSDT.Text == "SDT")
            {
                MessageBox.Show("Nhập đầy đủ thông tin", "Nhập liệu sai", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtEmail.Text.Contains("@gmail.com"))
            {
                MessageBox.Show("Định dạng mail sai", "Nhập liệu sai", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!XacNhanPassword()) return;

            // Define your SQL INSERT query
            string query = $"INSERT INTO TAIKHOAN (Email,HashedPassword,MaDocGia) VALUES (@email,@Password,@MaDocGia)";

            // Define parameters
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@email", txtEmail.Text),
                new SqlParameter("@Password", txtPassword.Text),    
                new SqlParameter("@MaDocGia", ThemMaDocGia())
             };
            // Call the method
            bool isInserted = db.ExecuteInsert(query, parameters);
            bool isDocGiaInserted = ThemDocGia();
            if (isInserted||isDocGiaInserted)
            {
                MessageBox.Show("Account inserted successfully!");
            }
            else
            {
                MessageBox.Show("Failed to insert account.");
            }

        }
    } 
}
