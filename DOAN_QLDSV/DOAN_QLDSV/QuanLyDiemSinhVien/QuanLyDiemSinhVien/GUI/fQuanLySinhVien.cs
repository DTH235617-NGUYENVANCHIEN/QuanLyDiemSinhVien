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
            this.FormClosing += new FormClosingEventHandler(this.fQuanLySinhVien_FormClosing);

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

            // SỬA: Mở kết nối 1 lần
            KetnoiSQL.MoKetNoi();

            // SỬA: Gọi hàm tải dữ liệu
            TaiLaiDuLieu_SV();

        }   
        private void fQuanLySinhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            KetnoiSQL.DongKetNoi();
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

            DialogResult kq;
            kq = MessageBox.Show("Bạn có muốn xóa sinh viên " + txtTen.Text + " (Mã: " + txtMaSV.Text + ") không?",
                                  "Xác nhận xóa",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Warning);

            if (kq == DialogResult.Yes)
            {
                try
                {
                    string sql = @"DELETE FROM SINHVIEN WHERE MaSV = @MaSV";
                    // SỬA: Dùng KetnoiSQL.conn
                    SqlCommand cmd = new SqlCommand(sql, KetnoiSQL.conn);
                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 20).Value = txtMaSV.Text;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // SỬA: Tải lại bằng hàm mới
                    TaiLaiDuLieu_SV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thất bại. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }  
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // --- BƯỚC 1: KIỂM TRA DỮ LIỆU (Giữ nguyên) ---
            if (txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Mã sinh viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSV.Focus();
            }
            else if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Họ tên sinh viên không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Focus();
            }
            else if (!rdoNam.Checked && !rdoNu.Checked)
            {
                MessageBox.Show("Bạn chưa chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cobLop.SelectedValue == null || cobLop.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn một lớp cho sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cobLop.Focus();
            }
            else if (dtaTime.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không thể ở tương lai!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtaTime.Focus();
            }
            else
            {
                // --- BƯỚC 2: LƯU ---
                try
                {
                    if (Masv == "") // THÊM MỚI
                    {
                        string sqlThem = @"INSERT INTO SINHVIEN(MaSV, HoTen, NgaySinh, GioiTinh, MaLop) 
                                         VALUES(@MaSV, @HoTen, @NgaySinh, @GioiTinh, @MaLop)";
                        // SỬA: Dùng KetnoiSQL.conn
                        SqlCommand cmd = new SqlCommand(sqlThem, KetnoiSQL.conn);
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
                        // SỬA: Dùng KetnoiSQL.conn
                        SqlCommand cmd = new SqlCommand(sqlSua, KetnoiSQL.conn);
                        cmd.Parameters.Add("@MaSVMoi", SqlDbType.VarChar, 20).Value = txtMaSV.Text;
                        cmd.Parameters.Add("@MaSVCu", SqlDbType.VarChar, 20).Value = Masv;
                        cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = txtTen.Text;
                        cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtaTime.Value;
                        cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = rdoNam.Checked;
                        cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 20).Value = cobLop.SelectedValue;
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // SỬA: Tải lại bằng hàm mới
                    TaiLaiDuLieu_SV();
                }
                catch (SqlException ex) // (Giữ nguyên)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Mã sinh viên này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMaSV.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            // Hàm này giả định kết nối ĐÃ MỞ

            // --- BƯỚC 1: TẢI ComboBox LỚP ---
            string LoaiTKsql = @"SELECT * FROM LOP";
            SqlDataAdapter loaiTKAdapter = new SqlDataAdapter(LoaiTKsql, KetnoiSQL.conn);
            DataTable tableLop = new DataTable();
            loaiTKAdapter.Fill(tableLop);
            cobLop.DataSource = tableLop;
            cobLop.DisplayMember = "TenLop";
            cobLop.ValueMember = "MaLop";

            // --- BƯỚC 2: TẢI DataGridView SINH VIÊN ---
            string sqlSinhVien = @"SELECT S.*,L.TenLop 
                                 FROM SINHVIEN S, LOP L
                                 WHERE S.MaLop=L.MaLop";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlSinhVien, KetnoiSQL.conn);
            DataTable data = new DataTable();
            dgvSinhVien.AutoGenerateColumns = false;
            dataAdapter.Fill(data);
            dgvSinhVien.DataSource = data;

            // --- BƯỚC 3: KÍCH HOẠT NÚT ---
            MoNut(true);

            // --- BƯỚC 4: DATA BINDING ---
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

            // Binding cho rdoNam (Checked = GioiTinh)
            Binding bindNam = new Binding("Checked", dgvSinhVien.DataSource, "GioiTinh", false, DataSourceUpdateMode.Never);
            rdoNam.DataBindings.Add(bindNam);

            // Binding cho rdoNu (Checked = !GioiTinh)
            Binding bindNu = new Binding("Checked", dgvSinhVien.DataSource, "GioiTinh", false, DataSourceUpdateMode.Never);
            bindNu.Format += (s, ev) =>
            {
                if (ev.Value != null && ev.Value != DBNull.Value)
                {
                    ev.Value = !(bool)ev.Value; // Lật ngược
                }
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
