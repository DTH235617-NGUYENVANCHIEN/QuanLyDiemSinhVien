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


namespace QuanLyDiemSinhVien.GUI
{
    public partial class fDiemSinhVien : Form
    {
        SqlConnection conn = new SqlConnection();
        private bool isAdding = false;
        private string MaSV_Cu = "";
        private string MaMH_Cu = "";
        private int HocKy_Cu = 0;
        private string NamHoc_Cu = "";
        public fDiemSinhVien()
        {
            InitializeComponent();
        }
        private string TinhDiemChu(float diemTongKet)
        {
            if (diemTongKet >= 9.0) return "A";
            if (diemTongKet >= 8.0) return "B+";
            if (diemTongKet >= 7.0) return "B";
            if (diemTongKet >= 6.0) return "C+";
            if (diemTongKet >= 5.0) return "C";
            if (diemTongKet >= 4.0) return "D+";
            if (diemTongKet >= 3.0) return "D";
            return "F";
        }
        private void MoNut(bool t)
        {
            cbTenSV.Enabled = !t;
            cbMonHoc.Enabled = !t;
            cbHocKy.Enabled = !t;
            txtNamhoc.Enabled = !t;
            txtDiemthanhphan.Enabled = !t;
            txtDiemthi.Enabled = !t;

            btnThem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnThoat.Enabled = t;
            btnLamlai.Enabled = !t;
            btnLuu.Enabled = !t;
        }

        private void LoadSinhVien()
        {
            string sqlSV = "SELECT MaSV, HoTen FROM SINHVIEN";
            SqlDataAdapter daSV = new SqlDataAdapter(sqlSV, conn);
            DataTable dtSV = new DataTable();
            daSV.Fill(dtSV);

            cbTenSV.DataSource = dtSV;
            cbTenSV.DisplayMember = "HoTen";
            cbTenSV.ValueMember = "MaSV";
        }

        private void LoadMonHoc()
        {
            string sqlMH = "SELECT MaMH, TenMH FROM MONHOC";
            SqlDataAdapter daMH = new SqlDataAdapter(sqlMH, conn);
            DataTable dtMH = new DataTable();
            daMH.Fill(dtMH);

            cbMonHoc.DataSource = dtMH;
            cbMonHoc.DisplayMember = "TenMH";
            cbMonHoc.ValueMember = "MaMH";
        }

        private void LoadDiemData()
        {
            
            string sqlDiem = @"SELECT D.MaSV, D.MaMH, D.HocKy, D.NamHoc, D.DiemThanhPhan, D.DiemThi, D.DiemTongKet, D.DiemChu, 
                                     S.HoTen AS TenSinhVien, M.TenMH AS TenMonHoc
                              FROM DIEM D 
                              JOIN SINHVIEN S ON D.MaSV = S.MaSV
                              JOIN MONHOC M ON D.MaMH = M.MaMH
                              ORDER BY D.NamHoc DESC, D.HocKy ASC, S.MaSV ASC, M.MaMH ASC";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlDiem, conn);
            DataTable data = new DataTable();
            dataAdapter.Fill(data);
            dgvDiem.AutoGenerateColumns = false;
            dgvDiem.DataSource = data;
            LoadSinhVien();
            LoadMonHoc();

            cbTenSV.DataBindings.Clear();
            cbMonHoc.DataBindings.Clear();
            cbHocKy.DataBindings.Clear();
            txtNamhoc.DataBindings.Clear();
            txtDiemthanhphan.DataBindings.Clear();
            txtDiemthi.DataBindings.Clear();

            // Thêm binding mới
            // (Phải đảm bảo 'data' (dgvDiem.DataSource) có dữ liệu thì binding mới hoạt động)
            cbTenSV.DataBindings.Add("SelectedValue", dgvDiem.DataSource, "MaSV", false, DataSourceUpdateMode.Never);
            cbMonHoc.DataBindings.Add("SelectedValue", dgvDiem.DataSource, "MaMH", false, DataSourceUpdateMode.Never);
            cbHocKy.DataBindings.Add("Text", dgvDiem.DataSource, "HocKy", false, DataSourceUpdateMode.Never);
            txtNamhoc.DataBindings.Add("Text", dgvDiem.DataSource, "NamHoc", false, DataSourceUpdateMode.Never);
            txtDiemthanhphan.DataBindings.Add("Text", dgvDiem.DataSource, "DiemThanhPhan", false, DataSourceUpdateMode.Never);
            txtDiemthi.DataBindings.Add("Text", dgvDiem.DataSource, "DiemThi", false, DataSourceUpdateMode.Never);
        }
        

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fDiemSinhVien_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    // Đảm bảo ConnectionString khớp với yêu cầu CSDL
                    conn.ConnectionString = @"server=.; Database=QLDSV;Integrated Security=True";
                    conn.Open();
                }

