using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVien.DAL
{
    public class DAL_Taikhoan
    {

        private static DAL_Taikhoan instance;
        public static DAL_Taikhoan Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAL_Taikhoan();
                return instance;
            }
            private set => instance = value;
        }

        private DAL_Taikhoan() { }
        public bool Them(string ten, string matkhau, string loai)
        {
            string sql = "insert into TaiKhoan(TenDangNhap, MatKhau, Quyen) values (@TenDangNhap, @MatKhau, @Quyen)";
            return KetNoi.Instance.ExecuteNonQuery(sql, new object[] { ten, matkhau, loai });
        }

        public bool Sua(string ten, string matkhau, string loai)
        {
            string sql = "update TaiKhoan set TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, Quyen = @Quyen where  ten= @ten";
            return KetNoi.Instance.ExecuteNonQuery(sql, new object[] { ten, matkhau, loai});
        }

        public bool Xoa(string ten)
        {
            string sql = "delete from TaiKhoan where ten = @ten";
            return KetNoi.Instance.ExecuteNonQuery(sql, new object[] { ten });
        }
        public DataTable DanhSach()
        {
            return KetNoi.Instance.ExcuteQuery("select * from TaiKhoan");
        }
    }
}
