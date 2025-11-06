namespace QuanLyDiemSinhVien.GUI
{
    partial class fQuanLyKhoa
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
            panel1 = new Panel();
            btnTailai = new Button();
            txtTenkhoa = new TextBox();
            label2 = new Label();
            txtMakhoa = new TextBox();
            label1 = new Label();
            btnThoat = new Button();
            btnLuu = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            dgvKhoa = new DataGridView();
            MaKhoa = new DataGridViewTextBoxColumn();
            TenKhoa = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhoa).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(192, 255, 192);
            panel1.Controls.Add(btnTailai);
            panel1.Controls.Add(txtTenkhoa);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtMakhoa);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnLuu);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(btnThem);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(920, 210);
            panel1.TabIndex = 0;
            // 
            // btnTailai
            // 
            btnTailai.Anchor = AnchorStyles.Top;
            btnTailai.Location = new Point(383, 145);
            btnTailai.Margin = new Padding(4, 3, 4, 3);
            btnTailai.Name = "btnTailai";
            btnTailai.Size = new Size(146, 37);
            btnTailai.TabIndex = 22;
            btnTailai.TabStop = false;
            btnTailai.Text = "Tải lại";
            btnTailai.UseVisualStyleBackColor = true;
            btnTailai.Click += btnTailai_Click;
            // 
            // txtTenkhoa
            // 
            txtTenkhoa.Anchor = AnchorStyles.Top;
            txtTenkhoa.Location = new Point(606, 32);
            txtTenkhoa.Margin = new Padding(4, 3, 4, 3);
            txtTenkhoa.MaxLength = 255;
            txtTenkhoa.Name = "txtTenkhoa";
            txtTenkhoa.Size = new Size(256, 35);
            txtTenkhoa.TabIndex = 20;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(490, 38);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(108, 27);
            label2.TabIndex = 21;
            label2.Text = "Tên khoa:";
            // 
            // txtMakhoa
            // 
            txtMakhoa.Anchor = AnchorStyles.Top;
            txtMakhoa.Location = new Point(198, 35);
            txtMakhoa.Margin = new Padding(5, 3, 5, 3);
            txtMakhoa.MaxLength = 255;
            txtMakhoa.Name = "txtMakhoa";
            txtMakhoa.Size = new Size(235, 35);
            txtMakhoa.TabIndex = 18;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(85, 35);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(103, 27);
            label1.TabIndex = 19;
            label1.Text = "Mã khoa:";
            // 
            // btnThoat
            // 
            btnThoat.Anchor = AnchorStyles.Top;
            btnThoat.Location = new Point(625, 145);
            btnThoat.Margin = new Padding(4, 3, 4, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(146, 37);
            btnThoat.TabIndex = 16;
            btnThoat.TabStop = false;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Top;
            btnLuu.Location = new Point(165, 145);
            btnLuu.Margin = new Padding(4, 3, 4, 3);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(146, 37);
            btnLuu.TabIndex = 15;
            btnLuu.TabStop = false;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Top;
            btnSua.Location = new Point(625, 86);
            btnSua.Margin = new Padding(4, 3, 4, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(146, 37);
            btnSua.TabIndex = 14;
            btnSua.TabStop = false;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Top;
            btnXoa.Location = new Point(383, 86);
            btnXoa.Margin = new Padding(4, 3, 4, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(146, 37);
            btnXoa.TabIndex = 13;
            btnXoa.TabStop = false;
            btnXoa.Text = "Xóa ";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top;
            btnThem.Location = new Point(165, 86);
            btnThem.Margin = new Padding(4, 3, 4, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(146, 37);
            btnThem.TabIndex = 12;
            btnThem.TabStop = false;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dgvKhoa
            // 
            dgvKhoa.AllowUserToAddRows = false;
            dgvKhoa.AllowUserToDeleteRows = false;
            dgvKhoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhoa.BackgroundColor = Color.FromArgb(255, 255, 192);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvKhoa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvKhoa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhoa.Columns.AddRange(new DataGridViewColumn[] { MaKhoa, TenKhoa });
            dgvKhoa.Dock = DockStyle.Fill;
            dgvKhoa.Location = new Point(0, 210);
            dgvKhoa.Margin = new Padding(4, 3, 4, 3);
            dgvKhoa.MultiSelect = false;
            dgvKhoa.Name = "dgvKhoa";
            dgvKhoa.ReadOnly = true;
            dgvKhoa.RowHeadersVisible = false;
            dgvKhoa.RowHeadersWidth = 62;
            dgvKhoa.RowTemplate.Height = 30;
            dgvKhoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhoa.Size = new Size(920, 276);
            dgvKhoa.TabIndex = 1;
            dgvKhoa.TabStop = false;
            // 
            // MaKhoa
            // 
            MaKhoa.DataPropertyName = "MaKhoa";
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 255, 192);
            MaKhoa.DefaultCellStyle = dataGridViewCellStyle2;
            MaKhoa.HeaderText = "MÃ KHOA";
            MaKhoa.MinimumWidth = 8;
            MaKhoa.Name = "MaKhoa";
            MaKhoa.ReadOnly = true;
            // 
            // TenKhoa
            // 
            TenKhoa.DataPropertyName = "TenKhoa";
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 255, 192);
            TenKhoa.DefaultCellStyle = dataGridViewCellStyle3;
            TenKhoa.HeaderText = "TÊN KHOA";
            TenKhoa.MinimumWidth = 8;
            TenKhoa.Name = "TenKhoa";
            TenKhoa.ReadOnly = true;
            // 
            // fQuanLyKhoa
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 486);
            Controls.Add(dgvKhoa);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "fQuanLyKhoa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Khoa";
            Load += fQuanLyKhoa_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhoa).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvKhoa;
        private Button btnThoat;
        private Button btnLuu;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private TextBox txtTenkhoa;
        private Label label2;
        private TextBox txtMakhoa;
        private Label label1;
        private Button btnTailai;
        private DataGridViewTextBoxColumn MaKhoa;
        private DataGridViewTextBoxColumn TenKhoa;
    }
}