                // Tải dữ liệu và thiết lập Binding
                LoadDiemData();
                MoNut(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL hoặc tải dữ liệu ban đầu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Đóng form nếu không thể kết nối/tải dữ liệu
                this.Close();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            MoNut(false);

            cbTenSV.SelectedIndex = -1;
            cbMonHoc.SelectedIndex = -1;
            cbHocKy.Text = "";
            txtNamhoc.Text = "";
            txtDiemthanhphan.Text = "";
            txtDiemthi.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDiem.CurrentRow == null) return;

            // Lấy Khóa Chính CŨ từ DataGridView
            string maSV = dgvDiem.CurrentRow.Cells["MaSV"].Value.ToString();
            string maMH = dgvDiem.CurrentRow.Cells["MaMH"].Value.ToString();
            int hocKy = int.Parse(dgvDiem.CurrentRow.Cells["HocKy"].Value.ToString());
            string namHoc = dgvDiem.CurrentRow.Cells["NamHoc"].Value.ToString();

            // Hiển thị thông tin điểm đang bị xóa
            string info = $"SV: {maSV} | MH: {maMH} | HK: {hocKy} | NH: {namHoc}";

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa điểm này?\n\n{info}", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    string deleteSql = @"DELETE FROM DIEM 
                                         WHERE MaSV = @MaSV AND MaMH = @MaMH AND HocKy = @HocKy AND NamHoc = @NamHoc";

