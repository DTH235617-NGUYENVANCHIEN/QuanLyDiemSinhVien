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
            cboLoaikhoa.Text = "";
            cobGiaovien.Text = "";
           
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
            
            if (txtMalop.Text.Trim() == "")
                MessageBox.Show("Mã lớp không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTenlop.Text.Trim() == "")
                MessageBox.Show("Tên lớp không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cobGiaovien.Text.Trim()=="")
                MessageBox.Show("Chưa chọn giáo viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboLoaikhoa.Text.Trim() == "")
                MessageBox.Show("Chưa chọn khoa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    // Thêm mới
                    if (Malop == "")
                    {
                        string sql = @"INSERT INTO Lop
                        VALUES(@MaLop, @TenLop, @MaGV_CVHT, @MaKhoa)";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 20).Value = txtMalop.Text;
                        cmd.Parameters.Add("@TenLop", SqlDbType.NVarChar, 100).Value = txtTenlop.Text;
                        cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 20).Value = cboLoaikhoa.SelectedValue;
                        cmd.Parameters.Add("@MaGV_CVHT", SqlDbType.VarChar, 20).Value = cobGiaovien.SelectedValue;
                        
                        cmd.ExecuteNonQuery();
                    }
                    else // Sửa
                    {
                        string sql = @"UPDATE Lop
                                    SET MaLop = @MaLopMoi,
                                    TenLop = @TenLop,
                                    MaGV_CVHT = @MaGV_CVHT,
                                    MaKhoa = @MaKhoa
                                    WHERE MaLop = @MaLopCu";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.Add("@MaLopMoi", SqlDbType.VarChar, 20).Value = txtMalop.Text;
                        cmd.Parameters.Add("@MaLopCu", SqlDbType.VarChar, 20).Value = Malop;
                        cmd.Parameters.Add("@TenLop", SqlDbType.NVarChar, 100).Value = txtTenlop.Text;
                        cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 20).Value = cboLoaikhoa.SelectedValue;
                        cmd.Parameters.Add("@MaGV_CVHT", SqlDbType.VarChar, 20).Value = cobGiaovien.SelectedValue;
                        
                        cmd.ExecuteNonQuery();
                    }
                    // Tải lại form
                    fQuanLyLop_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

