using Microsoft.VisualBasic.Logging;
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
    public partial class fQuanLyKhoa : Form
    {


        String maKhoa = "";
        public fQuanLyKhoa()
        {
            InitializeComponent();
   
        }

        private void fQuanLyKhoa_Load(object sender, EventArgs e)
        {
   
            TaiLaiDuLieu_Khoa();
        }
      
        private void btnThem_Click(object sender, EventArgs e)
        {
            maKhoa = "";
            //Xoa trang
            txtMakhoa.Text = "";
            txtTenkhoa.Text = "";
            MoAn(false);

        }  
        private void btnSua_Click(object sender, EventArgs e)
        {
            maKhoa = txtMakhoa.Text;
            MoAn(false);
        }  
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult kq;
            kq = MessageBox.Show("Bạn có muốn xóa  " + txtTenkhoa.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                // SỬA: Dùng 'using' để kết nối
                using (SqlConnection conn = KetnoiSQL.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string sql = @"DELETE FROM KHOA WHERE  MaKhoa= @MaKhoa";
                        SqlCommand cmd = new SqlCommand(sql, conn); // Dùng 'conn' mới
                        cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 20).Value = txtMakhoa.Text;
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                } // conn tự động đóng ở đây

                // Tải lại form
                TaiLaiDuLieu_Khoa();
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu (Giữ nguyên)
            if (txtMakhoa.Text.Trim() == "")
                MessageBox.Show("Chưa có mã khoa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTenkhoa.Text.Trim() == "")
                MessageBox.Show("Ten không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                // SỬA: Dùng 'using' để kết nối
                using (SqlConnection conn = KetnoiSQL.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        // Thêm mới
                        if (maKhoa == "")
                        {
                            string sql = @"INSERT INTO KHOA
                                           VALUES(@MaKhoa, @TenKhoa)";
                            SqlCommand cmd = new SqlCommand(sql, conn); // Dùng 'conn' mới
                            cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 20).Value = txtMakhoa.Text;
                            cmd.Parameters.Add("@TenKhoa", SqlDbType.NVarChar, 100).Value = txtTenkhoa.Text;
                            cmd.ExecuteNonQuery();
                        }
                        else // Sửa
                        {
                            string sql = @"UPDATE KHOA
                                           SET MaKhoa = @MaKhoaMoi,
                                           TenKhoa = @TenKhoa        
                                           WHERE MaKhoa = @MaKhoaCu";
                            SqlCommand cmd = new SqlCommand(sql, conn); // Dùng 'conn' mới
                            cmd.Parameters.Add("@MaKhoaMoi", SqlDbType.VarChar, 20).Value = txtMakhoa.Text;
                            cmd.Parameters.Add("@MaKhoaCu", SqlDbType.VarChar, 20).Value = maKhoa;
                            cmd.Parameters.Add("@TenKhoa", SqlDbType.NVarChar, 100).Value = txtTenkhoa.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                } // conn tự động đóng ở đây

                // Tải lại form
                TaiLaiDuLieu_Khoa();
            }
        } 
        private void btnTailai_Click(object sender, EventArgs e)
        {
            TaiLaiDuLieu_Khoa();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TaiLaiDuLieu_Khoa()
        {
            DataTable data = new DataTable();

            // SỬA: Dùng 'using' để kết nối
            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                try
                {
                    string sqlKhoa = @"SELECT * FROM KHOA";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlKhoa, conn); // Dùng 'conn' mới
                    dataAdapter.Fill(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            } // conn tự động đóng ở đây

            dgvKhoa.DataSource = data;

            MoAn(true);

            txtTenkhoa.DataBindings.Clear();
            txtMakhoa.DataBindings.Clear();

            txtMakhoa.DataBindings.Add("Text", dgvKhoa.DataSource, "MaKhoa", false, DataSourceUpdateMode.Never);
            txtTenkhoa.DataBindings.Add("Text", dgvKhoa.DataSource, "TenKhoa", false, DataSourceUpdateMode.Never);
        }
        

        private void MoAn(bool t)
        {
            txtMakhoa.Enabled = !t;
            txtTenkhoa.Enabled = !t;
            btnThem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnThoat.Enabled = t;
            btnTailai.Enabled = !t;
            btnLuu.Enabled = !t;

        }

        
    }
}
