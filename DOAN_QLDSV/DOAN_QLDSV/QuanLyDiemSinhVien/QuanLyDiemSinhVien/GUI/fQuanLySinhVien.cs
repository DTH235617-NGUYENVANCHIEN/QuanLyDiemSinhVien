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
    public partial class fQuanLySinhVien : Form
    {
        SqlConnection conn = new SqlConnection();
        String Mamonhoc = "";
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
            //kết nói với khóa ngoại
            string sqlSinhVien = @"SELECT S.*,L.TenLop 
                                 FROM SINHVIEN S, LOP L
                                 WHERE S.MaLop=L.MaLop"; // Use a valid SQL SELECT statement
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlSinhVien, conn);
            DataTable data = new DataTable();
            dgvSinhVien.AutoGenerateColumns = false;// xóa cột dư
            dataAdapter.Fill(data); // Fill the DataTable directly

            dgvSinhVien.DataSource = data; // Set the DataTable as the DataSource
            cobLop.DisplayMember = "TenLop";
            cobLop.ValueMember = "MaLop";


            string LoaiTKsql = @"SELECT * FROM LOP";
            SqlDataAdapter loaiTKAdapter = new SqlDataAdapter(LoaiTKsql, conn);
            DataTable tableLoaiSach = new DataTable();
            loaiTKAdapter.Fill(tableLoaiSach);
            cobLop.DataSource = tableLoaiSach;


            MoNut(true);
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
            rdoNam.DataBindings.Add("Checked", dgvSinhVien.DataSource, "GioiTinh", false, DataSourceUpdateMode.Never);
            rdoNu.DataBindings.Add("Checked", dgvSinhVien.DataSource, "GioiTinh", false, DataSourceUpdateMode.Never);






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
    }
}
