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
    public partial class fQuanLyLop : Form
    {

        String Malop = "";
        public fQuanLyLop()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.fQuanLyLop_FormClosing);
        }
        private void fQuanLyLop_Load(object sender, EventArgs e)
        {
            KetnoiSQL.MoKetNoi();
            TaiLaiDuLieu_Lop();
        } 
        private void fQuanLyLop_FormClosing(object sender, FormClosingEventArgs e)
        {
            KetnoiSQL.DongKetNoi();
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
        private void btnSua_Click(object sender, EventArgs e)
        {
            Malop = txtMalop.Text;
            MoNut(false);
        } 
        private void btnXoa_Click(object sender, EventArgs e)
        {

            DialogResult kq;
            kq = MessageBox.Show("Bạn có muốn xóa lớp " + txtTenlop.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                string sql = @"DELETE FROM Lop WHERE MaLop = @MaLop";
                SqlCommand cmd = new SqlCommand(sql, KetnoiSQL.conn);
                cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 20).Value = txtMalop.Text;
                cmd.ExecuteNonQuery();
               
                TaiLaiDuLieu_Lop();
            }
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
            else if (cboLoaikhoa.SelectedValue == null)
                MessageBox.Show("Vui lòng chọn Khoa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cobGiaovien.SelectedValue == null)
                MessageBox.Show("Vui lòng chọn Giáo viên quản lý!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                // Lấy MaKhoa và MaGV từ ComboBox
                string maKhoa = cboLoaikhoa.SelectedValue.ToString();
                string maGV = cobGiaovien.SelectedValue.ToString();

                try
                {
                    if (Malop == "") // THÊM MỚI
                    {
                        string sql = @"INSERT INTO LOP (MaLop, TenLop, MaKhoa, MaGV_CVHT) 
                                     VALUES (@MaLop, @TenLop, @MaKhoa, @MaGV_CVHT)";
                        // SỬA: Dùng KetnoiSQL.conn
                        using (SqlCommand cmd = new SqlCommand(sql, KetnoiSQL.conn))
                        {
                            cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 20).Value = maLop;
                            cmd.Parameters.Add("@TenLop", SqlDbType.NVarChar, 100).Value = tenLop;
                            cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 20).Value = maKhoa;
                            cmd.Parameters.Add("@MaGV_CVHT", SqlDbType.VarChar, 20).Value = maGV;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Thêm lớp mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else // SỬA
                    {
                        string sql = @"UPDATE LOP
                                     SET MaLop = @MaLop_Moi,
                                         TenLop = @TenLop,
                                         MaKhoa = @MaKhoa,
                                         MaGV_CVHT = @MaGV_CVHT
                                     WHERE MaLop = @MaLop_Cu";
                        // SỬA: Dùng KetnoiSQL.conn
                        using (SqlCommand cmd = new SqlCommand(sql, KetnoiSQL.conn))
                        {
                            cmd.Parameters.Add("@MaLop_Moi", SqlDbType.VarChar, 20).Value = maLop;
                            cmd.Parameters.Add("@TenLop", SqlDbType.NVarChar, 100).Value = tenLop;
                            cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 20).Value = maKhoa;
                            cmd.Parameters.Add("@MaGV_CVHT", SqlDbType.VarChar, 20).Value = maGV;
                            cmd.Parameters.Add("@MaLop_Cu", SqlDbType.VarChar, 20).Value = Malop;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cập nhật lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    // SỬA: Tải lại bằng hàm mới
                    TaiLaiDuLieu_Lop();
                }
                catch (SqlException ex) // (Giữ nguyên phần bắt lỗi)
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
        private void btnTailai_Click(object sender, EventArgs e)
        {
            TaiLaiDuLieu_Lop();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TaiLaiDuLieu_Lop()
        {
            // Hàm này giả định kết nối ĐÃ MỞ

            // 1. Tải dữ liệu LỚP cho DataGridView
            string sqlLop = @"SELECT L.*,G.HoTen,K.TenKhoa
                            FROM Lop L, GIAOVIEN G,KHOA K
                            WHERE L.MaGV_CVHT=G.MaGV 
                            AND L.MaKhoa =K.MaKhoa";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlLop, KetnoiSQL.conn);
            DataTable data = new DataTable();
            dgvLop.AutoGenerateColumns = false;
            dataAdapter.Fill(data);
            dgvLop.DataSource = data;

            // 2. Tải dữ liệu KHOA cho ComboBox
            string LoaiKhoasql = @"SELECT * FROM KHOA";
            SqlDataAdapter loaiKhoaAdapter = new SqlDataAdapter(LoaiKhoasql, KetnoiSQL.conn);
            DataTable tablekhoa = new DataTable();
            loaiKhoaAdapter.Fill(tablekhoa);
            cboLoaikhoa.DataSource = tablekhoa;
            cboLoaikhoa.DisplayMember = "TenKhoa";
            cboLoaikhoa.ValueMember = "MaKhoa";

            // 3. Tải dữ liệu GIÁO VIÊN cho ComboBox (Tải TẤT CẢ lúc đầu)
            // (Hàm LoadGiangVienComboBox sẽ lọc lại sau)
            string LoaiLopsql = @"SELECT * FROM GIAOVIEN";
            SqlDataAdapter loaiTKAdapter = new SqlDataAdapter(LoaiLopsql, KetnoiSQL.conn);
            DataTable tableGV = new DataTable();
            loaiTKAdapter.Fill(tableGV);
            cobGiaovien.DataSource = tableGV;
            cobGiaovien.DisplayMember = "HoTen";
            cobGiaovien.ValueMember = "MaGV";

            // 4. Đặt trạng thái nút
            MoNut(true);

            // 5. Data Bindings
            cboLoaikhoa.DataBindings.Clear();
            cobGiaovien.DataBindings.Clear();
            txtMalop.DataBindings.Clear();
            txtTenlop.DataBindings.Clear();

            cboLoaikhoa.DataBindings.Add("SelectedValue", dgvLop.DataSource, "MaKhoa", false, DataSourceUpdateMode.Never);
            cobGiaovien.DataBindings.Add("SelectedValue", dgvLop.DataSource, "MaGV_CVHT", false, DataSourceUpdateMode.Never);
            txtMalop.DataBindings.Add("Text", dgvLop.DataSource, "MaLop", false, DataSourceUpdateMode.Never);
            txtTenlop.DataBindings.Add("Text", dgvLop.DataSource, "TenLop", false, DataSourceUpdateMode.Never);

            // Đặt dòng này ở cuối để nó không kích hoạt sự kiện lúc DataBinding
            cboLoaikhoa.SelectedIndex = -1;
        }
        // HÀM MỚI: Tải GIÁO VIÊN (lọc theo MaKhoa được chọn)
        private void LoadGiangVienComboBox(string maKhoa)
        {
            DataTable dtGV = new DataTable();
            if (!string.IsNullOrEmpty(maKhoa))
            {
                string sqlGV = "SELECT MaGV, HoTen FROM GIAOVIEN WHERE MaKhoa = @MaKhoa";
                // SỬA: Dùng KetnoiSQL.conn
                SqlDataAdapter daGV = new SqlDataAdapter(sqlGV, KetnoiSQL.conn);
                daGV.SelectCommand.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 20).Value = maKhoa;
                daGV.Fill(dtGV);
            }
            cobGiaovien.DataSource = dtGV;
            cobGiaovien.DisplayMember = "HoTen";
            cobGiaovien.ValueMember = "MaGV";
        } 
        private void cboLoaikhoa_SelectedValueChanged(object sender, EventArgs e)
        {
            // Khi người dùng chọn 1 khoa (hoặc khi data binding)
            if (cboLoaikhoa.SelectedValue != null)
            {
                string maKhoa = cboLoaikhoa.SelectedValue.ToString();
                // Tải lại danh sách GV theo Khoa
                LoadGiangVienComboBox(maKhoa);
            }
            else
            {
                // Nếu không chọn Khoa nào (khi bấm Thêm mới)
                // Xóa sạch danh sách GV
                LoadGiangVienComboBox(null);
            }
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

       
    }
}

