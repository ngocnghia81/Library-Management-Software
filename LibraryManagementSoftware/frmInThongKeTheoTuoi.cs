using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSoftware
{
    public partial class frmInThongKeTheoTuoi : Form
    {
        DBConnection db = new DBConnection();

        public frmInThongKeTheoTuoi()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            GetReportData();
        }



        private DataTable GetReportData()
        {
            DataTable dt = db.ExecuteStoredProcedure("spThongKeTheoTuoi", null);

            ThongKeTheoTuoi report = new ThongKeTheoTuoi();
            report.SetDataSource(dt);

            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Visible = true;
            crystalReportViewer1.BringToFront();
            return dt;
        }
    }
}
