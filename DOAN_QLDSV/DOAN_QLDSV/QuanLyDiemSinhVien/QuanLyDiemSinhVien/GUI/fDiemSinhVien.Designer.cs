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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            panel2 = new Panel();
            cbTenGV = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            cbTenLop = new ComboBox();
            cbTenKhoa = new ComboBox();
            label7 = new Label();
            cbTenSV = new ComboBox();
            cbMonHoc = new ComboBox();
            btnLamlai = new Button();
            txtDiemthi = new TextBox();
            txtDiemthanhphan = new TextBox();
            txtNamhoc = new TextBox();
            cbHocKy = new ComboBox();
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
            dgvDiem = new DataGridView();
            TenSinhVien = new DataGridViewTextBoxColumn();
            TenMonHoc = new DataGridViewTextBoxColumn();
            HocKy = new DataGridViewTextBoxColumn();
            NamHoc = new DataGridViewTextBoxColumn();
            DiemThanhPhan = new DataGridViewTextBoxColumn();
            DiemThi = new DataGridViewTextBoxColumn();
            DiemTongKet = new DataGridViewTextBoxColumn();
            DiemChu = new DataGridViewTextBoxColumn();
            TenKhoa = new DataGridViewTextBoxColumn();
            TenLop = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDiem).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(192, 255, 192);
            panel2.Controls.Add(cbTenGV);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(cbTenLop);
            panel2.Controls.Add(cbTenKhoa);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(cbTenSV);
            panel2.Controls.Add(cbMonHoc);
            panel2.Controls.Add(btnLamlai);
            panel2.Controls.Add(txtDiemthi);
            panel2.Controls.Add(txtDiemthanhphan);
            panel2.Controls.Add(txtNamhoc);
            panel2.Controls.Add(cbHocKy);
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
            panel2.Size = new Size(1444, 208);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // cbTenGV
            // 
            cbTenGV.FormattingEnabled = true;
            cbTenGV.Location = new Point(811, 24);
            cbTenGV.Name = "cbTenGV";
            cbTenGV.Size = new Size(182, 27);
            cbTenGV.TabIndex = 43;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(683, 24);
            label9.Name = "label9";
            label9.Size = new Size(99, 19);
            label9.TabIndex = 42;
            label9.Text = "Tên Giáo Viên:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(345, 108);
            label8.Name = "label8";
            label8.Size = new Size(64, 19);
            label8.TabIndex = 41;
            label8.Text = "Tên Lớp:";
            // 
            // cbTenLop
            // 
            cbTenLop.FormattingEnabled = true;
            cbTenLop.Location = new Point(425, 108);
            cbTenLop.Name = "cbTenLop";
            cbTenLop.Size = new Size(182, 27);
            cbTenLop.TabIndex = 40;
            // 
            // cbTenKhoa
            // 
            cbTenKhoa.FormattingEnabled = true;
            cbTenKhoa.Location = new Point(425, 25);
            cbTenKhoa.Name = "cbTenKhoa";
            cbTenKhoa.Size = new Size(182, 27);
            cbTenKhoa.TabIndex = 39;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(336, 24);
            label7.Name = "label7";
            label7.Size = new Size(73, 19);
            label7.TabIndex = 38;
            label7.Text = "Tên Khoa:";
            // 
            // cbTenSV
            // 
            cbTenSV.FormattingEnabled = true;
            cbTenSV.Location = new Point(108, 24);
            cbTenSV.Name = "cbTenSV";
            cbTenSV.Size = new Size(182, 27);
            cbTenSV.TabIndex = 37;
            cbTenSV.SelectedIndexChanged += cbTenSV_SelectedIndexChanged;
            // 
            // cbMonHoc
            // 
            cbMonHoc.FormattingEnabled = true;
            cbMonHoc.Location = new Point(425, 67);
            cbMonHoc.Name = "cbMonHoc";
            cbMonHoc.Size = new Size(182, 27);
            cbMonHoc.TabIndex = 36;
            // 
            // btnLamlai
            // 
            btnLamlai.Location = new Point(1090, 155);
            btnLamlai.Margin = new Padding(4, 3, 4, 3);
            btnLamlai.Name = "btnLamlai";
            btnLamlai.Size = new Size(146, 37);
            btnLamlai.TabIndex = 35;
            btnLamlai.TabStop = false;
            btnLamlai.Text = "Làm lại";
            btnLamlai.UseVisualStyleBackColor = true;
            btnLamlai.Click += btnLamlai_Click;
            // 
            // txtDiemthi
            // 
            txtDiemthi.Location = new Point(811, 108);
            txtDiemthi.Name = "txtDiemthi";
            txtDiemthi.Size = new Size(182, 26);
            txtDiemthi.TabIndex = 34;
            // 
            // txtDiemthanhphan
            // 
            txtDiemthanhphan.Location = new Point(811, 67);
            txtDiemthanhphan.Name = "txtDiemthanhphan";
            txtDiemthanhphan.Size = new Size(182, 26);
            txtDiemthanhphan.TabIndex = 33;
            // 
            // txtNamhoc
            // 
            txtNamhoc.Location = new Point(108, 67);
            txtNamhoc.Name = "txtNamhoc";
            txtNamhoc.Size = new Size(182, 26);
            txtNamhoc.TabIndex = 32;
            // 
            // cbHocKy
            // 
            cbHocKy.FormattingEnabled = true;
            cbHocKy.Location = new Point(108, 108);
            cbHocKy.Name = "cbHocKy";
            cbHocKy.Size = new Size(182, 27);
            cbHocKy.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(720, 108);
            label6.Name = "label6";
            label6.Size = new Size(62, 19);
            label6.TabIndex = 27;
            label6.Text = "Điểm thi:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(669, 67);
            label5.Name = "label5";
            label5.Size = new Size(113, 19);
            label5.TabIndex = 26;
            label5.Text = "Điểm thành phần:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 67);
            label4.Name = "label4";
            label4.Size = new Size(68, 19);
            label4.TabIndex = 25;
            label4.Text = "Năm học:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 108);
            label3.Name = "label3";
            label3.Size = new Size(57, 19);
            label3.TabIndex = 24;
            label3.Text = "Học kỳ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(342, 67);
            label2.Name = "label2";
            label2.Size = new Size(67, 19);
            label2.TabIndex = 23;
            label2.Text = "Môn học:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 24);
            label1.Name = "label1";
            label1.Size = new Size(90, 19);
            label1.TabIndex = 22;
            label1.Text = "Tên sinh viên:";
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(1293, 155);
            btnThoat.Margin = new Padding(4, 3, 4, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(146, 37);
            btnThoat.TabIndex = 21;
            btnThoat.TabStop = false;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(1293, 90);
            btnLuu.Margin = new Padding(4, 3, 4, 3);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(146, 37);
            btnLuu.TabIndex = 20;
            btnLuu.TabStop = false;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(1090, 90);
            btnSua.Margin = new Padding(4, 3, 4, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(146, 37);
            btnSua.TabIndex = 19;
            btnSua.TabStop = false;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(1293, 25);
            btnXoa.Margin = new Padding(4, 3, 4, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(146, 37);
            btnXoa.TabIndex = 18;
            btnXoa.TabStop = false;
            btnXoa.Text = "Xóa ";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(1090, 23);
            btnThem.Margin = new Padding(4, 3, 4, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(146, 37);
            btnThem.TabIndex = 17;
            btnThem.TabStop = false;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvDiem);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 208);
            panel1.Name = "panel1";
            panel1.Size = new Size(1444, 343);
            panel1.TabIndex = 3;
            // 
            // dgvDiem
            // 
            dgvDiem.AllowUserToAddRows = false;
            dgvDiem.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDiem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiem.Columns.AddRange(new DataGridViewColumn[] { TenSinhVien, TenMonHoc, HocKy, NamHoc, DiemThanhPhan, DiemThi, DiemTongKet, DiemChu, TenKhoa, TenLop, HoTen });
            dgvDiem.Dock = DockStyle.Fill;
            dgvDiem.Location = new Point(0, 0);
            dgvDiem.MultiSelect = false;
            dgvDiem.Name = "dgvDiem";
            dgvDiem.ReadOnly = true;
            dgvDiem.RowHeadersVisible = false;
            dgvDiem.RowHeadersWidth = 62;
            dgvDiem.RowTemplate.Height = 30;
            dgvDiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiem.Size = new Size(1444, 343);
            dgvDiem.TabIndex = 2;
            dgvDiem.TabStop = false;
            dgvDiem.CellContentClick += dgvDiem_CellContentClick;
            // 
            // TenSinhVien
            // 
            TenSinhVien.DataPropertyName = "HoTen";
            TenSinhVien.FillWeight = 36.36364F;
            TenSinhVien.HeaderText = "TÊN SINH VIÊN";
            TenSinhVien.MinimumWidth = 8;
            TenSinhVien.Name = "TenSinhVien";
            TenSinhVien.ReadOnly = true;
            TenSinhVien.Width = 220;
            // 
            // TenMonHoc
            // 
            TenMonHoc.DataPropertyName = "TenMH";
            TenMonHoc.FillWeight = 36.36364F;
            TenMonHoc.HeaderText = "MÔN HỌC";
            TenMonHoc.MinimumWidth = 8;
            TenMonHoc.Name = "TenMonHoc";
            TenMonHoc.ReadOnly = true;
            TenMonHoc.Width = 180;
            // 
            // HocKy
            // 
            HocKy.DataPropertyName = "HocKy";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            HocKy.DefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NamHoc.DefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DiemThanhPhan.DefaultCellStyle = dataGridViewCellStyle4;
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
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DiemThi.DefaultCellStyle = dataGridViewCellStyle5;
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
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DiemTongKet.DefaultCellStyle = dataGridViewCellStyle6;
            DiemTongKet.FillWeight = 36.36364F;
            DiemTongKet.HeaderText = "ĐIỂM TỔNG KẾT";
            DiemTongKet.MinimumWidth = 8;
            DiemTongKet.Name = "DiemTongKet";
            DiemTongKet.ReadOnly = true;
            DiemTongKet.Width = 260;
            // 
            // DiemChu
            // 
            DiemChu.DataPropertyName = "DiemChu";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DiemChu.DefaultCellStyle = dataGridViewCellStyle7;
            DiemChu.HeaderText = "ĐIỂM CHỮ";
            DiemChu.MinimumWidth = 8;
            DiemChu.Name = "DiemChu";
            DiemChu.ReadOnly = true;
            DiemChu.Width = 180;
            // 
            // TenKhoa
            // 
            TenKhoa.DataPropertyName = "TenKhoa";
            TenKhoa.HeaderText = "TÊN KHOA";
            TenKhoa.Name = "TenKhoa";
            TenKhoa.ReadOnly = true;
            // 
            // TenLop
            // 
            TenLop.DataPropertyName = "TenLop";
            TenLop.HeaderText = "TÊN LỚP";
            TenLop.Name = "TenLop";
            TenLop.ReadOnly = true;
            // 
            // HoTen
            // 
            HoTen.DataPropertyName = "HoTen";
            HoTen.HeaderText = "TÊN GIÁO VIÊN";
            HoTen.Name = "HoTen";
            HoTen.ReadOnly = true;
            // 
            // fDiemSinhVien
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1444, 551);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "fDiemSinhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý điểm sinh viên";
            Load += fDiemSinhVien_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDiem).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Panel panel1;
        private DataGridView dgvDiem;
        private Button btnThoat;
        private Button btnLuu;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private ComboBox cbHocKy;
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
        private ComboBox cbTenSV;
        private ComboBox cbMonHoc;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn TenMH;
        private Label label7;
        private ComboBox cbTenKhoa;
        private Label label8;
        private ComboBox cbTenLop;
        private ComboBox cbTenGV;
        private Label label9;
        private DataGridViewTextBoxColumn TenSinhVien;
        private DataGridViewTextBoxColumn TenMonHoc;
        private DataGridViewTextBoxColumn HocKy;
        private DataGridViewTextBoxColumn NamHoc;
        private DataGridViewTextBoxColumn DiemThanhPhan;
        private DataGridViewTextBoxColumn DiemThi;
        private DataGridViewTextBoxColumn DiemTongKet;
        private DataGridViewTextBoxColumn DiemChu;
        private DataGridViewTextBoxColumn TenKhoa;
        private DataGridViewTextBoxColumn TenLop;
    }
}