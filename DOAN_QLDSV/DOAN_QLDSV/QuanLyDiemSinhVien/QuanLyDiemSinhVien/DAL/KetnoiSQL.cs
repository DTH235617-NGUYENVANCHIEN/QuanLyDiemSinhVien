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
        // Đây là biến lưu trữ kết nối, dùng chung
        public static SqlConnection conn = new SqlConnection();

        // Chuỗi kết nối
        private static string connectionString = @"server=.; Database=QLDSV;Integrated Security=True";

        // Đây là PHƯƠNG THỨC để mở kết nối
        public static void MoKetNoi()
        {
            // Di chuyển code logic của bạn vào đây
            if (conn.State == ConnectionState.Closed)
            {
                conn.ConnectionString = connectionString;
                conn.Open();
            }
        }

        // Tạo thêm phương thức đóng kết nối
        public static void DongKetNoi()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
       


    }
}
