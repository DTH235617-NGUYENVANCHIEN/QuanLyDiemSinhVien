using QuanLyDiemSinhVien.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSinhVien.GUI
{
    public partial class MainForm : Form
    {
        // khi bấm đổi nút
        private MenuHighlightManager menuManager;
        public MainForm()
        {
            InitializeComponent();

        }
        //Mở trang chủ khi thoát từ form con
        void f_ThoatVeTrangChu(object sender, EventArgs e)
        {
            menuManager.ResetAllButtons();
            // Khi nhận được tín hiệu, mở lại Form Trang chủ
            // (Nhớ đổi fTrangChu thành tên đúng)
            OpenChildForm(new fTrangChu());
        }
        void f_YeuCauDangXuat(object sender, EventArgs e)
        {
            // Đóng Form Chính -> Tự động quay về Form Đăng nhập
            this.Close();
        }
        private void OpenChildForm(Form childForm)
        {
            // 1. Xóa tất cả các control (form con cũ) đang có trong panel
            // (Đảm bảo panel của bạn tên là 'panel1')
            this.palForm.Controls.Clear();

            // 2. Thiết lập các thuộc tính quan trọng cho form con
            childForm.TopLevel = false;             // Không phải là form cấp cao nhất
            childForm.FormBorderStyle = FormBorderStyle.None; // Bỏ viền của form con
            childForm.Dock = DockStyle.Fill;        // Lấp đầy toàn bộ panel

            // 3. Thêm form con vào danh sách Controls của panel
            this.palForm.Controls.Add(childForm);

            // 4. Hiển thị form con
            childForm.Show();
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyKhoa f = new fQuanLyKhoa();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            OpenChildForm(f);
        }

        private void quảnLýLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyLop f = new fQuanLyLop();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            OpenChildForm(f);
        }

        private void quảnLýSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLySinhVien f = new fQuanLySinhVien();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            OpenChildForm(f);
        }

        private void quảnLýMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyMonHoc f = new fQuanLyMonHoc();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            OpenChildForm(f);
        }

        private void quảnLýGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyGiaoVien f = new fQuanLyGiaoVien();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            OpenChildForm(f);
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyTaiKhoan f = new fQuanLyTaiKhoan();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            OpenChildForm(f);
        } 
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                // Đóng form Main (sẽ quay về FormLogin nếu bạn lập trình đúng)
                this.Close();
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDoiMatKhau f = new fDoiMatKhau();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            // 2. Lắng nghe nút "Cập nhật" (bắt đăng xuất)
            f.YeuCauDangXuat += new EventHandler(f_YeuCauDangXuat);
            OpenChildForm(f);
        }

        private void thôngTinChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongTinChiTiet f = new fThongTinChiTiet();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            OpenChildForm(f);
        }

        private void qLĐIÊMSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDiemSinhVien f = new fDiemSinhVien();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            OpenChildForm(f);
        }

        private void xEMĐIỂMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fBangDiemSV f = new fBangDiemSV();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            OpenChildForm(f);
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Hệ thống quản lý - Chào: " + CurrentUser.Username +  " với quyền  " + CurrentUser.TenQuyen;

            // PHÂN QUYỀN
            if (CurrentUser.TenQuyen != null && CurrentUser.TenQuyen == "Student")
            {
                // Nếu là Sinh viên, ẩn hết các nút quản lý
                btnQLKhoa.Visible = false;
                btnQLLop.Visible = false;
                btnQLSV.Visible = false;
                btnbtnQLMonhoc.Visible = false;
                btnQLGV.Visible = false;
                btnQLTaikhoan.Visible = false;
                btnQLDSV.Visible = false;

                quảnLýKhoaToolStripMenuItem.Visible = false;
                quảnLýLớpToolStripMenuItem.Visible = false;
                quảnLýSinhViênToolStripMenuItem.Visible = false;
                quảnLýMônHọcToolStripMenuItem.Visible = false;
                quảnLýGiáoViênToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnToolStripMenuItem.Visible = false;
                qLĐIÊMSVToolStripMenuItem.Visible = false; // Ẩn "Quản lý điểm"

                // Chỉ để lại các nút này
                btnXemDiem.Visible = true;
                btnThongtin.Visible = true;
                btnDoiPass.Visible = true;
                btnDangXuat.Visible = true;

                xEMĐIỂMToolStripMenuItem.Visible = true; // Hiện "Xem điểm"
            }
            else if (CurrentUser.TenQuyen != null && CurrentUser.TenQuyen == "Teacher")
            {
                // Nếu là Giáo viên
                btnQLKhoa.Visible = false;
                btnQLLop.Visible = false;
                btnQLGV.Visible = false;
                btnQLTaikhoan.Visible = false;
                btnXemDiem.Visible = false;

                quảnLýKhoaToolStripMenuItem.Visible = false;
                quảnLýLớpToolStripMenuItem.Visible = false;
                quảnLýGiáoViênToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnToolStripMenuItem.Visible = false;
                xEMĐIỂMToolStripMenuItem.Visible = false; // Ẩn "Xem Điểm"

                // Được phép quản lý Sinh viên, Môn học, Điểm
                btnQLSV.Visible = true;
                btnbtnQLMonhoc.Visible = true;
                btnQLDSV.Visible = true;
                btnThongtin.Visible = true;
                btnDoiPass.Visible = true;
                btnDangXuat.Visible = true;
            }
            else if (CurrentUser.TenQuyen == "Admin")
            {
                xEMĐIỂMToolStripMenuItem.Visible = false;
                btnXemDiem.Visible = false;
            }
            // --- KHỞI TẠO MENU MANAGER ---
             // 1. Tạo một danh sách chứa tất cả các nút
            List<Button> menuButtons = new List<Button>()
            {
                // (Thêm tất cả các nút menu của bạn vào đây)
                btnQLTaikhoan,
                btnQLKhoa,      
                btnQLGV,
                btnQLLop,
                btnQLSV,
                btnbtnQLMonhoc, // (Bạn kiểm tra lại tên nút này nhé)
                btnQLDSV,
                btnThongtin,
                btnDoiPass,
                btnDangXuat,
                btnXemDiem
            };

            // 2. Khởi tạo manager
            menuManager = new MenuHighlightManager(menuButtons);
            // --- KẾT THÚC KHỞI TẠO ---

            OpenChildForm(new fTrangChu());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            menuManager.ActivateButton(btnQLLop);
            fQuanLyLop f = new fQuanLyLop();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            OpenChildForm(f);
        }

        private void btnQLKhoa_Click(object sender, EventArgs e)
        {
            menuManager.ActivateButton(btnQLKhoa);
            fQuanLyKhoa f = new fQuanLyKhoa();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            OpenChildForm(f);
        }

        private void btnQLSV_Click(object sender, EventArgs e)
        {
            menuManager.ActivateButton(btnQLSV);
            fQuanLySinhVien f = new fQuanLySinhVien();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            OpenChildForm(f);
        }

        private void btnbtnQLMonhoc_Click(object sender, EventArgs e)
        {
            menuManager.ActivateButton(btnbtnQLMonhoc);
            fQuanLyMonHoc f = new fQuanLyMonHoc();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            OpenChildForm(f);
        }

        private void btnQLGV_Click(object sender, EventArgs e)
        {
            menuManager.ActivateButton(btnQLGV);
            fQuanLyGiaoVien f = new fQuanLyGiaoVien();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            OpenChildForm(f);
        }

        private void btnQLTaikhoan_Click(object sender, EventArgs e)
        {
            menuManager.ActivateButton(btnQLTaikhoan);
            fQuanLyTaiKhoan f = new fQuanLyTaiKhoan();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            OpenChildForm(f);
        }

        private void btnQLDSV_Click(object sender, EventArgs e)
        {
            menuManager.ActivateButton(btnQLDSV);
            fDiemSinhVien f = new fDiemSinhVien();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            OpenChildForm(f);
        }

        private void btnXemDiem_Click(object sender, EventArgs e)
        {
            menuManager.ActivateButton(btnXemDiem);
            fBangDiemSV f = new fBangDiemSV();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            OpenChildForm(f);
        }

        private void btnThongtin_Click(object sender, EventArgs e)
        {
            menuManager.ActivateButton(btnThongtin);
            fThongTinChiTiet f = new fThongTinChiTiet();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            OpenChildForm(f);
        }

        private void btnDoiPass_Click(object sender, EventArgs e)
        {
            menuManager.ActivateButton(btnDoiPass);
            fDoiMatKhau f = new fDoiMatKhau();
            f.ThoatVeTrangChu += new EventHandler(f_ThoatVeTrangChu);
            // 2. Lắng nghe nút "Cập nhật" (bắt đăng xuất)
            f.YeuCauDangXuat += new EventHandler(f_YeuCauDangXuat);
            OpenChildForm(f);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            menuManager.ActivateButton(btnDangXuat);
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                // Đóng form Main (sẽ quay về FormLogin nếu bạn lập trình đúng)
                this.Close();
            }
        }

       
      
  


    }
}
