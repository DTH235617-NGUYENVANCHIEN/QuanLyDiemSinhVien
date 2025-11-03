using QuanLyDiemSinhVien.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVien.BLL
{
    public class BLL_TaiKhoan
    {
        private static BLL_TaiKhoan instance;
        public static BLL_TaiKhoan Instance
        {
            get
            {
                if (instance == null)
                    instance = new BLL_TaiKhoan();
                return instance;
            }
            private set => instance = value;
        }

        private BLL_TaiKhoan() { }
        public DataTable DanhSach()
        {
            return DAL_Taikhoan.Instance.DanhSach();
        }
    }
   
}
