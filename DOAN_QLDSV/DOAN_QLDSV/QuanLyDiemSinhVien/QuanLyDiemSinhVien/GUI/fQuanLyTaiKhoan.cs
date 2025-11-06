using QuanLyDiemSinhVien.BLL;
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
        
        String login = "";
        public fQuanLyTaiKhoan()
        {
            InitializeComponent();
           
        }
        private void fQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            
               
            TaiLaiDuLieu_TK();
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
            kq = MessageBox.Show("Bạn có muốn xóa tài khoản " + txtTen.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                // SỬA: Dùng 'using'
                using (SqlConnection conn = KetnoiSQL.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string sql = @"DELETE FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
                        SqlCommand cmd = new SqlCommand(sql, conn); // Dùng 'conn' mới
                        cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 20).Value = txtTen.Text;
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                } // conn tự động đóng

                TaiLaiDuLieu_TK();
            }

        }

        // Hàm băm mật khẩu (dùng SHA256)

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cobQuyen.Text.Trim() == "")
            {
                MessageBox.Show("Chưa chọn quyen!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Ten không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPass.Text.Trim() == "")
            {
                MessageBox.Show("MK không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // SỬA: Dùng 'using'
                using (SqlConnection conn = KetnoiSQL.GetConnection())
                {
                    try
                    {
                        conn.Open();

                        // SỬA: Gọi hàm MaHoa.cs
                        string passHashed = MaHoa.MaHoaSHA256(txtPass.Text);

                        if (login == "") // Thêm mới
                        {
                            string sql = @"INSERT INTO TaiKhoan
                                           VALUES(@TenDangNhap, @MatKhau, @MaQuyen)";
                            SqlCommand cmd = new SqlCommand(sql, conn); // Dùng 'conn' mới
                            cmd.Parameters.Add("@TenDangNhap", SqlDbType.VarChar, 20).Value = txtTen.Text;
                            cmd.Parameters.Add("@MatKhau", SqlDbType.VarChar, 128).Value = passHashed;
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
                            SqlCommand cmd = new SqlCommand(sql, conn); // Dùng 'conn' mới
                            cmd.Parameters.Add("@TenDangNhapMoi", SqlDbType.NVarChar, 10).Value = txtTen.Text;
                            cmd.Parameters.Add("@TenDangNhapCu", SqlDbType.NVarChar, 10).Value = login;
                            cmd.Parameters.Add("@MatKhau", SqlDbType.VarChar, 128).Value = passHashed;
                            cmd.Parameters.Add("@MaQuyen", SqlDbType.VarChar, 10).Value = cobQuyen.SelectedValue;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                } // conn tự động đóng

                TaiLaiDuLieu_TK();
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
            string sqlTaiKhoan = @"SELECT T.*,L.TenQuyen 
                                   FROM TaiKhoan T, LOAITAIKHOAN L
                                   WHERE L.MaQuyen=T.MaQuyen";
            string LoaiTKsql = @"SELECT * FROM LOAITAIKHOAN";

            DataTable data = new DataTable();
            DataTable tableLoaiSach = new DataTable();

            // SỬA: Dùng 1 'using' duy nhất
            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlTaiKhoan, conn); // Dùng 'conn' mới
                    dataAdapter.Fill(data);

                    SqlDataAdapter loaiTKAdapter = new SqlDataAdapter(LoaiTKsql, conn); // Dùng 'conn' mới
                    loaiTKAdapter.Fill(tableLoaiSach);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                    return;
                }
            } // conn tự động đóng

            // 1. Tải dữ liệu TAIKHOAN
            dgvTaikhoan.DataSource = data;

            // 2. Tải dữ liệu LOAITAIKHOAN (cho ComboBox)
            cobQuyen.DataSource = tableLoaiSach;
            cobQuyen.DisplayMember = "TenQuyen";
            cobQuyen.ValueMember = "MaQuyen";

            // 3. Đặt trạng thái nút
            MoNut(true);

            // 4. Data Bindings (Giữ nguyên)
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
  


    }
}
