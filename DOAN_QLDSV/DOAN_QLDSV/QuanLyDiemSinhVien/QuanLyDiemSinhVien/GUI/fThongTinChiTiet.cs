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



        public fThongTinChiTiet()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.fThongTinChiTiet_FormClosing);

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
            KetnoiSQL.MoKetNoi();
            LoadThongTinTaiKhoan();
        }  
        private void fThongTinChiTiet_FormClosing(object sender, FormClosingEventArgs e)
        {
            KetnoiSQL.DongKetNoi();
        }
        private void LoadThongTinTaiKhoan()
        {
            try
            {
                // SỬA: Bỏ 'conn.Open()' vì kết nối đã được mở ở Form_Load

                string sql = @"SELECT T.TenDangNhap, L.TenQuyen 
                               FROM TAIKHOAN T 
                               JOIN LOAITAIKHOAN L ON T.MaQuyen = L.MaQuyen 
                               WHERE T.TenDangNhap = @TenDangNhap";

                // SỬA: Dùng KetnoiSQL.conn
                SqlCommand cmd = new SqlCommand(sql, KetnoiSQL.conn);
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
            // SỬA: Bỏ khối 'finally' và 'conn.Close()'
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
