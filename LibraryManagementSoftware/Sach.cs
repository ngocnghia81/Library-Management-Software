using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSoftware
{
    internal class Sach
    {
        // Mã sách (khóa chính)
        public string MaSach { get; set; }

        // Tên sách (Không thể null)
        public string TenSach { get; set; }

        // Hình ảnh (Không thể null)
        public string HinhAnh { get; set; }

        // Mã nhà xuất bản (Khóa ngoại tới bảng NXB)
        public string MaNXB { get; set; }

        // Mã loại sách (Khóa ngoại tới bảng THELOAISACH)
        public string MaLoai { get; set; }

        // Mô tả (Không thể null)
        public string MoTa { get; set; }

        // Mã kệ sách (Khóa ngoại tới bảng KESACH)
        public string MaKe { get; set; }

        public int SoLuongKho { get; set; }
        public int TongSoLuong { get; set; }


        public Sach(DataRow dr)
        {
            MaSach = dr["MaSach"].ToString();
            TenSach = dr["TenSach"].ToString();
            HinhAnh = dr["HinhAnh"].ToString();
            MaNXB = dr["MaNXB"].ToString();
            MaLoai = dr["MaLoai"].ToString();
            MoTa = dr["MoTa"].ToString();
            MaKe = dr["MaKe"].ToString();
            SoLuongKho = int.Parse(dr["SoLuongKho"].ToString());
            TongSoLuong = int.Parse(dr["TongSoLuong"].ToString());
        }
    }
}
