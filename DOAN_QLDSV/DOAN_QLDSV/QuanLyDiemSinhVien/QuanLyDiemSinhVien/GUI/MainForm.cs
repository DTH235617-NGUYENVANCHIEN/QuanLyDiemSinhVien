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

        public MainForm()
        {
            InitializeComponent();

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
            OpenChildForm(new fQuanLyKhoa());
        }

        private void quảnLýLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLyLop());
        }

        private void quảnLýSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLySinhVien());
        }

        private void quảnLýMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLyMonHoc());
        }

        private void quảnLýGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLyGiaoVien());
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLyTaiKhoan());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Hệ thống quản lý - Chào: " + CurrentUser.Username;

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
            OpenChildForm(new fTrangChu());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLyLop());
        }

        private void btnQLKhoa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLyKhoa());
        }

        private void btnQLSV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLySinhVien());
        }

        private void btnbtnQLMonhoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLyMonHoc());
        }

        private void btnQLGV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLyGiaoVien());
        }

        private void btnQLTaikhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLyTaiKhoan());
        }

        private void btnQLDSV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fDiemSinhVien());
        }

        private void btnXemDiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fBangDiemSV());
        }

        private void btnThongtin_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fThongTinChiTiet());
        }

        private void btnDoiPass_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fDoiMatKhau());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                // Đóng form Main (sẽ quay về FormLogin nếu bạn lập trình đúng)
                this.Close();
            }
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
            OpenChildForm(new fDoiMatKhau());
        }

        private void thôngTinChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fThongTinChiTiet());
        }

        private void qLĐIÊMSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fDiemSinhVien());
        }

        private void xEMĐIỂMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fBangDiemSV());
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       
    }
}
