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
using QuanLyDiemSinhVien.BLL;


namespace QuanLyDiemSinhVien.GUI
{
    public partial class fDiemSinhVien : Form
    {
        private readonly string MaGV_HienTai = CurrentUser.Username; // <<< THAY THẾ BẰNG  THỰC TẾ

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


            // Khóa các ô Lớp và Khoa (chỉ hiển thị, không cho sửa trực tiếp)
            cbTenLop.Enabled = false;
            cbTenKhoa.Enabled = false;

            txtNamhoc.Enabled = !t;
            txtDiemthanhphan.Enabled = !t;
            txtDiemthi.Enabled = !t;

            btnThem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnThoat.Enabled = t;
            btnLuu.Enabled = !t;
        }

        private void LoadSinhVien()
        {
            string maGVHienTai = CurrentUser.Username;

            // Chỉ chọn sinh viên nào có MaGV hiện tại trong bảng DIEM
            string sqlSV = @"SELECT DISTINCT S.MaSV, S.HoTen, S.MaLop 
                     FROM SINHVIEN S
                     JOIN DIEM D ON S.MaSV = D.MaSV
                     WHERE D.MaGV = @MaGV
                     ORDER BY S.HoTen";

            SqlCommand cmd = new SqlCommand(sqlSV, conn);
            cmd.Parameters.AddWithValue("@MaGV", maGVHienTai);

            SqlDataAdapter daSV = new SqlDataAdapter(cmd);
            DataTable dtSV = new DataTable();
            daSV.Fill(dtSV);

                cbTenSV.DataSource = dtSV;
                cbTenSV.DisplayMember = "HoTen";
                cbTenSV.ValueMember = "MaSV";
            }
        }


        private void LoadMonHoc()
        {
            string maGVHienTai = CurrentUser.Username;

            // Chỉ chọn môn nào có MaGV hiện tại trong bảng DIEM
            string sqlMH = @"SELECT DISTINCT M.MaMH, M.TenMH 
                     FROM MONHOC M
                     JOIN DIEM D ON M.MaMH = D.MaMH
                     WHERE D.MaGV = @MaGV
                     ORDER BY M.TenMH";

            SqlCommand cmd = new SqlCommand(sqlMH, conn);
            cmd.Parameters.AddWithValue("@MaGV", maGVHienTai);

            SqlDataAdapter daMH = new SqlDataAdapter(cmd);
            DataTable dtMH = new DataTable();
            daMH.Fill(dtMH);

            cbMonHoc.DataSource = dtMH;
            cbMonHoc.DisplayMember = "TenMH";
            cbMonHoc.ValueMember = "MaMH";
        }

        private void LoadLop()
        {
            string maGVHienTai = CurrentUser.Username;

            // Chỉ chọn môn nào có MaGV hiện tại trong bảng DIEM
            string sqlLop = @"SELECT DISTINCT L.MaLop, L.TenLop 
                   FROM LOP L
                   JOIN SINHVIEN S ON L.MaLop = S.MaLop
                   JOIN DIEM D ON S.MaSV = D.MaSV
                   WHERE D.MaGV = @MaGV
                   ORDER BY L.TenLop";

            SqlCommand cmd = new SqlCommand(sqlLop, conn);
            cmd.Parameters.AddWithValue("@MaGV", maGVHienTai);

            SqlDataAdapter daLop = new SqlDataAdapter(cmd);
            DataTable dtLop = new DataTable();
            daLop.Fill(dtLop);

            cbTenLop.DataSource = dtLop;
            cbTenLop.DisplayMember = "TenLop";
            cbTenLop.ValueMember = "MaLop";
        }
        private void LoadKhoa()
        {
            string maGVHienTai = CurrentUser.Username;

            // Chỉ chọn môn nào có MaGV hiện tại trong bảng DIEM
            string sqlKhoa = @"SELECT DISTINCT K.MaKhoa, K.TenKhoa 
                    FROM KHOA K
                    JOIN LOP L ON K.MaKhoa = L.MaKhoa
                    JOIN SINHVIEN S ON L.MaLop = S.MaLop
                    JOIN DIEM D ON S.MaSV = D.MaSV
                    WHERE D.MaGV = @MaGV
                    ORDER BY K.TenKhoa";

            SqlCommand cmd = new SqlCommand(sqlKhoa, conn);
            cmd.Parameters.AddWithValue("@MaGV", maGVHienTai);

            SqlDataAdapter daKhoa = new SqlDataAdapter(cmd);
            DataTable dtKhoa = new DataTable();
            daKhoa.Fill(dtKhoa);

            cbTenKhoa.DataSource = dtKhoa;
            cbTenKhoa.DisplayMember = "TenKhoa";
            cbTenKhoa.ValueMember = "MaKhoa";
        }
        private void LoadHK()
        {
            string maGVHienTai = CurrentUser.Username;

            // Chỉ chọn môn nào có MaGV hiện tại trong bảng DIEM
            string sqlHK = @"SELECT DISTINCT HocKy 
                  FROM DIEM 
                  WHERE MaGV = @MaGV 
                  ORDER BY HocKy";

            SqlCommand cmd = new SqlCommand(sqlHK, conn);
            cmd.Parameters.AddWithValue("@MaGV", maGVHienTai);

            SqlDataAdapter daHK = new SqlDataAdapter(cmd);
            DataTable dtHK = new DataTable();
            daHK.Fill(dtHK);

            cbHocKy.DataSource = dtHK;
            cbHocKy.DisplayMember = "HocKy";
            cbHocKy.ValueMember = "HocKy";
        }
        private void GetLopKhoaGiaoVien(string maSV)
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

            // Nếu đang ở chế độ THÊM MỚI, đặt Giáo viên Môn học là Giáo viên Chủ nhiệm
        }
        private void LoadDiemData()
        {

            string sqlDiem = @"SELECT D.MaSV, D.MaMH, D.HocKy, D.NamHoc, D.DiemThanhPhan, D.DiemThi, D.DiemTongKet, D.DiemChu,
                              S.HoTen AS TenSinhVien, M.TenMH AS TenMonHoc, 
                              K.TenKhoa, L.TenLop, L.MaLop, K.MaKhoa
                       FROM DIEM D
                       JOIN SINHVIEN S ON D.MaSV = S.MaSV
                       JOIN MONHOC M ON D.MaMH = M.MaMH
                       JOIN LOP L ON S.MaLop = L.MaLop
                       JOIN KHOA K ON L.MaKhoa = K.MaKhoa
                       LEFT JOIN GIAOVIEN G ON D.MaGV = G.MaGV";

            SqlCommand cmd = new SqlCommand(sqlDiem, conn);

            // --- PHÂN QUYỀN XEM ---
            if (CurrentUser.TenQuyen == "Teacher")
            {
                // 1. Thêm điều kiện lọc vào câu SQL
                sqlDiem += " WHERE D.MaGV = @MaGV_HienTai";

                // 2. Cập nhật Command và truyền tham số
                cmd.CommandText = sqlDiem; // Gán lại câu SQL đã có WHERE
                cmd.Parameters.AddWithValue("@MaGV_HienTai", CurrentUser.Username); // Username = MaGV
            }
            // ----------------------

            sqlDiem += " ORDER BY D.NamHoc DESC, D.HocKy ASC, S.MaSV ASC, M.MaMH ASC";
            cmd.CommandText = sqlDiem; // Gán lại câu SQL cuối cùng

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataTable data = new DataTable();
            dataAdapter.Fill(data);

                dgvDiem.AutoGenerateColumns = false;
                dgvDiem.DataSource = data;

            // Tải dữ liệu cho các ComboBox
            LoadSinhVien();
            LoadMonHoc();
            LoadLop();
            LoadKhoa();
            LoadHK();

            // Xóa binding cũ
            cbTenSV.DataBindings.Clear();
            cbMonHoc.DataBindings.Clear();
            cbHocKy.DataBindings.Clear();
            txtNamhoc.DataBindings.Clear();
            txtDiemthanhphan.DataBindings.Clear();
            txtDiemthi.DataBindings.Clear();

                // Thiết lập Data Binding mới
                BindingSource bs = new BindingSource();
                bs.DataSource = data;
                dgvDiem.DataSource = bs;

            cbTenSV.DataBindings.Add("SelectedValue", bs, "MaSV", true, DataSourceUpdateMode.Never);
            cbMonHoc.DataBindings.Add("SelectedValue", bs, "MaMH", true, DataSourceUpdateMode.Never);
            cbHocKy.DataBindings.Add("Text", bs, "HocKy", true, DataSourceUpdateMode.Never);
            //cbTenLop.DataBindings.Add("SelectedValue", bs, "MaLop", true, DataSourceUpdateMode.Never); // Không dùng được vì MaLop không có trong DIEM
            //cbTenKhoa.DataBindings.Add("SelectedValue", bs, "MaKhoa", true, DataSourceUpdateMode.Never); // Tương tự
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
                // Luôn gán lại ConnectionString trước khi mở để chắc chắn
                if (conn.State == ConnectionState.Closed)
                {
                    conn.ConnectionString = @"server=.; Database=db_QLDSV;Integrated Security=True";
                    conn.Open();
                    LoadDiemData();
                }
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
            // Kiểm tra xem có dòng nào đang được chọn và có dữ liệu không
            if (dgvDiem.CurrentRow == null || dgvDiem.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng chọn dòng điểm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu gốc từ dòng hiện tại (ép kiểu về DataRowView)
            DataRowView drv = (DataRowView)dgvDiem.CurrentRow.DataBoundItem;

            // Lấy thông tin khóa chính từ nguồn dữ liệu (không phụ thuộc vào cột trên lưới)
            string maSV = drv["MaSV"].ToString();
            string maMH = drv["MaMH"].ToString();
            int hocKy = int.Parse(drv["HocKy"].ToString());
            string namHoc = drv["NamHoc"].ToString();

            // Hiển thị thông báo xác nhận
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

                    LoadDiemData(); // Tải lại dữ liệu sau khi xóa
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
            if (dgvDiem.CurrentRow.DataBoundItem is DataRowView drv)
            {
                MaSV_Cu = drv["MaSV"].ToString();
                MaMH_Cu = drv["MaMH"].ToString();
                HocKy_Cu = int.Parse(drv["HocKy"].ToString());
                NamHoc_Cu = drv["NamHoc"].ToString();
            }
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

            string maGV_ToSave = null;

            if (CurrentUser.TenQuyen == "Teacher")
            {
                // Nếu là GV, bắt buộc lưu mã của chính họ (Username = MaGV)
                maGV_ToSave = CurrentUser.Username;
            }

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
                    cmd.Parameters.AddWithValue("@MaGV", string.IsNullOrEmpty(maGV_ToSave) ? (object)DBNull.Value : maGV_ToSave);
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
                    cmd.Parameters.AddWithValue("@MaGV", string.IsNullOrEmpty(maGV_ToSave) ? (object)DBNull.Value : maGV_ToSave);
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
            isAdding = false;

            // 2. Xóa trắng toàn bộ các ô nhập liệu
            cbTenSV.SelectedIndex = -1;
            cbMonHoc.SelectedIndex = -1;
            cbHocKy.SelectedIndex = -1;
            // cbHocKy.Text = ""; // Nếu cbHocKy là DropDown thì dùng .Text = "", nếu là DropDownList thì dùng .SelectedIndex = -1

            txtNamhoc.Clear();
            txtDiemthanhphan.Clear();
            txtDiemthi.Clear();

            // 3. Xóa các biến lưu khóa chính cũ (để chắc chắn không bị nhầm lẫn khi sửa lần sau)
            MaSV_Cu = "";
            MaMH_Cu = "";
            HocKy_Cu = 0;
            NamHoc_Cu = "";

            // 4. Quay về trạng thái xem ban đầu (Khóa ô nhập, hiện nút Thêm/Sửa/Xóa)
            MoNut(true);

            // 5. (Tùy chọn) Bỏ chọn dòng hiện tại trên lưới để giao diện sạch hơn
            dgvDiem.ClearSelection();
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
                if (dgvDiem.Rows[e.RowIndex].DataBoundItem is DataRowView drv)
                {
                    // Lấy giá trị trực tiếp từ DataRowView.
                    // Cách này KHÔNG CẦN cột "MaSV", "MaMH"... phải hiện trên lưới.
                    MaSV_Cu = drv["MaSV"].ToString();
                    MaMH_Cu = drv["MaMH"].ToString();
                    int.TryParse(drv["HocKy"].ToString(), out HocKy_Cu);
                    NamHoc_Cu = drv["NamHoc"].ToString();

                    // Cập nhật các ComboBox Lớp/Khoa theo sinh viên vừa chọn
                    if (!string.IsNullOrEmpty(MaSV_Cu))
                    {
                        GetLopKhoa(MaSV_Cu);
                    }
                }
            }
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
