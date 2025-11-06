using Microsoft.VisualBasic.Logging;
using Microsoft.Win32.SafeHandles;
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
    public partial class fQuanLyMonHoc : Form
    {
        // Dùng để lưu trạng thái đang "Thêm mới" (rỗng) hay "Sửa" (chứa MaMH)
        String Mamonhoc = "";
        public fQuanLyMonHoc()
        {
            InitializeComponent();
            
        }


        private void fQuanLyMonHoc_Load(object sender, EventArgs e)
        {
            // Phân quyền: Nếu là Teacher thì ẩn các nút chức năng
            if (CurrentUser.TenQuyen == "Teacher")
            {
                // Ẩn tất cả các nút Thêm, Sửa, Xóa, Lưu
                btnThem.Visible = false;
                btnXoa.Visible = false;
                btnSua.Visible = false;
                btnLuu.Visible = false;
                btnTailai.Visible = false; // Ẩn luôn nút Tải lại/Hủy
            }

            TaiLaiDuLieu();
        }
     
        private void btnThem_Click(object sender, EventArgs e)
        {
            Mamonhoc = "";
            //Xoa trang
            txtMamonhoc.Text = "";
            txtTenMH.Text = "";
            nudSotinchi.Value = 0;

            MoNut(false);
            txtMamonhoc.Focus();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            Mamonhoc = txtMamonhoc.Text;
            MoNut(false);
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult kq;
            kq = MessageBox.Show("Bạn có muốn xóa môn học: " + txtTenMH.Text + " không?", "Xóa",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                // SỬA: Dùng 'using'
                using (SqlConnection conn = KetnoiSQL.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string sql = @"DELETE FROM MONHOC WHERE MaMH = @MaMH";
                        SqlCommand cmd = new SqlCommand(sql, conn); // Dùng 'conn' mới
                        cmd.Parameters.Add("@MaMH", SqlDbType.VarChar, 20).Value = txtMamonhoc.Text;
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } // conn tự động đóng
                TaiLaiDuLieu();
            }
        }



        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maMH = txtMamonhoc.Text.Trim();
            string tenMH = txtTenMH.Text.Trim();
            int soTC = (int)nudSotinchi.Value;

            // --- 1. KIỂM TRA DỮ LIỆU ĐẦU VÀO ---
            if (maMH == "")
                MessageBox.Show("Mã môn học không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tenMH == "")
                MessageBox.Show("Tên môn học không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (soTC <= 0)
                MessageBox.Show("Số tín chỉ phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                // --- 2. DỮ LIỆU HỢP LỆ -> TIẾN HÀNH LƯU ---
                // SỬA: Dùng 'using'
                using (SqlConnection conn = KetnoiSQL.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        // Trường hợp THÊM MỚI
                        if (Mamonhoc == "")
                        {
                            string sql = @"INSERT INTO MONHOC (MaMH, TenMH, SoTC) 
                                           VALUES (@MaMH, @TenMH, @SoTC)";

                            SqlCommand cmd = new SqlCommand(sql, conn); // Dùng 'conn' mới
                            cmd.Parameters.Add("@MaMH", SqlDbType.VarChar, 20).Value = maMH;
                            cmd.Parameters.Add("@TenMH", SqlDbType.NVarChar, 100).Value = tenMH;
                            cmd.Parameters.Add("@SoTC", SqlDbType.Int).Value = soTC;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Thêm môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        // Trường hợp SỬA
                        else
                        {
                            string sql = @"UPDATE MONHOC
                                           SET MaMH = @MaMH_Moi,
                                               TenMH = @TenMH,
                                               SoTC = @SoTC
                                           WHERE MaMH = @MaMH_Cu";

                            SqlCommand cmd = new SqlCommand(sql, conn); // Dùng 'conn' mới
                            cmd.Parameters.Add("@MaMH_Moi", SqlDbType.VarChar, 20).Value = maMH;
                            cmd.Parameters.Add("@TenMH", SqlDbType.NVarChar, 100).Value = tenMH;
                            cmd.Parameters.Add("@SoTC", SqlDbType.Int).Value = soTC;
                            cmd.Parameters.Add("@MaMH_Cu", SqlDbType.VarChar, 20).Value = Mamonhoc;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cập nhật môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (SqlException ex) // Bắt lỗi SQL (Giữ nguyên)
                    {
                        if (ex.Message.Contains("UNIQUE KEY constraint"))
                            MessageBox.Show("Mã môn học '" + maMH + "' đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else if (ex.Message.Contains("CHECK constraint"))
                            MessageBox.Show("Số tín chỉ phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } // conn tự động đóng

                // --- 3. TẢI LẠI FORM ---
                TaiLaiDuLieu();
            }
        }

        private void btnTailai_Click(object sender, EventArgs e)
        {
            TaiLaiDuLieu();
        }


        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TaiLaiDuLieu()
        {
            // SỬA LOGIC: Mặc định là Admin (SELECT *), nếu là Teacher thì lọc theo MaGV trong bảng DIEM
            string sqlMonHoc = @"SELECT * FROM MONHOC";

            // THÊM ĐIỀU KIỆN LỌC
            if (CurrentUser.TenQuyen == "Teacher")
            {
                // Chỉ chọn những môn học mà MaGV_HienTai có dạy (dựa trên MaMH có trong bảng DIEM)
                sqlMonHoc = @"
                    SELECT DISTINCT MH.* FROM MONHOC MH
                    WHERE MH.MaMH IN (
                        SELECT MaMH FROM DIEM 
                        WHERE MaGV = @MaGV_HienTai
                    )";
            }

            DataTable data = new DataTable();

            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlMonHoc, conn);

                    // THÊM PARAMETER NẾU LÀ GIÁO VIÊN
                    if (CurrentUser.TenQuyen == "Teacher")
                    {
                        // Giả định TenDangNhap của GV chính là MaGV
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@MaGV_HienTai", CurrentUser.Username);
                    }

                    dataAdapter.Fill(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                    return;
                }
            }

            dgvMonhoc.DataSource = data;
            MoNut(true);

            // Data Bindings (Giữ nguyên)
            txtMamonhoc.DataBindings.Clear();
            txtTenMH.DataBindings.Clear();
            nudSotinchi.DataBindings.Clear();

            txtMamonhoc.DataBindings.Add("Text", dgvMonhoc.DataSource, "MaMH", false, DataSourceUpdateMode.Never);
            txtTenMH.DataBindings.Add("Text", dgvMonhoc.DataSource, "TenMH", false, DataSourceUpdateMode.Never);
            nudSotinchi.DataBindings.Add("Value", dgvMonhoc.DataSource, "SoTC", false, DataSourceUpdateMode.Never);
        }
        private void MoNut(bool t)
        {
            txtMamonhoc.Enabled = !t;
            txtTenMH.Enabled = !t;
            nudSotinchi.Enabled = !t;

            btnThem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnThoat.Enabled = t;
            btnTailai.Enabled = !t;

            btnLuu.Enabled = !t;
        }

       
    }
}
