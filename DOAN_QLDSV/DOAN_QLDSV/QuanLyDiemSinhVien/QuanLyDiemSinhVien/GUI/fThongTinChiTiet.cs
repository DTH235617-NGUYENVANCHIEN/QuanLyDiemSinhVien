using QuanLyDiemSinhVien.BLL;
using QuanLyDiemSinhVien.DAL;
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

        //mở trang chủ khi bấm nút thoát 
        public event EventHandler ThoatVeTrangChu;

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
            // SỬA: Dùng 'using'
            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                try
                {
                    conn.Open(); // Mở kết nối
                    string sql = @"SELECT T.TenDangNhap, L.TenQuyen 
                                   FROM TAIKHOAN T 
                                   JOIN LOAITAIKHOAN L ON T.MaQuyen = L.MaQuyen 
                                   WHERE T.TenDangNhap = @TenDangNhap";

                    SqlCommand cmd = new SqlCommand(sql, conn); // Dùng 'conn' mới
                    cmd.Parameters.AddWithValue("@TenDangNhap", CurrentUser.Username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtTenDangNhap.Text = reader["TenDangNhap"].ToString();
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
            } // conn tự động đóng ở đây
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (ThoatVeTrangChu != null)
            {
                ThoatVeTrangChu(this, EventArgs.Empty);
            }
        }

     
    }
}
