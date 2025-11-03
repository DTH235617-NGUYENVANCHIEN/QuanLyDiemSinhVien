namespace QuanLyDiemSinhVien.GUI
{
    partial class fDiemSinhVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel2 = new Panel();
            txtDiemthi = new TextBox();
            txtDiemthanhphan = new TextBox();
            txtNamhoc = new TextBox();
            comboBox1 = new ComboBox();
            txtMonhoc = new TextBox();
            txtTenSV = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnThoat = new Button();
            btnLuu = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            btnLamlai = new Button();
            HoTen = new DataGridViewTextBoxColumn();
            TenMH = new DataGridViewTextBoxColumn();
            HocKy = new DataGridViewTextBoxColumn();
            NamHoc = new DataGridViewTextBoxColumn();
            DiemThanhPhan = new DataGridViewTextBoxColumn();
            DiemThi = new DataGridViewTextBoxColumn();
            DiemTongKet = new DataGridViewTextBoxColumn();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(btnLamlai);
            panel2.Controls.Add(txtDiemthi);
            panel2.Controls.Add(txtDiemthanhphan);
            panel2.Controls.Add(txtNamhoc);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(txtMonhoc);
            panel2.Controls.Add(txtTenSV);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnThoat);
            panel2.Controls.Add(btnLuu);
            panel2.Controls.Add(btnSua);
            panel2.Controls.Add(btnXoa);
            panel2.Controls.Add(btnThem);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1453, 208);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // txtDiemthi
            // 
            txtDiemthi.Location = new Point(848, 120);
            txtDiemthi.Name = "txtDiemthi";
            txtDiemthi.Size = new Size(182, 35);
            txtDiemthi.TabIndex = 34;
            // 
            // txtDiemthanhphan
            // 
            txtDiemthanhphan.Location = new Point(545, 112);
            txtDiemthanhphan.Name = "txtDiemthanhphan";
            txtDiemthanhphan.Size = new Size(182, 35);
            txtDiemthanhphan.TabIndex = 33;
            // 
            // txtNamhoc
            // 
            txtNamhoc.Location = new Point(165, 120);
            txtNamhoc.Name = "txtNamhoc";
            txtNamhoc.Size = new Size(182, 35);
            txtNamhoc.TabIndex = 32;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(848, 24);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 35);
            comboBox1.TabIndex = 31;
            // 
            // txtMonhoc
            // 
            txtMonhoc.Location = new Point(472, 21);
            txtMonhoc.Name = "txtMonhoc";
            txtMonhoc.Size = new Size(255, 35);
            txtMonhoc.TabIndex = 30;
            // 
            // txtTenSV
            // 
            txtTenSV.Location = new Point(165, 21);
            txtTenSV.Name = "txtTenSV";
            txtTenSV.Size = new Size(182, 35);
            txtTenSV.TabIndex = 29;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(754, 123);
            label6.Name = "label6";
            label6.Size = new Size(101, 27);
            label6.TabIndex = 27;
            label6.Text = "Điểm thi:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(362, 120);
            label5.Name = "label5";
            label5.Size = new Size(183, 27);
            label5.TabIndex = 26;
            label5.Text = "Điểm thành phần:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 120);
            label4.Name = "label4";
            label4.Size = new Size(105, 27);
            label4.TabIndex = 25;
            label4.Text = "Năm học:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(754, 21);
            label3.Name = "label3";
            label3.Size = new Size(88, 27);
            label3.TabIndex = 24;
            label3.Text = "Học kỳ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(362, 21);
            label2.Name = "label2";
            label2.Size = new Size(104, 27);
            label2.TabIndex = 23;
            label2.Text = "Môn học:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(147, 27);
            label1.TabIndex = 22;
            label1.Text = "Tên sinh viên:";
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(1274, 165);
            btnThoat.Margin = new Padding(4, 3, 4, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(146, 37);
            btnThoat.TabIndex = 21;
            btnThoat.TabStop = false;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(1274, 90);
            btnLuu.Margin = new Padding(4, 3, 4, 3);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(146, 37);
            btnLuu.TabIndex = 20;
            btnLuu.TabStop = false;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(1065, 90);
            btnSua.Margin = new Padding(4, 3, 4, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(146, 37);
            btnSua.TabIndex = 19;
            btnSua.TabStop = false;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(1274, 22);
            btnXoa.Margin = new Padding(4, 3, 4, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(146, 37);
            btnXoa.TabIndex = 18;
            btnXoa.TabStop = false;
            btnXoa.Text = "Xóa ";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(1065, 22);
            btnThem.Margin = new Padding(4, 3, 4, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(146, 37);
            btnThem.TabIndex = 17;
            btnThem.TabStop = false;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 208);
            panel1.Name = "panel1";
            panel1.Size = new Size(1453, 343);
            panel1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { HoTen, TenMH, HocKy, NamHoc, DiemThanhPhan, DiemThi, DiemTongKet });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1453, 343);
            dataGridView1.TabIndex = 2;
            dataGridView1.TabStop = false;
            // 
            // btnLamlai
            // 
            btnLamlai.Location = new Point(1065, 165);
            btnLamlai.Margin = new Padding(4, 3, 4, 3);
            btnLamlai.Name = "btnLamlai";
            btnLamlai.Size = new Size(146, 37);
            btnLamlai.TabIndex = 35;
            btnLamlai.TabStop = false;
            btnLamlai.Text = "Làm lại";
            btnLamlai.UseVisualStyleBackColor = true;
            // 
            // HoTen
            // 
            HoTen.DataPropertyName = "HoTen";
            HoTen.FillWeight = 36.36364F;
            HoTen.HeaderText = "TÊN SINH VIÊN";
            HoTen.MinimumWidth = 8;
            HoTen.Name = "HoTen";
            HoTen.ReadOnly = true;
            HoTen.Width = 230;
            // 
            // TenMH
            // 
            TenMH.DataPropertyName = "TenMH";
            TenMH.FillWeight = 36.36364F;
            TenMH.HeaderText = "MÔN HỌC";
            TenMH.MinimumWidth = 8;
            TenMH.Name = "TenMH";
            TenMH.ReadOnly = true;
            TenMH.Width = 180;
            // 
            // HocKy
            // 
            HocKy.DataPropertyName = "HocKy";
            HocKy.FillWeight = 36.36364F;
            HocKy.HeaderText = "HỌC KỲ";
            HocKy.MinimumWidth = 8;
            HocKy.Name = "HocKy";
            HocKy.ReadOnly = true;
            HocKy.Width = 150;
            // 
            // NamHoc
            // 
            NamHoc.DataPropertyName = "NamHoc";
            NamHoc.FillWeight = 36.36364F;
            NamHoc.HeaderText = "NĂM HỌC";
            NamHoc.MinimumWidth = 8;
            NamHoc.Name = "NamHoc";
            NamHoc.ReadOnly = true;
            NamHoc.Width = 170;
            // 
            // DiemThanhPhan
            // 
            DiemThanhPhan.DataPropertyName = "DiemThanhPhan";
            DiemThanhPhan.FillWeight = 36.36364F;
            DiemThanhPhan.HeaderText = "ĐIỂM THÀNH PHẦN";
            DiemThanhPhan.MinimumWidth = 8;
            DiemThanhPhan.Name = "DiemThanhPhan";
            DiemThanhPhan.ReadOnly = true;
            DiemThanhPhan.Width = 280;
            // 
            // DiemThi
            // 
            DiemThi.DataPropertyName = "DiemThi";
            DiemThi.FillWeight = 36.36364F;
            DiemThi.HeaderText = "ĐIỂM THI";
            DiemThi.MinimumWidth = 8;
            DiemThi.Name = "DiemThi";
            DiemThi.ReadOnly = true;
            DiemThi.Width = 180;
            // 
            // DiemTongKet
            // 
            DiemTongKet.DataPropertyName = "DiemTongKet";
            DiemTongKet.FillWeight = 36.36364F;
            DiemTongKet.HeaderText = "ĐIỂM TỔNG KẾT";
            DiemTongKet.MinimumWidth = 8;
            DiemTongKet.Name = "DiemTongKet";
            DiemTongKet.ReadOnly = true;
            DiemTongKet.Width = 260;
            // 
            // fDiemSinhVien
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1453, 551);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fDiemSinhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý điểm sinh viên";
            Load += fDiemSinhVien_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Panel panel1;
        private DataGridView dataGridView1;
        private Button btnThoat;
        private Button btnLuu;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private ComboBox comboBox1;
        private TextBox txtMonhoc;
        private TextBox txtTenSV;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtDiemthi;
        private TextBox txtDiemthanhphan;
        private TextBox txtNamhoc;
        private Button btnLamlai;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn TenMH;
        private DataGridViewTextBoxColumn HocKy;
        private DataGridViewTextBoxColumn NamHoc;
        private DataGridViewTextBoxColumn DiemThanhPhan;
        private DataGridViewTextBoxColumn DiemThi;
        private DataGridViewTextBoxColumn DiemTongKet;
    }
}