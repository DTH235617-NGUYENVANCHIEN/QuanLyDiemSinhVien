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

        private void label2_Click(object sender, EventArgs e)
        {

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
                fQuanLyTaiKhoan_Load(sender, e);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            login = txtTen.Text;
            MoNut(false);

        }
        // Hàm băm mật khẩu (dùng SHA256)
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // Chuyển sang dạng hexa
                }
                return builder.ToString();
            }
        }
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
                    // Thêm mới
                    if (login == "")
                    {
                        string sql = @"INSERT INTO TaiKhoan
                        VALUES(@TenDangNhap, @MatKhau, @MaQuyen)";
                        SqlCommand cmd = new SqlCommand(sql, conn);
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
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.Add("@TenDangNhapMoi", SqlDbType.NVarChar, 10).Value = txtTen.Text;
                        cmd.Parameters.Add("@TenDangNhapCu", SqlDbType.NVarChar, 10).Value = login;
                        cmd.Parameters.Add("@MatKhau", SqlDbType.VarChar, 128).Value = HashPassword(txtPass.Text);
                        cmd.Parameters.Add("@MaQuyen", SqlDbType.VarChar, 10).Value = cobQuyen.SelectedValue;

                        cmd.ExecuteNonQuery();
                    }
                    // Tải lại form
                    fQuanLyTaiKhoan_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void fQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {

            if (conn.State == ConnectionState.Closed)
            {
                conn.ConnectionString = @"server=.; Database=QLDSV;Integrated Security=True";
                conn.Open();
            }
            string sqlTaiKhoan = @"SELECT T.*,L.TenQuyen 
                                 FROM TaiKhoan T, LOAITAIKHOAN L
                                 WHERE L.MaQuyen=T.MaQuyen"; // Use a valid SQL SELECT statement
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlTaiKhoan, conn);
            DataTable data = new DataTable();
            dataAdapter.Fill(data); // Fill the DataTable directly
            dgvTaikhoan.DataSource = data; // Set the DataTable as the DataSource
            cobQuyen.DisplayMember = "TenQuyen";
            cobQuyen.ValueMember = "MaQuyen";


            string LoaiTKsql = @"SELECT * FROM LOAITAIKHOAN";
            SqlDataAdapter loaiTKAdapter = new SqlDataAdapter(LoaiTKsql, conn);
            DataTable tableLoaiSach = new DataTable();
            loaiTKAdapter.Fill(tableLoaiSach);
            cobQuyen.DataSource = tableLoaiSach;


            MoNut(true);
            cobQuyen.DataBindings.Clear();
            txtTen.DataBindings.Clear();
            txtPass.DataBindings.Clear();



            cobQuyen.DataBindings.Add("SelectedValue", dgvTaikhoan.DataSource, "MaQuyen", false, DataSourceUpdateMode.Never);
            txtTen.DataBindings.Add("Text", dgvTaikhoan.DataSource, "TenDangNhap", false, DataSourceUpdateMode.Never);
            //txtPass.DataBindings.Add("Text", dgvTaikhoan.DataSource, "MatKhau", false, DataSourceUpdateMode.Never);





        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTailai_Click(object sender, EventArgs e)
        {
            fQuanLyTaiKhoan_Load(sender, e);
        }

        private void dgvTaikhoan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTaikhoan.CurrentRow != null)
            {
               txtPass.Text= HashPassword(txtPass.Text); ; // Luôn xóa pass khi chọn dòng
            }
        }
    }
}
