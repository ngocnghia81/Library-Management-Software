namespace LibraryManagementSoftware
{
    partial class frmThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartThongKeLoaiSach = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartThongKeTheoTuoi = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartThongKeSoDocGia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeLoaiSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeTheoTuoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeSoDocGia)).BeginInit();
            this.SuspendLayout();
            // 
            // chartThongKeLoaiSach
            // 
            this.chartThongKeLoaiSach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartThongKeLoaiSach.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartThongKeLoaiSach.Legends.Add(legend1);
            this.chartThongKeLoaiSach.Location = new System.Drawing.Point(694, 12);
            this.chartThongKeLoaiSach.Name = "chartThongKeLoaiSach";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartThongKeLoaiSach.Series.Add(series1);
            this.chartThongKeLoaiSach.Size = new System.Drawing.Size(527, 369);
            this.chartThongKeLoaiSach.TabIndex = 0;
            this.chartThongKeLoaiSach.Text = "chart1";
            this.chartThongKeLoaiSach.DoubleClick += new System.EventHandler(this.chartThongKeLoaiSach_DoubleClick);
            // 
            // chartThongKeTheoTuoi
            // 
            this.chartThongKeTheoTuoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartThongKeTheoTuoi.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartThongKeTheoTuoi.Legends.Add(legend2);
            this.chartThongKeTheoTuoi.Location = new System.Drawing.Point(12, 12);
            this.chartThongKeTheoTuoi.Name = "chartThongKeTheoTuoi";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartThongKeTheoTuoi.Series.Add(series2);
            this.chartThongKeTheoTuoi.Size = new System.Drawing.Size(676, 369);
            this.chartThongKeTheoTuoi.TabIndex = 1;
            this.chartThongKeTheoTuoi.Text = "chart1";
            this.chartThongKeTheoTuoi.Click += new System.EventHandler(this.chartThongKeTheoTuoi_Click);
            this.chartThongKeTheoTuoi.DoubleClick += new System.EventHandler(this.chartThongKeTheoTuoi_DoubleClick);
            // 
            // chartThongKeSoDocGia
            // 
            this.chartThongKeSoDocGia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chartThongKeSoDocGia.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartThongKeSoDocGia.Legends.Add(legend3);
            this.chartThongKeSoDocGia.Location = new System.Drawing.Point(12, 387);
            this.chartThongKeSoDocGia.Name = "chartThongKeSoDocGia";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartThongKeSoDocGia.Series.Add(series3);
            this.chartThongKeSoDocGia.Size = new System.Drawing.Size(1209, 314);
            this.chartThongKeSoDocGia.TabIndex = 2;
            this.chartThongKeSoDocGia.Text = "chart1";
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1233, 703);
            this.ControlBox = false;
            this.Controls.Add(this.chartThongKeSoDocGia);
            this.Controls.Add(this.chartThongKeTheoTuoi);
            this.Controls.Add(this.chartThongKeLoaiSach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThongKe";
            this.Text = "frmThongKe";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeLoaiSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeTheoTuoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeSoDocGia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKeLoaiSach;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKeTheoTuoi;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKeSoDocGia;
    }
}