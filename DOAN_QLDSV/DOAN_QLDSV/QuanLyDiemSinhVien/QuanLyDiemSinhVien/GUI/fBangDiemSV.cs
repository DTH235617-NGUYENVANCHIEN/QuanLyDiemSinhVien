using QuanLyDiemSinhVien.BLL;
using QuanLyDiemSinhVien.DAL;
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

namespace QuanLyDiemSinhVien.GUI
{
    
    public partial class fBangDiemSV : Form
    {

       
        BindingSource bsDiem = new BindingSource();
        DataTable dtDiem = new DataTable();
        private bool isLoaded = false;
        public event EventHandler ThoatVeTrangChu;
        public fBangDiemSV()
        {
            InitializeComponent();
            this.cbMonHoc.SelectedIndexChanged += new System.EventHandler(this.cbMonHoc_SelectedIndexChanged);
            this.cbNamHoc.SelectedIndexChanged += new System.EventHandler(this.cbNamHoc_SelectedIndexChanged);
            this.cbHocKy.SelectedIndexChanged += new System.EventHandler(this.cbHocKy_SelectedIndexChanged);
        }

        private void fBangDiemSV_Load(object sender, EventArgs e)
        {
            cbNamHoc.Enabled = true;
            cbMonHoc.Enabled = true;
            cbHocKy.Enabled = true;
            try
            {
                        
                   LoadThongTinSinhVien();
                   LoadComboBoxFilter();
                   LoadDiemData();
                   isLoaded = true;
                
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

                // Mở kết nối cục bộ
                using (SqlConnection conn = KetnoiSQL.GetConnection())
                {
                    conn.Open();

                    // 1. Lấy thông tin cơ bản
                    string sql = @"
                    SELECT S.HoTen, S.MaSV, L.TenLop, K.TenKhoa
                    FROM SINHVIEN S JOIN LOP L ON S.MaLop = L.MaLop
                    JOIN KHOA K ON L.MaKhoa = K.MaKhoa
                    WHERE S.MaSV = @MaSV";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lbTen.Text = reader["HoTen"].ToString();
                                lbMSV.Text = reader["MaSV"].ToString();
                                lbLop.Text = reader["TenLop"].ToString();
                                lbKhoa.Text = reader["TenKhoa"].ToString();
                            }
                            reader.Close();
                        }
                    }

                    // 2. Tính điểm trung bình và xếp loại
                    string sqlDiemTB = @"
                    SELECT SUM(D.DiemTongKet * M.SoTC) / SUM(M.SoTC) AS DiemTrungBinh
                    FROM DIEM D
                    JOIN MONHOC M ON D.MaMH = M.MaMH
                    WHERE D.MaSV = @MaSV";

