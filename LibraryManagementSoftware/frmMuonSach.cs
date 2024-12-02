using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSoftware
{
    public partial class frmMuonSach : Form
    {
        private DBConnection db = new DBConnection();

        public frmMuonSach()
        {
            InitializeComponent();
        }

        // Load thông tin độc giả vào combobox
        private void LoadDocGia()
        {
            try
            {
                DataTable dt = db.ExecuteSelect("SELECT MaDocGia, TenDocGia FROM DOCGIA");

                cmbMaDocGia.DataSource = dt;
                cmbMaDocGia.DisplayMember = "TenDocGia";
                cmbMaDocGia.ValueMember = "MaDocGia";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin độc giả: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load thông tin sách vào combobox
        private void LoadSach()
        {
            try
            {
                DataTable dt = db.ExecuteSelect("SELECT MaSach, TenSach FROM SACH WHERE SoLuongKho > 0");

                cmbTenSach.DataSource = dt;
                cmbTenSach.DisplayMember = "TenSach";
                cmbTenSach.ValueMember = "MaSach";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMuonSach_Click(object sender, EventArgs e)
        {
            string maDocGia = cmbMaDocGia.SelectedValue.ToString();
            string maSach = cmbTenSach.SelectedValue.ToString();
            DateTime ngayMuon = DateTime.Now;

            if (string.IsNullOrEmpty(maDocGia) || string.IsNullOrEmpty(maSach))
            {
                MessageBox.Show("Vui lòng chọn độc giả và sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Logic mượn sách ở đây
            // Ví dụ: thêm mượn sách vào database
            try
            {
                string query = "INSERT INTO MUONSACH (MaDocGia, MaSach, NgayMuon) VALUES (@MaDocGia, @MaSach, @NgayMuon)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaDocGia", maDocGia),
                    new SqlParameter("@MaSach", maSach),
                    new SqlParameter("@NgayMuon", ngayMuon)
                };

                db.ExecuteInsert(query, parameters);
                MessageBox.Show("Mượn sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mượn sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện khi bấm nút Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Load dữ liệu khi form được load
        private void frmMuonSach_Load(object sender, EventArgs e)
        {
            LoadDocGia();
            LoadSach();

            // Điều chỉnh font chữ của DataGridView
            dgvSach.Font = new Font("Microsoft Sans Serif", 16);  // Font 16 chữ

            // Điều chỉnh chiều cao của các dòng
            dgvSach.RowTemplate.Height = 30;  // Chiều cao dòng, bạn có thể thay đổi giá trị này

            // Điều chỉnh chiều cao của header cột
            dgvSach.ColumnHeadersHeight = 40;  // Chiều cao của header cột, bạn có thể thay đổi giá trị này

            // Điều chỉnh font chữ cho các ô trong DataGridView
            dgvSach.DefaultCellStyle.Font = new Font("Arial", 12);  // Font chữ của các ô trong bảng
            dgvSach.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12);  // Font chữ của tiêu đề cột

            // Nếu DataGridView chưa có cột, thêm các cột vào
            if (dgvSach.Columns.Count == 0)
            {
                dgvSach.Columns.Add("MaSach", "Mã sách");
                dgvSach.Columns.Add("TenSach", "Tên sách");
            }
        }


        // Thêm sách vào DataGridView khi người dùng chọn
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra ComboBox có giá trị được chọn không
            if (cmbTenSach.SelectedValue == null || string.IsNullOrEmpty(cmbTenSach.Text) || string.IsNullOrEmpty(cmbMaDocGia.Text))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ dữ liệu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy giá trị từ ComboBox sau khi đã kiểm tra
            string maSach = cmbTenSach.SelectedValue.ToString();
            string tenSach = cmbTenSach.Text;

            // Kiểm tra xem sách đã được thêm vào DataGridView chưa
            if(dgvSach.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in dgvSach.Rows)
                {
                    if (row.Cells["MaSach"].Value != null && row.Cells["MaSach"].Value.ToString() == maSach)
                    {
                        MessageBox.Show("Sách này đã được thêm vào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            dgvSach.Rows.Add(maSach, tenSach);
        }

        private void cmbMaDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvSach.Rows.Count > 1)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn đổi khách hàng? Dữ liệu ở bảng sẽ biến mất!",
                                                      "Cảnh báo",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    dgvSach.Rows.Clear();  
                }
                
            }
        }

        private void dgvSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSach.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvSach.SelectedRows[0];

                bool isRowEmpty = selectedRow.Cells.Cast<DataGridViewCell>().All(cell => cell.Value == null || string.IsNullOrEmpty(cell.Value.ToString()));

                if (isRowEmpty)
                {
                    btnXoaSach.Visible = false;
                    btnXoaSach.Enabled = false;
                }
                else
                {
                    btnXoaSach.Visible = true;
                    btnXoaSach.Enabled = true;
                }
            }
            else
            {
                btnXoaSach.Visible = false;
                btnXoaSach.Enabled = false;
            }
        }


        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            if (dgvSach.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvSach.SelectedRows)
                {
                    dgvSach.Rows.RemoveAt(row.Index);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sách để xoá.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMuon_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(cmbMaDocGia.Text) || dgvSach.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn độc giả và ít nhất một cuốn sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin
            string maDocGia = cmbMaDocGia.SelectedValue.ToString();
            DateTime ngayMuon = DateTime.Now;
            DateTime ngayDaoHan = ngayMuon.AddDays(7);

            // Lấy mã phiếu mượn mới (PM<stt>)
            string maPhieuMuon;
            string queryGetNextPhieuMuon = "SELECT ISNULL(MAX(CAST(SUBSTRING(MaPhieuMuon, 3, LEN(MaPhieuMuon)) AS INT)), 0) + 1 FROM PHIEUMUON";
            object result = db.ExecuteScalar(queryGetNextPhieuMuon);
            maPhieuMuon = "PM" + (result != null ? result.ToString() : "1");

            // Thêm vào bảng PHIEUMUON
            string insertPhieuMuonQuery = "INSERT INTO PHIEUMUON (MaPhieuMuon, MaDocGia, NgayMuon, NgayDaoHan) VALUES (@MaPhieuMuon, @MaDocGia, @NgayMuon, @NgayDaoHan)";
            SqlParameter[] parametersPhieuMuon = new SqlParameter[]
            {
        new SqlParameter("@MaPhieuMuon", maPhieuMuon),
        new SqlParameter("@MaDocGia", maDocGia),
        new SqlParameter("@NgayMuon", ngayMuon),
        new SqlParameter("@NgayDaoHan", ngayDaoHan)
            };

            bool resultPhieuMuon = db.ExecuteInsert(insertPhieuMuonQuery, parametersPhieuMuon);
            if (!resultPhieuMuon)
            {
                MessageBox.Show("Không thể tạo phiếu mượn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Duyệt qua DataGridView để thêm chi tiết phiếu mượn
            foreach (DataGridViewRow row in dgvSach.Rows)
            {
                if (row.Cells["MaSach"].Value != null)
                {
                    string maSach = row.Cells["MaSach"].Value.ToString();

                    // Tạo mã chi tiết phiếu mượn tự động
                    string maCTPM;
                    string queryGetNextChiTietPhieuMuon = "SELECT ISNULL(MAX(CAST(SUBSTRING(MaCTPM, 5, LEN(MaCTPM)) AS INT)), 0) + 1 FROM CHITIETPHIEUMUON";
                    object resultCTPM = db.ExecuteScalar(queryGetNextChiTietPhieuMuon);
                    maCTPM = "CTPM" + (resultCTPM != null ? resultCTPM.ToString() : "1");

                    // Thêm vào bảng CHITIETPHIEUMUON
                    string insertChiTietPhieuMuonQuery = "INSERT INTO CHITIETPHIEUMUON (MaCTPM, MaPhieuMuon, MaSach) VALUES (@MaCTPM, @MaPhieuMuon, @MaSach)";
                    SqlParameter[] parametersChiTietPhieuMuon = new SqlParameter[]
                    {
                new SqlParameter("@MaCTPM", maCTPM),
                new SqlParameter("@MaPhieuMuon", maPhieuMuon),
                new SqlParameter("@MaSach", maSach)
                    };

                    bool resultChiTietPhieuMuon = db.ExecuteInsert(insertChiTietPhieuMuonQuery, parametersChiTietPhieuMuon);
                    if (!resultChiTietPhieuMuon)
                    {
                        MessageBox.Show($"Không thể thêm chi tiết phiếu mượn cho sách {maSach}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Cập nhật số lượng sách trong kho
                    string updateSoLuongKhoQuery = "UPDATE SACH SET SoLuongKho = SoLuongKho - 1 WHERE MaSach = @MaSach";
                    SqlParameter[] parametersSoLuongKho = new SqlParameter[]
                    {
                new SqlParameter("@MaSach", maSach)
                    };

                    bool resultUpdateKho = db.ExecuteUpdate(updateSoLuongKhoQuery, parametersSoLuongKho);
                    if (!resultUpdateKho)
                    {
                        MessageBox.Show($"Không thể cập nhật số lượng sách {maSach}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            MessageBox.Show($"Mượn sách thành công! Mã phiếu mượn: {maPhieuMuon}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
