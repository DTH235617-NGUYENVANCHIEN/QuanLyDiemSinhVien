namespace QuanLyDiemSinhVien.GUI
{
    partial class fQuanLyLop
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
            cobGiaovien = new ComboBox();
            btnTailai = new Button();
            cboLoaikhoa = new ComboBox();
            lbl1 = new Label();
            lbl = new Label();
            txtTenlop = new TextBox();
            label2 = new Label();
            txtMalop = new TextBox();
            label1 = new Label();
            btnThoat = new Button();
            btnLuu = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            dgvLop = new DataGridView();
            MaLop = new DataGridViewTextBoxColumn();
            TenLop = new DataGridViewTextBoxColumn();
            TenKhoa = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLop).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(192, 255, 192);
            panel1.Controls.Add(cobGiaovien);
            panel1.Controls.Add(btnTailai);
            panel1.Controls.Add(cboLoaikhoa);
            panel1.Controls.Add(lbl1);
            panel1.Controls.Add(lbl);
            panel1.Controls.Add(txtTenlop);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtMalop);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnLuu);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(btnThem);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(673, 214);
            panel1.TabIndex = 0;
            // 
            // cobGiaovien
            // 
            cobGiaovien.Anchor = AnchorStyles.Top;
            cobGiaovien.FormattingEnabled = true;
            cobGiaovien.Location = new Point(141, 121);
            cobGiaovien.Name = "cobGiaovien";
            cobGiaovien.Size = new Size(202, 35);
            cobGiaovien.TabIndex = 40;
            // 
            // btnTailai
            // 
            btnTailai.Anchor = AnchorStyles.Top;
            btnTailai.Location = new Point(506, 94);
            btnTailai.Margin = new Padding(4, 3, 4, 3);
            btnTailai.Name = "btnTailai";
            btnTailai.Size = new Size(146, 37);
            btnTailai.TabIndex = 39;
            btnTailai.TabStop = false;
            btnTailai.Text = "Tải lại";
            btnTailai.UseVisualStyleBackColor = true;
            btnTailai.Click += btnTailai_Click;
            // 
            // cboLoaikhoa
            // 
            cboLoaikhoa.Anchor = AnchorStyles.Top;
            cboLoaikhoa.FormattingEnabled = true;
            cboLoaikhoa.Location = new Point(141, 70);
            cboLoaikhoa.Name = "cboLoaikhoa";
            cboLoaikhoa.Size = new Size(202, 35);
            cboLoaikhoa.TabIndex = 38;
            cboLoaikhoa.SelectedValueChanged += cboLoaikhoa_SelectedValueChanged;
            // 
            // lbl1
            // 
            lbl1.Anchor = AnchorStyles.Top;
            lbl1.AutoSize = true;
            lbl1.Location = new Point(25, 121);
            lbl1.Margin = new Padding(4, 0, 4, 0);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(92, 27);
            lbl1.TabIndex = 37;
            lbl1.Text = "Tên GV:";
            // 
            // lbl
            // 
            lbl.Anchor = AnchorStyles.Top;
            lbl.AutoSize = true;
            lbl.Location = new Point(9, 70);
            lbl.Margin = new Padding(5, 0, 5, 0);
            lbl.Name = "lbl";
            lbl.Size = new Size(108, 27);
            lbl.TabIndex = 36;
            lbl.Text = "Tên khoa:";
            // 
            // txtTenlop
            // 
            txtTenlop.Anchor = AnchorStyles.Top;
            txtTenlop.Location = new Point(141, 172);
            txtTenlop.Margin = new Padding(4, 3, 4, 3);
            txtTenlop.MaxLength = 255;
            txtTenlop.Name = "txtTenlop";
            txtTenlop.Size = new Size(202, 35);
            txtTenlop.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(25, 172);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(92, 27);
            label2.TabIndex = 33;
            label2.Text = "Tên lớp:";
            // 
            // txtMalop
            // 
            txtMalop.Anchor = AnchorStyles.Top;
            txtMalop.Location = new Point(141, 17);
            txtMalop.Margin = new Padding(5, 3, 5, 3);
            txtMalop.MaxLength = 255;
            txtMalop.Name = "txtMalop";
            txtMalop.Size = new Size(202, 35);
            txtMalop.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(30, 17);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(87, 27);
            label1.TabIndex = 32;
            label1.Text = "Mã lớp:";
            // 
            // btnThoat
            // 
            btnThoat.Anchor = AnchorStyles.Top;
            btnThoat.Location = new Point(506, 172);
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
            btnLuu.Location = new Point(351, 172);
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
            btnSua.Location = new Point(352, 94);
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
            btnXoa.Location = new Point(506, 15);
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
            btnThem.Location = new Point(352, 15);
            btnThem.Margin = new Padding(4, 3, 4, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(146, 37);
            btnThem.TabIndex = 26;
            btnThem.TabStop = false;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dgvLop
            // 
            dgvLop.AllowUserToAddRows = false;
            dgvLop.AllowUserToDeleteRows = false;
            dgvLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvLop.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvLop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLop.Columns.AddRange(new DataGridViewColumn[] { MaLop, TenLop, TenKhoa, HoTen });
            dgvLop.Dock = DockStyle.Fill;
            dgvLop.Location = new Point(0, 214);
            dgvLop.MultiSelect = false;
            dgvLop.Name = "dgvLop";
            dgvLop.ReadOnly = true;
            dgvLop.RowHeadersVisible = false;
            dgvLop.RowHeadersWidth = 62;
            dgvLop.RowTemplate.Height = 30;
            dgvLop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLop.Size = new Size(673, 238);
            dgvLop.TabIndex = 1;
            dgvLop.TabStop = false;
            // 
            // MaLop
            // 
            MaLop.DataPropertyName = "MaLop";
            MaLop.HeaderText = "MÃ LỚP";
            MaLop.MinimumWidth = 8;
            MaLop.Name = "MaLop";
            MaLop.ReadOnly = true;
            // 
            // TenLop
            // 
            TenLop.DataPropertyName = "TenLop";
            TenLop.HeaderText = "TÊN LỚP";
            TenLop.MinimumWidth = 8;
            TenLop.Name = "TenLop";
            TenLop.ReadOnly = true;
            // 
            // TenKhoa
            // 
            TenKhoa.DataPropertyName = "TenKhoa";
            TenKhoa.HeaderText = "TÊN KHOA";
            TenKhoa.MinimumWidth = 8;
            TenKhoa.Name = "TenKhoa";
            TenKhoa.ReadOnly = true;
            // 
            // HoTen
            // 
            HoTen.DataPropertyName = "HoTen";
            HoTen.HeaderText = "GV QUẢN LÍ";
            HoTen.MinimumWidth = 8;
            HoTen.Name = "HoTen";
            HoTen.ReadOnly = true;
            // 
            // fQuanLyLop
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(673, 452);
            Controls.Add(dgvLop);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "fQuanLyLop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Lớp";
            FormClosing += fQuanLyLop_FormClosing;
            Load += fQuanLyLop_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLop).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvLop;
        private TextBox txtTenlop;
        private Label label2;
        private TextBox txtMalop;
        private Label label1;
        private Button btnThoat;
        private Button btnLuu;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private Label lbl1;
        private Label lbl;
        private ComboBox cboLoaikhoa;
        private Button btnTailai;
        private ComboBox cobGiaovien;
        private DataGridViewTextBoxColumn MaLop;
        private DataGridViewTextBoxColumn TenLop;
        private DataGridViewTextBoxColumn TenKhoa;
        private DataGridViewTextBoxColumn HoTen;
    }
}