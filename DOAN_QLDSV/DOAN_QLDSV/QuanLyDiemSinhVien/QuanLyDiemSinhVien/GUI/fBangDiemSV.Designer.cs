namespace QuanLyDiemSinhVien.GUI
{
    partial class fBangDiemSV
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
            txtDiemthi = new TextBox();
            txtDiemthanhphan = new TextBox();
            txtNamhoc = new TextBox();
            comboBox1 = new ComboBox();
            txtMonhoc = new TextBox();
            txtTenSV = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            HoTen = new DataGridViewTextBoxColumn();
            TenMH = new DataGridViewTextBoxColumn();
            HocKy = new DataGridViewTextBoxColumn();
            NamHoc = new DataGridViewTextBoxColumn();
            DiemThanhPhan = new DataGridViewTextBoxColumn();
            DiemThi = new DataGridViewTextBoxColumn();
            DiemTongKet = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtDiemthi
            // 
            txtDiemthi.Enabled = false;
            txtDiemthi.Location = new Point(1004, 89);
            txtDiemthi.Margin = new Padding(4);
            txtDiemthi.Name = "txtDiemthi";
            txtDiemthi.Size = new Size(233, 35);
            txtDiemthi.TabIndex = 6;
            // 
            // txtDiemthanhphan
            // 
            txtDiemthanhphan.Enabled = false;
            txtDiemthanhphan.Location = new Point(642, 84);
            txtDiemthanhphan.Margin = new Padding(4);
            txtDiemthanhphan.Name = "txtDiemthanhphan";
            txtDiemthanhphan.Size = new Size(192, 35);
            txtDiemthanhphan.TabIndex = 5;
            txtDiemthanhphan.TextChanged += txtDiemthanhphan_TextChanged;
            // 
            // txtNamhoc
            // 
            txtNamhoc.Enabled = false;
            txtNamhoc.Location = new Point(224, 92);
            txtNamhoc.Margin = new Padding(4);
            txtNamhoc.Name = "txtNamhoc";
            txtNamhoc.Size = new Size(192, 35);
            txtNamhoc.TabIndex = 4;
            // 
            // comboBox1
            // 
            comboBox1.Enabled = false;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1004, 16);
            comboBox1.Margin = new Padding(4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(233, 35);
            comboBox1.TabIndex = 3;
            // 
            // txtMonhoc
            // 
            txtMonhoc.Enabled = false;
            txtMonhoc.Location = new Point(590, 20);
            txtMonhoc.Margin = new Padding(4);
            txtMonhoc.Name = "txtMonhoc";
            txtMonhoc.Size = new Size(244, 35);
            txtMonhoc.TabIndex = 2;
            // 
            // txtTenSV
            // 
            txtTenSV.Enabled = false;
            txtTenSV.Location = new Point(224, 24);
            txtTenSV.Margin = new Padding(4);
            txtTenSV.Name = "txtTenSV";
            txtTenSV.Size = new Size(192, 35);
            txtTenSV.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(868, 92);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(101, 27);
            label6.TabIndex = 45;
            label6.Text = "Điểm thi:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(451, 92);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(183, 27);
            label5.TabIndex = 44;
            label5.Text = "Điểm thành phần:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 92);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(105, 27);
            label4.TabIndex = 43;
            label4.Text = "Năm học:";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(881, 24);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(88, 27);
            label3.TabIndex = 42;
            label3.Text = "Học kỳ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(449, 24);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(104, 27);
            label2.TabIndex = 41;
            label2.Text = "Môn học:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 25);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(147, 27);
            label1.TabIndex = 40;
            label1.Text = "Tên sinh viên:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { HoTen, TenMH, HocKy, NamHoc, DiemThanhPhan, DiemThi, DiemTongKet });
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 159);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1254, 434);
            dataGridView1.TabIndex = 52;
            dataGridView1.TabStop = false;
            // 
            // HoTen
            // 
            HoTen.FillWeight = 36.36364F;
            HoTen.HeaderText = "TÊN SINH VIÊN";
            HoTen.MinimumWidth = 8;
            HoTen.Name = "HoTen";
            HoTen.ReadOnly = true;
            HoTen.Width = 150;
            // 
            // TenMH
            // 
            TenMH.FillWeight = 36.36364F;
            TenMH.HeaderText = "MÔN HỌC";
            TenMH.MinimumWidth = 8;
            TenMH.Name = "TenMH";
            TenMH.ReadOnly = true;
            TenMH.Width = 210;
            // 
            // HocKy
            // 
            HocKy.FillWeight = 36.36364F;
            HocKy.HeaderText = "HỌC KỲ";
            HocKy.MinimumWidth = 8;
            HocKy.Name = "HocKy";
            HocKy.ReadOnly = true;
            HocKy.Width = 150;
            // 
            // NamHoc
            // 
            NamHoc.FillWeight = 36.36364F;
            NamHoc.HeaderText = "NĂM HỌC";
            NamHoc.MinimumWidth = 8;
            NamHoc.Name = "NamHoc";
            NamHoc.ReadOnly = true;
            NamHoc.Width = 150;
            // 
            // DiemThanhPhan
            // 
            DiemThanhPhan.FillWeight = 36.36364F;
            DiemThanhPhan.HeaderText = "ĐIỂM THÀNH PHẦN";
            DiemThanhPhan.MinimumWidth = 8;
            DiemThanhPhan.Name = "DiemThanhPhan";
            DiemThanhPhan.ReadOnly = true;
            DiemThanhPhan.Width = 230;
            // 
            // DiemThi
            // 
            DiemThi.FillWeight = 36.36364F;
            DiemThi.HeaderText = "ĐIỂM THI";
            DiemThi.MinimumWidth = 8;
            DiemThi.Name = "DiemThi";
            DiemThi.ReadOnly = true;
            DiemThi.Width = 150;
            // 
            // DiemTongKet
            // 
            DiemTongKet.FillWeight = 36.36364F;
            DiemTongKet.HeaderText = "ĐIỂM TỔNG KẾT";
            DiemTongKet.MinimumWidth = 8;
            DiemTongKet.Name = "DiemTongKet";
            DiemTongKet.ReadOnly = true;
            DiemTongKet.Width = 210;
            // 
            // fBangDiemSV
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1254, 593);
            Controls.Add(dataGridView1);
            Controls.Add(txtDiemthi);
            Controls.Add(txtDiemthanhphan);
            Controls.Add(txtNamhoc);
            Controls.Add(comboBox1);
            Controls.Add(txtMonhoc);
            Controls.Add(txtTenSV);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Enabled = false;
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "fBangDiemSV";
            Text = "Bảng Điểm Sinh Viên:";
            Load += fBangDiemSV_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDiemthi;
        private TextBox txtDiemthanhphan;
        private TextBox txtNamhoc;
        private ComboBox comboBox1;
        private TextBox txtMonhoc;
        private TextBox txtTenSV;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn TenMH;
        private DataGridViewTextBoxColumn HocKy;
        private DataGridViewTextBoxColumn NamHoc;
        private DataGridViewTextBoxColumn DiemThanhPhan;
        private DataGridViewTextBoxColumn DiemThi;
        private DataGridViewTextBoxColumn DiemTongKet;
    }
}