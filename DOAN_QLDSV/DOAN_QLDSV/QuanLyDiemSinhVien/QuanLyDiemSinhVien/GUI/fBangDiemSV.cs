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
            cbHocKy.Enabled = true;
            try
            {
                // Luôn gán lại ConnectionString trước khi mở để chắc chắn
                if (conn.State == ConnectionState.Closed)
                {
                    conn.ConnectionString = @"server=.; Database=db_QLDSV;User ID=sa;Password=123;Integrated Security=True";
                    conn.Open();
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
                DataTable dtMH = new DataTable();
                daMH.Fill(dtMH);

                DataRow drMH = dtMH.NewRow();
                drMH["MaMH"] = "ALL";
                drMH["TenMH"] = "--- Tất cả môn ---";
                dtMH.Rows.InsertAt(drMH, 0);
                cbMonHoc.DisplayMember = "TenMH";
                cbMonHoc.ValueMember = "MaMH";
                cbMonHoc.DataSource = dtMH;

                // 2. Năm Học: Chỉ lấy năm mà sinh viên này CÓ ĐIỂM
                string sqlNH = @"
            SELECT DISTINCT NamHoc 
            FROM DIEM 
            WHERE MaSV = @MaSV 
            ORDER BY NamHoc DESC";
                SqlDataAdapter daNH = new SqlDataAdapter(sqlNH, conn);
                daNH.SelectCommand.Parameters.AddWithValue("@MaSV", maSVHienTai);
                DataTable dtNH = new DataTable();
                daNH.Fill(dtNH);

                DataTable dtNHFilter = new DataTable();
                dtNHFilter.Columns.Add("NamHoc", typeof(string));
                dtNHFilter.Rows.Add("--- Tất cả năm ---"); // Đổi chữ "ALL" thành tiếng Việt cho đồng bộ
                                                           // Lưu ý: Giá trị thực tế để lọc vẫn cần xử lý là "ALL" hoặc chuỗi rỗng trong ApplyFilter nếu cần
                foreach (DataRow row in dtNH.Rows) dtNHFilter.Rows.Add(row["NamHoc"].ToString());

                cbNamHoc.DisplayMember = "NamHoc";
                cbNamHoc.ValueMember = "NamHoc";
                cbNamHoc.DataSource = dtNHFilter;

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
                dtHK.Columns.Add("HocKy", typeof(string));
                dtHK.Columns.Add("TenHocKy", typeof(string));
                dtHK.Rows.Add("ALL", "--- Tất cả học kỳ ---");
                foreach (DataRow row in dtHK_Raw.Rows)
                {
                    string hk = row["HocKy"].ToString();
                    dtHK.Rows.Add(hk, "Học kỳ " + hk);
                }

                cbHocKy.DisplayMember = "TenHocKy";
                cbHocKy.ValueMember = "HocKy";
                cbHocKy.DataSource = dtHK;
            }
    catch (Exception ex) { /* Bỏ qua lỗi nhỏ khi load filter */ }
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