                    using (SqlCommand cmdDiemTB = new SqlCommand(sqlDiemTB, conn))
                    {
                        cmdDiemTB.Parameters.AddWithValue("@MaSV", maSV);
                        object result = cmdDiemTB.ExecuteScalar();

                        if (result != DBNull.Value && result != null)
                        {
                            double diemTB = Convert.ToDouble(result);
                            string xepLoai = (diemTB >= 9.0) ? "Xuất sắc" :
                                             (diemTB >= 8.0) ? "Giỏi" :
                                             (diemTB >= 7.0) ? "Khá" :
                                             (diemTB >= 5.0) ? "Trung bình" : "Yếu";

                            lbXL.Text = xepLoai;
                            lbTB.Text = diemTB.ToString("F2");
                        }
                        else
                        {
                            lbXL.Text = "Đang cập nhật";
                            lbTB.Text = "0.00";
                        }
                    }
                } // Kết nối tự động đóng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin sinh viên: " + ex.Message);
            }
        }
        // --- HÀM LOAD DỮ LIỆU CHO COMBOBOX ---
        private void LoadComboBoxFilter()
        {
            try
            {
                string maSVHienTai = CurrentUser.Username;

                using (SqlConnection conn = KetnoiSQL.GetConnection())
                {
                    conn.Open();

                    // 1. Môn Học
                    string sqlMH = @"SELECT DISTINCT M.MaMH, M.TenMH FROM MONHOC M JOIN DIEM D ON M.MaMH = D.MaMH WHERE D.MaSV = @MaSV ORDER BY M.TenMH";
                    using (SqlDataAdapter daMH = new SqlDataAdapter(sqlMH, conn))
                    {
                        daMH.SelectCommand.Parameters.AddWithValue("@MaSV", maSVHienTai);
                        DataTable dtMH_Raw = new DataTable(); daMH.Fill(dtMH_Raw);
                        DataTable dtMH = new DataTable(); dtMH.Columns.Add("MaMH"); dtMH.Columns.Add("TenMH");
                        dtMH.Rows.Add("ALL", "--- Tất cả môn ---");
                        foreach (DataRow row in dtMH_Raw.Rows) { dtMH.Rows.Add(row["MaMH"], row["TenMH"]); }
                        cbMonHoc.DataSource = dtMH; cbMonHoc.ValueMember = "MaMH"; cbMonHoc.DisplayMember = "TenMH";
                    }

                    // 2. Năm Học
                    string sqlNH = @"SELECT DISTINCT NamHoc FROM DIEM WHERE MaSV = @MaSV ORDER BY NamHoc DESC";
                    using (SqlDataAdapter daNH = new SqlDataAdapter(sqlNH, conn))
                    {
                        daNH.SelectCommand.Parameters.AddWithValue("@MaSV", maSVHienTai);
                        DataTable dtNH_Raw = new DataTable(); daNH.Fill(dtNH_Raw);
                        DataTable dtNH = new DataTable(); dtNH.Columns.Add("NamHoc"); dtNH.Columns.Add("HienNamHoc");
                        dtNH.Rows.Add("ALL", "--- Tất cả năm học ---");
                        foreach (DataRow row in dtNH_Raw.Rows) { dtNH.Rows.Add(row["NamHoc"], row["NamHoc"]); }
                        cbNamHoc.DataSource = dtNH; cbNamHoc.ValueMember = "NamHoc"; cbNamHoc.DisplayMember = "HienNamHoc";
                    }

                    // 3. Học Kỳ
                    string sqlHK = @"SELECT DISTINCT HocKy FROM DIEM WHERE MaSV = @MaSV ORDER BY HocKy";
                    using (SqlDataAdapter daHK = new SqlDataAdapter(sqlHK, conn))
                    {
                        daHK.SelectCommand.Parameters.AddWithValue("@MaSV", maSVHienTai);
                        DataTable dtHK_Raw = new DataTable(); daHK.Fill(dtHK_Raw);
                        DataTable dtHK = new DataTable(); dtHK.Columns.Add("HocKy"); dtHK.Columns.Add("TenHocKy");
                        dtHK.Rows.Add("ALL", "--- Tất cả học kỳ ---");
                        foreach (DataRow row in dtHK_Raw.Rows) { dtHK.Rows.Add(row["HocKy"], row["HocKy"]); }
                        cbHocKy.DataSource = dtHK; cbHocKy.ValueMember = "HocKy"; cbHocKy.DisplayMember = "TenHocKy";
                    }

                } // Kết nối tự động đóng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bộ lọc: " + ex.Message);
            }
        }


        // --- HÀM LOAD DỮ LIỆU ĐIỂM ---
        private void LoadDiemData()
        {
            try
            {
                string maSVHienTai = CurrentUser.Username;
                string sqlDiem = @"
                SELECT D.MaMH AS MaMonHoc, M.TenMH AS TenMonHoc,
                       D.HocKy AS HocKy, D.NamHoc AS NamHoc,
                       D.DiemThanhPhan AS DiemThanhPhan, D.DiemThi AS DiemThi, 
                       D.DiemTongKet AS DiemTongKet, D.DiemChu AS DiemChu
                FROM DIEM D
                JOIN MONHOC M ON D.MaMH = M.MaMH
                WHERE D.MaSV = @MaSV 
                ORDER BY D.NamHoc DESC, D.HocKy ASC";

                using (SqlConnection conn = KetnoiSQL.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sqlDiem, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@MaSV", maSVHienTai);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dtDiem.Clear(); // Xóa dữ liệu cũ
                    dataAdapter.Fill(dtDiem);

                    bsDiem.DataSource = dtDiem;
                    dgvDiem.AutoGenerateColumns = false;
                    dgvDiem.DataSource = bsDiem;
                }
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
                filter += $"NamHoc = '{cbNamHoc.SelectedValue}' AND ";
            if (cbHocKy.SelectedValue != null && cbHocKy.SelectedValue.ToString() != "ALL")
                filter += $"HocKy = {cbHocKy.SelectedValue} AND ";

            if (filter.EndsWith(" AND ")) filter = filter.Substring(0, filter.Length - 5);

            try { bsDiem.Filter = filter; } catch (Exception ex) { MessageBox.Show("Lỗi lọc: " + ex.Message); }
        }

        // --- SỰ KIỆN ---
        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            LoadDiemData();
            ApplyFilter();
            MessageBox.Show("Đã cập nhật dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Bạn nhớ kiểm tra lại sự kiện trong file Designer để đảm bảo nó trỏ đúng vào các hàm này (không có số _1)
        // --- Sự kiện lọc ---
        private void cbMonHoc_SelectedIndexChanged(object sender, EventArgs e) { ApplyFilter(); }
        private void cbNamHoc_SelectedIndexChanged(object sender, EventArgs e) { ApplyFilter(); }
        private void cbHocKy_SelectedIndexChanged(object sender, EventArgs e) { ApplyFilter(); }
        private void dgvDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (ThoatVeTrangChu != null)
            {
                ThoatVeTrangChu(this, EventArgs.Empty);
            }
        }
    }
}