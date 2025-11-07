using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyDiemSinhVien.BLL;

namespace QuanLyDiemSinhVien.GUI
{
    public partial class fBangDiemSV : Form
    {
        SqlConnection conn = new SqlConnection();
        BindingSource bsDiem = new BindingSource();
        DataTable dtDiem = new DataTable();
        private bool isLoaded = false;

        public fBangDiemSV()
        {
        InitializeComponent();
        }

        private void fBangDiemSV_Load(object sender, EventArgs e)
        {
            cbNamHoc.Enabled = true;
            cbMonHoc.Enabled = true;
            cbHocKy.Enabled = true;
            try
            {
                // Luôn gán lại ConnectionString trước khi mở để chắc chắn
                if (conn.State == ConnectionState.Closed)
                {
                    conn.ConnectionString = @"server=.; Database=db_QLDSV;Integrated Security=True";
                    conn.Open();
                    LoadThongTinSinhVien();
                    LoadComboBoxFilter();
                    LoadDiemData();
                    isLoaded = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi động: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // --- HÀM LOAD THÔNG TIN SINH VIÊN ---
        private void LoadThongTinSinhVien()
        {
            try
            {
                string maSV = CurrentUser.Username;

                string sql = @"
            SELECT S.HoTen, S.MaSV, L.TenLop, K.TenKhoa
            FROM SINHVIEN S
            JOIN LOP L ON S.MaLop = L.MaLop
            JOIN KHOA K ON L.MaKhoa = K.MaKhoa
            WHERE S.MaSV = @MaSV";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);

                //if (conn.State == ConnectionState.Closed) 
                    //conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Gán thông tin vào các Label (Nhớ đổi tên label19, label12... cho dễ nhớ)
                    lbTen.Text = reader["HoTen"].ToString(); // Họ và tên
                    lbMSV.Text = reader["MaSV"].ToString();  // Mã sinh viên
                    lbLop.Text = reader["TenLop"].ToString(); // Lớp
                    lbKhoa.Text = reader["TenKhoa"].ToString(); // Khoa
                }
                reader.Close();

                // --- Tính điểm trung bình và xếp loại
                // Công thức: Tổng (Điểm Tổng Kết * Số Tín Chỉ) / Tổng Số Tín Chỉ
                string sqlDiemTB = @"
    SELECT SUM(D.DiemTongKet * M.SoTC) / SUM(M.SoTC) AS DiemTrungBinh
    FROM DIEM D
    JOIN MONHOC M ON D.MaMH = M.MaMH
    WHERE D.MaSV = @MaSV";

                SqlCommand cmdDiemTB = new SqlCommand(sqlDiemTB, conn);
                cmdDiemTB.Parameters.AddWithValue("@MaSV", maSV);

                object result = cmdDiemTB.ExecuteScalar(); // Lấy 1 giá trị duy nhất

                if (result != DBNull.Value && result != null)
                {
                    double diemTB = Convert.ToDouble(result);
                    string xepLoai = "";

                    if (diemTB >= 9.0) xepLoai = "Xuất sắc";
                    else if (diemTB >= 8.0) xepLoai = "Giỏi";
                    else if (diemTB >= 7.0) xepLoai = "Khá";
                    else if (diemTB >= 5.0) xepLoai = "Trung bình";
                    else xepLoai = "Yếu";

                    // Hiển thị lên Label (giả sử lbXL là label Xếp loại)

                    lbXL.Text = xepLoai;
                    // Hiển thị điểm trung bình lên label mới (làm tròn 2 chữ số thập phân)
                    lbTB.Text = diemTB.ToString("F2");
                }
                else
                {
                    lbXL.Text = "Đang cập nhật";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin sinh viên: " + ex.Message);
                if (conn.State == ConnectionState.Open) conn.Close(); // Đảm bảo đóng kết nối nếu lỗi
            }
        }
        // --- HÀM LOAD DỮ LIỆU CHO COMBOBOX ---
        private void LoadComboBoxFilter()
        {
            try
            {
                // Lấy mã SV hiện tại 
                string maSVHienTai = CurrentUser.Username;

                // 1. Môn Học: Chỉ lấy môn mà sinh viên này ĐÃ CÓ ĐIỂM
                string sqlMH = @"
            SELECT DISTINCT M.MaMH, M.TenMH 
            FROM MONHOC M 
            JOIN DIEM D ON M.MaMH = D.MaMH 
            WHERE D.MaSV = @MaSV
            ORDER BY M.TenMH";
                SqlDataAdapter daMH = new SqlDataAdapter(sqlMH, conn);
                daMH.SelectCommand.Parameters.AddWithValue("@MaSV", maSVHienTai);
                DataTable dtMH_Raw = new DataTable();
                daMH.Fill(dtMH_Raw);

                DataTable dtMH = new DataTable();
                dtMH.Columns.Add("MaMH");
                dtMH.Columns.Add("TenMH");
                dtMH.Rows.Add("ALL", "--- Tất cả môn ---");
                foreach (DataRow row in dtMH_Raw.Rows)
                {
                    dtMH.Rows.Add(row["MaMH"], row["TenMH"]);
                }
                cbMonHoc.DataSource = dtMH;
                cbMonHoc.ValueMember = "MaMH";
                cbMonHoc.DisplayMember = "TenMH";

                // 2. Năm Học: Chỉ lấy năm mà sinh viên này CÓ ĐIỂM
                string sqlNH = @"
            SELECT DISTINCT NamHoc 
            FROM DIEM 
            WHERE MaSV = @MaSV 
            ORDER BY NamHoc DESC";
                SqlDataAdapter daNH = new SqlDataAdapter(sqlNH, conn);
                daNH.SelectCommand.Parameters.AddWithValue("@MaSV", maSVHienTai);
                DataTable dtNH_Raw = new DataTable();
                daNH.Fill(dtNH_Raw);

                DataTable dtNH = new DataTable();
                dtNH.Columns.Add("NamHoc");   // Cột giá trị (ValueMember)
                dtNH.Columns.Add("HienNamHoc");  // Cột hiển thị (DisplayMember)
                dtNH.Rows.Add("ALL", "--- Tất cả năm học ---"); // Dòng đầu tiên
                foreach (DataRow row in dtNH_Raw.Rows)
                {
                    dtNH.Rows.Add(row["NamHoc"], row["NamHoc"]);
                }
                cbNamHoc.DataSource = dtNH;
                cbNamHoc.ValueMember = "NamHoc";
                cbNamHoc.DisplayMember = "HienNamHoc";

                // 3. Học Kỳ: Chỉ lấy học kỳ mà sinh viên này CÓ ĐIỂM
                string sqlHK = @"
            SELECT DISTINCT HocKy 
            FROM DIEM 
            WHERE MaSV = @MaSV 
            ORDER BY HocKy";
                SqlDataAdapter daHK = new SqlDataAdapter(sqlHK, conn);
                daHK.SelectCommand.Parameters.AddWithValue("@MaSV", maSVHienTai);
                DataTable dtHK_Raw = new DataTable();
                daHK.Fill(dtHK_Raw);

                DataTable dtHK = new DataTable();
                dtHK.Columns.Add("HocKy");   // Cột giá trị (ValueMember)
                dtHK.Columns.Add("TenHocKy");  // Cột hiển thị (DisplayMember)
                dtHK.Rows.Add("ALL", "--- Tất cả học kỳ ---"); // Dòng đầu tiên
                foreach (DataRow row in dtHK_Raw.Rows)
                {
                    dtHK.Rows.Add(row["HocKy"], row["HocKy"]);
                }
                cbHocKy.DataSource = dtHK;
                cbHocKy.ValueMember = "HocKy";
                cbHocKy.DisplayMember = "TenHocKy";
            }
            catch (Exception ex) 
            { 
                /* Bỏ qua lỗi nhỏ khi load filter */ 
            }
        }


        // --- HÀM LOAD DỮ LIỆU ĐIỂM ---
        private void LoadDiemData()
        {
            try
            {
                string maSVHienTai = CurrentUser.Username;
                string sqlDiem = @"
            SELECT 
                D.MaMH AS MaMonHoc, 
                M.TenMH AS TenMonHoc,
                D.HocKy AS HocKy, 
                D.NamHoc AS NamHoc,
                D.DiemThanhPhan AS DiemThanhPhan, 
                D.DiemThi AS DiemThi, 
                D.DiemTongKet AS DiemTongKet, 
                D.DiemChu AS DiemChu
            FROM DIEM D
            JOIN MONHOC M ON D.MaMH = M.MaMH
            WHERE D.MaSV = @MaSV --(Tạm thời bỏ qua lọc SV để test cho dễ)
            ORDER BY D.NamHoc DESC, D.HocKy ASC";

                SqlCommand cmd = new SqlCommand(sqlDiem, conn);
                // Truyền tham số Mã SV vào câu truy vấn
                cmd.Parameters.AddWithValue("@MaSV", maSVHienTai);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dtDiem.Clear();
                dataAdapter.Fill(dtDiem);

                bsDiem.DataSource = dtDiem;
                dgvDiem.AutoGenerateColumns = false;
                dgvDiem.DataSource = bsDiem;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải điểm: " + ex.Message);
            }

        }
        

        // --- HÀM LỌC ---
        private void ApplyFilter()
        {
            if (!isLoaded) return;

            string filter = "";
            if (cbMonHoc.SelectedValue != null && cbMonHoc.SelectedValue.ToString() != "ALL")
                filter += $"MaMonHoc = '{cbMonHoc.SelectedValue}' AND ";
            if (cbNamHoc.SelectedValue != null && cbNamHoc.SelectedValue.ToString() != "ALL")
                filter += $"NamHoc = {cbNamHoc.SelectedValue} AND ";
            if (cbHocKy.SelectedValue != null && cbHocKy.SelectedValue.ToString() != "ALL")
                filter += $"HocKy = {cbHocKy.SelectedValue} AND ";

            if (filter.EndsWith(" AND ")) filter = filter.Substring(0, filter.Length - 5);

            try { bsDiem.Filter = filter; } catch { }
        }

        // --- SỰ KIỆN ---
        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            LoadDiemData();
            ApplyFilter();
            MessageBox.Show("Đã cập nhật dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Bạn nhớ kiểm tra lại sự kiện trong file Designer để đảm bảo nó trỏ đúng vào các hàm này (không có số _1)
        private void cbMonHoc_SelectedIndexChanged(object sender, EventArgs e) { ApplyFilter(); }
        private void cbNamHoc_SelectedIndexChanged_1(object sender, EventArgs e) { ApplyFilter(); }
        private void cbHocKy_SelectedIndexChanged_1(object sender, EventArgs e) { ApplyFilter(); }

        private void dgvDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}