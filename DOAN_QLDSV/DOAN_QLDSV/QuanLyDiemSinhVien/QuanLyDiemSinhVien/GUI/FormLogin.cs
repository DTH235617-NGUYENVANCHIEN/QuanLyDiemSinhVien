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
            // Lấy dữ liệu từ TextBox (giả sử tên là txtTenDangNhap và txtMatKhau)
            string tenDangNhap = txtTen.Text.Trim();
            string matKhau = txtPass.Text.Trim();

            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // BĂM MẬT KHẨU
            // Chúng ta phải băm mật khẩu người dùng nhập vào 
            // để so sánh với mật khẩu đã băm trong CSDL.
            string matKhauHashed = HashPassword(matKhau);

            try
            {
                // Gọi BUS để kiểm tra
                bool dangNhapThanhCong = taiKhoanBUS.KiemTraDangNhap(tenDangNhap, matKhauHashed);

                if (dangNhapThanhCong)
                {
                    // ĐĂNG NHẬP THÀNH CÔNG
                    MessageBox.Show("Đăng nhập thành công! Quyền của bạn là: " + CurrentUser.TenQuyen, "Thông báo");

                    // Ẩn form login và mở Main Form
                    this.Hide();
                    MainForm frmMain = new MainForm();
                    frmMain.ShowDialog();

                    // --- QUAN TRỌNG: XỬ LÝ KHI ĐĂNG XUẤT ---
                    // Sau khi MainForm đóng (tức là người dùng đăng xuất),
                    // chúng ta sẽ xóa phiên làm việc và hiển thị lại FormLogin.
                    CurrentUser.Clear(); // Xóa thông tin người dùng
                    this.Show();
                    txtPass.Text = ""; // Xóa mật khẩu cũ
                }
                else
                {
                    // ĐĂNG NHẬP THẤT BẠI
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. HÀM BĂM MẬT KHẨU (HASH PASSWORD)
        // (Đây là hàm bạn đã dùng trong code mẫu `fQuanLyTaiKhoan`)
        // Dùng SHA-256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                // Vì CSDL của bạn là VARCHAR(128), chúng ta nên cắt băm
                // (Mặc dù SHA256 là 64 ký tự hex, nhưng để an toàn,
                // ta nên dùng chung 1 chuẩn)
                // Tuy nhiên, CSDL của bạn là 128, vậy là đủ cho SHA-512.
                // Tạm thời, ta dùng SHA256 (64 ký tự).
                return builder.ToString();
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
