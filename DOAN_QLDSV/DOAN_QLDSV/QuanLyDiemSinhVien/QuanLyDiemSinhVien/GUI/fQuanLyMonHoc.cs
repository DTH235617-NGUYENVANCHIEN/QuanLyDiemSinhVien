using Microsoft.VisualBasic.Logging;
using Microsoft.Win32.SafeHandles;
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
    public partial class fQuanLyMonHoc : Form
    {
        SqlConnection conn = new SqlConnection();
        String Mamonhoc = "";
        public fQuanLyMonHoc()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void MoNut(bool t)
        {
            txtMamonhoc.Enabled = !t;
            cboMon.Enabled = !t;
            nudSotinchi.Enabled = !t;

            btnThem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnThoat.Enabled = t;
            btnTailai.Enabled = !t;

            btnLuu.Enabled = !t;
        }
        private void fQuanLyMonHoc_Load(object sender, EventArgs e)
        {


            if (conn.State == ConnectionState.Closed)
            {
                conn.ConnectionString = @"server=.; Database=QLDSV;Integrated Security=True";
                conn.Open();
            }
            string sqlTaiKhoan = @"SELECT M.*,T.TenMH
                                 FROM MONHOC M, TENMONHOC T
                                 WHERE M.MaMH= T.MaMH"; // Use a valid SQL SELECT statement
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlTaiKhoan, conn);
            DataTable data = new DataTable();
            dgvMonhoc.AutoGenerateColumns = false;//xóa các cột dư
            dataAdapter.Fill(data); // Fill the DataTable directly
            dgvMonhoc.DataSource = data; // Set the DataTable as the DataSource
            cboMon.DisplayMember = "TenMH";
            cboMon.ValueMember = "MaMH";


            string LoaiTKsql = @"SELECT * FROM TENMONHOC";
            SqlDataAdapter loaiTKAdapter = new SqlDataAdapter(LoaiTKsql, conn);
            DataTable tableLoaiSach = new DataTable();
            loaiTKAdapter.Fill(tableLoaiSach);
            cboMon.DataSource = tableLoaiSach;


            MoNut(true);
            cboMon.DataBindings.Clear();
            txtMamonhoc.DataBindings.Clear();
            nudSotinchi.DataBindings.Clear();

            //cobQuyen.DataBindings.Add("SelectedValue", dgvTaikhoan.DataSource, "MaQuyen", false, DataSourceUpdateMode.Never);
            //txtTen.DataBindings.Add("Text", dgvTaikhoan.DataSource, "TenDangNhap", false, DataSourceUpdateMode.Never);
            //txtPass.DataBindings.Add("Text", dgvTaikhoan.DataSource, "MatKhau", false, DataSourceUpdateMode.Never);
            cboMon.DataBindings.Add("SelectedValue", dgvMonhoc.DataSource, "MaMH", false, DataSourceUpdateMode.Never);
            txtMamonhoc.DataBindings.Add("Text", dgvMonhoc.DataSource, "MaMH", false, DataSourceUpdateMode.Never);
            nudSotinchi.DataBindings.Add("Value", dgvMonhoc.DataSource, "SoTC", false, DataSourceUpdateMode.Never);










        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Mamonhoc = "";
            //Xoa trang
            txtMamonhoc.Text = "";
            cboMon.Text = "";
            nudSotinchi.Value = 0;

            MoNut(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Lấy STT của dòng đang được chọn trong DataGridView
            // Giả định dgvMonhoc có tên cột chứa STT là "STT"
            object sttValue = null;
            if (dgvMonhoc.CurrentRow != null)
            {
                sttValue = dgvMonhoc.CurrentRow.Cells["STT"].Value;
            }

            if (sttValue == null || sttValue == DBNull.Value)
            {
                MessageBox.Show("Vui lòng chọn một môn học để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xác nhận xóa (Dùng tên môn học đang hiển thị trên cboMon)
            DialogResult kq;
            kq = MessageBox.Show("Bạn có muốn xóa môn học: " + cboMon.Text + " không?", "Xóa",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                try
                {
                    // Truy vấn SQL đã đúng: Xóa theo STT
                    string sql = @"DELETE FROM MONHOC WHERE STT = @STT";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // SỬA LỖI: Thêm tham số @STT với giá trị lấy từ dòng đang chọn
                    cmd.Parameters.Add("@STT", SqlDbType.Int).Value = sttValue;

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại form
                    fQuanLyMonHoc_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Mamonhoc = txtMamonhoc.Text;
            MoNut(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (cboMon.Text.Trim() == "")
                MessageBox.Show("Chưa chọn môn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtMamonhoc.Text.Trim() == "")
                MessageBox.Show("Ten không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (nudSotinchi.Value == 0)
                MessageBox.Show("Số tín chỉ không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                try
                {
                    // Thêm mới
                    if (Mamonhoc == "")
                    {
                        string sql = @"INSERT INTO MONHOC
                        VALUES( @MaMH, @SoTC)";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        
                        cmd.Parameters.Add("@MaMH", SqlDbType.VarChar, 20).Value = txtMamonhoc.Text;
                        cmd.Parameters.Add("@", SqlDbType.VarChar, 20).Value = cboMon.SelectedValue;
                        cmd.Parameters.Add("@SoTC", SqlDbType.Int).Value = nudSotinchi.Value;

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
                        cmd.Parameters.Add("@MatKhau", SqlDbType.VarChar, 128).Value = txtPass.Text;
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

        private void btnTailai_Click(object sender, EventArgs e)
        {
            fQuanLyMonHoc_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
