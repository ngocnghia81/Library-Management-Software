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
using System.Windows.Forms.DataVisualization.Charting;

namespace LibraryManagementSoftware
{
    public partial class frmThongKe : Form
    {
        DBConnection db = new DBConnection();

        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            LoadThongKeLoaiSach();
            LoadThongKeTheoTuoi();
            LoadThongKeSoDocGia();
        }

        private void LoadThongKeLoaiSach()
        {
            string query = @"
        SELECT TL.TenLoai, COUNT(S.MaSach) AS SoLuong
        FROM THELOAISACH TL
        LEFT JOIN SACH S ON TL.MaLoai = S.MaLoai
        GROUP BY TL.TenLoai";

            DataTable dt = db.ExecuteSelect(query);

            chartThongKeLoaiSach.Series.Clear();

            var series = new Series
            {
                ChartType = SeriesChartType.Pie, 
                Name = "Số lượng sách theo thể loại",
                IsValueShownAsLabel = false,     
                IsVisibleInLegend = true
            };

            foreach (DataRow row in dt.Rows)
            {
                string tenLoai = row["TenLoai"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);

                series.Points.AddXY(tenLoai, soLuong);
            }

            chartThongKeLoaiSach.Series.Add(series);

            chartThongKeLoaiSach.Titles.Clear();
            chartThongKeLoaiSach.Titles.Add("Thống kê số lượng sách theo thể loại");
        }


        private void LoadThongKeTheoTuoi()
        {
            string query = @"
                    SELECT
                CASE 
                    WHEN DATEDIFF(YEAR, DOCGIA.NgaySinh, GETDATE()) BETWEEN 0 AND 18 THEN N'0-18 tuổi'
                    WHEN DATEDIFF(YEAR, DOCGIA.NgaySinh, GETDATE()) BETWEEN 19 AND 30 THEN N'19-30 tuổi'
                    WHEN DATEDIFF(YEAR, DOCGIA.NgaySinh, GETDATE()) BETWEEN 31 AND 50 THEN N'31-50 tuổi'
                    ELSE N'Trên 50 tuổi'
                END AS DoTuoi,
                COUNT(DISTINCT CHITIETPHIEUMUON.MaSach) AS SoLuongSachMuon
            FROM
                DOCGIA
            JOIN PHIEUMUON ON DOCGIA.MaDocGia = PHIEUMUON.MaDocGia
            JOIN CHITIETPHIEUMUON ON PHIEUMUON.MaPhieuMuon = CHITIETPHIEUMUON.MaPhieuMuon
            GROUP BY
                CASE 
                    WHEN DATEDIFF(YEAR, DOCGIA.NgaySinh, GETDATE()) BETWEEN 0 AND 18 THEN N'0-18 tuổi'
                    WHEN DATEDIFF(YEAR, DOCGIA.NgaySinh, GETDATE()) BETWEEN 19 AND 30 THEN N'19-30 tuổi'
                    WHEN DATEDIFF(YEAR, DOCGIA.NgaySinh, GETDATE()) BETWEEN 31 AND 50 THEN N'31-50 tuổi'
                    ELSE N'Trên 50 tuổi'
                END
            ORDER BY
                DoTuoi;
            ";

            DataTable dt = db.ExecuteSelect(query);

            chartThongKeTheoTuoi.Series.Clear(); 

            var series = new Series
            {
                ChartType = SeriesChartType.Bar, 
                Name = "Số lượng sách mượn theo độ tuổi",
                IsValueShownAsLabel = true, 
                IsVisibleInLegend = false
            };

            foreach (DataRow row in dt.Rows)
            {
                string doTuoi = row["DoTuoi"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuongSachMuon"]);

                series.Points.AddXY(doTuoi, soLuong); 
            }

            chartThongKeTheoTuoi.Series.Add(series);

            chartThongKeTheoTuoi.Titles.Clear();
            chartThongKeTheoTuoi.Titles.Add("Thống kê số lượng sách mượn theo độ tuổi");
        }


        private void LoadThongKeSoDocGia()
        {
            string query = @"
        SELECT 
            CONVERT(DATE, PHIEUMUON.NgayMuon) AS NgayMuon, 
            COUNT(DISTINCT PHIEUMUON.MaDocGia) AS SoLuongDocGia
        FROM 
            PHIEUMUON
        WHERE 
            PHIEUMUON.NgayMuon >= DATEADD(DAY, -6, GETDATE())  -- Lọc các ngày từ hôm nay đến 6 ngày trước
            AND PHIEUMUON.NgayMuon <= GETDATE()  -- Đảm bảo chỉ lấy dữ liệu từ hôm nay trở về trước
        GROUP BY 
            CONVERT(DATE, PHIEUMUON.NgayMuon)
        ORDER BY 
            NgayMuon DESC;
    ";

            DataTable dt = db.ExecuteSelect(query);

            chartThongKeSoDocGia.Series.Clear(); 

            var series = new Series
            {
                ChartType = SeriesChartType.Column, 
                Name = "Số lượng độc giả mượn sách trong tuần",
                IsValueShownAsLabel = true, 
                IsVisibleInLegend = false
            };

            foreach (DataRow row in dt.Rows)
            {
                DateTime ngayMuon = Convert.ToDateTime(row["NgayMuon"]);  // Ngày mượn
                int soLuongDocGia = Convert.ToInt32(row["SoLuongDocGia"]);

                var dataPoint = new DataPoint
                {
                    XValue = ngayMuon.ToOADate(),  
                    YValues = new double[] { soLuongDocGia }      
                };

                dataPoint.Label = soLuongDocGia.ToString();  

                series.Points.Add(dataPoint); 
            }

            chartThongKeSoDocGia.Series.Add(series);

            chartThongKeSoDocGia.ChartAreas[0].AxisX.LabelStyle.Angle = -45;  
            chartThongKeSoDocGia.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            chartThongKeSoDocGia.ChartAreas[0].AxisX.Interval = 1;
            chartThongKeSoDocGia.ChartAreas[0].AxisX.MajorGrid.Enabled = false; 


            chartThongKeSoDocGia.Titles.Clear();
            chartThongKeSoDocGia.Titles.Add("Thống kê số lượng độc giả mượn sách trong tuần");
        }

        private void chartThongKeLoaiSach_DoubleClick(object sender, EventArgs e)
        {
            List<SqlParameter> parameters = null;
            OpenChildForm(new frmInBaoCaoTheoLoaiSach(parameters));

        }

        private void OpenChildForm(Form childForm)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == childForm.GetType())
                {
                    frm.Activate();
                    return;
                }
            }

            childForm.Dock = DockStyle.Fill;
            childForm.Show();
        }

        private void chartThongKeTheoTuoi_Click(object sender, EventArgs e)
        {

        }

        private void chartThongKeTheoTuoi_DoubleClick(object sender, EventArgs e)
        {
            OpenChildForm(new frmInThongKeTheoTuoi());

        }



    }
}
