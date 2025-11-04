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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            panel2 = new Panel();
            dgvGiaovien = new DataGridView();
            MaGV = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            NgaySinh = new DataGridViewTextBoxColumn();
            TenKhoa = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGiaovien).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
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
            panel1.Size = new Size(793, 257);
            panel1.TabIndex = 0;
            // 
            // cboLoaikhoa
            // 
            cboLoaikhoa.FormattingEnabled = true;
            cboLoaikhoa.Location = new Point(174, 196);
            cboLoaikhoa.Name = "cboLoaikhoa";
            cboLoaikhoa.Size = new Size(207, 35);
            cboLoaikhoa.TabIndex = 44;
            // 
            // btnTailai
            // 
            btnTailai.Location = new Point(430, 182);
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
            dtTime.CustomFormat = "dd/MM/yyyy";
            dtTime.Format = DateTimePickerFormat.Short;
            dtTime.Location = new Point(176, 138);
            dtTime.Name = "dtTime";
            dtTime.Size = new Size(205, 35);
            dtTime.TabIndex = 42;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 138);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(114, 27);
            label6.TabIndex = 41;
            label6.Text = "Ngày sinh:";
            // 
            // txtHotengv
            // 
            txtHotengv.Location = new Point(176, 85);
            txtHotengv.Margin = new Padding(4, 3, 4, 3);
            txtHotengv.MaxLength = 255;
            txtHotengv.Name = "txtHotengv";
            txtHotengv.Size = new Size(205, 35);
            txtHotengv.TabIndex = 25;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 196);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(108, 27);
            label3.TabIndex = 33;
            label3.Text = "Tên khoa:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 85);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(83, 27);
            label2.TabIndex = 32;
            label2.Text = "Họ tên:";
            // 
            // txtMaGV
            // 
            txtMaGV.Location = new Point(176, 25);
            txtMaGV.Margin = new Padding(5, 3, 5, 3);
            txtMaGV.MaxLength = 255;
            txtMaGV.Name = "txtMaGV";
            txtMaGV.Size = new Size(205, 35);
            txtMaGV.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 25);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(143, 27);
            label1.TabIndex = 31;
            label1.Text = "Mã giáo viên:";
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(602, 182);
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
            btnLuu.Location = new Point(602, 100);
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
            btnSua.Location = new Point(430, 100);
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
            btnXoa.Location = new Point(602, 17);
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
            btnThem.Location = new Point(430, 17);
            btnThem.Margin = new Padding(4, 3, 4, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(146, 37);
            btnThem.TabIndex = 26;
            btnThem.TabStop = false;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvGiaovien);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 257);
            panel2.Name = "panel2";
            panel2.Size = new Size(793, 212);
            panel2.TabIndex = 1;
            // 
            // dgvGiaovien
            // 
            dgvGiaovien.AllowUserToAddRows = false;
            dgvGiaovien.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvGiaovien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvGiaovien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGiaovien.Columns.AddRange(new DataGridViewColumn[] { MaGV, HoTen, NgaySinh, TenKhoa });
            dgvGiaovien.Dock = DockStyle.Fill;
            dgvGiaovien.Location = new Point(0, 0);
            dgvGiaovien.MultiSelect = false;
            dgvGiaovien.Name = "dgvGiaovien";
            dgvGiaovien.ReadOnly = true;
            dgvGiaovien.RowHeadersVisible = false;
            dgvGiaovien.RowHeadersWidth = 62;
            dgvGiaovien.RowTemplate.Height = 30;
            dgvGiaovien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGiaovien.Size = new Size(793, 212);
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
            MaGV.Width = 230;
            // 
            // HoTen
            // 
            HoTen.DataPropertyName = "HoTen";
            HoTen.HeaderText = "HỌ TÊN GV";
            HoTen.MinimumWidth = 8;
            HoTen.Name = "HoTen";
            HoTen.ReadOnly = true;
            HoTen.Width = 200;
            // 
            // NgaySinh
            // 
            NgaySinh.DataPropertyName = "NgaySinh";
            NgaySinh.HeaderText = "NGÀY SINH";
            NgaySinh.MinimumWidth = 8;
            NgaySinh.Name = "NgaySinh";
            NgaySinh.ReadOnly = true;
            NgaySinh.Width = 190;
            // 
            // TenKhoa
            // 
            TenKhoa.DataPropertyName = "TenKhoa";
            TenKhoa.HeaderText = "TÊN KHOA";
            TenKhoa.MinimumWidth = 8;
            TenKhoa.Name = "TenKhoa";
            TenKhoa.ReadOnly = true;
            TenKhoa.Width = 170;
            // 
            // fQuanLyGiaoVien
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(793, 469);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "fQuanLyGiaoVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Giao Viên";
            Load += fQuanLyGiaoVien_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGiaovien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
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
        private DataGridViewTextBoxColumn MaGV;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn NgaySinh;
        private DataGridViewTextBoxColumn TenKhoa;
        private Button btnTailai;
        private ComboBox cboLoaikhoa;
    }
}