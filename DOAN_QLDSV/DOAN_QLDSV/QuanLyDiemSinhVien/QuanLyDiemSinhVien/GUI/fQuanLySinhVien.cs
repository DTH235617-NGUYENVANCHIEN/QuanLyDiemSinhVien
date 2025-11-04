using Microsoft.VisualBasic.Logging;
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
        SqlConnection conn = new SqlConnection();
        String Masv = "";
        public fQuanLySinhVien()
        {
            InitializeComponent();
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


        private void fQuanLySinhVien_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.ConnectionString = @"server=.; Database=QLDSV;Integrated Security=True";
                conn.Open();
            }

            // --- BƯỚC 1: TẢI VÀ CẤU HÌNH ComboBox LỚP (SỬA LỖI THỨ TỰ) ---
            string LoaiTKsql = @"SELECT * FROM LOP";
            SqlDataAdapter loaiTKAdapter = new SqlDataAdapter(LoaiTKsql, conn);
            DataTable tableLop = new DataTable();
            loaiTKAdapter.Fill(tableLop);

            // PHẢI gán DataSource TRƯỚC
            cobLop.DataSource = tableLop;
            // Gán DisplayMember và ValueMember SAU
            cobLop.DisplayMember = "TenLop";
            cobLop.ValueMember = "MaLop";


            // --- BƯỚC 2: TẢI DỮ LIỆU SINH VIÊN LÊN DataGridView ---
            string sqlSinhVien = @"SELECT S.*,L.TenLop 
                           FROM SINHVIEN S, LOP L
                           WHERE S.MaLop=L.MaLop";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlSinhVien, conn);
            DataTable data = new DataTable();
            dgvSinhVien.AutoGenerateColumns = false;
            dataAdapter.Fill(data);
            dgvSinhVien.DataSource = data;

            MoNut(true);

            // --- BƯỚC 3: DATA BINDING (SỬA LỖI RADIO BUTTON) ---

            // Xóa các binding cũ
            cobLop.DataBindings.Clear();
            txtMaSV.DataBindings.Clear();
            txtTen.DataBindings.Clear();
            dtaTime.DataBindings.Clear();
            rdoNam.DataBindings.Clear();
            rdoNu.DataBindings.Clear();

            // Binding cho các control bình thường
            cobLop.DataBindings.Add("SelectedValue", dgvSinhVien.DataSource, "MaLop", false, DataSourceUpdateMode.Never);
            txtMaSV.DataBindings.Add("Text", dgvSinhVien.DataSource, "MaSV", false, DataSourceUpdateMode.Never);
            txtTen.DataBindings.Add("Text", dgvSinhVien.DataSource, "HoTen", false, DataSourceUpdateMode.Never);
            dtaTime.DataBindings.Add("Text", dgvSinhVien.DataSource, "NgaySinh", false, DataSourceUpdateMode.Never);

            // SỬA LỖI BINDING GIỚI TÍNH
            // 1. Binding cho rdoNam (Checked = GioiTinh)
            // Khi GioiTinh là 'True', rdoNam.Checked = True
            Binding bindNam = new Binding("Checked", dgvSinhVien.DataSource, "GioiTinh", false, DataSourceUpdateMode.Never);
            rdoNam.DataBindings.Add(bindNam);

            // 2. Binding cho rdoNu (Checked = !GioiTinh)
            // Chúng ta cần lật ngược giá trị boolean
            Binding bindNu = new Binding("Checked", dgvSinhVien.DataSource, "GioiTinh", false, DataSourceUpdateMode.Never);

            // Thêm sự kiện Format để lật ngược giá trị
            bindNu.Format += (s, ev) =>
            {
                // ev.Value là giá trị boolean (True/False) từ cột "GioiTinh"
                // Ta gán cho rdoNu.Checked = giá trị NGƯỢC LẠI
                if (ev.Value != null && ev.Value != DBNull.Value)
                {
                    ev.Value = !(bool)ev.Value; // Dấu ! để lật ngược True thành False và ngược lại
                }
            };

            rdoNu.DataBindings.Add(bindNu);






        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSinhVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 1. Kiểm tra xem có phải cột "GioiTinh" không
            // (Tên "GioiTinh" là DataPropertyName của cột)
            if (this.dgvSinhVien.Columns[e.ColumnIndex].DataPropertyName == "GioiTinh")
            {
                // 2. Kiểm tra giá trị có tồn tại không
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    try
                    {
                        // 3. "Dịch" giá trị
                        bool gioiTinh = Convert.ToBoolean(e.Value);
                        if (gioiTinh == true) // Nếu là True
                        {
                            e.Value = "Nam"; // Hiển thị "Nam"
                        }
                        else // Nếu là False
                        {
                            e.Value = "Nữ"; // Hiển thị "Nữ"
                        }

                        // 4. Báo cho grid biết là ta đã xử lý xong
                        e.FormattingApplied = true;
                    }
                    catch (Exception)
                    {
                        e.Value = "Lỗi";
                    }
                }
            }
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // --- BƯỚC 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO (VALIDATION) ---
            // (Áp dụng cấu trúc "else if" giống như code mẫu của bạn)

            // Chỉ kiểm tra Mã SV khi ở chế độ "Thêm"
            if (txtMaSV.Text.Trim() == "" )
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
            // 5. THÊM LẠI: Kiểm tra Ngày sinh (không ở tương lai)
            else if (dtaTime.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không thể ở tương lai!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtaTime.Focus();
            }

            // (Bạn có thể thêm các kiểm tra khác ở đây nếu cần)
            else
            {
                // --- BƯỚC 2: KHI DỮ LIỆU HỢP LỆ, TIẾN HÀNH LƯU ---
                try
                {
                    
    
                    // THÊM MỚI (dựa trên biến currentAction ta đã làm)
                    if (Masv == "")
                    {
                        string sqlThem = @"INSERT INTO SINHVIEN(MaSV, HoTen, NgaySinh, GioiTinh, MaLop) 
                                   VALUES(@MaSV, @HoTen, @NgaySinh, @GioiTinh, @MaLop)";

                        SqlCommand cmd = new SqlCommand(sqlThem, conn);
                        // Thêm Parameters (theo style SQLDbType của bạn)
                        cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 20).Value = txtMaSV.Text;
                        cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = txtTen.Text;
                        cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtaTime.Value;
                        cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = rdoNam.Checked;
                        cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 20).Value = cobLop.SelectedValue;
                        cmd.ExecuteNonQuery(); 

                    }
                    // SỬA
                    else // 
                    {
                        string sqlSua = @"UPDATE SINHVIEN 
                                SET MaSV=@MaSVMoi,
                                    HoTen = @HoTen, 
                                    NgaySinh = @NgaySinh, 
                                    GioiTinh = @GioiTinh, 
                                    MaLop = @MaLop 
                                    WHERE MaSV = @MaSVCu";
                        SqlCommand cmd = new SqlCommand(sqlSua, conn);
                        cmd.Parameters.Add("@MaSVMoi", SqlDbType.VarChar, 20).Value = txtMaSV.Text;
                        cmd.Parameters.Add("@MaSVCu", SqlDbType.VarChar, 20).Value = Masv;
                        cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = txtTen.Text;
                        cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtaTime.Value;
                        cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = rdoNam.Checked;
                        cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 20).Value = cobLop.SelectedValue;

                        // Thêm Parameters (theo style SQLDbType của bạn)
                        cmd.ExecuteNonQuery();
                    }

                    // --- BƯỚC 4: THỰC THI VÀ HOÀN TẤT ---
                    

                    MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MoNut(true); // Chuyển về chế độ xem

                    // Tải lại Grid (Tốt hơn là gọi lại f..._Load)
                    fQuanLySinhVien_Load(sender, e);

                    
                }
                catch (SqlException ex)
                {
                    // Bắt lỗi trùng khóa chính (Mã SV) khi Thêm
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
                    // Bắt các lỗi chung khác
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           // 1.Kiểm tra xem có dòng nào được chọn không(dựa vào Mã SV)
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Hỏi xác nhận (giống như code mẫu của bạn)
            DialogResult kq;
            // Dùng txtTen.Text để hiển thị tên và txtMaSV.Text để hiển thị mã
            kq = MessageBox.Show("Bạn có muốn xóa sinh viên " + txtTen.Text + " (Mã: " + txtMaSV.Text + ") không?",
                                 "Xác nhận xóa",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Warning); // Nên dùng Warning (cảnh báo) cho thao tác Xóa

            // 3. Nếu người dùng đồng ý (nhấn Yes)
            if (kq == DialogResult.Yes)
            {
                try
                {
                    // 4. Tạo lệnh SQL (DELETE FROM SINHVIEN, WHERE MaSV)
                    string sql = @"DELETE FROM SINHVIEN WHERE MaSV = @MaSV";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // 5. Thêm tham số (lấy từ txtMaSV, không phải txtTen)
                    // (Giả sử MaSV là VARCHAR(20) như bảng của bạn)
                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 20).Value = txtMaSV.Text;

                    // 6. Thực thi
                    cmd.ExecuteNonQuery();

                    // 7. Thông báo và tải lại dữ liệu
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại Grid (Tốt hơn là gọi fQuanLySinhVien_Load)
                    // Đây là hàm ta đã tạo ở code "làm tất cả button"
                    fQuanLySinhVien_Load(sender, e);
                }
                catch (Exception ex)
                {
                    // Báo lỗi nếu có
                    MessageBox.Show("Xóa thất bại. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Masv = txtMaSV.Text;
            MoNut(false);
        }

        private void btnTailai_Click(object sender, EventArgs e)
        {
            fQuanLySinhVien_Load(sender, e);
        }
    }
}
