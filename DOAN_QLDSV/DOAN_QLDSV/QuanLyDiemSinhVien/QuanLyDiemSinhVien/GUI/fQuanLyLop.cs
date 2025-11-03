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
    public partial class fQuanLyLop : Form
    {
        SqlConnection conn = new SqlConnection();
        String Malop = "";
        public fQuanLyLop()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        // HÀM MỚI: Tải GIÁO VIÊN (lọc theo MaKhoa được chọn)
        private void LoadGiangVienComboBox(string maKhoa)
        {
            DataTable dtGV = new DataTable(); // Luôn tạo 1 bảng mới

            // Chỉ truy vấn CSDL nếu có MaKhoa hợp lệ
            if (!string.IsNullOrEmpty(maKhoa))
            {
                string sqlGV = "SELECT MaGV, HoTen FROM GIAOVIEN WHERE MaKhoa = @MaKhoa";
                SqlDataAdapter daGV = new SqlDataAdapter(sqlGV, conn);
                daGV.SelectCommand.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 20).Value = maKhoa;
                daGV.Fill(dtGV);
            }

            // Gán nguồn dữ liệu (DataSource) cho cobGiaovien
            // Nếu không có MaKhoa, dtGV sẽ rỗng -> ComboBox tự động trống
            cobGiaovien.DataSource = dtGV;
            cobGiaovien.DisplayMember = "HoTen";
            cobGiaovien.ValueMember = "MaGV";
        }
        private void MoNut(bool t)
        {
            txtMalop.Enabled = !t;
            txtTenlop.Enabled = !t;
            cobGiaovien.Enabled = !t;
            cboLoaikhoa.Enabled = !t;


            btnThem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnThoat.Enabled = t;
            btnTailai.Enabled = !t;

            btnLuu.Enabled = !t;
        }

        private void fQuanLyLop_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.ConnectionString = @"server=.; Database=QLDSV;Integrated Security=True";
                conn.Open();
            }
            string sqlLop = @"SELECT L.*,G.HoTen,K.TenKhoa
                                 FROM Lop L, GIAOVIEN G,KHOA K
                                 WHERE L.MaGV_CVHT=G.MaGV 
                                 AND L.MaKhoa =K.MaKhoa"; // Use a valid SQL SELECT statement
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlLop, conn);
            DataTable data = new DataTable();
            dgvLop.AutoGenerateColumns = false;//xóa các cột dư
            dataAdapter.Fill(data); // Fill the DataTable directly
            dgvLop.DataSource = data; // Set the DataTable as the DataSource



            string LoaiLopsql = @"SELECT * FROM GIAOVIEN";
            SqlDataAdapter loaiTKAdapter = new SqlDataAdapter(LoaiLopsql, conn);
            DataTable tableGV = new DataTable();
            loaiTKAdapter.Fill(tableGV);
            cobGiaovien.DataSource = tableGV;
            cobGiaovien.DisplayMember = "HoTen";
            cobGiaovien.ValueMember = "MaGV";

            string LoaiKhoasql = @"SELECT * FROM KHOA";
            SqlDataAdapter loaiKhoaAdapter = new SqlDataAdapter(LoaiKhoasql, conn);
            DataTable tablekhoa = new DataTable();


            loaiKhoaAdapter.Fill(tablekhoa);
            cboLoaikhoa.DataSource = tablekhoa;
            cboLoaikhoa.DisplayMember = "TenKhoa";
            cboLoaikhoa.ValueMember = "MaKhoa";
            // THÊM DÒNG NÀY: Để đảm bảo ban đầu không chọn gì
            cboLoaikhoa.SelectedIndex = -1;

            MoNut(true);
            cboLoaikhoa.DataBindings.Clear();
            cobGiaovien.DataBindings.Clear();
            txtMalop.DataBindings.Clear();
            txtTenlop.DataBindings.Clear();

            cboLoaikhoa.DataBindings.Add("SelectedValue", dgvLop.DataSource, "MaKhoa", false, DataSourceUpdateMode.Never);
            cobGiaovien.DataBindings.Add("SelectedValue", dgvLop.DataSource, "MaGV_CVHT", false, DataSourceUpdateMode.Never);
            txtMalop.DataBindings.Add("Text", dgvLop.DataSource, "MaLop", false, DataSourceUpdateMode.Never);
            txtTenlop.DataBindings.Add("Text", dgvLop.DataSource, "TenLop", false, DataSourceUpdateMode.Never);



        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Malop = "";
            //Xoa trang
            txtMalop.Text = "";
            txtTenlop.Text = "";
            // THAY BẰNG DÒNG NÀY:
            cboLoaikhoa.SelectedIndex = -1; // Set về không chọn gì
                                            // Dòng trên sẽ tự động kích hoạt sự kiện ở Bước 3
                                            // và làm cho cobGiaovien (ComboBox giáo viên) tự động bị xóa theo.
           

            MoNut(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            DialogResult kq;
            kq = MessageBox.Show("Bạn có muốn xóa lớp " + txtTenlop.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                string sql = @"DELETE FROM Lop WHERE MaLop = @MaLop";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 20).Value = txtMalop.Text;
                cmd.ExecuteNonQuery();
                // Tải lại form
                fQuanLyLop_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Malop = txtMalop.Text;
            MoNut(false);
        }

        private void btnTailai_Click(object sender, EventArgs e)
        {
            fQuanLyLop_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            string maLop = txtMalop.Text.Trim();
            string tenLop = txtTenlop.Text.Trim();

            // --- KIỂM TRA DỮ LIỆU ---
            if (maLop == "")
                MessageBox.Show("Mã lớp không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tenLop == "")
                MessageBox.Show("Tên lớp không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboLoaikhoa.SelectedValue == null) // Kiểm tra xem đã chọn Khoa chưa
                MessageBox.Show("Vui lòng chọn Khoa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cobGiaovien.SelectedValue == null) // Kiểm tra xem đã chọn GV chưa
                MessageBox.Show("Vui lòng chọn Giáo viên quản lý!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                // Lấy MaKhoa và MaGV từ ComboBox
                string maKhoa = cboLoaikhoa.SelectedValue.ToString();
                string maGV = cobGiaovien.SelectedValue.ToString();

                try
                {
                    // Trường hợp THÊM MỚI (vì MaLop_Cu rỗng)
                    if (Malop == "")
                    {
                        string sql = @"INSERT INTO LOP (MaLop, TenLop, MaKhoa, MaGV_CVHT) 
                                       VALUES (@MaLop, @TenLop, @MaKhoa, @MaGV_CVHT)";

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 20).Value = maLop;
                            cmd.Parameters.Add("@TenLop", SqlDbType.NVarChar, 100).Value = tenLop;
                            cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 20).Value = maKhoa;
                            cmd.Parameters.Add("@MaGV_CVHT", SqlDbType.VarChar, 20).Value = maGV;

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Thêm lớp mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else // Trường hợp SỬA
                    {
                        string sql = @"UPDATE LOP
                                       SET MaLop = @MaLop_Moi,
                                           TenLop = @TenLop,
                                           MaKhoa = @MaKhoa,
                                           MaGV_CVHT = @MaGV_CVHT
                                       WHERE MaLop = @MaLop_Cu";

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.Add("@MaLop_Moi", SqlDbType.VarChar, 20).Value = maLop;
                            cmd.Parameters.Add("@TenLop", SqlDbType.NVarChar, 100).Value = tenLop;
                            cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 20).Value = maKhoa;
                            cmd.Parameters.Add("@MaGV_CVHT", SqlDbType.VarChar, 20).Value = maGV;
                            cmd.Parameters.Add("@MaLop_Cu", SqlDbType.VarChar, 20).Value = Malop; // Dùng MaLop cũ

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cập nhật lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    // Tải lại form (cho cả 2 trường hợp Thêm/Sửa)
                    fQuanLyLop_Load(sender, e);
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("UNIQUE KEY constraint"))
                        MessageBox.Show("Mã lớp '" + maLop + "' đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (ex.Message.Contains("FOREIGN KEY constraint"))
                        MessageBox.Show("Lỗi khóa ngoại, kiểm tra lại Mã Khoa hoặc Mã Giáo viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboLoaikhoa_SelectedValueChanged(object sender, EventArgs e)
        {
            // Biến tạm để lưu MaGV đang được chọn (nếu có)
            object selectedGV = cobGiaovien.SelectedValue;

            if (cboLoaikhoa.SelectedValue != null)
            {
                string maKhoa = cboLoaikhoa.SelectedValue.ToString();

                // Tải lại danh sách GV dựa theo Khoa vừa chọn
                // (Đây là hàm chúng ta tạo ở Bước 1)
                LoadGiangVienComboBox(maKhoa);

                // Cố gắng chọn lại GV cũ (nếu nó vẫn còn trong danh sách mới)
                if (selectedGV != null)
                {
                    cobGiaovien.SelectedValue = selectedGV;
                }
            }
            else
            {
                // Nếu không chọn Khoa nào (ví dụ lúc nhấn Thêm mới),
                // thì xóa sạch danh sách GV
                LoadGiangVienComboBox(null);
            }
        }
    }
}

