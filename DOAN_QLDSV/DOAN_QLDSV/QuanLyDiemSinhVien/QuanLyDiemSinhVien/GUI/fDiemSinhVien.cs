using QuanLyDiemSinhVien.BLL;
using QuanLyDiemSinhVien.DAL;
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
        // Biến toàn cục và biến trạng thái
        private readonly string MaGV_HienTai = CurrentUser.Username;

        public event EventHandler ThoatVeTrangChu;

        // Xóa bỏ hoặc làm private string để không dùng biến conn toàn cục cho CSDL
        // SqlConnection conn = new SqlConnection(); 
        private bool isAdding = false;
        private string MaSV_Cu = "";
        private string MaMH_Cu = "";
        private int HocKy_Cu = 0;
        private string NamHoc_Cu = "";

        private string MaLop_Current = "";
        private string MaKhoa_Current = "";

        public fDiemSinhVien()
        {
            InitializeComponent();
            this.dgvDiem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiem_CellContentClick);
            this.cbTenSV.SelectedIndexChanged += new System.EventHandler(this.cbTenSV_SelectedIndexChanged);
            this.btnLamlai.Click += new System.EventHandler(this.btnLamlai_Click);
        }

        #region HÀM HỖ TRỢ CHUNG (TÍNH ĐIỂM, NÚT)

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
            // MỞ KHÓA TẤT CẢ FIELDS NHẬP LIỆU (nếu không phải chế độ xem)
            bool isInputEnabled = !t;

            cbTenSV.Enabled = isInputEnabled; cbMonHoc.Enabled = isInputEnabled; cbHocKy.Enabled = isInputEnabled;
            txtNamhoc.Enabled = isInputEnabled; txtDiemthanhphan.Enabled = isInputEnabled; txtDiemthi.Enabled = isInputEnabled;

            // Khóa các ô Lớp và Khoa (chỉ hiển thị)
            cbTenLop.Enabled = false; cbTenKhoa.Enabled = false;

            // Logic nút
            btnThem.Enabled = t; btnXoa.Enabled = t; btnSua.Enabled = t;
            btnThoat.Enabled = t; btnLuu.Enabled = !t; btnLamlai.Enabled = !t;

            // --- LOGIC PHÂN QUYỀN VÀ KHÓA CHẶT ---
            bool isAdmin = (CurrentUser.TenQuyen == "Admin");

            if (isAdmin)
            {
                // Khóa tất cả fields và ẩn nút CRUD cho Admin (Chế độ giám sát)
                cbTenSV.Enabled = false; cbMonHoc.Enabled = false; cbHocKy.Enabled = false;
                txtNamhoc.Enabled = false; txtDiemthanhphan.Enabled = false; txtDiemthi.Enabled = false;

                btnThem.Visible = false; btnXoa.Visible = false; btnSua.Visible = false;
                btnLuu.Visible = false; btnLamlai.Visible = false;
            }
            else
            {
                // Đảm bảo nút hiện lên cho Teacher
                btnThem.Visible = true; btnXoa.Visible = true; btnSua.Visible = true;
                btnLuu.Visible = true; btnLamlai.Visible = true;
            }
            btnThoat.Enabled = true;
        }

        #endregion

        #region LOAD DỮ LIỆU ĐỒNG BỘ (SỬ DỤNG KetnoiSQL)

        // Hàm này lấy mã khoa của GV (cần kết nối cục bộ)
        private string GetMaKhoaCuaGV(string maGV)
        {
            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                conn.Open();
                SqlCommand cmdKhoa = new SqlCommand("SELECT MaKhoa FROM GIAOVIEN WHERE MaGV = @MaGV", conn);
                cmdKhoa.Parameters.AddWithValue("@MaGV", maGV);
                object result = cmdKhoa.ExecuteScalar();
                return result?.ToString();
            }
        }

        private void LoadSinhVien(string maGV) // LỌC SINH VIÊN THEO MÃ GV (CVHT)
        {
            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                conn.Open();
                string sqlSV;
                SqlCommand cmd;

                if (maGV == null) // Admin: Chọn tất cả sinh viên
                {
                    sqlSV = "SELECT MaSV, HoTen, MaLop FROM SINHVIEN ORDER BY HoTen";
                    cmd = new SqlCommand(sqlSV, conn);
                }
                else // Teacher: Lọc sinh viên theo MaGV_CVHT
                {
                    sqlSV = @"
                SELECT S.MaSV, S.HoTen, S.MaLop 
                FROM SINHVIEN S 
                JOIN LOP L ON S.MaLop = L.MaLop 
                WHERE L.MaGV_CVHT = @MaGV 
                ORDER BY S.HoTen";

                    cmd = new SqlCommand(sqlSV, conn);
                    cmd.Parameters.AddWithValue("@MaGV", maGV);
                }

                SqlDataAdapter daSV = new SqlDataAdapter(cmd);
                DataTable dtSV = new DataTable();
                daSV.Fill(dtSV);

                cbTenSV.DataSource = dtSV;
                cbTenSV.DisplayMember = "HoTen";
                cbTenSV.ValueMember = "MaSV";
            }
        }

        private void LoadMonHoc(string maKhoaCuaGV)
        {
            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                conn.Open();
                string sqlMH = (maKhoaCuaGV == null)
                    ? "SELECT MaMH, TenMH FROM MONHOC ORDER BY TenMH"
                    : "SELECT MaMH, TenMH FROM MONHOC WHERE MaKhoa = @MaKhoa ORDER BY TenMH";

                using (SqlCommand cmd = new SqlCommand(sqlMH, conn))
                {
                    if (maKhoaCuaGV != null) cmd.Parameters.AddWithValue("@MaKhoa", maKhoaCuaGV);
                    SqlDataAdapter daMH = new SqlDataAdapter(cmd);
                    DataTable dtMH = new DataTable();
                    daMH.Fill(dtMH);

                    cbMonHoc.DataSource = dtMH;
                    cbMonHoc.DisplayMember = "TenMH";
                    cbMonHoc.ValueMember = "MaMH";
                }
            }
        }

        private void LoadLop(string maGV, string maKhoaCuaGV)
        {
            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                conn.Open();
                string sqlLop;
                SqlCommand cmd;

                if (maGV == null) // ADMIN: Lấy tất cả lớp thuộc Khoa (nếu có) hoặc tất cả
                {
                    if (maKhoaCuaGV == null)
                    {
                        // Admin (Xem tất cả)
                        sqlLop = "SELECT MaLop, TenLop FROM LOP ORDER BY TenLop";
                        cmd = new SqlCommand(sqlLop, conn);
                    }
                    else
                    {
                        // Admin (Nếu muốn xem theo Khoa cụ thể)
                        sqlLop = "SELECT MaLop, TenLop FROM LOP WHERE MaKhoa = @MaKhoa ORDER BY TenLop";
                        cmd = new SqlCommand(sqlLop, conn);
                        cmd.Parameters.AddWithValue("@MaKhoa", maKhoaCuaGV);
                    }
                }
                else // TEACHER: Lọc theo Mã GV_CVHT VÀ Mã Khoa (Lớp mà GV phụ trách VÀ thuộc Khoa)
                {
                    // Sử dụng MaGV_CVHT để lọc ra các lớp mà GV này là chủ nhiệm.
                    sqlLop = "SELECT MaLop, TenLop FROM LOP WHERE MaGV_CVHT = @MaGV AND MaKhoa = @MaKhoa ORDER BY TenLop";

                    cmd = new SqlCommand(sqlLop, conn);
                    cmd.Parameters.AddWithValue("@MaGV", maGV);
                    cmd.Parameters.AddWithValue("@MaKhoa", maKhoaCuaGV);
                }

                SqlDataAdapter daLop = new SqlDataAdapter(cmd);
                DataTable dtLop = new DataTable(); daLop.Fill(dtLop);

                cbTenLop.DataSource = dtLop; cbTenLop.DisplayMember = "TenLop"; cbTenLop.ValueMember = "MaLop";
            }
        }

        private void LoadKhoa(string maKhoaCuaGV)
        {
            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                conn.Open();
                string sqlKhoa = (maKhoaCuaGV == null)
                    ? "SELECT MaKhoa, TenKhoa FROM KHOA ORDER BY TenKhoa"
                    : "SELECT MaKhoa, TenKhoa FROM KHOA WHERE MaKhoa = @MaKhoa ORDER BY TenKhoa";

                using (SqlCommand cmd = new SqlCommand(sqlKhoa, conn))
                {
                    if (maKhoaCuaGV != null) cmd.Parameters.AddWithValue("@MaKhoa", maKhoaCuaGV);
                    SqlDataAdapter daKhoa = new SqlDataAdapter(cmd);
                    DataTable dtKhoa = new DataTable();
                    daKhoa.Fill(dtKhoa);

                    cbTenKhoa.DataSource = dtKhoa;
                    cbTenKhoa.DisplayMember = "TenKhoa";
                    cbTenKhoa.ValueMember = "MaKhoa";
                }
            }
        }

        private void LoadHK()
        {
            DataTable dtHK = new DataTable();
            dtHK.Columns.Add("HocKy", typeof(int));
            dtHK.Rows.Add(1); dtHK.Rows.Add(2); dtHK.Rows.Add(3);

            cbHocKy.DataSource = dtHK;
            cbHocKy.DisplayMember = "HocKy";
            cbHocKy.ValueMember = "HocKy";
        }

        private void GetLopKhoa(string maSV)
        {
            MaLop_Current = ""; MaKhoa_Current = "";

            if (string.IsNullOrEmpty(maSV)) { cbTenLop.SelectedIndex = -1; cbTenKhoa.SelectedIndex = -1; return; }

            string sql = @"SELECT L.MaLop, K.MaKhoa FROM SINHVIEN S JOIN LOP L ON S.MaLop = L.MaLop
                            JOIN KHOA K ON L.MaKhoa = K.MaKhoa WHERE S.MaSV = @MaSV";

            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                conn.Open();
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
            }

            cbTenLop.SelectedValue = MaLop_Current;
            cbTenKhoa.SelectedValue = MaKhoa_Current;
        }

        private void LoadDiemData()
        {
            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                conn.Open();
                string sqlDiem = @"SELECT D.MaSV, D.MaMH, D.HocKy, D.NamHoc, D.DiemThanhPhan, D.DiemThi, D.DiemTongKet, D.DiemChu,
                                      S.HoTen AS TenSinhVien, M.TenMH AS TenMonHoc, K.TenKhoa, L.TenLop, L.MaLop, K.MaKhoa
                                FROM DIEM D JOIN SINHVIEN S ON D.MaSV = S.MaSV
                                JOIN MONHOC M ON D.MaMH = M.MaMH JOIN LOP L ON S.MaLop = L.MaLop
                                JOIN KHOA K ON L.MaKhoa = K.MaKhoa LEFT JOIN GIAOVIEN G ON D.MaGV = G.MaGV";

                string whereClause = "";
                bool isTeacher = (CurrentUser.TenQuyen == "Teacher");

                if (isTeacher) { whereClause = " WHERE D.MaGV = @MaGV_HienTai"; }

                sqlDiem += whereClause;
                sqlDiem += " ORDER BY D.NamHoc DESC, D.HocKy ASC, S.MaSV ASC, M.MaMH ASC";

                using (SqlCommand cmd = new SqlCommand(sqlDiem, conn))
                {
                    if (isTeacher) { cmd.Parameters.AddWithValue("@MaGV_HienTai", CurrentUser.Username); }
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dataAdapter.Fill(data);

                    dgvDiem.AutoGenerateColumns = false;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = data;
                    dgvDiem.DataSource = bs;

                    // Data Binding UI
                    cbTenSV.DataBindings.Clear(); cbMonHoc.DataBindings.Clear(); cbHocKy.DataBindings.Clear();
                    txtNamhoc.DataBindings.Clear(); txtDiemthanhphan.DataBindings.Clear(); txtDiemthi.DataBindings.Clear();
                    cbTenLop.DataBindings.Clear(); cbTenKhoa.DataBindings.Clear();

                    cbTenSV.DataBindings.Add("SelectedValue", bs, "MaSV", true, DataSourceUpdateMode.Never);
                    cbMonHoc.DataBindings.Add("SelectedValue", bs, "MaMH", true, DataSourceUpdateMode.Never);
                    cbHocKy.DataBindings.Add("SelectedValue", bs, "HocKy", true, DataSourceUpdateMode.Never);
                    txtNamhoc.DataBindings.Add("Text", bs, "NamHoc", true, DataSourceUpdateMode.Never);
                    txtDiemthanhphan.DataBindings.Add("Text", bs, "DiemThanhPhan", true, DataSourceUpdateMode.Never);
                    txtDiemthi.DataBindings.Add("Text", bs, "DiemThi", true, DataSourceUpdateMode.Never);
                    cbTenLop.DataBindings.Add("SelectedValue", bs, "MaLop", true, DataSourceUpdateMode.Never);
                    cbTenKhoa.DataBindings.Add("SelectedValue", bs, "MaKhoa", true, DataSourceUpdateMode.Never);
                }
            }
        }






        private void fDiemSinhVien_Load(object sender, EventArgs e)
        {
            string maGVHienTai = (CurrentUser.TenQuyen == "Teacher") ? CurrentUser.Username : null;
            string maKhoaCuaGV = null;

            if (CurrentUser.TenQuyen == "Teacher")
            {
                try
                {
                    maKhoaCuaGV = GetMaKhoaCuaGV(CurrentUser.Username);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi không tìm thấy khoa của giáo viên: " + ex.Message);
                }
            }

            try
            {   LoadKhoa(maKhoaCuaGV);
                LoadLop(maGVHienTai, maKhoaCuaGV);
                LoadSinhVien(maGVHienTai);
                LoadMonHoc(maKhoaCuaGV);
                
              
                LoadHK();
                LoadDiemData();
                MoNut(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi động: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            MoNut(false);

            cbTenSV.SelectedIndex = -1; cbMonHoc.SelectedIndex = -1; cbHocKy.Text = "";
            txtNamhoc.Text = ""; txtDiemthanhphan.Text = ""; txtDiemthi.Text = "";

            cbTenSV.Focus();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDiem.CurrentRow == null || dgvDiem.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng chọn dòng điểm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            DataRowView drv = (DataRowView)dgvDiem.CurrentRow.DataBoundItem;
            string maSV = drv["MaSV"].ToString(); string maMH = drv["MaMH"].ToString();
            int hocKy = int.Parse(drv["HocKy"].ToString()); string namHoc = drv["NamHoc"].ToString();

            string info = $"SV: {maSV} | MH: {maMH} | HK: {hocKy} | NH: {namHoc}";
            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa điểm này?\n\n{info}", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    string deleteSql = @"DELETE FROM DIEM WHERE MaSV = @MaSV AND MaMH = @MaMH AND HocKy = @HocKy AND NamHoc = @NamHoc";

                    using (SqlConnection conn = KetnoiSQL.GetConnection())
                    using (SqlCommand cmd = new SqlCommand(deleteSql, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@MaSV", maSV); cmd.Parameters.AddWithValue("@MaMH", maMH);
                        cmd.Parameters.AddWithValue("@HocKy", hocKy); cmd.Parameters.AddWithValue("@NamHoc", namHoc);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa điểm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LoadDiemData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa điểm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isAdding = false;
            MoNut(false); // Mở khóa tất cả (bao gồm khóa chính)

            // BƯỚC ĐỒNG BỘ DATA BINDING
            BindingSource bs = dgvDiem.DataSource as BindingSource;
            if (dgvDiem.CurrentRow != null && bs != null)
            {
                bs.Position = dgvDiem.CurrentRow.Index; // Buộc UI cập nhật

                DataRowView drv = bs.Current as DataRowView;
                if (drv != null)
                {
                    // LƯU KHÓA CHÍNH CŨ
                    MaSV_Cu = drv["MaSV"].ToString(); MaMH_Cu = drv["MaMH"].ToString();
                    HocKy_Cu = int.Parse(drv["HocKy"].ToString()); NamHoc_Cu = drv["NamHoc"].ToString();

                    // CẬP NHẬT COMBOBOX LỌC
                    GetLopKhoa(MaSV_Cu);
                    LoadMonHoc(MaKhoa_Current);
                }
            }

            // KHÓA LẠI CÁC TRƯỜNG KHÓA CHÍNH KHI SỬA
            cbTenSV.Enabled = false; cbMonHoc.Enabled = false; cbHocKy.Enabled = false; txtNamhoc.Enabled = false;

            txtDiemthanhphan.Focus();
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maSV = cbTenSV.SelectedValue?.ToString(); string maMH = cbMonHoc.SelectedValue?.ToString();
            string hocKyText = cbHocKy.Text.Trim(); string namHoc = txtNamhoc.Text.Trim();
            string diemThanhPhanText = txtDiemthanhphan.Text.Trim(); string diemThiText = txtDiemthi.Text.Trim();
            float diemTP, diemThi;

            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(maMH) || string.IsNullOrEmpty(hocKyText) || string.IsNullOrEmpty(namHoc))
            { MessageBox.Show("Vui lòng nhập đầy đủ Tên Sinh viên, Môn học, Học kỳ và Năm học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (!int.TryParse(hocKyText, out int hocKy) || hocKy < 1 || hocKy > 3)
            { MessageBox.Show("Học kỳ phải là số nguyên 1, 2 hoặc 3!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); cbHocKy.Focus(); return; }
            if (!System.Text.RegularExpressions.Regex.IsMatch(namHoc, @"^\d{4}$"))
            { MessageBox.Show("Năm học phải là số nguyên có 4 chữ số (ví dụ: 2024)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); txtNamhoc.Focus(); return; }
            if (!float.TryParse(diemThanhPhanText, out diemTP) || diemTP < 0 || diemTP > 10 ||
                !float.TryParse(diemThiText, out diemThi) || diemThi < 0 || diemThi > 10)
            { MessageBox.Show("Điểm thành phần và Điểm thi phải là số từ 0 đến 10!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            float diemTongKet = (float)Math.Round((diemTP * 0.3 + diemThi * 0.7), 2);
            string diemChu = TinhDiemChu(diemTongKet);
            string maGV_ToSave = (CurrentUser.TenQuyen == "Teacher") ? CurrentUser.Username : null;

            try
            {
                using (SqlConnection conn = KetnoiSQL.GetConnection())
                {
                    conn.Open();
                    if (isAdding) // THÊM MỚI
                    {
                        string sqlThem = @"INSERT INTO DIEM(MaSV, MaMH, HocKy, NamHoc, DiemThanhPhan ,DiemThi, DiemChu, MaGV) 
                                           VALUES(@MaSV, @MaMH, @HocKy, @NamHoc, @DiemThanhPhan, @DiemThi, @DiemChu, @MaGV)";

                        using (SqlCommand cmd = new SqlCommand(sqlThem, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaSV", maSV); cmd.Parameters.AddWithValue("@MaMH", maMH);
                            cmd.Parameters.AddWithValue("@HocKy", hocKy); cmd.Parameters.AddWithValue("@NamHoc", namHoc);
                            cmd.Parameters.AddWithValue("@DiemThanhPhan", diemTP); cmd.Parameters.AddWithValue("@DiemThi", diemThi);
                           
                            cmd.Parameters.AddWithValue("@DiemChu", diemChu);
                            cmd.Parameters.AddWithValue("@MaGV", string.IsNullOrEmpty(maGV_ToSave) ? (object)DBNull.Value : maGV_ToSave);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Thêm điểm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else // SỬA ĐIỂM
                    {
                        // Sửa: Bỏ DiemTongKet khỏi SET
                        string sqlSua = @"UPDATE DIEM SET DiemThanhPhan = @DiemThanhPhan, DiemThi = @DiemThi, DiemChu = @DiemChu
                                          WHERE MaSV = @MaSV_Cu AND MaMH = @MaMH_Cu AND HocKy = @HocKy_Cu AND NamHoc = @NamHoc_Cu";

                        using (SqlCommand cmd = new SqlCommand(sqlSua, conn))
                        {
                            cmd.Parameters.AddWithValue("@DiemThanhPhan", diemTP); cmd.Parameters.AddWithValue("@DiemThi", diemThi);
                            
                            cmd.Parameters.AddWithValue("@DiemChu", diemChu);

                            cmd.Parameters.AddWithValue("@MaSV_Cu", MaSV_Cu); cmd.Parameters.AddWithValue("@MaMH_Cu", MaMH_Cu);
                            cmd.Parameters.AddWithValue("@HocKy_Cu", HocKy_Cu); cmd.Parameters.AddWithValue("@NamHoc_Cu", NamHoc_Cu);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cập nhật điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                MoNut(true);
                LoadDiemData(); // Tải lại dữ liệu sau khi sửa/thêm
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 && isAdding)
                { MessageBox.Show("Mục điểm này (SV, MH, HK, NH) đã tồn tại! Vui lòng chọn Sửa hoặc kiểm tra lại.", "Lỗi Trùng Lặp", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                { MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            catch (Exception ex)
            { MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        

        private void btnLamlai_Click(object sender, EventArgs e)
        {
            isAdding = false;

            cbTenSV.SelectedIndex = -1; cbMonHoc.SelectedIndex = -1; cbHocKy.SelectedIndex = -1;
            txtNamhoc.Clear(); txtDiemthanhphan.Clear(); txtDiemthi.Clear();

            MaSV_Cu = ""; MaMH_Cu = ""; HocKy_Cu = 0; NamHoc_Cu = "";

            MoNut(true);
            dgvDiem.ClearSelection();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (ThoatVeTrangChu != null)
            {
                ThoatVeTrangChu(this, EventArgs.Empty);
            }
        }

        private void dgvDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {// Mục đích: Lấy dữ liệu của dòng đang chọn trên lưới và hiển thị lên controls
            if (isAdding) return;

            if (e.RowIndex >= 0)
            {
                if (dgvDiem.Rows[e.RowIndex].DataBoundItem is DataRowView drv)
                {
                    MaSV_Cu = drv["MaSV"].ToString(); MaMH_Cu = drv["MaMH"].ToString();
                    int.TryParse(drv["HocKy"].ToString(), out HocKy_Cu); NamHoc_Cu = drv["NamHoc"].ToString();

                    if (!string.IsNullOrEmpty(MaSV_Cu))
                    {
                        GetLopKhoa(MaSV_Cu);
                    }
                }
            }
        }



        private void cbTenSV_SelectedIndexChanged(object sender, EventArgs e)
        {// Mục đích: 
         // 1. Khi người dùng chọn SV MỚI từ ComboBox (thường ở chế độ THÊM),
         // 2. Cập nhật Lớp/Khoa của SV đó,
         // 3. Lọc danh sách Môn học theo Khoa đó.

            if (cbTenSV.SelectedValue != null && cbTenSV.SelectedValue != DBNull.Value)
            {
                string maSVChon = cbTenSV.SelectedValue.ToString();

                GetLopKhoa(maSVChon);

                LoadMonHoc(MaKhoa_Current);
            }
            else
            {
                cbTenLop.SelectedIndex = -1; cbTenKhoa.SelectedIndex = -1;
                LoadMonHoc(null);
            }

        }
        #endregion
    }
}





