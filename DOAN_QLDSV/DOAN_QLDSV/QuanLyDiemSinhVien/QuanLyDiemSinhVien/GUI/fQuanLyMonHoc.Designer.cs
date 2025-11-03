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
            panel2 = new Panel();
            dgvMonhoc = new DataGridView();
            STT = new DataGridViewTextBoxColumn();
            MaMH = new DataGridViewTextBoxColumn();
            TenMH = new DataGridViewTextBoxColumn();
            SoTC = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSotinchi).BeginInit();
            panel2.SuspendLayout();
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
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(833, 180);
            panel1.TabIndex = 2;
            // 
            // txtTenMH
            // 
            txtTenMH.Location = new Point(421, 31);
            txtTenMH.Name = "txtTenMH";
            txtTenMH.Size = new Size(150, 31);
            txtTenMH.TabIndex = 25;
            // 
            // btnTailai
            // 
            btnTailai.Location = new Point(319, 124);
            btnTailai.Margin = new Padding(4, 3, 4, 3);
            btnTailai.Name = "btnTailai";
            btnTailai.Size = new Size(146, 37);
            btnTailai.TabIndex = 24;
            btnTailai.TabStop = false;
            btnTailai.Text = "Tải lại";
            btnTailai.UseVisualStyleBackColor = true;
            btnTailai.Click += btnTailai_Click;
            // 
            // nudSotinchi
            // 
            nudSotinchi.Location = new Point(714, 32);
            nudSotinchi.Name = "nudSotinchi";
            nudSotinchi.Size = new Size(66, 31);
            nudSotinchi.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(618, 35);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(89, 25);
            label3.TabIndex = 22;
            label3.Text = "Số tín chỉ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(282, 35);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(118, 25);
            label2.TabIndex = 21;
            label2.Text = "Tên môn học:";
            // 
            // txtMamonhoc
            // 
            txtMamonhoc.Location = new Point(132, 35);
            txtMamonhoc.Margin = new Padding(5, 3, 5, 3);
            txtMamonhoc.MaxLength = 255;
            txtMamonhoc.Name = "txtMamonhoc";
            txtMamonhoc.Size = new Size(141, 31);
            txtMamonhoc.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 35);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(117, 25);
            label1.TabIndex = 19;
            label1.Text = "Mã môn học:";
            label1.Click += label1_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(484, 123);
            btnThoat.Margin = new Padding(4, 3, 4, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(146, 37);
            btnThoat.TabIndex = 16;
            btnThoat.TabStop = false;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click_1;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(148, 123);
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
            btnSua.Location = new Point(484, 80);
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
            btnXoa.Location = new Point(319, 81);
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
            btnThem.Location = new Point(148, 80);
            btnThem.Margin = new Padding(4, 3, 4, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(146, 37);
            btnThem.TabIndex = 12;
            btnThem.TabStop = false;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvMonhoc);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 180);
            panel2.Name = "panel2";
            panel2.Size = new Size(833, 270);
            panel2.TabIndex = 3;
            // 
            // dgvMonhoc
            // 
            dgvMonhoc.AllowUserToAddRows = false;
            dgvMonhoc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMonhoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMonhoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonhoc.Columns.AddRange(new DataGridViewColumn[] { STT, MaMH, TenMH, SoTC });
            dgvMonhoc.Dock = DockStyle.Fill;
            dgvMonhoc.Location = new Point(0, 0);
            dgvMonhoc.Margin = new Padding(4, 3, 4, 3);
            dgvMonhoc.MultiSelect = false;
            dgvMonhoc.Name = "dgvMonhoc";
            dgvMonhoc.ReadOnly = true;
            dgvMonhoc.RowHeadersVisible = false;
            dgvMonhoc.RowHeadersWidth = 62;
            dgvMonhoc.RowTemplate.Height = 30;
            dgvMonhoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMonhoc.Size = new Size(833, 270);
            dgvMonhoc.TabIndex = 2;
            dgvMonhoc.TabStop = false;
            // 
            // STT
            // 
            STT.DataPropertyName = "STT";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            STT.DefaultCellStyle = dataGridViewCellStyle2;
            STT.HeaderText = "SỐ TT";
            STT.MinimumWidth = 8;
            STT.Name = "STT";
            STT.ReadOnly = true;
            STT.Width = 150;
            // 
            // MaMH
            // 
            MaMH.DataPropertyName = "MaMH";
            MaMH.HeaderText = "MÃ MÔN HỌC";
            MaMH.MinimumWidth = 8;
            MaMH.Name = "MaMH";
            MaMH.ReadOnly = true;
            MaMH.Width = 250;
            // 
            // TenMH
            // 
            TenMH.DataPropertyName = "TenMH";
            TenMH.HeaderText = "TÊN MÔN";
            TenMH.MinimumWidth = 8;
            TenMH.Name = "TenMH";
            TenMH.ReadOnly = true;
            TenMH.Width = 180;
            // 
            // SoTC
            // 
            SoTC.DataPropertyName = "SoTC";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SoTC.DefaultCellStyle = dataGridViewCellStyle3;
            SoTC.HeaderText = "SỐ TÍN CHỈ";
            SoTC.MinimumWidth = 8;
            SoTC.Name = "SoTC";
            SoTC.ReadOnly = true;
            SoTC.Width = 250;
            // 
            // fQuanLyMonHoc
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(833, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "fQuanLyMonHoc";
            Text = "fQuanLyMonHoc";
            Load += fQuanLyMonHoc_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSotinchi).EndInit();
            panel2.ResumeLayout(false);
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
        private Panel panel2;
        private DataGridView dgvMonhoc;
        private NumericUpDown nudSotinchi;
        private Button btnTailai;
        private DataGridViewTextBoxColumn STT;
        private DataGridViewTextBoxColumn MaMH;
        private DataGridViewTextBoxColumn TenMH;
        private DataGridViewTextBoxColumn SoTC;
        private TextBox txtTenMH;
    }
}