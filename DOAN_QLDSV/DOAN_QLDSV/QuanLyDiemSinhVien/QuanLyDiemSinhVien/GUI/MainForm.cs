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
            // Ẩn form chính đi
            this.Hide();

            // Hiển thị form con. 
            // Dùng ShowDialog() để nó chạy độc lập và phải tắt nó mới quay lại Main được.
            childForm.Enabled = true;
            childForm.ShowDialog();

            // Sau khi form con (formToOpen) bị tắt, hiển thị lại form chính
            this.Show();
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyKhoa f = new fQuanLyKhoa();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void quảnLýLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyLop f = new fQuanLyLop();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void quảnLýSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLySinhVien f = new fQuanLySinhVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void quảnLýMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyMonHoc f = new fQuanLyMonHoc();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void quảnLýGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyGiaoVien f = new fQuanLyGiaoVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyTaiKhoan f = new fQuanLyTaiKhoan();
            this.Hide();
            f.ShowDialog();
            this.Show();
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
