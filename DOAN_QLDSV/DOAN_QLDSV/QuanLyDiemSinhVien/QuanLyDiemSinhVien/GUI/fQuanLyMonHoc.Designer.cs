namespace QuanLyDiemSinhVien.GUI
{
    partial class fQuanLyMonHoc
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
            panel1 = new Panel();
            txtTenMH = new TextBox();
            btnTailai = new Button();
            nudSotinchi = new NumericUpDown();
            label3 = new Label();
            label2 = new Label();
            txtMamonhoc = new TextBox();
            label1 = new Label();
            btnThoat = new Button();
            btnLuu = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            dgvMonhoc = new DataGridView();
            STT = new DataGridViewTextBoxColumn();
            MaMH = new DataGridViewTextBoxColumn();
            TenMH = new DataGridViewTextBoxColumn();
            SoTC = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSotinchi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMonhoc).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txtTenMH);
            panel1.Controls.Add(btnTailai);
            panel1.Controls.Add(nudSotinchi);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtMamonhoc);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnLuu);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(btnThem);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(5, 3, 5, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1371, 194);
            panel1.TabIndex = 2;
            // 
            // txtTenMH
            // 
            txtTenMH.Anchor = AnchorStyles.None;
            txtTenMH.Location = new Point(520, 35);
            txtTenMH.Margin = new Padding(4, 3, 4, 3);
            txtTenMH.Name = "txtTenMH";
            txtTenMH.Size = new Size(251, 35);
            txtTenMH.TabIndex = 25;
            // 
            // btnTailai
            // 
            btnTailai.Anchor = AnchorStyles.None;
            btnTailai.Location = new Point(609, 134);
            btnTailai.Margin = new Padding(5, 3, 5, 3);
            btnTailai.Name = "btnTailai";
            btnTailai.Size = new Size(190, 40);
            btnTailai.TabIndex = 24;
            btnTailai.TabStop = false;
            btnTailai.Text = "Tải lại";
            btnTailai.UseVisualStyleBackColor = true;
            btnTailai.Click += btnTailai_Click;
            // 
            // nudSotinchi
            // 
            nudSotinchi.Anchor = AnchorStyles.None;
            nudSotinchi.Location = new Point(1082, 33);
            nudSotinchi.Margin = new Padding(4, 3, 4, 3);
            nudSotinchi.Name = "nudSotinchi";
            nudSotinchi.Size = new Size(106, 30);
            nudSotinchi.TabIndex = 23;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(965, 38);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(91, 22);
            label3.TabIndex = 22;
            label3.Text = "Số tín chỉ:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(472, 38);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(117, 22);
            label2.TabIndex = 21;
            label2.Text = "Tên môn học:";
            // 
            // txtMamonhoc
            // 
            txtMamonhoc.Anchor = AnchorStyles.None;
            txtMamonhoc.Location = new Point(235, 33);
            txtMamonhoc.Margin = new Padding(6, 3, 6, 3);
            txtMamonhoc.MaxLength = 255;
            txtMamonhoc.Name = "txtMamonhoc";
            txtMamonhoc.Size = new Size(203, 30);
            txtMamonhoc.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(110, 38);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(113, 22);
            label1.TabIndex = 19;
            label1.Text = "Mã môn học:";
            // 
            // btnThoat
            // 
            btnThoat.Anchor = AnchorStyles.None;
            btnThoat.Location = new Point(823, 133);
            btnThoat.Margin = new Padding(5, 3, 5, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(190, 40);
            btnThoat.TabIndex = 16;
            btnThoat.TabStop = false;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click_1;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.None;
            btnLuu.Location = new Point(386, 133);
            btnLuu.Margin = new Padding(5, 3, 5, 3);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(190, 40);
            btnLuu.TabIndex = 15;
            btnLuu.TabStop = false;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.None;
            btnSua.Location = new Point(823, 86);
            btnSua.Margin = new Padding(5, 3, 5, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(190, 40);
            btnSua.TabIndex = 14;
            btnSua.TabStop = false;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.None;
            btnXoa.Location = new Point(609, 87);
            btnXoa.Margin = new Padding(5, 3, 5, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(190, 40);
            btnXoa.TabIndex = 13;
            btnXoa.TabStop = false;
            btnXoa.Text = "Xóa ";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.None;
            btnThem.Location = new Point(386, 86);
            btnThem.Margin = new Padding(5, 3, 5, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(190, 40);
            btnThem.TabIndex = 12;
            btnThem.TabStop = false;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dgvMonhoc
            // 
            dgvMonhoc.AllowUserToAddRows = false;
            dgvMonhoc.AllowUserToDeleteRows = false;
            dgvMonhoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonhoc.BackgroundColor = Color.FromArgb(255, 255, 192);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMonhoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMonhoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonhoc.Columns.AddRange(new DataGridViewColumn[] { STT, MaMH, TenMH, SoTC });
            dgvMonhoc.Dock = DockStyle.Fill;
            dgvMonhoc.GridColor = SystemColors.Desktop;
            dgvMonhoc.Location = new Point(0, 194);
            dgvMonhoc.Margin = new Padding(5, 3, 5, 3);
            dgvMonhoc.MultiSelect = false;
            dgvMonhoc.Name = "dgvMonhoc";
            dgvMonhoc.ReadOnly = true;
            dgvMonhoc.RowHeadersVisible = false;
            dgvMonhoc.RowHeadersWidth = 62;
            dgvMonhoc.RowTemplate.Height = 30;
            dgvMonhoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMonhoc.Size = new Size(1371, 292);
            dgvMonhoc.TabIndex = 2;
            dgvMonhoc.TabStop = false;
            // 
            // STT
            // 
            STT.DataPropertyName = "STT";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 255, 192);
            STT.DefaultCellStyle = dataGridViewCellStyle2;
            STT.HeaderText = "SỐ TT";
            STT.MinimumWidth = 8;
            STT.Name = "STT";
            STT.ReadOnly = true;
            // 
            // MaMH
            // 
            MaMH.DataPropertyName = "MaMH";
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 255, 192);
            MaMH.DefaultCellStyle = dataGridViewCellStyle3;
            MaMH.HeaderText = "MÃ MÔN HỌC";
            MaMH.MinimumWidth = 8;
            MaMH.Name = "MaMH";
            MaMH.ReadOnly = true;
            // 
            // TenMH
            // 
            TenMH.DataPropertyName = "TenMH";
            dataGridViewCellStyle4.BackColor = Color.FromArgb(255, 255, 192);
            TenMH.DefaultCellStyle = dataGridViewCellStyle4;
            TenMH.HeaderText = "TÊN MÔN";
            TenMH.MinimumWidth = 8;
            TenMH.Name = "TenMH";
            TenMH.ReadOnly = true;
            // 
            // SoTC
            // 
            SoTC.DataPropertyName = "SoTC";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(255, 255, 192);
            SoTC.DefaultCellStyle = dataGridViewCellStyle5;
            SoTC.HeaderText = "SỐ TÍN CHỈ";
            SoTC.MinimumWidth = 8;
            SoTC.Name = "SoTC";
            SoTC.ReadOnly = true;
            // 
            // fQuanLyMonHoc
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(1371, 486);
            Controls.Add(dgvMonhoc);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "fQuanLyMonHoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "fQuanLyMonHoc";
            Load += fQuanLyMonHoc_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSotinchi).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMonhoc).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private TextBox txtMamonhoc;
        private Label label1;
        private Button btnThoat;
        private Button btnLuu;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private Label label3;
        private NumericUpDown nudSotinchi;
        private Button btnTailai;
        private TextBox txtTenMH;
        private DataGridView dgvMonhoc;
        private DataGridViewTextBoxColumn STT;
        private DataGridViewTextBoxColumn MaMH;
        private DataGridViewTextBoxColumn TenMH;
        private DataGridViewTextBoxColumn SoTC;
    }
}