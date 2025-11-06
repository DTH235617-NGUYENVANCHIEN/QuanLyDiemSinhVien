using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVien.BLL
{
    public static class CurrentUser
    {
        // Chúng ta sẽ lưu Tên đăng nhập và Tên Quyền
        public static string Username { get; set; }

        // TenQuyen sẽ là 'Admin', 'Teacher', hoặc 'Student'
        public static string TenQuyen { get; set; }

        // Hàm để xóa thông tin khi đăng xuất
        public static void Clear()
        {
            Username = null;
            TenQuyen = null;
        }
    }
}
