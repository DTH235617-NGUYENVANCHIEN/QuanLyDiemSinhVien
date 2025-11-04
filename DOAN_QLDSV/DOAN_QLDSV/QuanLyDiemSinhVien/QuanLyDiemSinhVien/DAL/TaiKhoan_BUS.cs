using QuanLyDiemSinhVien.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVien.DAL
{
    public class TaiKhoan_BUS
    {
        /// <summary>
        /// Kiểm tra đăng nhập, nếu thành công thì lưu thông tin vào CurrentUser.
        /// </summary>
        /// <param name="tenDangNhap">Tên đăng nhập (plaintext)</param>
        /// <param name="matKhauHashed">Mật khẩu ĐÃ ĐƯỢC BĂM (hashed)</param>
        /// <returns>True nếu đăng nhập thành công, False nếu thất bại.</returns>
        public bool KiemTraDangNhap(string tenDangNhap, string matKhauHashed)
        {
            // Câu SQL JOIN 2 bảng để lấy Tên Quyền
            string sql = @"SELECT T.TenDangNhap, L.TenQuyen 
                           FROM TaiKhoan T
                           INNER JOIN LOAITAIKHOAN L ON T.MaQuyen = L.MaQuyen
                           WHERE T.TenDangNhap = @user AND T.MatKhau = @pass";

            try
            {
                KetnoiSQL.MoKetNoi();
                using (SqlCommand cmd = new SqlCommand(sql, KetnoiSQL.conn))
                {
                    cmd.Parameters.Add("@user", SqlDbType.VarChar, 20).Value = tenDangNhap;
                    // Chú ý: CSDL của bạn lưu mật khẩu 128 ký tự
                    cmd.Parameters.Add("@pass", SqlDbType.VarChar, 128).Value = matKhauHashed;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Nếu tìm thấy một dòng (đăng nhập đúng)
                        {
                            // LƯU THÔNG TIN VÀO PHIÊN LÀM VIỆC (SESSION)
                            CurrentUser.Username = reader["TenDangNhap"].ToString();

                            // SỬA Ở ĐÂY: Thêm .Trim() để cắt bỏ các khoảng trắng
                            CurrentUser.TenQuyen = reader["TenQuyen"].ToString().Trim();

                            reader.Close(); // Đóng reader trước khi return
                            return true; // Đăng nhập thành công
                        }
                        else
                        {
                            // Không tìm thấy (sai user/pass)
                            reader.Close();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Ném lỗi ra để FormLogin xử lý
                throw new Exception("Lỗi khi kiểm tra đăng nhập: " + ex.Message);
            }
            // Không cần finally để đóng kết nối, vì ta dùng chung 1 kết nối static
        }
    }
}
