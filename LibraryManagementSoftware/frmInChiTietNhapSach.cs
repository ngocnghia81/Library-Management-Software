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
    public partial class frmInChiTietNhapSach : Form
    {
        List<SqlParameter> parameters;
        DBConnection db = new DBConnection();
        private bool isReportLoaded = false;

        public frmInChiTietNhapSach(List<SqlParameter> parameters)
        {
            this.parameters = parameters;
            InitializeComponent();
        }

        private void frmInChiTietNhapSach_Load(object sender, EventArgs e)
        {
            if (!isReportLoaded)
            {
                GetReportData();
                isReportLoaded = true;
            }
        }

        private DataTable GetReportData()
        {
            if (parameters == null)
            {
                MessageBox.Show("Parameters are null");
                return null; // hoặc xử lý lỗi nếu cần
            }

            DataTable dt = db.ExecuteStoredProcedure("spThongKeChiTietNhapSach", parameters.ToArray());

            ThongKeDonNhap report = new ThongKeDonNhap();
            report.SetDataSource(dt);

            // Kiểm tra xem tham số @MaNhap có tồn tại hay không
            var maNhapParam = this.parameters.FirstOrDefault(p => p.ParameterName == "@MaNhap");

            if (maNhapParam != null)
            {
                string maNhap = maNhapParam.Value.ToString();

                // Thiết lập giá trị tham số cho Crystal Report
                report.Parameter_MaNhap.CurrentValues.Clear();
                report.Parameter_MaNhap.CurrentValues.Add(new CrystalDecisions.Shared.ParameterDiscreteValue { Value = maNhap });
            }
            else
            {
                // Xử lý trường hợp không tìm thấy tham số @MaNhap, nếu cần thiết
                MessageBox.Show("Không tìm thấy tham số @MaNhap!");
            }

            // Hiển thị báo cáo trong CrystalReportViewer
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Visible = true;
            crystalReportViewer1.BringToFront();

            return dt;
        }


    }
}
