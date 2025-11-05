using QuanLyDiemSinhVien.BLL;
using QuanLyDiemSinhVien.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSinhVien.GUI
{
    public partial class fDoiMatKhau : Form
    {


        public fDoiMatKhau()
        {
            InitializeComponent();
            // THAY ĐỔI: Đặt tiêu đề form dựa trên CurrentUser
            this.Text = "Đổi Mật Khẩu cho: " + CurrentUser.Username;
        }


        // --- HÀM MÃ HÓA SHA-256 ---
        // Hàm này tạo ra chuỗi hash giống hệt trong CSDL của bạn
        private string MaHoaSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Chuyển chuỗi input thành mảng byte và tính toán hash
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Chuyển mảng byte thành chuỗi hexa
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // "x2" để format thành lowercase hex
                }
                return builder.ToString();
            }
        }


        private void btnCapNhat_Click(object sender, EventArgs e)
        {// 1. Lấy dữ liệu
            string matKhauCu = txtMatKhauCu.Text;
            string matKhauMoi = txtMatKhauMoi.Text;
            string nhapLaiMatKhau = txtNhapLaiMatKhau.Text;

            // 2. Kiểm tra
            if (string.IsNullOrWhiteSpace(matKhauCu) ||
                string.IsNullOrWhiteSpace(matKhauMoi) ||
                string.IsNullOrWhiteSpace(nhapLaiMatKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (matKhauMoi != nhapLaiMatKhau)
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu nhập lại không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapLaiMatKhau.Focus();
                return;
            }

            try
            {
                // Mở kết nối
                KetnoiSQL.MoKetNoi();

                // 3. Kiểm tra mật khẩu cũ
                string sqlCheck = "SELECT MatKhau FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, KetnoiSQL.conn);
                cmdCheck.Parameters.AddWithValue("@TenDangNhap", CurrentUser.Username);

                string hashMatKhauCu_DB = cmdCheck.ExecuteScalar()?.ToString();
                string hashMatKhauCu_Input = MaHoaSHA256(matKhauCu);

                if (hashMatKhauCu_DB != hashMatKhauCu_Input)
                {
                    MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhauCu.Focus();
                    return; // Sẽ nhảy đến 'finally'
                }

                // 4. Cập nhật mật khẩu mới
                string hashMatKhauMoi = MaHoaSHA256(matKhauMoi);
                string sqlUpdate = "UPDATE TaiKhoan SET MatKhau = @MatKhauMoi WHERE TenDangNhap = @TenDangNhap";

                SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, KetnoiSQL.conn);
                cmdUpdate.Parameters.AddWithValue("@MatKhauMoi", hashMatKhauMoi);
                cmdUpdate.Parameters.AddWithValue("@TenDangNhap", CurrentUser.Username);

                cmdUpdate.ExecuteNonQuery();

                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Luôn đóng kết nối
                KetnoiSQL.DongKetNoi();
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fDoiMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}

