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
    public partial class frmBaoCaoLichSuMuonSach : Form
    {
        DBConnection db = new DBConnection();

        List<SqlParameter> parameters;
        public frmBaoCaoLichSuMuonSach(List<SqlParameter> parameters)
        {
            this.parameters = parameters;
            InitializeComponent();
        }

        private void firnBaoCaoLichSuMuonSach_Load(object sender, EventArgs e)
        {
            GetReportData();
        }

        private DataTable GetReportData()
        {
            DataTable dt = db.ExecuteStoredProcedure("sp_LichSuMuonSach", parameters.ToArray());

            LichSuMuonSachReport report = new LichSuMuonSachReport();
            report.SetDataSource(dt);

            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Visible = true;
            crystalReportViewer1.BringToFront();
            return dt;
        }
    }
}
