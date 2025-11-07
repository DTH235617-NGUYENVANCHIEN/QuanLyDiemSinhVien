using QuanLyDiemSinhVien.BLL;
using QuanLyDiemSinhVien.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSinhVien.GUI
{
    public partial class fDoiMatKhau : Form

    {
        //mở trang chủ khi bấm nút thoát 
        public event EventHandler ThoatVeTrangChu;
        public event EventHandler YeuCauDangXuat;
        private TaiKhoan_BUS bus_TaiKhoan = new TaiKhoan_BUS();

        public fDoiMatKhau()
        {
            InitializeComponent();
            // THAY ĐỔI: Đặt tiêu đề form dựa trên CurrentUser
            this.Text = "Đổi Mật Khẩu cho: " + CurrentUser.Username;

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu (Giữ nguyên)
            string matKhauCu = txtMatKhauCu.Text;
            string matKhauMoi = txtMatKhauMoi.Text;
            string nhapLaiMatKhau = txtNhapLaiMatKhau.Text;

            // 2. Kiểm tra (Giữ nguyên)
            if (string.IsNullOrWhiteSpace(matKhauCu) ||
                string.IsNullOrWhiteSpace(matKhauMoi) ||
                string.IsNullOrWhiteSpace(nhapLaiMatKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (matKhauMoi != nhapLaiMatKhau)
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu nhập lại không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapLaiMatKhau.Focus();
                return;
            }

            // 3. GỌI LỚP BUS ĐỂ XỬ LÝ
            try
            {
                // Bỏ MoKetNoi()
                bool ketQua = bus_TaiKhoan.DoiMatKhau(CurrentUser.Username, matKhauCu, matKhauMoi);

                if (ketQua)
                {
                    MessageBox.Show("Đổi mật khẩu thành công! Vui lòng đăng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // XÓA DÒNG: this.Close();
                    // THAY BẰNG: Bắn tín hiệu Yêu cầu Đăng xuất
                    if (YeuCauDangXuat != null)
                    {
                        YeuCauDangXuat(this, EventArgs.Empty);
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhauCu.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (ThoatVeTrangChu != null)
            {
                ThoatVeTrangChu(this, EventArgs.Empty);
            }
        }

       
    }
}

