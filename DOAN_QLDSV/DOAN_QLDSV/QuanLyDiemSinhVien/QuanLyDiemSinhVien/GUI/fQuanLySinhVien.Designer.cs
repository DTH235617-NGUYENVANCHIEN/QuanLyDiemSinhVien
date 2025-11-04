namespace QuanLyDiemSinhVien.GUI
{
    partial class fQuanLySinhVien
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btnTailai = new Button();
            cobLop = new ComboBox();
            panel3 = new Panel();
            rdoNu = new RadioButton();
            rdoNam = new RadioButton();
            dtaTime = new DateTimePicker();
            label6 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtTen = new TextBox();
            label2 = new Label();
            txtMaSV = new TextBox();
            label1 = new Label();
            btnThoat = new Button();
            btnLuu = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            panel2 = new Panel();
            dgvSinhVien = new DataGridView();
            MaSV = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            NgaySinh = new DataGridViewTextBoxColumn();
            GioiTinh = new DataGridViewTextBoxColumn();
            TenLop = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnTailai);
            panel1.Controls.Add(cobLop);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(dtaTime);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtTen);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtMaSV);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnLuu);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(btnThem);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(923, 150);
            panel1.TabIndex = 0;
            // 
            // btnTailai
            // 
            btnTailai.Location = new Point(631, 107);
            btnTailai.Margin = new Padding(4, 3, 4, 3);
            btnTailai.Name = "btnTailai";
            btnTailai.Size = new Size(97, 37);
            btnTailai.TabIndex = 43;
            btnTailai.TabStop = false;
            btnTailai.Text = "Tải lại";
            btnTailai.UseVisualStyleBackColor = true;
            btnTailai.Click += btnTailai_Click;
            // 
            // cobLop
            // 
            cobLop.FormattingEnabled = true;
            cobLop.Location = new Point(439, 61);
            cobLop.Name = "cobLop";
            cobLop.Size = new Size(182, 35);
            cobLop.TabIndex = 42;
            // 
            // panel3
            // 
            panel3.Controls.Add(rdoNu);
            panel3.Controls.Add(rdoNam);
            panel3.Location = new Point(139, 57);
            panel3.Name = "panel3";
            panel3.Size = new Size(163, 35);
            panel3.TabIndex = 41;
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(80, 3);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(67, 31);
            rdoNu.TabIndex = 43;
            rdoNu.TabStop = true;
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Location = new Point(3, 3);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(83, 31);
            rdoNam.TabIndex = 42;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            // 
            // dtaTime
            // 
            dtaTime.CustomFormat = "dd/MM/yyyy";
            dtaTime.Format = DateTimePickerFormat.Short;
            dtaTime.Location = new Point(753, 8);
            dtaTime.Name = "dtaTime";
            dtaTime.Size = new Size(163, 35);
            dtaTime.TabIndex = 40;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(631, 14);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(114, 27);
            label6.TabIndex = 37;
            label6.Text = "Ngày sinh:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(340, 61);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(92, 27);
            label3.TabIndex = 35;
            label3.Text = "Tên lớp:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 61);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(103, 27);
            label4.TabIndex = 33;
            label4.Text = "Giới tính:";
            // 
            // txtTen
            // 
            txtTen.Location = new Point(431, 8);
            txtTen.Margin = new Padding(4, 3, 4, 3);
            txtTen.MaxLength = 255;
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(182, 35);
            txtTen.TabIndex = 30;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(340, 16);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(83, 27);
            label2.TabIndex = 31;
            label2.Text = "Họ tên:";
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(155, 11);
            txtMaSV.Margin = new Padding(5, 3, 5, 3);
            txtMaSV.MaxLength = 255;
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(163, 35);
            txtMaSV.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 16);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(142, 27);
            label1.TabIndex = 29;
            label1.Text = "Mã sinh viên:";
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(766, 107);
            btnThoat.Margin = new Padding(4, 3, 4, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(97, 37);
            btnThoat.TabIndex = 26;
            btnThoat.TabStop = false;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(205, 107);
            btnLuu.Margin = new Padding(4, 3, 4, 3);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(97, 37);
            btnLuu.TabIndex = 25;
            btnLuu.TabStop = false;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(492, 107);
            btnSua.Margin = new Padding(4, 3, 4, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(97, 37);
            btnSua.TabIndex = 24;
            btnSua.TabStop = false;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(353, 107);
            btnXoa.Margin = new Padding(4, 3, 4, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(97, 37);
            btnXoa.TabIndex = 23;
            btnXoa.TabStop = false;
            btnXoa.Text = "Xóa ";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(59, 107);
            btnThem.Margin = new Padding(4, 3, 4, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(97, 37);
            btnThem.TabIndex = 22;
            btnThem.TabStop = false;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvSinhVien);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 150);
            panel2.Name = "panel2";
            panel2.Size = new Size(923, 283);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvSinhVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Columns.AddRange(new DataGridViewColumn[] { MaSV, HoTen, NgaySinh, GioiTinh, TenLop });
            dgvSinhVien.Dock = DockStyle.Fill;
            dgvSinhVien.Location = new Point(0, 0);
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.RowHeadersVisible = false;
            dgvSinhVien.RowHeadersWidth = 62;
            dgvSinhVien.RowTemplate.Height = 30;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.Size = new Size(923, 283);
            dgvSinhVien.TabIndex = 3;
            dgvSinhVien.TabStop = false;
            dgvSinhVien.CellFormatting += dgvSinhVien_CellFormatting;
            // 
            // MaSV
            // 
            MaSV.DataPropertyName = "MaSV";
            MaSV.HeaderText = "MÃ SINH VIÊN";
            MaSV.MinimumWidth = 8;
            MaSV.Name = "MaSV";
            MaSV.ReadOnly = true;
            MaSV.Width = 250;
            // 
            // HoTen
            // 
            HoTen.DataPropertyName = "HoTen";
            HoTen.HeaderText = "HỌ TÊN";
            HoTen.MinimumWidth = 8;
            HoTen.Name = "HoTen";
            HoTen.ReadOnly = true;
            HoTen.Width = 150;
            // 
            // NgaySinh
            // 
            NgaySinh.DataPropertyName = "NgaySinh";
            NgaySinh.HeaderText = "NGÀY SINH";
            NgaySinh.MinimumWidth = 8;
            NgaySinh.Name = "NgaySinh";
            NgaySinh.ReadOnly = true;
            NgaySinh.Width = 200;
            // 
            // GioiTinh
            // 
            GioiTinh.DataPropertyName = "GioiTinh";
            GioiTinh.HeaderText = "GIỚI TÍNH";
            GioiTinh.MinimumWidth = 8;
            GioiTinh.Name = "GioiTinh";
            GioiTinh.ReadOnly = true;
            GioiTinh.Width = 170;
            // 
            // TenLop
            // 
            TenLop.DataPropertyName = "TenLop";
            TenLop.HeaderText = "TÊN LỚP";
            TenLop.MinimumWidth = 8;
            TenLop.Name = "TenLop";
            TenLop.ReadOnly = true;
            TenLop.Width = 150;
            // 
            // fQuanLySinhVien
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 433);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "fQuanLySinhVien";
            Text = "fQuanLySinhVien";
            Load += fQuanLySinhVien_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label6;
        private Label label3;
        private Label label4;
        private TextBox txtTen;
        private Label label2;
        private TextBox txtMaSV;
        private Label label1;
        private Button btnThoat;
        private Button btnLuu;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private Panel panel3;
        private RadioButton rdoNu;
        private RadioButton rdoNam;
        private DateTimePicker dtaTime;
        private DataGridView dgvSinhVien;
        private DataGridViewTextBoxColumn MaSV;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn NgaySinh;
        private DataGridViewTextBoxColumn GioiTinh;
        private DataGridViewTextBoxColumn TenLop;
        private ComboBox cobLop;
        private Button btnTailai;
    }
}