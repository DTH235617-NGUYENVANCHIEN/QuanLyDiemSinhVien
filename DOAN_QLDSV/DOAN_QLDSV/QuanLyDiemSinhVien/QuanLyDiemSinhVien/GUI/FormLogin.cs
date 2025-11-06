using QuanLyDiemSinhVien.BLL;
using QuanLyDiemSinhVien.DAL;
using QuanLyDiemSinhVien.GUI;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
namespace QuanLyDiemSinhVien
{




    public partial class FormLogin : Form
    {

        TaiKhoan_BUS taiKhoanBUS = new TaiKhoan_BUS();
        public FormLogin()
        {
            InitializeComponent();
            this.Text = "Đăng Nhập Hệ Thống";
            // Đặt thuộc tính UseSystemPasswordChar = true cho txtMatKhau trong Designer
        }


        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string tenDangNhap = txtTen.Text.Trim();
            string matKhau = txtPass.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Băm mật khẩu nhập vào
            string matKhauHashed = MaHoa.MaHoaSHA256(matKhau);

            try
            {
                // 2. Gửi Tên đăng nhập VÀ Mật khẩu ĐÃ BĂM vào BUS
                bool dangNhapThanhCong = taiKhoanBUS.KiemTraDangNhap(tenDangNhap, matKhauHashed);

                if (dangNhapThanhCong)
                {
                    MessageBox.Show("Đăng nhập thành công! Quyền của bạn là: " + CurrentUser.TenQuyen, "Thông báo");

                    this.Hide();
                    MainForm frmMain = new MainForm();
                    frmMain.ShowDialog();

                    // Xử lý sau khi đăng xuất
                    CurrentUser.Clear();
                    this.Show();
                    txtPass.Text = "";
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }

}
