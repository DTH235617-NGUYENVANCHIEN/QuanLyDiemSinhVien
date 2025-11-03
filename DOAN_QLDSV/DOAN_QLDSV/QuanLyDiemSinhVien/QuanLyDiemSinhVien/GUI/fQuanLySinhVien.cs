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


       

        private void fQuanLySinhVien_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.ConnectionString = @"server=.; Database=QLDSV;Integrated Security=True";
                conn.Open();
            }
            
        
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        } 
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
