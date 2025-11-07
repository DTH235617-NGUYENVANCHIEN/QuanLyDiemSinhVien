using QuanLyDiemSinhVien.BLL;
using QuanLyDiemSinhVien.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSinhVien.GUI
{
    public partial class fQuanLyTaiKhoan : Form
    {

        String login = "";
        //mở trang chủ khi bấm nút thoát 
        public event EventHandler ThoatVeTrangChu;

        public fQuanLyTaiKhoan()
        {
            InitializeComponent();

        }
        private void fQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {


            TaiLaiDuLieu_TK();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            login = "";
            //Xoa trang
            txtTen.Text = "";
            txtPass.Text = "";
            cobQuyen.Text = "";
            MoNut(false);
            txtTen.Focus();

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            login = txtTen.Text;
            MoNut(false);
            txtPass.Text = "";
            txtPass.Focus();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult kq;
            kq = MessageBox.Show("Bạn có muốn xóa tài khoản " + txtTen.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                // SỬA: Dùng 'using'
                using (SqlConnection conn = KetnoiSQL.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string sql = @"DELETE FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
                        SqlCommand cmd = new SqlCommand(sql, conn); // Dùng 'conn' mới
                        cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 20).Value = txtTen.Text;
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                } // conn tự động đóng

                TaiLaiDuLieu_TK();
            }

        }

        // Hàm băm mật khẩu (dùng SHA256)

        private void btnLuu_Click(object sender, EventArgs e)
        {
           // ---CÁC KIỂM TRA CŨ(Giữ nguyên)-- -
            if (cobQuyen.Text.Trim() == "")
            {
                MessageBox.Show("Chưa chọn quyen!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng lại
            }
            if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Ten không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng lại
            }
            if (login == "" && txtPass.Text.Trim() == "") // login == "" là Thêm mới
            {
                MessageBox.Show("MK không được bỏ trống khi thêm mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng lại
            }

            // --- TIẾN HÀNH LƯU (ĐÃ SỬA) ---
            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                try
                {
                    conn.Open();
                    string tenMoi = txtTen.Text.Trim(); // Tên mới người dùng nhập

                    if (login == "") // Thêm mới
                    {
                        // ===== BƯỚC 1: KIỂM TRA TRÙNG KHI THÊM MỚI =====
                        string sqlCheck = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
                        SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                        cmdCheck.Parameters.Add("@TenDangNhap", SqlDbType.VarChar, 20).Value = tenMoi;

                        int count = (int)cmdCheck.ExecuteScalar(); // Lấy số lượng

                        if (count > 0)
                        {
                            // Nếu tìm thấy (count > 0), báo lỗi thân thiện và dừng lại
                            MessageBox.Show(
                                "Tên đăng nhập '" + tenMoi + "' đã tồn tại. Vui lòng chọn tên khác!",
                                "Lỗi Trùng Tên",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            return; // Dừng, không INSERT
                        }
                        // ===== KẾT THÚC KIỂM TRA TRÙNG =====

                        // Nếu không trùng, tiếp tục INSERT
                        string passHashed = MaHoa.MaHoaSHA256(txtPass.Text);
                        string sqlInsert = @"INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaQuyen)
                                     VALUES(@TenDangNhap, @MatKhau, @MaQuyen)";

                        SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                        cmd.Parameters.Add("@TenDangNhap", SqlDbType.VarChar, 20).Value = tenMoi;
                        cmd.Parameters.Add("@MatKhau", SqlDbType.VarChar, 128).Value = passHashed;
                        cmd.Parameters.Add("@MaQuyen", SqlDbType.VarChar, 10).Value = cobQuyen.SelectedValue;
                        cmd.ExecuteNonQuery();
                    }
                    else // Sửa
                    {
                        // ===== BƯỚC 2: KIỂM TRA TRÙNG KHI SỬA =====
                        // (Chỉ kiểm tra nếu người dùng đổi Tên đăng nhập)
                        if (tenMoi != login) // Nếu tên mới khác tên gốc (login)
                        {
                            string sqlCheck = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
                            SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                            cmdCheck.Parameters.Add("@TenDangNhap", SqlDbType.VarChar, 20).Value = tenMoi;
                            int count = (int)cmdCheck.ExecuteScalar();
                            if (count > 0)
                            {
                                MessageBox.Show(
                                    "Tên đăng nhập '" + tenMoi + "' đã tồn tại. Vui lòng chọn tên khác!",
                                    "Lỗi Trùng Tên",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                return; // Dừng, không UPDATE
                            }
                        }
                        // ===== KẾT THÚC KIỂM TRA TRÙNG =====

                        // Nếu không trùng, tiếp tục UPDATE
                        SqlCommand cmd;
                        if (txtPass.Text.Trim() == "") // Không đổi pass
                        {
                            string sqlUpdate = @"UPDATE TaiKhoan
                                         SET TenDangNhap = @TenDangNhapMoi,
                                             MaQuyen = @MaQuyen
                                         WHERE TenDangNhap = @TenDangNhapCu";
                            cmd = new SqlCommand(sqlUpdate, conn);
                        }
                        else // Có đổi pass
                        {
                            string passHashed = MaHoa.MaHoaSHA256(txtPass.Text);
                            string sqlUpdate = @"UPDATE TaiKhoan
                                         SET TenDangNhap = @TenDangNhapMoi,
                                             MatKhau = @MatKhau,
                                             MaQuyen = @MaQuyen
                                         WHERE TenDangNhap = @TenDangNhapCu";
                            cmd = new SqlCommand(sqlUpdate, conn);
                            cmd.Parameters.Add("@MatKhau", SqlDbType.VarChar, 128).Value = passHashed;
                        }

                        // Các tham số chung
                        cmd.Parameters.Add("@TenDangNhapMoi", SqlDbType.NVarChar, 10).Value = tenMoi;
                        cmd.Parameters.Add("@TenDangNhapCu", SqlDbType.NVarChar, 10).Value = login;
                        cmd.Parameters.Add("@MaQuyen", SqlDbType.VarChar, 10).Value = cobQuyen.SelectedValue;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Catch này giờ chỉ bắt các lỗi khác (ví dụ: mất kết nối)
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            } // conn tự động đóng

            TaiLaiDuLieu_TK(); // Tải lại dữ liệu sau khi Lưu

        }


        private void btnTailai_Click(object sender, EventArgs e)
        {
            TaiLaiDuLieu_TK();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (ThoatVeTrangChu != null)
            {
                ThoatVeTrangChu(this, EventArgs.Empty);
            }
        }
        private void TaiLaiDuLieu_TK()
        {
            string sqlTaiKhoan = @"SELECT T.*,L.TenQuyen 
                                   FROM TaiKhoan T, LOAITAIKHOAN L
                                   WHERE L.MaQuyen=T.MaQuyen";
            string LoaiTKsql = @"SELECT * FROM LOAITAIKHOAN";

            DataTable data = new DataTable();
            DataTable tableLoaiSach = new DataTable();
            this.dgvTaikhoan.Columns["MatKhau"].Visible = false; // Ẩn cột Mật khẩu
     

            // SỬA: Dùng 1 'using' duy nhất
            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlTaiKhoan, conn); // Dùng 'conn' mới
                    dataAdapter.Fill(data);

                    SqlDataAdapter loaiTKAdapter = new SqlDataAdapter(LoaiTKsql, conn); // Dùng 'conn' mới
                    loaiTKAdapter.Fill(tableLoaiSach);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                    return;
                }
            } // conn tự động đóng

            // 1. Tải dữ liệu TAIKHOAN
            dgvTaikhoan.AutoGenerateColumns = false;
            dgvTaikhoan.DataSource = data;

            // 2. Tải dữ liệu LOAITAIKHOAN (cho ComboBox)
            cobQuyen.DataSource = tableLoaiSach;
            cobQuyen.DisplayMember = "TenQuyen";
            cobQuyen.ValueMember = "MaQuyen";

            // 3. Đặt trạng thái nút
            MoNut(true);

            // 4. Data Bindings (Giữ nguyên)
            cobQuyen.DataBindings.Clear();
            txtTen.DataBindings.Clear();


            cobQuyen.DataBindings.Add("SelectedValue", dgvTaikhoan.DataSource, "MaQuyen", false, DataSourceUpdateMode.Never);
            txtTen.DataBindings.Add("Text", dgvTaikhoan.DataSource, "TenDangNhap", false, DataSourceUpdateMode.Never);

        }


        private void MoNut(bool t)
        {
            txtTen.Enabled = !t;
            txtPass.Enabled = !t;
            cobQuyen.Enabled = !t;

            btnThem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnThoat.Enabled = t;
            btnTailai.Enabled = !t;

            btnLuu.Enabled = !t;
        }

        private void dgvTaikhoan_SelectionChanged(object sender, EventArgs e)
        {
            // Khi người dùng bấm chọn 1 hàng (ở chế độ xem, không phải Sửa/Thêm)
            // Luôn luôn đặt txtPass là "********"
            if (btnLuu.Enabled == false) // btnLuu.Enabled = false nghĩa là đang ở chế độ xem
            {
                txtPass.Text = "********";
            }
        }
    }
}