                    using (SqlCommand cmd = new SqlCommand(deleteSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.Parameters.AddWithValue("@MaMH", maMH);
                        cmd.Parameters.AddWithValue("@HocKy", hocKy);
                        cmd.Parameters.AddWithValue("@NamHoc", namHoc);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa điểm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LoadDiemData(); // Refresh Data
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa điểm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDiem.CurrentRow == null) return;

            isAdding = false; // Thiết lập trạng thái Sửa
            MoNut(false); // Mở các control nhập liệu

            cbTenSV.Enabled = false;
            cbMonHoc.Enabled = false;
            cbHocKy.Enabled = false;
            txtNamhoc.Enabled = false;

            // Lưu Khóa Chính CŨ vào biến để sử dụng khi UPDATE
            MaSV_Cu = dgvDiem.CurrentRow.Cells["MaSV"].Value.ToString();
            MaMH_Cu = dgvDiem.CurrentRow.Cells["MaMH"].Value.ToString();
            HocKy_Cu = int.Parse(dgvDiem.CurrentRow.Cells["HocKy"].Value.ToString());
            NamHoc_Cu = dgvDiem.CurrentRow.Cells["NamHoc"].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maSV = cbTenSV.SelectedValue?.ToString();
            string maMH = cbMonHoc.SelectedValue?.ToString();
            string hocKyText = cbHocKy.Text.Trim();
            string namHoc = txtNamhoc.Text.Trim();
            string diemThanhPhanText = txtDiemthanhphan.Text.Trim();
            string diemThiText = txtDiemthi.Text.Trim();

            float diemTP, diemThi;

            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Bạn phải chọn tên cho sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbTenSV.Focus();
                return;
            }
            if (string.IsNullOrEmpty(maMH))
            {
                MessageBox.Show("Bạn phải chọn một môn học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbMonHoc.Focus();
                return;
            }
            if (!int.TryParse(hocKyText, out int hocKy) || hocKy < 1 || hocKy > 3)
            {
                MessageBox.Show("Học kỳ phải là số nguyên 1, 2 hoặc 3!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbHocKy.Focus();
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(namHoc, @"^\d{4}$")) // Chỉ kiểm tra năm bắt đầu
            {
                MessageBox.Show("Năm học phải là số nguyên có 4 chữ số (ví dụ: 2024)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNamhoc.Focus();
                return;
            }
            if (!float.TryParse(diemThanhPhanText, out diemTP) || diemTP < 0 || diemTP > 10)
            {
                MessageBox.Show("Điểm thành phần phải là số từ 0 đến 10!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiemthanhphan.Focus();
                return;
            }
            if (!float.TryParse(diemThiText, out diemThi) || diemThi < 0 || diemThi > 10)
            {
                MessageBox.Show("Điểm thi phải là số từ 0 đến 10!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiemthi.Focus();
                return;
            }

            // --- BƯỚC 2: TÍNH ĐIỂM TỔNG KẾT VÀ ĐIỂM CHỮ ---
            // DiemTongKet sẽ được CSDL tự tính (Computed Column), nhưng ta tính trước để lấy DiemChu.
            float diemTongKet = (float)Math.Round((diemTP * 0.3 + diemThi * 0.7), 2);
            string diemChu = TinhDiemChu(diemTongKet);

            // --- BƯỚC 3: THỰC THI THÊM/SỬA ---
            try
            {
                if (isAdding) // THÊM MỚI
                {
                    string sqlThem = @"INSERT INTO DIEM(MaSV, MaMH, HocKy, NamHoc, DiemThanhPhan, DiemThi, DiemChu) 
                                       VALUES(@MaSV, @MaMH, @HocKy, @NamHoc, @DiemThanhPhan, @DiemThi, @DiemChu)";

                    SqlCommand cmd = new SqlCommand(sqlThem, conn);
                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    cmd.Parameters.AddWithValue("@MaMH", maMH);
                    cmd.Parameters.AddWithValue("@HocKy", hocKy);
                    cmd.Parameters.AddWithValue("@NamHoc", namHoc);
                    cmd.Parameters.AddWithValue("@DiemThanhPhan", diemTP);
                    cmd.Parameters.AddWithValue("@DiemThi", diemThi);
                    cmd.Parameters.AddWithValue("@DiemChu", diemChu);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm điểm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // SỬA ĐIỂM
                {
                    string sqlSua = @"UPDATE DIEM 
                                      SET DiemThanhPhan = @DiemThanhPhan, 
                                          DiemThi = @DiemThi, 
                                          DiemChu = @DiemChu 
                                      WHERE MaSV = @MaSV_Cu AND MaMH = @MaMH_Cu AND HocKy = @HocKy_Cu AND NamHoc = @NamHoc_Cu";

                    SqlCommand cmd = new SqlCommand(sqlSua, conn);
                    cmd.Parameters.AddWithValue("@DiemThanhPhan", diemTP);
                    cmd.Parameters.AddWithValue("@DiemThi", diemThi);
                    cmd.Parameters.AddWithValue("@DiemChu", diemChu);

                    // Khóa chính cũ để xác định dòng cần sửa
                    cmd.Parameters.AddWithValue("@MaSV_Cu", MaSV_Cu);
                    cmd.Parameters.AddWithValue("@MaMH_Cu", MaMH_Cu);
                    cmd.Parameters.AddWithValue("@HocKy_Cu", HocKy_Cu);
                    cmd.Parameters.AddWithValue("@NamHoc_Cu", NamHoc_Cu);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // --- BƯỚC 4: HOÀN TẤT ---
                MoNut(true); // Chuyển về chế độ xem
                LoadDiemData(); // Tải lại Grid

            }
            catch (SqlException ex)
            {
                // Bắt lỗi trùng khóa chính (MaSV, MaMH, HocKy, NamHoc) khi Thêm
                if (ex.Number == 2627 && isAdding)
                {
                    MessageBox.Show("Mục điểm này (SV, MH, HK, NH) đã tồn tại! Vui lòng chọn Sửa hoặc kiểm tra lại.", "Lỗi Trùng Lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamlai_Click(object sender, EventArgs e)
        {
            fDiemSinhVien_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
