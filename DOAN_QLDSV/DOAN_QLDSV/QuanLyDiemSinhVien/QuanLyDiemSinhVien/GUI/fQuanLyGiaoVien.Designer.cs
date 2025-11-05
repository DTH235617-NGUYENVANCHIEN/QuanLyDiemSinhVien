namespace QuanLyDiemSinhVien.GUI
{
    partial class fQuanLyGiaoVien
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
            panel1 = new Panel();
            cboLoaikhoa = new ComboBox();
            btnTailai = new Button();
            dtTime = new DateTimePicker();
            label6 = new Label();
            txtHotengv = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtMaGV = new TextBox();
            label1 = new Label();
            btnThoat = new Button();
            btnLuu = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            dgvGiaovien = new DataGridView();
            MaGV = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            NgaySinh = new DataGridViewTextBoxColumn();
            TenKhoa = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGiaovien).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(192, 255, 192);
            panel1.Controls.Add(cboLoaikhoa);
            panel1.Controls.Add(btnTailai);
            panel1.Controls.Add(dtTime);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtHotengv);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtMaGV);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnLuu);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(btnThem);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(895, 257);
            panel1.TabIndex = 0;
            // 
            // cboLoaikhoa
            // 
            cboLoaikhoa.Anchor = AnchorStyles.Top;
            cboLoaikhoa.FormattingEnabled = true;
            cboLoaikhoa.Location = new Point(204, 195);
            cboLoaikhoa.Name = "cboLoaikhoa";
            cboLoaikhoa.Size = new Size(285, 35);
            cboLoaikhoa.TabIndex = 44;
            // 
            // btnTailai
            // 
            btnTailai.Anchor = AnchorStyles.Top;
            btnTailai.Location = new Point(516, 198);
            btnTailai.Margin = new Padding(4, 3, 4, 3);
            btnTailai.Name = "btnTailai";
            btnTailai.Size = new Size(146, 37);
            btnTailai.TabIndex = 43;
            btnTailai.TabStop = false;
            btnTailai.Text = "Tải lại";
            btnTailai.UseVisualStyleBackColor = true;
            btnTailai.Click += btnTailai_Click;
            // 
            // dtTime
            // 
            dtTime.Anchor = AnchorStyles.Top;
            dtTime.CustomFormat = "dd/MM/yyyy";
            dtTime.Format = DateTimePickerFormat.Short;
            dtTime.Location = new Point(206, 140);
            dtTime.Name = "dtTime";
            dtTime.Size = new Size(283, 35);
            dtTime.TabIndex = 42;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Location = new Point(39, 140);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(114, 27);
            label6.TabIndex = 41;
            label6.Text = "Ngày sinh:";
            // 
            // txtHotengv
            // 
            txtHotengv.Anchor = AnchorStyles.Top;
            txtHotengv.Location = new Point(206, 90);
            txtHotengv.Margin = new Padding(4, 3, 4, 3);
            txtHotengv.MaxLength = 255;
            txtHotengv.Name = "txtHotengv";
            txtHotengv.Size = new Size(283, 35);
            txtHotengv.TabIndex = 25;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(39, 198);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(108, 27);
            label3.TabIndex = 33;
            label3.Text = "Tên khoa:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(39, 90);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(83, 27);
            label2.TabIndex = 32;
            label2.Text = "Họ tên:";
            // 
            // txtMaGV
            // 
            txtMaGV.Anchor = AnchorStyles.Top;
            txtMaGV.Location = new Point(206, 32);
            txtMaGV.Margin = new Padding(5, 3, 5, 3);
            txtMaGV.MaxLength = 255;
            txtMaGV.Name = "txtMaGV";
            txtMaGV.Size = new Size(283, 35);
            txtMaGV.TabIndex = 23;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(39, 32);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(143, 27);
            label1.TabIndex = 31;
            label1.Text = "Mã giáo viên:";
            // 
            // btnThoat
            // 
            btnThoat.Anchor = AnchorStyles.Top;
            btnThoat.Location = new Point(705, 193);
            btnThoat.Margin = new Padding(4, 3, 4, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(146, 37);
            btnThoat.TabIndex = 30;
            btnThoat.TabStop = false;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Top;
            btnLuu.Location = new Point(705, 114);
            btnLuu.Margin = new Padding(4, 3, 4, 3);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(146, 37);
            btnLuu.TabIndex = 29;
            btnLuu.TabStop = false;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Top;
            btnSua.Location = new Point(516, 114);
            btnSua.Margin = new Padding(4, 3, 4, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(146, 37);
            btnSua.TabIndex = 28;
            btnSua.TabStop = false;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Top;
            btnXoa.Location = new Point(705, 30);
            btnXoa.Margin = new Padding(4, 3, 4, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(146, 37);
            btnXoa.TabIndex = 27;
            btnXoa.TabStop = false;
            btnXoa.Text = "Xóa ";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top;
            btnThem.Location = new Point(516, 30);
            btnThem.Margin = new Padding(4, 3, 4, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(146, 37);
            btnThem.TabIndex = 26;
            btnThem.TabStop = false;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dgvGiaovien
            // 
            dgvGiaovien.AllowUserToAddRows = false;
            dgvGiaovien.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvGiaovien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvGiaovien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGiaovien.Columns.AddRange(new DataGridViewColumn[] { MaGV, HoTen, NgaySinh, TenKhoa });
            dgvGiaovien.Dock = DockStyle.Fill;
            dgvGiaovien.Location = new Point(0, 257);
            dgvGiaovien.MultiSelect = false;
            dgvGiaovien.Name = "dgvGiaovien";
            dgvGiaovien.ReadOnly = true;
            dgvGiaovien.RowHeadersVisible = false;
            dgvGiaovien.RowHeadersWidth = 62;
            dgvGiaovien.RowTemplate.Height = 30;
            dgvGiaovien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGiaovien.Size = new Size(895, 212);
            dgvGiaovien.TabIndex = 2;
            dgvGiaovien.TabStop = false;
            // 
            // MaGV
            // 
            MaGV.DataPropertyName = "MaGV";
            MaGV.HeaderText = "MÃ GIÁO VIÊN";
            MaGV.MinimumWidth = 8;
            MaGV.Name = "MaGV";
            MaGV.ReadOnly = true;
            MaGV.Width = 211;
            // 
            // HoTen
            // 
            HoTen.DataPropertyName = "HoTen";
            HoTen.HeaderText = "HỌ TÊN GV";
            HoTen.MinimumWidth = 8;
            HoTen.Name = "HoTen";
            HoTen.ReadOnly = true;
            HoTen.Width = 210;
            // 
            // NgaySinh
            // 
            NgaySinh.DataPropertyName = "NgaySinh";
            NgaySinh.HeaderText = "NGÀY SINH";
            NgaySinh.MinimumWidth = 8;
            NgaySinh.Name = "NgaySinh";
            NgaySinh.ReadOnly = true;
            NgaySinh.Width = 211;
            // 
            // TenKhoa
            // 
            TenKhoa.DataPropertyName = "TenKhoa";
            TenKhoa.HeaderText = "TÊN KHOA";
            TenKhoa.MinimumWidth = 8;
            TenKhoa.Name = "TenKhoa";
            TenKhoa.ReadOnly = true;
            TenKhoa.Width = 260;
            // 
            // fQuanLyGiaoVien
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(895, 469);
            Controls.Add(dgvGiaovien);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "fQuanLyGiaoVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Giao Viên";
            FormClosing += fQuanLyGiaoVien_FormClosing;
            Load += fQuanLyGiaoVien_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGiaovien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtHotengv;
        private Label label3;
        private Label label2;
        private TextBox txtMaGV;
        private Label label1;
        private Button btnThoat;
        private Button btnLuu;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private DateTimePicker dtTime;
        private Label label6;
        private DataGridView dgvGiaovien;
        private Button btnTailai;
        private ComboBox cboLoaikhoa;
        private DataGridViewTextBoxColumn MaGV;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn NgaySinh;
        private DataGridViewTextBoxColumn TenKhoa;
    }
}