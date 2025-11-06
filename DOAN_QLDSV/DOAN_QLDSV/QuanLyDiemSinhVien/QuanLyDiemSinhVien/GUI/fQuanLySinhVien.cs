using Microsoft.VisualBasic.Logging;
using QuanLyDiemSinhVien.BLL;
using QuanLyDiemSinhVien.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSinhVien.GUI
{
    public partial class fQuanLySinhVien : Form
    {

        String Masv = "";
        public fQuanLySinhVien()
        {
            InitializeComponent();
     

        }
        private void fQuanLySinhVien_Load(object sender, EventArgs e)
        {
            // Phân quyền (Giữ nguyên)
            if (CurrentUser.TenQuyen == "Teacher")
            {
                btnThem.Visible = false;
                btnXoa.Visible = false;
                btnSua.Visible = false;
                btnLuu.Visible = false;
                btnTailai.Visible = false;
            }
            else if (CurrentUser.TenQuyen == "Admin")
            {
                // Admin thì không cần làm gì
            }

            TaiLaiDuLieu_SV();

        }   
      
        private void btnThem_Click(object sender, EventArgs e)
        {
            Masv = "";
            MoNut(false);          // Mở khóa các ô nhập liệu

            // Xóa trắng các ô để nhập mới
            txtMaSV.Text = "";
            txtTen.Text = "";
            dtaTime.Value = DateTime.Now;
            rdoNam.Checked = true; // Mặc định là Nam
            cobLop.SelectedIndex = -1; // Chọn lớp đầu tiên

            txtMaSV.Focus(); // Đưa con trỏ vào ô Mã SV
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            Masv = txtMaSV.Text;
            MoNut(false);
        }   
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult kq = MessageBox.Show("Bạn có muốn xóa sinh viên " + txtTen.Text + " (Mã: " + txtMaSV.Text + ") không?",
                                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (kq == DialogResult.Yes)
            {
                // SỬA: Dùng 'using'
                using (SqlConnection conn = KetnoiSQL.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string sql = @"DELETE FROM SINHVIEN WHERE MaSV = @MaSV";
                        SqlCommand cmd = new SqlCommand(sql, conn); // Dùng 'conn' mới
                        cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 20).Value = txtMaSV.Text;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thất bại. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } // conn tự động đóng

                TaiLaiDuLieu_SV();
            }
        }  
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // --- BƯỚC 1: KIỂM TRA DỮ LIỆU (Giữ nguyên) ---
            if (txtMaSV.Text.Trim() == "")
                MessageBox.Show("Mã sinh viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTen.Text.Trim() == "")
                MessageBox.Show("Họ tên sinh viên không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // ... (các kiểm tra khác giữ nguyên) ...
            else
            {
                // --- BƯỚC 2: LƯU ---
                // SỬA: Dùng 'using'
                using (SqlConnection conn = KetnoiSQL.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        if (Masv == "") // THÊM MỚI
                        {
                            string sqlThem = @"INSERT INTO SINHVIEN(MaSV, HoTen, NgaySinh, GioiTinh, MaLop) 
                                               VALUES(@MaSV, @HoTen, @NgaySinh, @GioiTinh, @MaLop)";
                            SqlCommand cmd = new SqlCommand(sqlThem, conn); // Dùng 'conn' mới
                            cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 20).Value = txtMaSV.Text;
                            cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = txtTen.Text;
                            cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtaTime.Value;
                            cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = rdoNam.Checked;
                            cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 20).Value = cobLop.SelectedValue;
                            cmd.ExecuteNonQuery();
                        }
                        else // SỬA
                        {
                            string sqlSua = @"UPDATE SINHVIEN 
                                            SET MaSV=@MaSVMoi,
                                                HoTen = @HoTen, 
                                                NgaySinh = @NgaySinh, 
                                                GioiTinh = @GioiTinh, 
                                                MaLop = @MaLop 
                                            WHERE MaSV = @MaSVCu";
                            SqlCommand cmd = new SqlCommand(sqlSua, conn); // Dùng 'conn' mới
                            cmd.Parameters.Add("@MaSVMoi", SqlDbType.VarChar, 20).Value = txtMaSV.Text;
                            cmd.Parameters.Add("@MaSVCu", SqlDbType.VarChar, 20).Value = Masv;
                            cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = txtTen.Text;
                            cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtaTime.Value;
                            cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = rdoNam.Checked;
                            cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 20).Value = cobLop.SelectedValue;
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex) // Bắt lỗi SQL (Giữ nguyên)
                    {
                        if (ex.Number == 2627)
                            MessageBox.Show("Mã sinh viên này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } // conn tự động đóng

                TaiLaiDuLieu_SV();
            }
        }   
        private void btnTailai_Click(object sender, EventArgs e)
        {
            TaiLaiDuLieu_SV();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TaiLaiDuLieu_SV()
        {
            string sqlLop = @"SELECT * FROM LOP";

            // Câu SQL cho SINH VIÊN (Mặc định cho Admin)
            string sqlSinhVien = @"
                SELECT DISTINCT S.*, L.TenLop 
                FROM SINHVIEN S
                INNER JOIN LOP L ON S.MaLop=L.MaLop
                WHERE 1 = 1 ";

            // THÊM ĐIỀU KIỆN LỌC THEO GIÁO VIÊN
            if (CurrentUser.TenQuyen == "Teacher")
            {
                // Lọc sinh viên mà GV đó ĐÃ CHẤM ĐIỂM (dựa trên bảng DIEM)
                sqlSinhVien = @"
                    SELECT DISTINCT S.*, L.TenLop 
                    FROM SINHVIEN S
                    INNER JOIN LOP L ON S.MaLop = L.MaLop
                    WHERE S.MaSV IN (
                        SELECT MaSV FROM DIEM 
                        WHERE MaGV = @MaGV_HienTai
                    )";
            }

            DataTable tableLop = new DataTable();
            DataTable data = new DataTable();

            // SỬA: Dùng 1 'using' duy nhất
            using (SqlConnection conn = KetnoiSQL.GetConnection())
            {
                try
                {
                    conn.Open();

                    // TẢI LỚP (không lọc)
                    SqlDataAdapter loaiTKAdapter = new SqlDataAdapter(sqlLop, conn);
                    loaiTKAdapter.Fill(tableLop);

                    // TẢI SINH VIÊN (có lọc)
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlSinhVien, conn);

                    // THÊM PARAMETER NẾU LÀ GIÁO VIÊN
                    if (CurrentUser.TenQuyen == "Teacher")
                    {
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@MaGV_HienTai", CurrentUser.Username);
                    }

                    dataAdapter.Fill(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                    return;
                }
            } // conn tự động đóng

            // --- BƯỚC 1: TẢI ComboBox LỚP ---
            cobLop.DataSource = tableLop;
            cobLop.DisplayMember = "TenLop";
            cobLop.ValueMember = "MaLop";

            // --- BƯỚC 2: TẢI DataGridView SINH VIÊN ---
            dgvSinhVien.AutoGenerateColumns = false;
            dgvSinhVien.DataSource = data;

            // --- BƯỚC 3: KÍCH HOẠT NÚT ---
            MoNut(true);

            // --- BƯỚC 4: DATA BINDING (Giữ nguyên) ---
            cobLop.DataBindings.Clear();
            txtMaSV.DataBindings.Clear();
            txtTen.DataBindings.Clear();
            dtaTime.DataBindings.Clear();
            rdoNam.DataBindings.Clear();
            rdoNu.DataBindings.Clear();

            cobLop.DataBindings.Add("SelectedValue", dgvSinhVien.DataSource, "MaLop", false, DataSourceUpdateMode.Never);
            txtMaSV.DataBindings.Add("Text", dgvSinhVien.DataSource, "MaSV", false, DataSourceUpdateMode.Never);
            txtTen.DataBindings.Add("Text", dgvSinhVien.DataSource, "HoTen", false, DataSourceUpdateMode.Never);
            dtaTime.DataBindings.Add("Text", dgvSinhVien.DataSource, "NgaySinh", false, DataSourceUpdateMode.Never);

            Binding bindNam = new Binding("Checked", dgvSinhVien.DataSource, "GioiTinh", false, DataSourceUpdateMode.Never);
            rdoNam.DataBindings.Add(bindNam);

            Binding bindNu = new Binding("Checked", dgvSinhVien.DataSource, "GioiTinh", false, DataSourceUpdateMode.Never);
            bindNu.Format += (s, ev) =>
            {
                if (ev.Value != null && ev.Value != DBNull.Value)
                    ev.Value = !(bool)ev.Value;
            };
            rdoNu.DataBindings.Add(bindNu);
        }
        private void MoNut(bool t)
        {
            txtMaSV.Enabled = !t;
            txtTen.Enabled = !t;
            cobLop.Enabled = !t;
            dtaTime.Enabled = !t;
            rdoNam.Enabled = !t;
            rdoNu.Enabled = !t;


            btnThem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnThoat.Enabled = t;
            btnTailai.Enabled = !t;

            btnLuu.Enabled = !t;
        }
        private void dgvSinhVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // "Dịch" cột GioiTinh (True/False) thành "Nam"/"Nữ"
            if (this.dgvSinhVien.Columns[e.ColumnIndex].DataPropertyName == "GioiTinh")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    try
                    {
                        bool gioiTinh = Convert.ToBoolean(e.Value);
                        if (gioiTinh == true)
                            e.Value = "Nam";
                        else
                            e.Value = "Nữ";
                        e.FormattingApplied = true;
                    }
                    catch (Exception)
                    {
                        e.Value = "Lỗi";
                    }
                }
            }
        }

    }
}
