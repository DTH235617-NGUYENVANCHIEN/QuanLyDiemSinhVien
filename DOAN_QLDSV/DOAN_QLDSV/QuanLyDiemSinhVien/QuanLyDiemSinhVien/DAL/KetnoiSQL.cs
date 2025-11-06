using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVien.DAL
{
    internal class KetnoiSQL
    {
        // 1. Chuỗi kết nối ĐÚNG
        // (Xóa 'Integrated Security' và thêm 'TrustServerCertificate')
        private static string connectionString = @"server=.; Database=db_QLDSV;User ID=sa;Password=123;TrustServerCertificate=True";

        // 2. Hàm này trả về một KẾT NỐI MỚI mỗi khi được gọi
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }



    }
}
