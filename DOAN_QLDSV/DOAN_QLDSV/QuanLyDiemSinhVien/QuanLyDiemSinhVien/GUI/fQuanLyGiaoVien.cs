using Microsoft.VisualBasic.Logging;
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
    public partial class fQuanLyGiaoVien : Form
    {
        SqlConnection conn = new SqlConnection();
        String magv = "";
        public fQuanLyGiaoVien()
        {
            InitializeComponent();
        }
        private void MoNut(bool t)
        {
            txtMaGV.Enabled = !t;
            txtHotengv.Enabled = !t;
            dtTime.Enabled = !t;
            cboLoaikhoa.Enabled = !t;
            btnThem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnThoat.Enabled = t;
            btnTailai.Enabled = !t;
            btnLuu.Enabled = !t;

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            magv = txtMaGV.Text;
            MoNut(false);
        }

        private void fQuanLyGiaoVien_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.ConnectionString = @"server=.; Database=QLDSV;Integrated Security=True";
                conn.Open();
            }
            string sqlTaiKhoan = @"SELECT G.*,K.TenKhoa 
                                 FROM GIAOVIEN G, KHOA K
                                 WHERE G.MaKhoa=K.MaKhoa"; // Use a valid SQL SELECT statement
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlTaiKhoan, conn);
            DataTable data = new DataTable();
            dataAdapter.Fill(data); // Fill the DataTable directly
            dgvGiaovien.AutoGenerateColumns = false;//xóa các cột dư
            dgvGiaovien.DataSource = data; // Set the DataTable as the DataSource
            cboLoaikhoa.DisplayMember = "TenKhoa";
            cboLoaikhoa.ValueMember = "MaKhoa";

            //dgvGiaovien.Columns["MaKhoa"].Visible = false;


            string LoaiTKsql = @"SELECT * FROM KHOA";
            SqlDataAdapter loaiTKAdapter = new SqlDataAdapter(LoaiTKsql, conn);
            DataTable tableLoaiSach = new DataTable();
            loaiTKAdapter.Fill(tableLoaiSach);
            cboLoaikhoa.DataSource = tableLoaiSach;



            MoNut(true);
            cboLoaikhoa.DataBindings.Clear();
            txtMaGV.DataBindings.Clear();
            txtHotengv.DataBindings.Clear();
            dtTime.DataBindings.Clear();


            cboLoaikhoa.DataBindings.Add("SelectedValue", dgvGiaovien.DataSource, "MaKhoa", false, DataSourceUpdateMode.Never);
            txtMaGV.DataBindings.Add("Text", dgvGiaovien.DataSource, "MaGV", false, DataSourceUpdateMode.Never);
            txtHotengv.DataBindings.Add("Text", dgvGiaovien.DataSource, "HoTen", false, DataSourceUpdateMode.Never);
            dtTime.DataBindings.Add("Text", dgvGiaovien.DataSource, "NgaySinh", false, DataSourceUpdateMode.Never);

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            magv = "";
            //Xoa trang
            txtMaGV.Text = "";
            txtHotengv.Text = "";
            dtTime.Value = DateTime.Now;
            cboLoaikhoa.Text = "";
            MoNut(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult kq;
            kq = MessageBox.Show("Bạn có muốn xóa " + txtHotengv.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                string sql = @"DELETE FROM GIAOVIEN WHERE MaGV = @MaGV";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaGV", SqlDbType.VarChar, 20).Value = txtMaGV.Text;
                cmd.ExecuteNonQuery();
                // Tải lại form
                fQuanLyGiaoVien_Load(sender, e);
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DateTime ngayHienTai = DateTime.Now.Date;
            DateTime ngayDaChon = dtTime.Value.Date;
            // Kiểm tra dữ liệu
            if (cboLoaikhoa.Text.Trim() == "")
                MessageBox.Show("Chưa chọn khoa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtMaGV.Text.Trim() == "")
                MessageBox.Show("Ma không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtHotengv.Text.Trim() == "")
                MessageBox.Show("Tên không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (ngayDaChon == ngayHienTai)
                MessageBox.Show("Ngay sinh chưa đổi(đang là ngày hôm nay)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    // Thêm mới
                    if (magv== "")
                    {
                        string sql = @"INSERT INTO GIAOVIEN 
                        VALUES (@MaGV, @HoTen, @NgaySinh, @MaKhoa)";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.Add("@MaGV", SqlDbType.VarChar, 20).Value = txtMaGV.Text;
                        cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = txtHotengv.Text;
                        cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtTime.Value;
                        cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar,20).Value = cboLoaikhoa.SelectedValue;

                        cmd.ExecuteNonQuery();
                    }
                    else // Sửa
                    {
                        string sql = @"UPDATE GIAOVIEN
                                     SET MaGV = @MaGVMoi,
                                     HoTen = @HoTen,
                                     NgaySinh = @NgaySinh,
                                     MaKhoa = @MaKhoa
                                     WHERE MaGV = @MaGVCu";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.Add("@MaGVMoi", SqlDbType.VarChar, 20).Value = txtMaGV.Text;
                        cmd.Parameters.Add("@MaGVCu", SqlDbType.VarChar, 20).Value = magv;
                        cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = txtHotengv.Text;
                        cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtTime.Value;
                        cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 20).Value = cboLoaikhoa.SelectedValue;


                    

                        cmd.ExecuteNonQuery();
                    }
                    // Tải lại form
                    fQuanLyGiaoVien_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnTailai_Click(object sender, EventArgs e)
        {
            fQuanLyGiaoVien_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
