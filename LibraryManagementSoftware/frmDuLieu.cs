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
    public partial class frmDuLieu : Form
    {
        DBConnection db = new DBConnection();

        public frmDuLieu()
        {
            InitializeComponent();
        }

        private void frmDuLieu_Load(object sender, EventArgs e)
        {
            LoadMethod();
        }

        private void LoadMethod()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaPhuongThuc", typeof(string));
            dt.Columns.Add("TenPhuongThuc", typeof(string));

            DataRow row1 = dt.NewRow();
            row1["MaPhuongThuc"] = "FULL";
            row1["TenPhuongThuc"] = "Sao lưu đầy đủ";
            dt.Rows.Add(row1);

            DataRow row2 = dt.NewRow();
            row2["MaPhuongThuc"] = "DIFFERENTIAL";
            row2["TenPhuongThuc"] = "Sao lưu phân biệt";
            dt.Rows.Add(row2);

            cbbMeThod.DataSource = dt;
            cbbMeThod.DisplayMember = "TenPhuongThuc";
            cbbMeThod.ValueMember = "MaPhuongThuc";  
            cbbMeThod.SelectedIndex = 0;  
        }


        private void btnRes_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;

            
            string restoreFilePath = textBoxR.Text; 
            string databaseName = "QL_ThuVien"; 

            if (string.IsNullOrEmpty(restoreFilePath))
            {
                MessageBox.Show("Vui lòng chọn file sao lưu.");
                return;
            }
            try
            {
                RestoreDatabase(databaseName, restoreFilePath);
                MessageBox.Show("Khôi phục cơ sở dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi khôi phục: " + ex.Message);
            }
        }

        private void RestoreDatabase(string databaseName, string restoreFilePath)
        {
            SqlConnection conn = db.GetConnection();
            try
            {
                conn.Open();

                string offlineQuery = string.Format("ALTER DATABASE [{0}] SET OFFLINE WITH ROLLBACK IMMEDIATE;", databaseName);
                using (SqlCommand cmd = new SqlCommand(offlineQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Thực hiện khôi phục cơ sở dữ liệu
                string restoreQuery = string.Format("RESTORE DATABASE [{0}] FROM DISK = '{1}' WITH REPLACE;", databaseName, restoreFilePath);
                using (SqlCommand cmd = new SqlCommand(restoreQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Đưa cơ sở dữ liệu về trạng thái online
                string onlineQuery = string.Format("ALTER DATABASE [{0}] SET ONLINE;", databaseName);
                using (SqlCommand cmd = new SqlCommand(onlineQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện khôi phục: " + ex.Message);
            }
            finally
            {
                conn.Close();
                progressBar1.Visible = false;
            }
        }

        private void btnpathRes_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Backup Files (*.bak)|*.bak"; 

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string currentDateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                string restoreFileName = @"\" + currentDateTime + "_restore.bak";

                textBoxR.Text = openFileDialog.FileName ;
                
            }

        }

         private void btnBak_Click(object sender, EventArgs e)
        {
            string backupPath = textBoxBK.Text; 
            string databaseName = "QL_ThuVien"; 

            if (string.IsNullOrEmpty(backupPath))
            {
                MessageBox.Show("Vui lòng chọn đường dẫn sao lưu.");
                return;
            }

            string method = cbbMeThod.SelectedValue.ToString(); 
            try
            {
                BackupDatabase(databaseName, backupPath, method);
                MessageBox.Show("Sao lưu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi sao lưu: " + ex.Message);
            }
        }

        // Phương thức thực hiện sao lưu
        private void BackupDatabase(string databaseName, string backupFilePath, string method)
        {
            SqlConnection conn = db.GetConnection();
            try
            {
                conn.Open();
                string backupQuery = "";

                if (method == "FULL")
                {
                    backupQuery = string.Format("BACKUP DATABASE [{0}] TO DISK = '{1}' WITH INIT, COMPRESSION;", databaseName, backupFilePath);
                }
                else if (method == "DIFFERENTIAL")
                {
                    backupQuery = string.Format("BACKUP DATABASE [{0}] TO DISK = '{1}' WITH DIFFERENTIAL, COMPRESSION;", databaseName, backupFilePath);
                }

                using (SqlCommand cmd = new SqlCommand(backupQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện sao lưu: " + ex.Message);
            }

            finally
            {
                conn.Close();
            }
        }


        private void btnpathBk_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn thư mục
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy thời gian hiện tại để đặt tên file sao lưu
                string currentDateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                // Lấy phương thức sao lưu đã chọn từ ComboBox
                string selectedMethod = cbbMeThod.SelectedValue.ToString();

                // Tạo tên file sao lưu với loại backup (Full hoặc Differential)
                string backupFileName = @"\" + currentDateTime + "_" + selectedMethod.ToLower() + "_backup.bak";

                // Đặt đường dẫn file sao lưu vào textBoxBK
                textBoxBK.Text = folderDialog.SelectedPath + backupFileName;
            }
        }

    }
}
