using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryManagementSoftware
{
    public static class ValidationHelper
    {
        // Phương thức kiểm tra email hợp lệ
        public static bool IsValidEmail(string email)
        {
            // Biểu thức chính quy để kiểm tra định dạng email
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        // Phương thức kiểm tra số điện thoại hợp lệ (10 chữ số)
        public static bool IsValidPhoneNumber(string phone)
        {
            // Biểu thức chính quy để kiểm tra số điện thoại 10 chữ số
            string pattern = @"^\d{10}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(phone);
        }

        // Bạn có thể thêm các phương thức kiểm tra khác nếu cần, ví dụ: kiểm tra mật khẩu
        public static bool IsValidPassword(string password)
        {
            // Kiểm tra độ dài mật khẩu và các yêu cầu đặc biệt (có thể tùy chỉnh)
            return password.Length >= 8; // Ví dụ: mật khẩu phải dài ít nhất 8 ký tự
        }

        public static bool IsNumeric(string input)
        {
            // Kiểm tra xem chuỗi có phải là số hay không
            return !string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^\d+$");
        }
    }
}
