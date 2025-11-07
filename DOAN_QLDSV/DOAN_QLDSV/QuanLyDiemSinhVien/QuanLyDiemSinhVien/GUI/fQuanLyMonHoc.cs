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
        //mở trang chủ khi bấm nút thoát 
        public event EventHandler ThoatVeTrangChu;
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
            txtMaKhoa.Text = "";

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
            // <--- SỬA 2: Lấy MaKhoa từ TextBox (Giả sử tên là txtMaKhoa) --->
            string maKhoa = txtMaKhoa.Text.Trim();

            // --- 1. KIỂM TRA DỮ LIỆU ĐẦU VÀO ---
            if (maMH == "")
                MessageBox.Show("Mã môn học không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tenMH == "")
                MessageBox.Show("Tên môn học không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (soTC <= 0)
                MessageBox.Show("Số tín chỉ phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // <--- SỬA 3: Thay đổi logic kiểm tra Khoa --->
            else if (string.IsNullOrEmpty(maKhoa))
            {
                MessageBox.Show("Bạn phải nhập Mã khoa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKhoa.Focus();
            }
            // <--- THÊM MỚI 2: Ràng buộc (Constraint) mà bạn yêu cầu --->
            else if (!KiemTraKhoaTonTai(maKhoa))
            {
                MessageBox.Show("Mã khoa '" + maKhoa + "' không tồn tại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKhoa.Focus();
            }
            else
            {
                // --- 2. DỮ LIỆU HỢP LỆ -> TIẾN HÀNH LƯU ---
                using (SqlConnection conn = KetnoiSQL.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        // Trường hợp THÊM MỚI
                        if (Mamonhoc == "")
                        {
                            // Câu lệnh SQL vẫn đúng (đã lưu MaKhoa)
                            string sql = @"INSERT INTO MONHOC (MaMH, TenMH, SoTC, MaKhoa) 
                                           VALUES (@MaMH, @TenMH, @SoTC, @MaKhoa)";

                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.Add("@MaMH", SqlDbType.VarChar, 20).Value = maMH;
                            cmd.Parameters.Add("@TenMH", SqlDbType.NVarChar, 100).Value = tenMH;
                            cmd.Parameters.Add("@SoTC", SqlDbType.Int).Value = soTC;
                            cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 20).Value = maKhoa;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Thêm môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        // Trường hợp SỬA
                        else
                        {
                            // Câu lệnh SQL vẫn đúng (đã lưu MaKhoa)
                            string sql = @"UPDATE MONHOC
                                           SET MaMH = @MaMH_Moi,
                                               TenMH = @TenMH,
                                               SoTC = @SoTC,
                                               MaKhoa = @MaKhoa
                                           WHERE MaMH = @MaMH_Cu";

                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.Add("@MaMH_Moi", SqlDbType.VarChar, 20).Value = maMH;
                            cmd.Parameters.Add("@TenMH", SqlDbType.NVarChar, 100).Value = tenMH;
                            cmd.Parameters.Add("@SoTC", SqlDbType.Int).Value = soTC;
                            cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 20).Value = maKhoa;
                            cmd.Parameters.Add("@MaMH_Cu", SqlDbType.VarChar, 20).Value = Mamonhoc;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cập nhật môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (SqlException ex)
                    {
                        // ... (Phần bắt lỗi giữ nguyên) ...
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
            if (ThoatVeTrangChu != null)
            {
                ThoatVeTrangChu(this, EventArgs.Empty);
            }
        }
        private void TaiLaiDuLieu()
        {
            string sqlMonHoc = @"
                SELECT 
                    ROW_NUMBER() OVER (ORDER BY MH.MaMH) AS SoThuTuHienThi, 
                    MH.MaMH, MH.TenMH, MH.SoTC, MH.MaKhoa
                FROM MONHOC MH";

            // THÊM ĐIỀU KIỆN LỌC
            if (CurrentUser.TenQuyen == "Teacher")
            {
                // <--- SỬA 5: Cập nhật SQL cho Teacher (Bỏ JOIN, chỉ lấy MaKhoa) --->
                sqlMonHoc = @"
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY MH.MaMH) AS SoThuTuHienThi, 
                        MH.MaMH, MH.TenMH, MH.SoTC, MH.MaKhoa
                    FROM MONHOC MH
                    WHERE MH.MaMH IN (
                        SELECT DISTINCT MaMH FROM DIEM 
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

                    if (CurrentUser.TenQuyen == "Teacher")
                    {
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

            // Data Bindings
            txtMamonhoc.DataBindings.Clear();
            txtTenMH.DataBindings.Clear();
            nudSotinchi.DataBindings.Clear();
            // <--- SỬA 6: Đổi ComboBox sang TextBox --->
            txtMaKhoa.DataBindings.Clear();

            txtMamonhoc.DataBindings.Add("Text", dgvMonhoc.DataSource, "MaMH", false, DataSourceUpdateMode.Never);
            txtTenMH.DataBindings.Add("Text", dgvMonhoc.DataSource, "TenMH", false, DataSourceUpdateMode.Never);
            nudSotinchi.DataBindings.Add("Value", dgvMonhoc.DataSource, "SoTC", false, DataSourceUpdateMode.Never);
            // <--- SỬA 7: Binding cho TextBox MaKhoa --->
            txtMaKhoa.DataBindings.Add("Text", dgvMonhoc.DataSource, "MaKhoa", false, DataSourceUpdateMode.Never);
        }
        private bool KiemTraKhoaTonTai(string maKhoa)
        {
            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Dùng SELECT 1 (nhanh hơn COUNT(*)) để kiểm tra sự tồn tại
                    string sql = "SELECT 1 FROM KHOA WHERE MaKhoa = @MaKhoa";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);

                    object result = cmd.ExecuteScalar();

                    // Nếu ExecuteScalar trả về 1 (hoặc bất cứ gì không null), nghĩa là Mã Khoa tồn tại
                    return (result != null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra mã khoa: " + ex.Message);
                    return false; // Gặp lỗi thì coi như không tồn tại
                }
            }
        }
        private void MoNut(bool t)
        {
            txtMamonhoc.Enabled = !t;
            txtTenMH.Enabled = !t;
            nudSotinchi.Enabled = !t;
            txtMaKhoa.Enabled = !t;

            btnThem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnThoat.Enabled = t;
            btnTailai.Enabled = !t;

            btnLuu.Enabled = !t;
        }
    }
}
