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
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDiem).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
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
            panel2.Size = new Size(1623, 208);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // cbTenSV
            // 
            cbTenSV.FormattingEnabled = true;
            cbTenSV.Location = new Point(165, 25);
            cbTenSV.Name = "cbTenSV";
            cbTenSV.Size = new Size(182, 35);
            cbTenSV.TabIndex = 37;
            // 
            // cbMonHoc
            // 
            cbMonHoc.FormattingEnabled = true;
            cbMonHoc.Location = new Point(545, 25);
            cbMonHoc.Name = "cbMonHoc";
            cbMonHoc.Size = new Size(182, 35);
            cbMonHoc.TabIndex = 36;
            // 
            // btnLamlai
            // 
            btnLamlai.Location = new Point(1201, 155);
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
            // cbHocKy
            // 
            cbHocKy.FormattingEnabled = true;
            cbHocKy.Location = new Point(848, 24);
            cbHocKy.Name = "cbHocKy";
            cbHocKy.Size = new Size(182, 35);
            cbHocKy.TabIndex = 31;
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
            btnThoat.Location = new Point(1404, 155);
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
            btnLuu.Location = new Point(1404, 90);
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
            btnSua.Location = new Point(1201, 90);
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
            btnXoa.Location = new Point(1404, 25);
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
            btnThem.Location = new Point(1201, 23);
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
            panel1.Size = new Size(1623, 343);
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
            dgvDiem.Columns.AddRange(new DataGridViewColumn[] { TenSinhVien, TenMonHoc, HocKy, NamHoc, DiemThanhPhan, DiemThi, DiemTongKet, DiemChu });
            dgvDiem.Dock = DockStyle.Fill;
            dgvDiem.Location = new Point(0, 0);
            dgvDiem.MultiSelect = false;
            dgvDiem.Name = "dgvDiem";
            dgvDiem.ReadOnly = true;
            dgvDiem.RowHeadersVisible = false;
            dgvDiem.RowHeadersWidth = 62;
            dgvDiem.RowTemplate.Height = 30;
            dgvDiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiem.Size = new Size(1623, 343);
            dgvDiem.TabIndex = 2;
            dgvDiem.TabStop = false;
            dgvDiem.CellContentClick += dgvDiem_CellContentClick;
            // 
            // TenSinhVien
            // 
            TenSinhVien.DataPropertyName = "TenSinhVien";
            TenSinhVien.FillWeight = 36.36364F;
            TenSinhVien.HeaderText = "TÊN SINH VIÊN";
            TenSinhVien.MinimumWidth = 8;
            TenSinhVien.Name = "TenSinhVien";
            TenSinhVien.ReadOnly = true;
            TenSinhVien.Width = 220;
            // 
            // TenMonHoc
            // 
            TenMonHoc.DataPropertyName = "TenMonHoc";
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
            // fDiemSinhVien
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1623, 551);
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
        private DataGridViewTextBoxColumn TenSinhVien;
        private DataGridViewTextBoxColumn TenMonHoc;
        private DataGridViewTextBoxColumn HocKy;
        private DataGridViewTextBoxColumn NamHoc;
        private DataGridViewTextBoxColumn DiemThanhPhan;
        private DataGridViewTextBoxColumn DiemThi;
        private DataGridViewTextBoxColumn DiemTongKet;
        private DataGridViewTextBoxColumn DiemChu;
    }
}