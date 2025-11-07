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
    public partial class fQuanLyGiaoVien : Form
    {

        String magv = "";
        //mở trang chủ khi bấm nút thoát 
        public event EventHandler ThoatVeTrangChu;
        public fQuanLyGiaoVien()
        {
            InitializeComponent();
            
        }
        private void fQuanLyGiaoVien_Load(object sender, EventArgs e)
        {
            TaiLaiDuLieu_GV();

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
        private void btnSua_Click(object sender, EventArgs e)
        {
            magv = txtMaGV.Text;
            MoNut(false);
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult kq;
            kq = MessageBox.Show("Bạn có muốn xóa " + txtHotengv.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                // Dùng kết nối MỚI, tự đóng
                using (SqlConnection conn = KetnoiSQL.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string sql = @"DELETE FROM GIAOVIEN WHERE MaGV = @MaGV";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.Add("@MaGV", SqlDbType.VarChar, 20).Value = txtMaGV.Text;
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                } // conn tự động đóng ở đây

                // Tải lại form
                TaiLaiDuLieu_GV();
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DateTime ngayHienTai = DateTime.Now.Date;
            DateTime ngayDaChon = dtTime.Value.Date;

            // Kiểm tra dữ liệu (Giữ nguyên)
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
                // Dùng kết nối MỚI, tự đóng
                using (SqlConnection conn = KetnoiSQL.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        // Thêm mới
                        if (magv == "")
                        {
                            string sql = @"INSERT INTO GIAOVIEN 
                                           VALUES (@MaGV, @HoTen, @NgaySinh, @MaKhoa)";
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.Add("@MaGV", SqlDbType.VarChar, 20).Value = txtMaGV.Text;
                            cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = txtHotengv.Text;
                            cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtTime.Value;
                            cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 20).Value = cboLoaikhoa.SelectedValue;
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                } // conn tự động đóng ở đây

                // Tải lại form
                TaiLaiDuLieu_GV();
            }
        }

        private void btnTailai_Click(object sender, EventArgs e)
        {
            TaiLaiDuLieu_GV();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (ThoatVeTrangChu != null)
            {
                ThoatVeTrangChu(this, EventArgs.Empty);
            }
        }
        private void TaiLaiDuLieu_GV()
        {
            // 1. Tải dữ liệu GIAOVIEN cho DataGridView
            // (Thêm MaGV vào câu SELECT để cột hiển thị)
            string sqlTaiKhoan = @"SELECT G.MaGV, G.HoTen, G.NgaySinh, K.TenKhoa, G.MaKhoa
                                    FROM GIAOVIEN G, KHOA K
                                    WHERE G.MaKhoa=K.MaKhoa";

            // 2. Tải dữ liệu KHOA cho ComboBox
            string LoaiTKsql = @"SELECT * FROM KHOA";

            DataTable data = new DataTable();
            DataTable tableLoaiSach = new DataTable();

            // Dùng kết nối MỚI, tự đóng
            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlTaiKhoan, conn);
                    dataAdapter.Fill(data);

                    SqlDataAdapter loaiTKAdapter = new SqlDataAdapter(LoaiTKsql, conn);
                    loaiTKAdapter.Fill(tableLoaiSach);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                    return;
                }
            } // conn tự động đóng ở đây

            // 3. Đổ dữ liệu
            dgvGiaovien.AutoGenerateColumns = false;
            dgvGiaovien.DataSource = data;

            cboLoaikhoa.DataSource = tableLoaiSach;
            cboLoaikhoa.DisplayMember = "TenKhoa";
            cboLoaikhoa.ValueMember = "MaKhoa";

            // 4. Đặt trạng thái nút
            MoNut(true);

            // 5. Data Bindings (Giữ nguyên)
            cboLoaikhoa.DataBindings.Clear();
            txtMaGV.DataBindings.Clear();
            txtHotengv.DataBindings.Clear();
            dtTime.DataBindings.Clear();

            // Sửa DataBinding cho ComboBox để dùng SelectedValue
            cboLoaikhoa.DataBindings.Add("SelectedValue", dgvGiaovien.DataSource, "MaKhoa", false, DataSourceUpdateMode.Never);
            txtMaGV.DataBindings.Add("Text", dgvGiaovien.DataSource, "MaGV", false, DataSourceUpdateMode.Never);
            txtHotengv.DataBindings.Add("Text", dgvGiaovien.DataSource, "HoTen", false, DataSourceUpdateMode.Never);
            dtTime.DataBindings.Add("Text", dgvGiaovien.DataSource, "NgaySinh", false, DataSourceUpdateMode.Never);
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

       
    }
}
