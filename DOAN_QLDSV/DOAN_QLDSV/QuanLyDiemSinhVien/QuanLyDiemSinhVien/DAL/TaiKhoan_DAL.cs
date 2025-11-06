using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVien.DAL
{
    public class TaiKhoan_DAL
    {
        /// <summary>
        /// Lấy thông tin tài khoản từ CSDL.
        /// </summary>
        /// <returns>Một DataTable chứa 1 dòng (nếu tìm thấy) hoặc 0 dòng (nếu sai).</returns>
        public DataTable KiemTraDangNhap_DAL(string tenDangNhap, string matKhauHashed)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT T.TenDangNhap, L.TenQuyen 
                           FROM TaiKhoan T
                           INNER JOIN LOAITAIKHOAN L ON T.MaQuyen = L.MaQuyen
                           WHERE T.TenDangNhap = @user AND T.MatKhau = @pass";

            // SỬA LỖI 1: Dùng 'using' để tạo kết nối mới và tự động đóng
            // Giống hệt cách chúng ta đã sửa ở file fQuanLyGiaoVien.cs
            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@user", SqlDbType.VarChar, 20).Value = tenDangNhap;
                        cmd.Parameters.Add("@pass", SqlDbType.VarChar, 128).Value = matKhauHashed;

                        // Dùng SqlDataAdapter để lấy dữ liệu vào DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    // Ném lỗi ra để lớp BUS hoặc GUI xử lý
                    throw new Exception("Lỗi khi truy vấn CSDL: " + ex.Message);
                }
            } // Kết nối tự động đóng ở đây

            return dt;
        }
        public string GetMatKhau_DAL(string tenDangNhap)
        {
            string sql = "SELECT MatKhau FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";

            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

                    // Dùng ExecuteScalar để lấy 1 giá trị duy nhất
                    object result = cmd.ExecuteScalar();
                    return result?.ToString(); // Trả về hash
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy mật khẩu: " + ex.Message);
                }
            } // conn tự đóng
        }

        // HÀM MỚI 2: Cập nhật mật khẩu mới
        public bool UpdateMatKhau_DAL(string tenDangNhap, string matKhauMoiHashed)
        {
            string sql = "UPDATE TaiKhoan SET MatKhau = @MatKhauMoi WHERE TenDangNhap = @TenDangNhap";

            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MatKhauMoi", matKhauMoiHashed);
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu cập nhật thành công
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi cập nhật mật khẩu: " + ex.Message);
                }
            } // conn tự đóng
        }
    }
}
