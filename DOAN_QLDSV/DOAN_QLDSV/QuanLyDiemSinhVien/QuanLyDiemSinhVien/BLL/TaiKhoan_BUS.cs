using QuanLyDiemSinhVien.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVien.BLL
{
    public class TaiKhoan_BUS
    {
        // 1. Tạo một đối tượng DAL
        private TaiKhoan_DAL dal_TaiKhoan = new TaiKhoan_DAL();

        /// <summary>
        /// Kiểm tra đăng nhập, nếu thành công thì lưu thông tin vào CurrentUser.
        /// </summary>
        public bool KiemTraDangNhap(string tenDangNhap, string matKhauHashed)
        {
            // 2. Gọi DAL để lấy dữ liệu
            DataTable dt = dal_TaiKhoan.KiemTraDangNhap_DAL(tenDangNhap, matKhauHashed);

            // 3. Xử lý logic (Đây là việc của BUS)
            if (dt.Rows.Count > 0) // Nếu có 1 dòng trở lên (tìm thấy)
            {
                // Lấy dòng đầu tiên
                DataRow row = dt.Rows[0];

                // LƯU THÔNG TIN VÀO PHIÊN LÀM VIỆC (SESSION)
                CurrentUser.Username = row["TenDangNhap"].ToString();
                CurrentUser.TenQuyen = row["TenQuyen"].ToString().Trim();

                return true; // Đăng nhập thành công
            }
            else
            {
                // Không tìm thấy (sai user/pass)
                return false;
            }
        }
        public bool DoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi)
        {
            // 1. Lấy hash mật khẩu cũ trong CSDL
            string hashMatKhauCu_DB = dal_TaiKhoan.GetMatKhau_DAL(tenDangNhap);

            // 2. Băm mật khẩu cũ người dùng nhập
            // (Sử dụng lớp MaHoa tiện ích chúng ta vừa tạo)
            string hashMatKhauCu_Input = MaHoa.MaHoaSHA256(matKhauCu);

            // 3. So sánh
            if (hashMatKhauCu_DB != hashMatKhauCu_Input)
            {
                // Mật khẩu cũ không đúng
                return false;
            }

            // 4. Băm mật khẩu mới
            string hashMatKhauMoi = MaHoa.MaHoaSHA256(matKhauMoi);

            // 5. Yêu cầu DAL cập nhật CSDL
            return dal_TaiKhoan.UpdateMatKhau_DAL(tenDangNhap, hashMatKhauMoi);
        }
    }
}
