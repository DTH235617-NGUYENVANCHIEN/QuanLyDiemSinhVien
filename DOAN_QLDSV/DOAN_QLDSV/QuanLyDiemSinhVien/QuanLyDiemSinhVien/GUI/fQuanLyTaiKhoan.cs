using QuanLyDiemSinhVien.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSinhVien.GUI
{
    public partial class fQuanLyTaiKhoan : Form
    {
        SqlConnection conn = new SqlConnection();
        String login = "";
        public fQuanLyTaiKhoan()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.fQuanLyTaiKhoan_FormClosing);
        }
        private void fQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            
            KetnoiSQL.MoKetNoi();         
            TaiLaiDuLieu_TK();
        } 
        private void fQuanLyTaiKhoan_FormClosing(object sender, FormClosingEventArgs e)
        {
            KetnoiSQL.DongKetNoi();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            login = "";
            //Xoa trang
            txtTen.Text = "";
            txtPass.Text = "";
            cobQuyen.Text = "";
            MoNut(false);
            txtTen.Focus();

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            login = txtTen.Text;
            MoNut(false);
            txtTen.Focus();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult kq;
            kq = MessageBox.Show("Bạn có muốn xóa sách " + txtTen.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                string sql = @"DELETE FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 20).Value = txtTen.Text;
                cmd.ExecuteNonQuery();
                // Tải lại form
                TaiLaiDuLieu_TK();
            }

        }

        // Hàm băm mật khẩu (dùng SHA256)

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (cobQuyen.Text.Trim() == "")
                MessageBox.Show("Chưa chọn quyen!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTen.Text.Trim() == "")
                MessageBox.Show("Ten không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtPass.Text.Trim() == "")
                MessageBox.Show("MK không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    if (login == "") // Thêm mới
                    {
                        string sql = @"INSERT INTO TaiKhoan
                                     VALUES(@TenDangNhap, @MatKhau, @MaQuyen)";
                        // SỬA: Dùng KetnoiSQL.conn
                        SqlCommand cmd = new SqlCommand(sql, KetnoiSQL.conn);
                        cmd.Parameters.Add("@TenDangNhap", SqlDbType.VarChar, 20).Value = txtTen.Text;
                        cmd.Parameters.Add("@MatKhau", SqlDbType.VarChar, 128).Value = HashPassword(txtPass.Text);
                        cmd.Parameters.Add("@MaQuyen", SqlDbType.VarChar, 10).Value = cobQuyen.SelectedValue;
                        cmd.ExecuteNonQuery();
                    }
                    else // Sửa
                    {
                        string sql = @"UPDATE TaiKhoan
                                     SET TenDangNhap = @TenDangNhapMoi,
                                         MatKhau = @MatKhau,
                                         MaQuyen = @MaQuyen
                                     WHERE TenDangNhap = @TenDangNhapCu";
                        // SỬA: Dùng KetnoiSQL.conn
                        SqlCommand cmd = new SqlCommand(sql, KetnoiSQL.conn);
                        cmd.Parameters.Add("@TenDangNhapMoi", SqlDbType.NVarChar, 10).Value = txtTen.Text;
                        cmd.Parameters.Add("@TenDangNhapCu", SqlDbType.NVarChar, 10).Value = login;
                        cmd.Parameters.Add("@MatKhau", SqlDbType.VarChar, 128).Value = HashPassword(txtPass.Text);
                        cmd.Parameters.Add("@MaQuyen", SqlDbType.VarChar, 10).Value = cobQuyen.SelectedValue;
                        cmd.ExecuteNonQuery();
                    }

                    // SỬA: Tải lại bằng hàm mới
                    TaiLaiDuLieu_TK();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void btnTailai_Click(object sender, EventArgs e)
        {
            TaiLaiDuLieu_TK();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TaiLaiDuLieu_TK()
        {
            // Hàm này giả định kết nối ĐÃ MỞ

            // 1. Tải dữ liệu TAIKHOAN
            string sqlTaiKhoan = @"SELECT T.*,L.TenQuyen 
                                   FROM TaiKhoan T, LOAITAIKHOAN L
                                   WHERE L.MaQuyen=T.MaQuyen";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlTaiKhoan, KetnoiSQL.conn);
            DataTable data = new DataTable();
            dataAdapter.Fill(data);
            dgvTaikhoan.DataSource = data;

            // 2. Tải dữ liệu LOAITAIKHOAN (cho ComboBox)
            string LoaiTKsql = @"SELECT * FROM LOAITAIKHOAN";
            SqlDataAdapter loaiTKAdapter = new SqlDataAdapter(LoaiTKsql, KetnoiSQL.conn);
            DataTable tableLoaiSach = new DataTable();
            loaiTKAdapter.Fill(tableLoaiSach);
            cobQuyen.DataSource = tableLoaiSach;
            cobQuyen.DisplayMember = "TenQuyen";
            cobQuyen.ValueMember = "MaQuyen";

            // 3. Đặt trạng thái nút
            MoNut(true);

            // 4. Data Bindings
            cobQuyen.DataBindings.Clear();
            txtTen.DataBindings.Clear();
            txtPass.DataBindings.Clear();

            cobQuyen.DataBindings.Add("SelectedValue", dgvTaikhoan.DataSource, "MaQuyen", false, DataSourceUpdateMode.Never);
            txtTen.DataBindings.Add("Text", dgvTaikhoan.DataSource, "TenDangNhap", false, DataSourceUpdateMode.Never);
            txtPass.DataBindings.Add("Text", dgvTaikhoan.DataSource, "MatKhau", false, DataSourceUpdateMode.Never);
        }


        private void MoNut(bool t)
        {
            txtTen.Enabled = !t;
            txtPass.Enabled = !t;
            cobQuyen.Enabled = !t;

            btnThem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnThoat.Enabled = t;
            btnTailai.Enabled = !t;

            btnLuu.Enabled = !t;
        }
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
                return builder.ToString();
            }
        }


    }
}
