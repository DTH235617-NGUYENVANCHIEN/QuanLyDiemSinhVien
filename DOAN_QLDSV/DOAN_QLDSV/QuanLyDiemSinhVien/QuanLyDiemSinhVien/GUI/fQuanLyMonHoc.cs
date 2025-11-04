using Microsoft.VisualBasic.Logging;
using Microsoft.Win32.SafeHandles;
using QuanLyDiemSinhVien.BLL;
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
    public partial class fQuanLyMonHoc : Form
    {
        //SqlConnection conn = new SqlConnection();
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
            txtTenMH.Enabled = !t;
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
            if (CurrentUser.TenQuyen == "Teacher")
            {
                // Ẩn tất cả các nút Thêm, Sửa, Xóa, Lưu
                btnThem.Visible = false;
                btnXoa.Visible = false;
                btnSua.Visible = false;
                btnLuu.Visible = false;
                btnTailai.Visible = false; // Ẩn luôn nút Tải lại/Hủy
            }

            KetnoiSQL.MoKetNoi();
            string sqlTaiKhoan = @"SELECT * FROM MONHOC"; // Use a valid SQL SELECT statement
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlTaiKhoan, KetnoiSQL.conn);
            DataTable data = new DataTable();

            dataAdapter.Fill(data); // Fill the DataTable directly
            dgvMonhoc.DataSource = data; // Set the DataTable as the DataSource
            MoNut(true);
            txtMamonhoc.DataBindings.Clear();
            txtTenMH.DataBindings.Clear();
            nudSotinchi.DataBindings.Clear();
            txtMamonhoc.DataBindings.Add("Text", dgvMonhoc.DataSource, "MaMH", false, DataSourceUpdateMode.Never);
            txtTenMH.DataBindings.Add("Text", dgvMonhoc.DataSource, "TenMH", false, DataSourceUpdateMode.Never);
            nudSotinchi.DataBindings.Add("Value", dgvMonhoc.DataSource, "SoTC", false, DataSourceUpdateMode.Never);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Mamonhoc = "";
            //Xoa trang
            txtMamonhoc.Text = "";
            txtTenMH.Text = "";
            nudSotinchi.Value = 0;

            MoNut(false);
            txtMamonhoc.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Xác nhận (Dùng TenMH cho thân thiện)
            DialogResult kq;
            kq = MessageBox.Show("Bạn có muốn xóa môn học: " + txtTenMH.Text + " không?", "Xóa",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                try
                {
                    // Dùng MaMH (lấy từ TextBox) để làm điều kiện Xóa
                    string sql = @"DELETE FROM MONHOC WHERE MaMH = @MaMH";
                    SqlCommand cmd = new SqlCommand(sql, KetnoiSQL.conn);
                    cmd.Parameters.Add("@MaMH", SqlDbType.VarChar, 20).Value = txtMamonhoc.Text;
                    cmd.ExecuteNonQuery();

                    // Tải lại form
                    fQuanLyMonHoc_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string maMH = txtMamonhoc.Text.Trim();
            string tenMH = txtTenMH.Text.Trim();
            int soTC = (int)nudSotinchi.Value;


            // --- KIỂM TRA DỮ LIỆU ---
            if (maMH == "")
                MessageBox.Show("Mã môn học không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tenMH == "")
                MessageBox.Show("Tên môn học không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (soTC <= 0)
                MessageBox.Show("Số tín chỉ phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // Kiểm tra xem Số tín chỉ có phải là SỐ hay không

            else
            {
                // --- DỮ LIỆU HỢP LỆ -> TIẾN HÀNH LƯU ---
                try
                {
                    // THÊM MỚI (vì biến trạng thái rỗng)
                    if (Mamonhoc == "")
                    {
                        string sql = @"INSERT INTO MONHOC (MaMH, TenMH, SoTC) 
                                     VALUES (@MaMH, @TenMH, @SoTC)";

                        using (SqlCommand cmd = new SqlCommand(sql, KetnoiSQL.conn))
                        {
                            cmd.Parameters.Add("@MaMH", SqlDbType.VarChar, 20).Value = maMH;
                            cmd.Parameters.Add("@TenMH", SqlDbType.NVarChar, 100).Value = tenMH;
                            cmd.Parameters.Add("@SoTC", SqlDbType.Int).Value = soTC;

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Thêm môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else // SỬA (vì biến trạng thái có chứa MaMH cũ)
                    {
                        string sql = @"UPDATE MONHOC
                                     SET MaMH = @MaMH_Moi,
                                         TenMH = @TenMH,
                                         SoTC = @SoTC
                                     WHERE MaMH = @MaMH_Cu";

                        using (SqlCommand cmd = new SqlCommand(sql, KetnoiSQL.conn))
                        {
                            cmd.Parameters.Add("@MaMH_Moi", SqlDbType.VarChar, 20).Value = maMH;
                            cmd.Parameters.Add("@TenMH", SqlDbType.NVarChar, 100).Value = tenMH;
                            cmd.Parameters.Add("@SoTC", SqlDbType.Int).Value = soTC;
                            cmd.Parameters.Add("@MaMH_Cu", SqlDbType.VarChar, 20).Value = Mamonhoc; // Lấy MaMH gốc từ biến

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cập nhật môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    // Tải lại form (cho cả 2 trường hợp Thêm/Sửa)
                    fQuanLyMonHoc_Load(sender, e);
                }
                catch (SqlException ex)
                {
                    // Bắt lỗi CSDL (thân thiện hơn)
                    if (ex.Message.Contains("UNIQUE KEY constraint"))
                        MessageBox.Show("Mã môn học '" + maMH + "' đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (ex.Message.Contains("CHECK constraint"))
                        MessageBox.Show("Số tín chỉ phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Bắt các lỗi chung khác
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTailai_Click(object sender, EventArgs e)
        {
            fQuanLyMonHoc_Load(sender, e);
        }

      
        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
