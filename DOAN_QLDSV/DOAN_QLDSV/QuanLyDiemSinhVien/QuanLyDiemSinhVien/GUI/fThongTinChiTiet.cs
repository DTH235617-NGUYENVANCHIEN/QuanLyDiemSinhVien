using QuanLyDiemSinhVien.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSinhVien.GUI
{
    public partial class fThongTinChiTiet : Form
    {
        // Chuỗi kết nối, giống như form fQuanLyKhoa của bạn
        SqlConnection conn = new SqlConnection(@"server=.; Database=QLDSV;Integrated Security=True");


        public fThongTinChiTiet()
        {
            InitializeComponent();

        }

        private void fThongTinChiTiet_Load(object sender, EventArgs e)
        {
            // THAY ĐỔI: Kiểm tra CurrentUser.Username thay vì biến cục bộ
            if (string.IsNullOrEmpty(CurrentUser.Username))
            {
                MessageBox.Show("Không có thông tin tài khoản để hiển thị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            LoadThongTinTaiKhoan();
        }
        private void LoadThongTinTaiKhoan()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string sql = @"SELECT T.TenDangNhap, L.TenQuyen 
                               FROM TAIKHOAN T 
                               JOIN LOAITAIKHOAN L ON T.MaQuyen = L.MaQuyen 
                               WHERE T.TenDangNhap = @TenDangNhap";

                SqlCommand cmd = new SqlCommand(sql, conn);

                // THAY ĐỔI: Dùng CurrentUser.Username
                cmd.Parameters.AddWithValue("@TenDangNhap", CurrentUser.Username);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtTenDangNhap.Text = reader["TenDangNhap"].ToString();
                        // Lưu ý: Tên TextBox của bạn trong file .cs là txtQuyen,
                        // nhưng trong hình ảnh nó là "Loại Tài Khoản". 
                        // Tôi giữ nguyên tên txtQuyen theo code của bạn.
                        txtQuyen.Text = reader["TenQuyen"].ToString();
                        txtMatKhau.Text = "**********";
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
