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
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            panel2 = new Panel();
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
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDiem).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(192, 255, 192);
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
            panel2.Size = new Size(1924, 208);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Location = new Point(500, 153);
            label8.Name = "label8";
            label8.Size = new Size(101, 27);
            label8.TabIndex = 41;
            label8.Text = "Tên Lớp:";
            // 
            // cbTenLop
            // 
            cbTenLop.Anchor = AnchorStyles.Top;
            cbTenLop.FormattingEnabled = true;
            cbTenLop.Location = new Point(619, 153);
            cbTenLop.Name = "cbTenLop";
            cbTenLop.Size = new Size(300, 35);
            cbTenLop.TabIndex = 40;
            // 
            // cbTenKhoa
            // 
            cbTenKhoa.Anchor = AnchorStyles.Top;
            cbTenKhoa.FormattingEnabled = true;
            cbTenKhoa.Location = new Point(619, 25);
            cbTenKhoa.Name = "cbTenKhoa";
            cbTenKhoa.Size = new Size(300, 35);
            cbTenKhoa.TabIndex = 39;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Location = new Point(500, 25);
            label7.Name = "label7";
            label7.Size = new Size(113, 27);
            label7.TabIndex = 38;
            label7.Text = "Tên Khoa:";
            // 
            // cbTenSV
            // 
            cbTenSV.Anchor = AnchorStyles.Top;
            cbTenSV.FormattingEnabled = true;
            cbTenSV.Location = new Point(175, 25);
            cbTenSV.Name = "cbTenSV";
            cbTenSV.Size = new Size(268, 35);
            cbTenSV.TabIndex = 37;
            cbTenSV.SelectedIndexChanged += cbTenSV_SelectedIndexChanged;
            // 
            // cbMonHoc
            // 
            cbMonHoc.Anchor = AnchorStyles.Top;
            cbMonHoc.FormattingEnabled = true;
            cbMonHoc.Location = new Point(619, 89);
            cbMonHoc.Name = "cbMonHoc";
            cbMonHoc.Size = new Size(300, 35);
            cbMonHoc.TabIndex = 36;
            // 
            // btnLamlai
            // 
            btnLamlai.Anchor = AnchorStyles.Top;
            btnLamlai.Location = new Point(1445, 151);
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
            txtDiemthi.Anchor = AnchorStyles.Top;
            txtDiemthi.Location = new Point(1135, 89);
            txtDiemthi.Name = "txtDiemthi";
            txtDiemthi.Size = new Size(166, 35);
            txtDiemthi.TabIndex = 34;
            // 
            // txtDiemthanhphan
            // 
            txtDiemthanhphan.Anchor = AnchorStyles.Top;
            txtDiemthanhphan.Location = new Point(1135, 25);
            txtDiemthanhphan.Name = "txtDiemthanhphan";
            txtDiemthanhphan.Size = new Size(166, 35);
            txtDiemthanhphan.TabIndex = 33;
            // 
            // txtNamhoc
            // 
            txtNamhoc.Anchor = AnchorStyles.Top;
            txtNamhoc.Location = new Point(175, 89);
            txtNamhoc.Name = "txtNamhoc";
            txtNamhoc.Size = new Size(268, 35);
            txtNamhoc.TabIndex = 32;
            // 
            // cbHocKy
            // 
            cbHocKy.Anchor = AnchorStyles.Top;
            cbHocKy.FormattingEnabled = true;
            cbHocKy.Location = new Point(175, 153);
            cbHocKy.Name = "cbHocKy";
            cbHocKy.Size = new Size(268, 35);
            cbHocKy.TabIndex = 31;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Location = new Point(946, 89);
            label6.Name = "label6";
            label6.Size = new Size(101, 27);
            label6.TabIndex = 27;
            label6.Text = "Điểm thi:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Location = new Point(946, 25);
            label5.Name = "label5";
            label5.Size = new Size(183, 27);
            label5.TabIndex = 26;
            label5.Text = "Điểm thành phần:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Location = new Point(22, 89);
            label4.Name = "label4";
            label4.Size = new Size(105, 27);
            label4.TabIndex = 25;
            label4.Text = "Năm học:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(22, 153);
            label3.Name = "label3";
            label3.Size = new Size(88, 27);
            label3.TabIndex = 24;
            label3.Text = "Học kỳ:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(500, 89);
            label2.Name = "label2";
            label2.Size = new Size(104, 27);
            label2.TabIndex = 23;
            label2.Text = "Môn học:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(22, 25);
            label1.Name = "label1";
            label1.Size = new Size(147, 27);
            label1.TabIndex = 22;
            label1.Text = "Tên sinh viên:";
            // 
            // btnThoat
            // 
            btnThoat.Anchor = AnchorStyles.Top;
            btnThoat.Location = new Point(1719, 153);
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
            btnLuu.Anchor = AnchorStyles.Top;
            btnLuu.Location = new Point(1719, 89);
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
            btnSua.Anchor = AnchorStyles.Top;
            btnSua.Location = new Point(1445, 89);
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
            btnXoa.Anchor = AnchorStyles.Top;
            btnXoa.Location = new Point(1719, 25);
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
            btnThem.Anchor = AnchorStyles.Top;
            btnThem.Location = new Point(1445, 25);
            btnThem.Margin = new Padding(4, 3, 4, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(146, 37);
            btnThem.TabIndex = 17;
            btnThem.TabStop = false;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dgvDiem
            // 
            dgvDiem.AllowUserToAddRows = false;
            dgvDiem.AllowUserToDeleteRows = false;
            dgvDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiem.BackgroundColor = Color.FromArgb(255, 255, 192);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDiem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiem.Columns.AddRange(new DataGridViewColumn[] { TenSinhVien, TenMonHoc, HocKy, NamHoc, DiemThanhPhan, DiemThi, DiemTongKet, DiemChu, TenKhoa, TenLop });
            dgvDiem.Dock = DockStyle.Fill;
            dgvDiem.GridColor = Color.FromArgb(0, 64, 0);
            dgvDiem.Location = new Point(0, 208);
            dgvDiem.MultiSelect = false;
            dgvDiem.Name = "dgvDiem";
            dgvDiem.ReadOnly = true;
            dgvDiem.RowHeadersVisible = false;
            dgvDiem.RowHeadersWidth = 62;
            dgvDiem.RowTemplate.Height = 30;
            dgvDiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiem.Size = new Size(1924, 327);
            dgvDiem.TabIndex = 2;
            dgvDiem.TabStop = false;
            dgvDiem.CellContentClick += dgvDiem_CellContentClick;
            // 
            // TenSinhVien
            // 
            TenSinhVien.DataPropertyName = "TenSinhVien";
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 255, 192);
            TenSinhVien.DefaultCellStyle = dataGridViewCellStyle2;
            TenSinhVien.FillWeight = 63.5085869F;
            TenSinhVien.HeaderText = "TÊN SINH VIÊN";
            TenSinhVien.MinimumWidth = 8;
            TenSinhVien.Name = "TenSinhVien";
            TenSinhVien.ReadOnly = true;
            // 
            // TenMonHoc
            // 
            TenMonHoc.DataPropertyName = "TenMonHoc";
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 255, 192);
            TenMonHoc.DefaultCellStyle = dataGridViewCellStyle3;
            TenMonHoc.FillWeight = 51.1775322F;
            TenMonHoc.HeaderText = "MÔN HỌC";
            TenMonHoc.MinimumWidth = 8;
            TenMonHoc.Name = "TenMonHoc";
            TenMonHoc.ReadOnly = true;
            // 
            // HocKy
            // 
            HocKy.DataPropertyName = "HocKy";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(255, 255, 192);
            HocKy.DefaultCellStyle = dataGridViewCellStyle4;
            HocKy.FillWeight = 51.9660034F;
            HocKy.HeaderText = "HỌC KỲ";
            HocKy.MinimumWidth = 8;
            HocKy.Name = "HocKy";
            HocKy.ReadOnly = true;
            // 
            // NamHoc
            // 
            NamHoc.DataPropertyName = "NamHoc";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(255, 255, 192);
            NamHoc.DefaultCellStyle = dataGridViewCellStyle5;
            NamHoc.FillWeight = 54.28957F;
            NamHoc.HeaderText = "NĂM HỌC";
            NamHoc.MinimumWidth = 8;
            NamHoc.Name = "NamHoc";
            NamHoc.ReadOnly = true;
            // 
            // DiemThanhPhan
            // 
            DiemThanhPhan.DataPropertyName = "DiemThanhPhan";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(255, 255, 192);
            DiemThanhPhan.DefaultCellStyle = dataGridViewCellStyle6;
            DiemThanhPhan.FillWeight = 80.21691F;
            DiemThanhPhan.HeaderText = "ĐIỂM THÀNH PHẦN";
            DiemThanhPhan.MinimumWidth = 8;
            DiemThanhPhan.Name = "DiemThanhPhan";
            DiemThanhPhan.ReadOnly = true;
            // 
            // DiemThi
            // 
            DiemThi.DataPropertyName = "DiemThi";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(255, 255, 192);
            DiemThi.DefaultCellStyle = dataGridViewCellStyle7;
            DiemThi.FillWeight = 52.2910461F;
            DiemThi.HeaderText = "ĐIỂM THI";
            DiemThi.MinimumWidth = 8;
            DiemThi.Name = "DiemThi";
            DiemThi.ReadOnly = true;
            // 
            // DiemTongKet
            // 
            DiemTongKet.DataPropertyName = "DiemTongKet";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(255, 255, 192);
            DiemTongKet.DefaultCellStyle = dataGridViewCellStyle8;
            DiemTongKet.FillWeight = 59.13287F;
            DiemTongKet.HeaderText = "ĐIỂM TỔNG KẾT";
            DiemTongKet.MinimumWidth = 8;
            DiemTongKet.Name = "DiemTongKet";
            DiemTongKet.ReadOnly = true;
            // 
            // DiemChu
            // 
            DiemChu.DataPropertyName = "DiemChu";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(255, 255, 192);
            DiemChu.DefaultCellStyle = dataGridViewCellStyle9;
            DiemChu.FillWeight = 49.4599457F;
            DiemChu.HeaderText = "ĐIỂM CHỮ";
            DiemChu.MinimumWidth = 8;
            DiemChu.Name = "DiemChu";
            DiemChu.ReadOnly = true;
            // 
            // TenKhoa
            // 
            TenKhoa.DataPropertyName = "TenKhoa";
            dataGridViewCellStyle10.BackColor = Color.FromArgb(255, 255, 192);
            TenKhoa.DefaultCellStyle = dataGridViewCellStyle10;
            TenKhoa.FillWeight = 47.34905F;
            TenKhoa.HeaderText = "TÊN KHOA";
            TenKhoa.MinimumWidth = 8;
            TenKhoa.Name = "TenKhoa";
            TenKhoa.ReadOnly = true;
            // 
            // TenLop
            // 
            TenLop.DataPropertyName = "TenLop";
            dataGridViewCellStyle11.BackColor = Color.FromArgb(255, 255, 192);
            TenLop.DefaultCellStyle = dataGridViewCellStyle11;
            TenLop.FillWeight = 45.1539345F;
            TenLop.HeaderText = "TÊN LỚP";
            TenLop.MinimumWidth = 8;
            TenLop.Name = "TenLop";
            TenLop.ReadOnly = true;
            // 
            // fDiemSinhVien
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 535);
            Controls.Add(dgvDiem);
            Controls.Add(panel2);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "fDiemSinhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý điểm sinh viên";
            Load += fDiemSinhVien_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDiem).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
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
        private DataGridViewTextBoxColumn TenMH;
        private Label label7;
        private ComboBox cbTenKhoa;
        private Label label8;
        private ComboBox cbTenLop;
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