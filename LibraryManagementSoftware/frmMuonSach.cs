using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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



        // Load thông tin sách vào combobox
        private void LoadSach()
        {
            try
            {
                DataTable dt = db.ExecuteSelect("SELECT MaSach, TenSach FROM SACH WHERE SoLuongKho > 0");

                cmbTenSach.DataSource = dt;
                cmbTenSach.DisplayMember = "TenSach";
                cmbTenSach.ValueMember = "MaSach";

                TienIch.GoiYComboBox(cmbTenSach, "TenSach");

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Lỗi khi tải thông tin sách: {0}",ex.Message), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMuonSach_Click(object sender, EventArgs e)
        {
            string maDocGia = guna2TextBoxMaDG.Text.ToString();
            string maSach = cmbTenSach.SelectedValue.ToString();
            DateTime ngayMuon = DateTime.Now;

            if (string.IsNullOrEmpty(maDocGia) || string.IsNullOrEmpty(maSach))
            {
                MessageBox.Show("Vui lòng chọn độc giả và sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
                MessageBox.Show(string.Format("Lỗi khi mượn sách: {0}",ex.Message), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMuonSach_Load(object sender, EventArgs e)
        {
            LoadSach();

            dgvSach.Font = new Font("Microsoft Sans Serif", 16);  

            dgvSach.RowTemplate.Height = 40; 

            dgvSach.ColumnHeadersHeight = 40;  

            dgvSach.DefaultCellStyle.Font = new Font("Arial", 12);  
            dgvSach.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12);  

            if (dgvSach.Columns.Count == 0)
            {
                dgvSach.Columns.Add("MaSach", "Mã sách");
                dgvSach.Columns.Add("TenSach", "Tên sách");
            }
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (cmbTenSach.SelectedValue == null || string.IsNullOrEmpty(cmbTenSach.Text) || string.IsNullOrEmpty(guna2TextBoxMaDG.Text))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ dữ liệu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maDocGia = guna2TextBoxMaDG.Text.ToString();
            string maSach = cmbTenSach.SelectedValue.ToString();
            string tenSach = cmbTenSach.Text;

            foreach (DataGridViewRow row in dgvSach.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["MaSach"].Value != null && row.Cells["MaSach"].Value.ToString() == maSach)
                {
                    //MessageBox.Show("Sách này đã được thêm vào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            string query = @"
                SELECT COUNT(*)
                FROM CHITIETPHIEUMUON CTPM
                JOIN PHIEUMUON PM ON CTPM.MaPhieuMuon = PM.MaPhieuMuon
                WHERE PM.MaDocGia = @MaDocGia AND CTPM.MaSach = @MaSach";

            SqlParameter[] parametersCheckMuon = new SqlParameter[]
            {
                new SqlParameter("@MaDocGia", maDocGia),
                new SqlParameter("@MaSach", maSach)
            };

            DataTable dt = db.ExecuteSelect(query, parametersCheckMuon);
            int countMuon = Convert.ToInt32(dt.Rows[0][0].ToString());

            if (countMuon > 0)
            {
                DialogResult confirm = MessageBox.Show(
                    "Độc giả đã mượn sách " + tenSach + " trước đây. Bạn có muốn mượn lại không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.No)
                {
                    return; 
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
            if (string.IsNullOrEmpty(guna2TextBoxMaDG.Text) || dgvSach.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn độc giả và ít nhất một cuốn sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maDocGia = guna2TextBoxMaDG.Text.ToString();
            DateTime ngayMuon = DateTime.Now;
            DateTime ngayDaoHan = ngayMuon.AddDays(7);

            string maPhieuMuon;
            string queryGetNextPhieuMuon = "SELECT ISNULL(MAX(CAST(SUBSTRING(MaPhieuMuon, 3, LEN(MaPhieuMuon)) AS INT)), 0) + 1 FROM PHIEUMUON";
            object result = db.ExecuteScalar(queryGetNextPhieuMuon);
            maPhieuMuon = "PM" + (result != null ? result.ToString() : "1");

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

            foreach (DataGridViewRow row in dgvSach.Rows)
            {
                if (row.Cells["MaSach"].Value != null)
                {
                    string maSach = row.Cells["MaSach"].Value.ToString();

                    string maCTPM;
                    string queryGetNextChiTietPhieuMuon = "SELECT ISNULL(MAX(CAST(SUBSTRING(MaCTPM, 5, LEN(MaCTPM)) AS INT)), 0) + 1 FROM CHITIETPHIEUMUON";
                    object resultCTPM = db.ExecuteScalar(queryGetNextChiTietPhieuMuon);
                    maCTPM = "CTPM" + (resultCTPM != null ? resultCTPM.ToString() : "1");

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
                        MessageBox.Show(string.Format("Không thể thêm chi tiết phiếu mượn cho sách {0}.",maSach), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string updateSoLuongKhoQuery = "UPDATE SACH SET SoLuongKho = SoLuongKho - 1 WHERE MaSach = @MaSach";
                    SqlParameter[] parametersSoLuongKho = new SqlParameter[]
                    {
                         new SqlParameter("@MaSach", maSach)
                    };

                    bool resultUpdateKho = db.ExecuteUpdate(updateSoLuongKhoQuery, parametersSoLuongKho);
                    if (!resultUpdateKho)
                    {
                        MessageBox.Show(string.Format("Không thể cập nhật số lượng sách {0}.",maSach), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            OpenChildForm(new frmInPhieuMuon(new List<SqlParameter> { new SqlParameter("@MaPhieuMuon", maPhieuMuon) }));

            MessageBox.Show(string.Format("Mượn sách thành công! Mã phiếu mượn: {0}", maPhieuMuon), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string ma = guna2TextBoxMaDG.Text; 

            string query = @"
                    SELECT DOCGIA.MaDocGia, DOCGIA.TenDocGia, DOCGIA.NgaySinh, DOCGIA.SDT, DOCGIA.DiaChi, DOCGIA.NgayDangKy, 
                           TAIKHOAN.Email
                    FROM DOCGIA
                    INNER JOIN TAIKHOAN ON DOCGIA.MaDocGia = TAIKHOAN.MaDocGia
                    WHERE DOCGIA.MaDocGia = @Ma AND TAIKHOAN.VaiTro = 'user'";

            SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter("@Ma", ma)
            };

            DataTable dt = db.ExecuteSelect(query, parameters);

            if (dt.Rows.Count > 0)
            {
                // Lấy thông tin từ dòng đầu tiên của DataTable
                DataRow row = dt.Rows[0];

                // Gán thông tin vào các Label
                guna2HtmlLabelTen.Text = "Tên độc giả: " + row["TenDocGia"].ToString();
                guna2HtmlLabelNgaySinh.Text = "Ngày sinh: " + DateTime.Parse(row["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                guna2HtmlLabelSDT.Text = "SĐT: " + row["SDT"].ToString();
                guna2HtmlLabelEmail.Text = "Email: " + row["Email"].ToString();
                guna2HtmlLabelNgayDK.Text = "Ngày đăng ký: " + DateTime.Parse(row["NgayDangKy"].ToString()).ToString("dd/MM/yyyy");
            }
            else
            {
                // Thông báo nếu không tìm thấy thông tin độc giả
                MessageBox.Show("Không tìm thấy thông tin độc giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
