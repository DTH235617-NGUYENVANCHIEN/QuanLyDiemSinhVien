using Microsoft.VisualBasic.Logging;
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
    public partial class fQuanLyLop : Form
    {

        String Malop = "";
        public fQuanLyLop()
        {
            InitializeComponent();
            
        }
        private void fQuanLyLop_Load(object sender, EventArgs e)
        {
     
            TaiLaiDuLieu_Lop();
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            Malop = "";
            //Xoa trang
            txtMalop.Text = "";
            txtTenlop.Text = "";
            // THAY BẰNG DÒNG NÀY:
            cboLoaikhoa.SelectedIndex = -1; // Set về không chọn gì
                                            // Dòng trên sẽ tự động kích hoạt sự kiện ở Bước 3
                                            // và làm cho cobGiaovien (ComboBox giáo viên) tự động bị xóa theo.
            MoNut(false);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            Malop = txtMalop.Text;
            MoNut(false);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {

            DialogResult kq;
            kq = MessageBox.Show("Bạn có muốn xóa lớp " + txtTenlop.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                // SỬA: Dùng 'using'
                using (SqlConnection conn = KetnoiSQL.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string sql = @"DELETE FROM Lop WHERE MaLop = @MaLop";
                        SqlCommand cmd = new SqlCommand(sql, conn); // Dùng 'conn' mới
                        cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 20).Value = txtMalop.Text;
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                } // conn tự động đóng
                TaiLaiDuLieu_Lop();
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maLop = txtMalop.Text.Trim();
            string tenLop = txtTenlop.Text.Trim();

            // --- KIỂM TRA DỮ LIỆU ---
            if (maLop == "")
                MessageBox.Show("Mã lớp không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tenLop == "")
                MessageBox.Show("Tên lớp không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboLoaikhoa.SelectedValue == null)
                MessageBox.Show("Vui lòng chọn Khoa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cobGiaovien.SelectedValue == null)
                MessageBox.Show("Vui lòng chọn Giáo viên quản lý!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                // SỬA: Dùng 'using'
                using (SqlConnection conn = KetnoiSQL.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string maKhoa = cboLoaikhoa.SelectedValue.ToString();
                        string maGV = cobGiaovien.SelectedValue.ToString();

                        if (Malop == "") // THÊM MỚI
                        {
                            string sql = @"INSERT INTO LOP (MaLop, TenLop, MaKhoa, MaGV_CVHT) 
                                           VALUES (@MaLop, @TenLop, @MaKhoa, @MaGV_CVHT)";
                            SqlCommand cmd = new SqlCommand(sql, conn); // Dùng 'conn' mới
                            cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 20).Value = maLop;
                            cmd.Parameters.Add("@TenLop", SqlDbType.NVarChar, 100).Value = tenLop;
                            cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 20).Value = maKhoa;
                            cmd.Parameters.Add("@MaGV_CVHT", SqlDbType.VarChar, 20).Value = maGV;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Thêm lớp mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else // SỬA
                        {
                            string sql = @"UPDATE LOP
                                           SET MaLop = @MaLop_Moi,
                                               TenLop = @TenLop,
                                               MaKhoa = @MaKhoa,
                                               MaGV_CVHT = @MaGV_CVHT
                                           WHERE MaLop = @MaLop_Cu";
                            SqlCommand cmd = new SqlCommand(sql, conn); // Dùng 'conn' mới
                            cmd.Parameters.Add("@MaLop_Moi", SqlDbType.VarChar, 20).Value = maLop;
                            cmd.Parameters.Add("@TenLop", SqlDbType.NVarChar, 100).Value = tenLop;
                            cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 20).Value = maKhoa;
                            cmd.Parameters.Add("@MaGV_CVHT", SqlDbType.VarChar, 20).Value = maGV;
                            cmd.Parameters.Add("@MaLop_Cu", SqlDbType.VarChar, 20).Value = Malop;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cập nhật lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (SqlException ex) // (Bắt lỗi SQL)
                    {
                        if (ex.Message.Contains("UNIQUE KEY constraint"))
                            MessageBox.Show("Mã lớp '" + maLop + "' đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else if (ex.Message.Contains("FOREIGN KEY constraint"))
                            MessageBox.Show("Lỗi khóa ngoại, kiểm tra lại Mã Khoa hoặc Mã Giáo viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } // conn tự động đóng

                TaiLaiDuLieu_Lop();
            }

        }
        private void btnTailai_Click(object sender, EventArgs e)
        {
            TaiLaiDuLieu_Lop();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TaiLaiDuLieu_Lop()
        {
            // SỬA: Tạo 3 câu SQL
            string sqlLop = @"SELECT L.*,G.HoTen,K.TenKhoa
                            FROM Lop L, GIAOVIEN G,KHOA K
                            WHERE L.MaGV_CVHT=G.MaGV 
                            AND L.MaKhoa =K.MaKhoa";
            string LoaiKhoasql = @"SELECT * FROM KHOA";
            string LoaiGVsql = @"SELECT * FROM GIAOVIEN"; // Tải tất cả GV

            DataTable data = new DataTable();
            DataTable tablekhoa = new DataTable();
            DataTable tableGV = new DataTable();

            // SỬA: Dùng 1 'using' duy nhất để tải cả 3 bảng
            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlLop, conn);
                    dataAdapter.Fill(data);

                    SqlDataAdapter loaiKhoaAdapter = new SqlDataAdapter(LoaiKhoasql, conn);
                    loaiKhoaAdapter.Fill(tablekhoa);

                    SqlDataAdapter loaiGVAdapter = new SqlDataAdapter(LoaiGVsql, conn);
                    loaiGVAdapter.Fill(tableGV);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                    return;
                }
            } // conn tự động đóng

            // 1. Đổ dữ liệu LỚP
            dgvLop.AutoGenerateColumns = false;
            dgvLop.DataSource = data;

            // 2. Đổ dữ liệu KHOA
            cboLoaikhoa.DataSource = tablekhoa;
            cboLoaikhoa.DisplayMember = "TenKhoa";
            cboLoaikhoa.ValueMember = "MaKhoa";

            // 3. Đổ dữ liệu GIÁO VIÊN (tạm thời)
            cobGiaovien.DataSource = tableGV;
            cobGiaovien.DisplayMember = "HoTen";
            cobGiaovien.ValueMember = "MaGV";

            // 4. Đặt trạng thái nút
            MoNut(true);

            // 5. Data Bindings
            cboLoaikhoa.DataBindings.Clear();
            cobGiaovien.DataBindings.Clear();
            txtMalop.DataBindings.Clear();
            txtTenlop.DataBindings.Clear();

            cboLoaikhoa.DataBindings.Add("SelectedValue", dgvLop.DataSource, "MaKhoa", false, DataSourceUpdateMode.Never);
            cobGiaovien.DataBindings.Add("SelectedValue", dgvLop.DataSource, "MaGV_CVHT", false, DataSourceUpdateMode.Never);
            txtMalop.DataBindings.Add("Text", dgvLop.DataSource, "MaLop", false, DataSourceUpdateMode.Never);
            txtTenlop.DataBindings.Add("Text", dgvLop.DataSource, "TenLop", false, DataSourceUpdateMode.Never);
        }
        private void LoadGiangVienComboBox(string maKhoa)
        {
            DataTable dtGV = new DataTable();

            // SỬA: Dùng 'using'
            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                try
                {
                    if (!string.IsNullOrEmpty(maKhoa))
                    {
                        string sqlGV = "SELECT MaGV, HoTen FROM GIAOVIEN WHERE MaKhoa = @MaKhoa";
                        SqlDataAdapter daGV = new SqlDataAdapter(sqlGV, conn); // conn mới
                        daGV.SelectCommand.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 20).Value = maKhoa;
                        daGV.Fill(dtGV);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lọc giáo viên: " + ex.Message);
                }
            } // conn tự động đóng

            cobGiaovien.DataSource = dtGV;
            cobGiaovien.DisplayMember = "HoTen";
            cobGiaovien.ValueMember = "MaGV";
        }
        private void cboLoaikhoa_SelectedValueChanged(object sender, EventArgs e)
        {
            // Chỉ chạy khi người dùng tương tác (không phải lúc data binding)
            // Sửa: (cboLoaikhoa.Focused || !cboLoaikhoa.Enabled) để bắt sự kiện khi bấm Thêm
            if (cboLoaikhoa.Focused || !cboLoaikhoa.Enabled)
            {
                if (cboLoaikhoa.SelectedValue != null)
                {
                    string maKhoa = cboLoaikhoa.SelectedValue.ToString();
                    LoadGiangVienComboBox(maKhoa); // Tải lại GV theo Khoa
                }
                else
                {
                    LoadGiangVienComboBox(null); // Xóa sạch GV
                }
            }
        }
        private void MoNut(bool t)
        {
            txtMalop.Enabled = !t;
            txtTenlop.Enabled = !t;
            cobGiaovien.Enabled = !t;
            cboLoaikhoa.Enabled = !t;


            btnThem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnThoat.Enabled = t;
            btnTailai.Enabled = !t;

            btnLuu.Enabled = !t;
        }
    }
}

