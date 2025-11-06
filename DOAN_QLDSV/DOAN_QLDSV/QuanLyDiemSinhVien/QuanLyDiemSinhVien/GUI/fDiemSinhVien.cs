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
        private readonly string MaGV_HienTai = "GV001"; // <<< THAY THẾ BẰNG CurrentUser.MaGV THỰC TẾ

        // Thay vì MaGV, ta dùng MaGV_HienTai để xác định sinh viên thuộc quyền quản lý
        SqlConnection conn = new SqlConnection();
        private bool isAdding = false;
        private string MaSV_Cu = "";
        private string MaMH_Cu = "";
        private int HocKy_Cu = 0;
        private string NamHoc_Cu = "";

        // Giữ lại các biến này để hiển thị thông tin khi chọn SV
        private string MaLop_Current = "";
        private string MaKhoa_Current = "";
        public fDiemSinhVien()
        {
            InitializeComponent();
            this.dgvDiem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiem_CellContentClick);
            this.cbTenSV.SelectedIndexChanged += new System.EventHandler(this.cbTenSV_SelectedIndexChanged);
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
            
            cbTenLop.Enabled = false;
            cbTenKhoa.Enabled = false;

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
            // Sửa câu truy vấn: Bỏ JOIN không chính xác với MONHOC
            string sqlSV = @"
                SELECT DISTINCT S.MaSV, S.HoTen, S.MaLop 
                FROM SINHVIEN S
                WHERE S.MaSV IN (
                    SELECT MaSV FROM DIEM WHERE MaGV = @MaGV_HienTai
                 )
                ORDER BY S.HoTen";

            using (SqlDataAdapter daSV = new SqlDataAdapter(sqlSV, conn))
            {
                daSV.SelectCommand.Parameters.AddWithValue("@MaGV_HienTai", MaGV_HienTai);
                DataTable dtSV = new DataTable();
                daSV.Fill(dtSV);

                cbTenSV.DataSource = dtSV;
                cbTenSV.DisplayMember = "HoTen";
                cbTenSV.ValueMember = "MaSV";
            }
        }


        private void LoadMonHoc()
        {
            string sqlMH = @"
                SELECT DISTINCT M.MaMH, M.TenMH 
                FROM MONHOC M
                JOIN DIEM D ON M.MaMH = D.MaMH
                WHERE D.MaGV = @MaGV_HienTai
                ORDER BY M.TenMH";

            using (SqlDataAdapter daMH = new SqlDataAdapter(sqlMH, conn))
            {
                daMH.SelectCommand.Parameters.AddWithValue("@MaGV_HienTai", MaGV_HienTai);
                DataTable dtMH = new DataTable();
                daMH.Fill(dtMH);

                cbMonHoc.DataSource = dtMH;
                cbMonHoc.DisplayMember = "TenMH";
                cbMonHoc.ValueMember = "MaMH";
            }
        }
        private void LoadLop()
        {
            string sqlLop = "SELECT MaLop, TenLop FROM LOP ORDER BY TenLop";
            using (SqlDataAdapter daLop = new SqlDataAdapter(sqlLop, conn))
            {
                DataTable dtLop = new DataTable();
                daLop.Fill(dtLop);
                cbTenLop.DataSource = dtLop;
                cbTenLop.DisplayMember = "TenLop";
                cbTenLop.ValueMember = "MaLop";
            }
        }
        private void LoadKhoa()
        {
            string sqlKhoa = "SELECT MaKhoa, TenKhoa FROM KHOA ORDER BY TenKhoa";
            using (SqlDataAdapter daKhoa = new SqlDataAdapter(sqlKhoa, conn))
            {
                DataTable dtKhoa = new DataTable();
                daKhoa.Fill(dtKhoa);
                cbTenKhoa.DataSource = dtKhoa;
                cbTenKhoa.DisplayMember = "TenKhoa";
                cbTenKhoa.ValueMember = "MaKhoa";
            }
        }
        private void GetLopKhoa(string maSV) 
        {
            MaLop_Current = "";
            MaKhoa_Current = "";

            if (string.IsNullOrEmpty(maSV))
            {
                cbTenLop.SelectedIndex = -1;
                cbTenKhoa.SelectedIndex = -1;
                return;
            }

            string sql = @"SELECT L.MaLop, K.MaKhoa
                            FROM SINHVIEN S
                            JOIN LOP L ON S.MaLop = L.MaLop
                            JOIN KHOA K ON L.MaKhoa = K.MaKhoa
                            WHERE S.MaSV = @MaSV";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        MaLop_Current = reader["MaLop"].ToString();
                        MaKhoa_Current = reader["MaKhoa"].ToString();
                    }
                }
            }

            // Hiển thị thông tin
            cbTenLop.SelectedValue = MaLop_Current;
            cbTenKhoa.SelectedValue = MaKhoa_Current;
        }
        private void LoadDiemData()
        {

            string sqlDiem = @"
                SELECT D.MaSV, D.MaMH, D.HocKy, D.NamHoc, D.DiemThanhPhan, D.DiemThi, D.DiemTongKet, D.DiemChu,
                        S.HoTen AS TenSinhVien, M.TenMH AS TenMonHoc, 
                        K.TenKhoa, L.TenLop
                FROM DIEM D
                JOIN SINHVIEN S ON D.MaSV = S.MaSV
                JOIN MONHOC M ON D.MaMH = M.MaMH
                JOIN LOP L ON S.MaLop = L.MaLop
                JOIN KHOA K ON L.MaKhoa = K.MaKhoa
                WHERE D.MaGV = @MaGV_HienTai -- CHỈ LẤY ĐIỂM MÀ GIÁO VIÊN NÀY PHỤ TRÁCH
                ORDER BY D.NamHoc DESC, D.HocKy ASC, S.MaSV ASC, M.MaMH ASC";

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlDiem, conn))
            {
                dataAdapter.SelectCommand.Parameters.AddWithValue("@MaGV_HienTai", MaGV_HienTai);
                DataTable data = new DataTable();
                dataAdapter.Fill(data);

                dgvDiem.AutoGenerateColumns = false;
                dgvDiem.DataSource = data;

                // Tải dữ liệu cho các ComboBox (Chỉ tải những gì GV này quản lý)
                LoadSinhVien();
                LoadMonHoc();
                LoadLop();
                LoadKhoa();

                // Xóa binding cũ
                cbTenSV.DataBindings.Clear();
                cbMonHoc.DataBindings.Clear();
                cbHocKy.DataBindings.Clear();
                cbTenLop.DataBindings.Clear();
                cbTenKhoa.DataBindings.Clear();
                txtNamhoc.DataBindings.Clear();
                txtDiemthanhphan.DataBindings.Clear();
                txtDiemthi.DataBindings.Clear();

                // Thiết lập Data Binding mới
                BindingSource bs = new BindingSource();
                bs.DataSource = data;
                dgvDiem.DataSource = bs;

                cbTenSV.DataBindings.Add("SelectedValue", bs, "MaSV", true, DataSourceUpdateMode.Never);
                cbMonHoc.DataBindings.Add("SelectedValue", bs, "MaMH", true, DataSourceUpdateMode.Never);
                // Bỏ cbTenGV.DataBindings
                cbHocKy.DataBindings.Add("Text", bs, "HocKy", true, DataSourceUpdateMode.Never);
                // 2 dòng binding này chỉ dùng để hiển thị, MaLop/MaKhoa không có trong DIEM nhưng có trong DataTable dataAdapter.Fill(data)
                cbTenLop.DataBindings.Add("SelectedValue", bs, "MaLop", true, DataSourceUpdateMode.Never);
                cbTenKhoa.DataBindings.Add("SelectedValue", bs, "MaKhoa", true, DataSourceUpdateMode.Never);
                txtNamhoc.DataBindings.Add("Text", bs, "NamHoc", true, DataSourceUpdateMode.Never);
                txtDiemthanhphan.DataBindings.Add("Text", bs, "DiemThanhPhan", true, DataSourceUpdateMode.Never);
                txtDiemthi.DataBindings.Add("Text", bs, "DiemThi", true, DataSourceUpdateMode.Never);
            }

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
                    conn.ConnectionString = @"server=.; Database=db_QLDSV;User ID=sa;Password=123;TrustServerCertificate=True";
                    conn.Open();
                }

                LoadDiemData();
                MoNut(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL hoặc tải dữ liệu ban đầu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            cbTenSV.Focus();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDiem.CurrentRow == null) return;

            // Lấy Khóa Chính CŨ từ DataGridView
            string maSV = dgvDiem.CurrentRow.Cells["MaSV"].Value.ToString();
            string maMH = dgvDiem.CurrentRow.Cells["MaMH"].Value.ToString();
            int hocKy = int.Parse(dgvDiem.CurrentRow.Cells["HocKy"].Value.ToString());
            string namHoc = dgvDiem.CurrentRow.Cells["NamHoc"].Value.ToString();

            string info = $"SV: {maSV} | MH: {maMH} | HK: {hocKy} | NH: {namHoc}";

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa điểm này?\n\n{info}", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    string deleteSql = @"DELETE FROM DIEM WHERE MaSV = @MaSV AND MaMH = @MaMH AND HocKy = @HocKy AND NamHoc = @NamHoc";

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
            isAdding = false; // Thiết lập trạng thái Sửa
            MoNut(false); // Mở các control nhập liệu

            // KHÓA CÁC TRƯỜNG KHÓA CHÍNH KHI SỬA
            cbTenSV.Enabled = false;
            cbMonHoc.Enabled = false;
            cbHocKy.Enabled = false;
            txtNamhoc.Enabled = false;

            // LƯU KHÓA CHÍNH CŨ
            MaSV_Cu = dgvDiem.CurrentRow.Cells["MaSV"].Value?.ToString() ?? "";
            MaMH_Cu = dgvDiem.CurrentRow.Cells["MaMH"].Value?.ToString() ?? "";
            int.TryParse(dgvDiem.CurrentRow.Cells["HocKy"].Value?.ToString(), out HocKy_Cu);
            NamHoc_Cu = dgvDiem.CurrentRow.Cells["NamHoc"].Value?.ToString() ?? "";
        }
        

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maSV = cbTenSV.SelectedValue?.ToString();
            string maMH = cbMonHoc.SelectedValue?.ToString();
            // Bỏ: string maGV = cbTenGV.SelectedValue == DBNull.Value ? null : cbTenGV.SelectedValue?.ToString(); 
            string hocKyText = cbHocKy.Text.Trim();
            string namHoc = txtNamhoc.Text.Trim();
            string diemThanhPhanText = txtDiemthanhphan.Text.Trim();
            string diemThiText = txtDiemthi.Text.Trim();

            float diemTP, diemThi;

            // BƯỚC 1: KIỂM TRA DỮ LIỆU (Giữ nguyên)
            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(maMH) || string.IsNullOrEmpty(hocKyText) || string.IsNullOrEmpty(namHoc))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên Sinh viên, Môn học, Học kỳ và Năm học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(hocKyText, out int hocKy) || hocKy < 1 || hocKy > 3)
            {
                MessageBox.Show("Học kỳ phải là số nguyên 1, 2 hoặc 3!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbHocKy.Focus();
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(namHoc, @"^\d{4}$"))
            {
                MessageBox.Show("Năm học phải là số nguyên có 4 chữ số (ví dụ: 2024)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNamhoc.Focus();
                return;
            }
            if (!float.TryParse(diemThanhPhanText, out diemTP) || diemTP < 0 || diemTP > 10 ||
                !float.TryParse(diemThiText, out diemThi) || diemThi < 0 || diemThi > 10)
            {
                MessageBox.Show("Điểm thành phần và Điểm thi phải là số từ 0 đến 10!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // BƯỚC 2: TÍNH ĐIỂM TỔNG KẾT VÀ ĐIỂM CHỮ (Giữ nguyên)
            float diemTongKet = (float)Math.Round((diemTP * 0.3 + diemThi * 0.7), 2);
            string diemChu = TinhDiemChu(diemTongKet);

            // BƯỚC 3: THỰC THI THÊM/SỬA
            try
            {
                if (isAdding) // THÊM MỚI
                {
                    // Thêm trường MaGV_HienTai
                    string sqlThem = @"INSERT INTO DIEM(MaSV, MaMH, HocKy, NamHoc, DiemThanhPhan, DiemThi, DiemTongKet, DiemChu, MaGV) 
                                         VALUES(@MaSV, @MaMH, @HocKy, @NamHoc, @DiemThanhPhan, @DiemThi, @DiemTongKet, @DiemChu, @MaGV)";

                    SqlCommand cmd = new SqlCommand(sqlThem, conn);
                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    cmd.Parameters.AddWithValue("@MaMH", maMH);
                    cmd.Parameters.AddWithValue("@HocKy", hocKy);
                    cmd.Parameters.AddWithValue("@NamHoc", namHoc);
                    cmd.Parameters.AddWithValue("@DiemThanhPhan", diemTP);
                    cmd.Parameters.AddWithValue("@DiemThi", diemThi);
                    // Cần thêm DiemTongKet vào INSERT
                    cmd.Parameters.AddWithValue("@DiemTongKet", diemTongKet);
                    cmd.Parameters.AddWithValue("@DiemChu", diemChu);
                    // Thêm MaGV_HienTai của người dùng đang nhập
                    cmd.Parameters.AddWithValue("@MaGV", MaGV_HienTai);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm điểm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // SỬA ĐIỂM
                {
                    // Không cần update MaGV vì MaGV là một phần của khóa chính logic
                    string sqlSua = @"UPDATE DIEM 
                                         SET DiemThanhPhan = @DiemThanhPhan, 
                                             DiemThi = @DiemThi, 
                                             DiemTongKet = @DiemTongKet,
                                             DiemChu = @DiemChu
                                         WHERE MaSV = @MaSV_Cu AND MaMH = @MaMH_Cu AND HocKy = @HocKy_Cu AND NamHoc = @NamHoc_Cu";

                    SqlCommand cmd = new SqlCommand(sqlSua, conn);
                    cmd.Parameters.AddWithValue("@DiemThanhPhan", diemTP);
                    cmd.Parameters.AddWithValue("@DiemThi", diemThi);
                    cmd.Parameters.AddWithValue("@DiemTongKet", diemTongKet);
                    cmd.Parameters.AddWithValue("@DiemChu", diemChu);

                    // Khóa chính cũ để xác định dòng cần sửa
                    cmd.Parameters.AddWithValue("@MaSV_Cu", MaSV_Cu);
                    cmd.Parameters.AddWithValue("@MaMH_Cu", MaMH_Cu);
                    cmd.Parameters.AddWithValue("@HocKy_Cu", HocKy_Cu);
                    cmd.Parameters.AddWithValue("@NamHoc_Cu", NamHoc_Cu);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // BƯỚC 4: HOÀN TẤT
                MoNut(true); // Chuyển về chế độ xem
                LoadDiemData(); // Tải lại Grid

            }
            catch (SqlException ex)
            {
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
            if (isAdding) return;

            if (e.RowIndex >= 0)
            {
                BindingSource bs = dgvDiem.DataSource as BindingSource;
                if (bs != null)
                {
                    bs.Position = e.RowIndex;

                    DataGridViewRow row = dgvDiem.Rows[e.RowIndex];
                    MaSV_Cu = row.Cells["MaSV"].Value?.ToString() ?? "";
                    MaMH_Cu = row.Cells["MaMH"].Value?.ToString() ?? "";
                    if (row.Cells["HocKy"].Value != null)
                    {
                        int.TryParse(row.Cells["HocKy"].Value.ToString(), out HocKy_Cu);
                    }
                    NamHoc_Cu = row.Cells["NamHoc"].Value?.ToString() ?? "";

                    // Cập nhật các ComboBox Lớp/Khoa theo sinh viên được chọn
                    if (!string.IsNullOrEmpty(MaSV_Cu))
                    {
                        GetLopKhoa(MaSV_Cu);
                    }
                }
            }\`a
        }

        private void cbTenSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTenSV.SelectedValue != null && cbTenSV.SelectedValue != DBNull.Value)
            {
                GetLopKhoa(cbTenSV.SelectedValue.ToString());
            }
            else
            {
                cbTenLop.SelectedIndex = -1;
                cbTenKhoa.SelectedIndex = -1;
            }
        }
    }
}
