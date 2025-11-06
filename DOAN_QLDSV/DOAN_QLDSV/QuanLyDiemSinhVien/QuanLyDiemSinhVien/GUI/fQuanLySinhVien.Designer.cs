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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
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
            dgvSinhVien = new DataGridView();
            MaSV = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            NgaySinh = new DataGridViewTextBoxColumn();
            GioiTinh = new DataGridViewTextBoxColumn();
            TenLop = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(192, 255, 192);
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
            panel1.Size = new Size(1271, 150);
            panel1.TabIndex = 0;
            // 
            // btnTailai
            // 
            btnTailai.Anchor = AnchorStyles.Top;
            btnTailai.Location = new Point(805, 107);
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
            cobLop.Anchor = AnchorStyles.Top;
            cobLop.FormattingEnabled = true;
            cobLop.Location = new Point(605, 65);
            cobLop.Name = "cobLop";
            cobLop.Size = new Size(378, 35);
            cobLop.TabIndex = 42;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top;
            panel3.Controls.Add(rdoNu);
            panel3.Controls.Add(rdoNam);
            panel3.Location = new Point(342, 65);
            panel3.Name = "panel3";
            panel3.Size = new Size(163, 35);
            panel3.TabIndex = 41;
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(80, 3);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(56, 26);
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
            rdoNam.Size = new Size(68, 26);
            rdoNam.TabIndex = 42;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            // 
            // dtaTime
            // 
            dtaTime.Anchor = AnchorStyles.Top;
            dtaTime.CustomFormat = "dd/MM/yyyy";
            dtaTime.Format = DateTimePickerFormat.Short;
            dtaTime.Location = new Point(927, 16);
            dtaTime.Name = "dtaTime";
            dtaTime.Size = new Size(163, 30);
            dtaTime.TabIndex = 40;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Location = new Point(805, 16);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(94, 22);
            label6.TabIndex = 37;
            label6.Text = "Ngày sinh:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(509, 65);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(78, 22);
            label3.TabIndex = 35;
            label3.Text = "Tên lớp:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Location = new Point(205, 65);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(87, 22);
            label4.TabIndex = 33;
            label4.Text = "Giới tính:";
            // 
            // txtTen
            // 
            txtTen.Anchor = AnchorStyles.Top;
            txtTen.Location = new Point(605, 16);
            txtTen.Margin = new Padding(4, 3, 4, 3);
            txtTen.MaxLength = 255;
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(182, 30);
            txtTen.TabIndex = 30;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(514, 16);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(68, 22);
            label2.TabIndex = 31;
            label2.Text = "Họ tên:";
            // 
            // txtMaSV
            // 
            txtMaSV.Anchor = AnchorStyles.Top;
            txtMaSV.Location = new Point(342, 16);
            txtMaSV.Margin = new Padding(5, 3, 5, 3);
            txtMaSV.MaxLength = 255;
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(163, 30);
            txtMaSV.TabIndex = 28;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(205, 16);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(118, 22);
            label1.TabIndex = 29;
            label1.Text = "Mã sinh viên:";
            // 
            // btnThoat
            // 
            btnThoat.Anchor = AnchorStyles.Top;
            btnThoat.Location = new Point(940, 107);
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
            btnLuu.Anchor = AnchorStyles.Top;
            btnLuu.Location = new Point(379, 107);
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
            btnSua.Anchor = AnchorStyles.Top;
            btnSua.Location = new Point(666, 107);
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
            btnXoa.Anchor = AnchorStyles.Top;
            btnXoa.Location = new Point(527, 107);
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
            btnThem.Anchor = AnchorStyles.Top;
            btnThem.Location = new Point(233, 107);
            btnThem.Margin = new Padding(4, 3, 4, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(97, 37);
            btnThem.TabIndex = 22;
            btnThem.TabStop = false;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.BackgroundColor = Color.FromArgb(255, 255, 192);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSinhVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Columns.AddRange(new DataGridViewColumn[] { MaSV, HoTen, NgaySinh, GioiTinh, TenLop });
            dgvSinhVien.Dock = DockStyle.Fill;
            dgvSinhVien.GridColor = Color.Black;
            dgvSinhVien.Location = new Point(0, 150);
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.RowHeadersVisible = false;
            dgvSinhVien.RowHeadersWidth = 62;
            dgvSinhVien.RowTemplate.Height = 30;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.Size = new Size(1271, 283);
            dgvSinhVien.TabIndex = 3;
            dgvSinhVien.TabStop = false;
            dgvSinhVien.CellFormatting += dgvSinhVien_CellFormatting;
            // 
            // MaSV
            // 
            MaSV.DataPropertyName = "MaSV";
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 255, 192);
            MaSV.DefaultCellStyle = dataGridViewCellStyle2;
            MaSV.HeaderText = "MÃ SINH VIÊN";
            MaSV.MinimumWidth = 8;
            MaSV.Name = "MaSV";
            MaSV.ReadOnly = true;
            // 
            // HoTen
            // 
            HoTen.DataPropertyName = "HoTen";
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 255, 192);
            HoTen.DefaultCellStyle = dataGridViewCellStyle3;
            HoTen.HeaderText = "HỌ TÊN";
            HoTen.MinimumWidth = 8;
            HoTen.Name = "HoTen";
            HoTen.ReadOnly = true;
            // 
            // NgaySinh
            // 
            NgaySinh.DataPropertyName = "NgaySinh";
            dataGridViewCellStyle4.BackColor = Color.FromArgb(255, 255, 192);
            NgaySinh.DefaultCellStyle = dataGridViewCellStyle4;
            NgaySinh.HeaderText = "NGÀY SINH";
            NgaySinh.MinimumWidth = 8;
            NgaySinh.Name = "NgaySinh";
            NgaySinh.ReadOnly = true;
            // 
            // GioiTinh
            // 
            GioiTinh.DataPropertyName = "GioiTinh";
            dataGridViewCellStyle5.BackColor = Color.FromArgb(255, 255, 192);
            GioiTinh.DefaultCellStyle = dataGridViewCellStyle5;
            GioiTinh.HeaderText = "GIỚI TÍNH";
            GioiTinh.MinimumWidth = 8;
            GioiTinh.Name = "GioiTinh";
            GioiTinh.ReadOnly = true;
            // 
            // TenLop
            // 
            TenLop.DataPropertyName = "TenLop";
            dataGridViewCellStyle6.BackColor = Color.FromArgb(255, 255, 192);
            TenLop.DefaultCellStyle = dataGridViewCellStyle6;
            TenLop.HeaderText = "TÊN LỚP";
            TenLop.MinimumWidth = 8;
            TenLop.Name = "TenLop";
            TenLop.ReadOnly = true;
            // 
            // fQuanLySinhVien
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 433);
            Controls.Add(dgvSinhVien);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "fQuanLySinhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "fQuanLySinhVien";
            Load += fQuanLySinhVien_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
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
        private ComboBox cobLop;
        private Button btnTailai;
        private DataGridViewTextBoxColumn MaSV;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn NgaySinh;
        private DataGridViewTextBoxColumn GioiTinh;
        private DataGridViewTextBoxColumn TenLop;
    }
}