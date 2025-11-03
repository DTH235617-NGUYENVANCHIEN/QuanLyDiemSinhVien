namespace QuanLyDiemSinhVien.GUI
{
    partial class fQuanLyTaiKhoan
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
            panel1 = new Panel();
            btnTailai = new Button();
            btnThoat = new Button();
            btnLuu = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            cobQuyen = new ComboBox();
            txtPass = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtTen = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            dgvTaikhoan = new DataGridView();
            TenDangNhap = new DataGridViewTextBoxColumn();
            MatKhau = new DataGridViewTextBoxColumn();
            TenQuyen = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaikhoan).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnTailai);
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnLuu);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(btnThem);
            panel1.Controls.Add(cobQuyen);
            panel1.Controls.Add(txtPass);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtTen);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(752, 162);
            panel1.TabIndex = 0;
            // 
            // btnTailai
            // 
            btnTailai.Location = new Point(500, 118);
            btnTailai.Name = "btnTailai";
            btnTailai.Size = new Size(112, 34);
            btnTailai.TabIndex = 11;
            btnTailai.TabStop = false;
            btnTailai.Text = "Tải lại";
            btnTailai.UseVisualStyleBackColor = true;
            btnTailai.Click += btnTailai_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(627, 118);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(112, 34);
            btnThoat.TabIndex = 10;
            btnThoat.TabStop = false;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(369, 118);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(112, 34);
            btnLuu.TabIndex = 9;
            btnLuu.TabStop = false;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(627, 78);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(112, 34);
            btnSua.TabIndex = 8;
            btnSua.TabStop = false;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(500, 78);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(112, 34);
            btnXoa.TabIndex = 7;
            btnXoa.TabStop = false;
            btnXoa.Text = "Xóa ";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(369, 78);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(112, 34);
            btnThem.TabIndex = 6;
            btnThem.TabStop = false;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // cobQuyen
            // 
            cobQuyen.FormattingEnabled = true;
            cobQuyen.Location = new Point(167, 89);
            cobQuyen.Name = "cobQuyen";
            cobQuyen.Size = new Size(182, 35);
            cobQuyen.TabIndex = 2;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(562, 25);
            txtPass.MaxLength = 255;
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(150, 35);
            txtPass.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 97);
            label3.Name = "label3";
            label3.Size = new Size(157, 27);
            label3.TabIndex = 3;
            label3.Text = "Loại tài khoản:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(446, 28);
            label2.Name = "label2";
            label2.Size = new Size(110, 27);
            label2.TabIndex = 2;
            label2.Text = "Mật khẩu:";
            label2.Click += label2_Click;
            // 
            // txtTen
            // 
            txtTen.Location = new Point(167, 28);
            txtTen.Margin = new Padding(4, 3, 4, 3);
            txtTen.MaxLength = 255;
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(182, 35);
            txtTen.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 28);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(160, 27);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập:";
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvTaikhoan);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 162);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(752, 324);
            panel2.TabIndex = 1;
            // 
            // dgvTaikhoan
            // 
            dgvTaikhoan.AllowUserToAddRows = false;
            dgvTaikhoan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTaikhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTaikhoan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTaikhoan.Columns.AddRange(new DataGridViewColumn[] { TenDangNhap, MatKhau, TenQuyen });
            dgvTaikhoan.Dock = DockStyle.Fill;
            dgvTaikhoan.Location = new Point(0, 0);
            dgvTaikhoan.Margin = new Padding(4, 3, 4, 3);
            dgvTaikhoan.MultiSelect = false;
            dgvTaikhoan.Name = "dgvTaikhoan";
            dgvTaikhoan.ReadOnly = true;
            dgvTaikhoan.RowHeadersVisible = false;
            dgvTaikhoan.RowHeadersWidth = 62;
            dgvTaikhoan.RowTemplate.Height = 30;
            dgvTaikhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaikhoan.Size = new Size(752, 324);
            dgvTaikhoan.TabIndex = 1;
            dgvTaikhoan.TabStop = false;
            // 
            // TenDangNhap
            // 
            TenDangNhap.DataPropertyName = "TenDangNhap";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TenDangNhap.DefaultCellStyle = dataGridViewCellStyle2;
            TenDangNhap.HeaderText = "TÊN ĐĂNG NHẬP";
            TenDangNhap.MinimumWidth = 8;
            TenDangNhap.Name = "TenDangNhap";
            TenDangNhap.ReadOnly = true;
            TenDangNhap.Width = 250;
            // 
            // MatKhau
            // 
            MatKhau.DataPropertyName = "MatKhau";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MatKhau.DefaultCellStyle = dataGridViewCellStyle3;
            MatKhau.HeaderText = "MẬT KHẨU";
            MatKhau.MinimumWidth = 8;
            MatKhau.Name = "MatKhau";
            MatKhau.ReadOnly = true;
            MatKhau.Width = 250;
            // 
            // TenQuyen
            // 
            TenQuyen.DataPropertyName = "TenQuyen";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TenQuyen.DefaultCellStyle = dataGridViewCellStyle4;
            TenQuyen.HeaderText = "LOẠI TÀI KHOẢN";
            TenQuyen.MinimumWidth = 8;
            TenQuyen.Name = "TenQuyen";
            TenQuyen.ReadOnly = true;
            TenQuyen.Width = 250;
            // 
            // fQuanLyTaiKhoan
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 486);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "fQuanLyTaiKhoan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "fQuanLyTaiKhoan";
            Load += fQuanLyTaiKhoan_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTaikhoan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DataGridView dgvTaikhoan;
        private ComboBox cobQuyen;
        private TextBox txtPass;
        private Label label3;
        private Label label2;
        private TextBox txtTen;
        private Label label1;
        private Button btnThoat;
        private Button btnLuu;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private Button btnTailai;
        private DataGridViewTextBoxColumn TenDangNhap;
        private DataGridViewTextBoxColumn MatKhau;
        private DataGridViewTextBoxColumn TenQuyen;
    }
}