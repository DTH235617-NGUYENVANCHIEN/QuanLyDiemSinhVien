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
            cbHocKy = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            dgvDiem = new DataGridView();
            colMaMH = new DataGridViewTextBoxColumn();
            colTenMH = new DataGridViewTextBoxColumn();
            colHocKy = new DataGridViewTextBoxColumn();
            colNamHoc = new DataGridViewTextBoxColumn();
            colDiemTP = new DataGridViewTextBoxColumn();
            colDiemThi = new DataGridViewTextBoxColumn();
            colDiemTK = new DataGridViewTextBoxColumn();
            colDiemChu = new DataGridViewTextBoxColumn();
            cbNamHoc = new ComboBox();
            cbMonHoc = new ComboBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btnLamMoi = new Button();
            label1 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            lbTen = new Label();
            lbKhoa = new Label();
            lbLop = new Label();
            lbMSV = new Label();
            lbXL = new Label();
            groupBox1 = new GroupBox();
            label9 = new Label();
            lbTB = new Label();
            panel1 = new Panel();
            btnThoat = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDiem).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cbHocKy
            // 
            cbHocKy.Anchor = AnchorStyles.Top;
            cbHocKy.Enabled = false;
            cbHocKy.FormattingEnabled = true;
            cbHocKy.Location = new Point(951, 447);
            cbHocKy.Margin = new Padding(4);
            cbHocKy.Name = "cbHocKy";
            cbHocKy.Size = new Size(233, 35);
            cbHocKy.TabIndex = 3;
           
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(192, 255, 192);
            label4.Location = new Point(446, 450);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(105, 27);
            label4.TabIndex = 43;
            label4.Text = "Năm học:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(192, 255, 192);
            label3.Location = new Point(828, 450);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(88, 27);
            label3.TabIndex = 42;
            label3.Text = "Học kỳ:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(192, 255, 192);
            label2.Location = new Point(33, 450);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(104, 27);
            label2.TabIndex = 41;
            label2.Text = "Môn học:";
            // 
            // dgvDiem
            // 
            dgvDiem.AllowUserToAddRows = false;
            dgvDiem.AllowUserToDeleteRows = false;
            dgvDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiem.BackgroundColor = Color.FromArgb(255, 255, 192);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDiem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiem.Columns.AddRange(new DataGridViewColumn[] { colMaMH, colTenMH, colHocKy, colNamHoc, colDiemTP, colDiemThi, colDiemTK, colDiemChu });
            dgvDiem.Dock = DockStyle.Fill;
            dgvDiem.Location = new Point(0, 519);
            dgvDiem.Margin = new Padding(4);
            dgvDiem.MultiSelect = false;
            dgvDiem.Name = "dgvDiem";
            dgvDiem.ReadOnly = true;
            dgvDiem.RowHeadersVisible = false;
            dgvDiem.RowHeadersWidth = 62;
            dgvDiem.RowTemplate.Height = 30;
            dgvDiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiem.Size = new Size(1349, 531);
            dgvDiem.TabIndex = 52;
            dgvDiem.TabStop = false;
            dgvDiem.CellContentClick += dgvDiem_CellContentClick;
            // 
            // colMaMH
            // 
            colMaMH.DataPropertyName = "MaMonHoc";
            colMaMH.HeaderText = "MÃ MÔN";
            colMaMH.MinimumWidth = 6;
            colMaMH.Name = "colMaMH";
            colMaMH.ReadOnly = true;
            // 
            // colTenMH
            // 
            colTenMH.DataPropertyName = "TenMonHoc";
            colTenMH.HeaderText = "TÊN MÔN HỌC";
            colTenMH.MinimumWidth = 6;
            colTenMH.Name = "colTenMH";
            colTenMH.ReadOnly = true;
            // 
            // colHocKy
            // 
            colHocKy.DataPropertyName = "HocKy";
            colHocKy.HeaderText = "HỌC KỲ";
            colHocKy.MinimumWidth = 6;
            colHocKy.Name = "colHocKy";
            colHocKy.ReadOnly = true;
            // 
            // colNamHoc
            // 
            colNamHoc.DataPropertyName = "NamHoc";
            colNamHoc.HeaderText = "NĂM HỌC";
            colNamHoc.MinimumWidth = 6;
            colNamHoc.Name = "colNamHoc";
            colNamHoc.ReadOnly = true;
            // 
            // colDiemTP
            // 
            colDiemTP.DataPropertyName = "DiemThanhPhan";
            colDiemTP.HeaderText = "ĐIỂM TP";
            colDiemTP.MinimumWidth = 6;
            colDiemTP.Name = "colDiemTP";
            colDiemTP.ReadOnly = true;
            // 
            // colDiemThi
            // 
            colDiemThi.DataPropertyName = "DiemThi";
            colDiemThi.HeaderText = "ĐIỂM THI";
            colDiemThi.MinimumWidth = 6;
            colDiemThi.Name = "colDiemThi";
            colDiemThi.ReadOnly = true;
            // 
            // colDiemTK
            // 
            colDiemTK.DataPropertyName = "DiemTongKet";
            colDiemTK.HeaderText = "TỔNG KẾT";
            colDiemTK.MinimumWidth = 6;
            colDiemTK.Name = "colDiemTK";
            colDiemTK.ReadOnly = true;
            // 
            // colDiemChu
            // 
            colDiemChu.DataPropertyName = "DiemChu";
            colDiemChu.HeaderText = "ĐIỂM CHỮ";
            colDiemChu.MinimumWidth = 6;
            colDiemChu.Name = "colDiemChu";
            colDiemChu.ReadOnly = true;
            // 
            // cbNamHoc
            // 
            cbNamHoc.Anchor = AnchorStyles.Top;
            cbNamHoc.FormattingEnabled = true;
            cbNamHoc.Location = new Point(558, 447);
            cbNamHoc.Name = "cbNamHoc";
            cbNamHoc.Size = new Size(223, 35);
            cbNamHoc.TabIndex = 53;
           
            // 
            // cbMonHoc
            // 
            cbMonHoc.Anchor = AnchorStyles.Top;
            cbMonHoc.FormattingEnabled = true;
            cbMonHoc.Location = new Point(144, 447);
            cbMonHoc.Name = "cbMonHoc";
            cbMonHoc.Size = new Size(225, 35);
            cbMonHoc.TabIndex = 54;
            cbMonHoc.SelectedIndexChanged += cbMonHoc_SelectedIndexChanged;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top;
            btnLamMoi.Location = new Point(1207, 330);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(124, 53);
            btnLamMoi.TabIndex = 55;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 52);
            label1.Name = "label1";
            label1.Size = new Size(112, 27);
            label1.TabIndex = 56;
            label1.Text = "Họ và tên:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(50, 101);
            label5.Name = "label5";
            label5.Size = new Size(142, 27);
            label5.TabIndex = 57;
            label5.Text = "Mã sinh viên:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(52, 149);
            label6.Name = "label6";
            label6.Size = new Size(58, 27);
            label6.TabIndex = 58;
            label6.Text = "Lớp:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(50, 203);
            label7.Name = "label7";
            label7.Size = new Size(70, 27);
            label7.TabIndex = 59;
            label7.Text = "Khoa:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(50, 302);
            label8.Name = "label8";
            label8.Size = new Size(99, 27);
            label8.TabIndex = 60;
            label8.Text = "Xếp loại:";
            // 
            // lbTen
            // 
            lbTen.AutoSize = true;
            lbTen.Location = new Point(170, 52);
            lbTen.Name = "lbTen";
            lbTen.Size = new Size(70, 27);
            lbTen.TabIndex = 61;
            lbTen.Text = "label9";
            // 
            // lbKhoa
            // 
            lbKhoa.AutoSize = true;
            lbKhoa.Location = new Point(114, 203);
            lbKhoa.Name = "lbKhoa";
            lbKhoa.Size = new Size(82, 27);
            lbKhoa.TabIndex = 62;
            lbKhoa.Text = "label10";
            // 
            // lbLop
            // 
            lbLop.AutoSize = true;
            lbLop.Location = new Point(106, 149);
            lbLop.Name = "lbLop";
            lbLop.Size = new Size(81, 27);
            lbLop.TabIndex = 63;
            lbLop.Text = "label11";
            // 
            // lbMSV
            // 
            lbMSV.AutoSize = true;
            lbMSV.Location = new Point(198, 101);
            lbMSV.Name = "lbMSV";
            lbMSV.Size = new Size(82, 27);
            lbMSV.TabIndex = 64;
            lbMSV.Text = "label12";
            // 
            // lbXL
            // 
            lbXL.AutoSize = true;
            lbXL.Location = new Point(155, 302);
            lbXL.Name = "lbXL";
            lbXL.Size = new Size(82, 27);
            lbXL.TabIndex = 65;
            lbXL.Text = "label13";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top;
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(lbMSV);
            groupBox1.Controls.Add(lbLop);
            groupBox1.Controls.Add(lbXL);
            groupBox1.Controls.Add(lbKhoa);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(lbTen);
            groupBox1.Controls.Add(lbTB);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label5);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(515, 28);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(496, 371);
            groupBox1.TabIndex = 66;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin cá nhân:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(50, 254);
            label9.Name = "label9";
            label9.Size = new Size(174, 27);
            label9.TabIndex = 67;
            label9.Text = "Điểm trung bình:";
            // 
            // lbTB
            // 
            lbTB.AutoSize = true;
            lbTB.Location = new Point(230, 254);
            lbTB.Name = "lbTB";
            lbTB.Size = new Size(82, 27);
            lbTB.TabIndex = 68;
            lbTB.Text = "label10";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(192, 255, 192);
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnLamMoi);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1349, 519);
            panel1.TabIndex = 67;
            // 
            // btnThoat
            // 
            btnThoat.Anchor = AnchorStyles.Top;
            btnThoat.Location = new Point(1207, 428);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(124, 53);
            btnThoat.TabIndex = 56;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // fBangDiemSV
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1349, 1050);
            Controls.Add(cbMonHoc);
            Controls.Add(cbNamHoc);
            Controls.Add(dgvDiem);
            Controls.Add(cbHocKy);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "fBangDiemSV";
            Text = "Bảng Điểm Sinh Viên:";
            Load += fBangDiemSV_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDiem).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cbHocKy;
        private TextBox txtMonhoc;
        private TextBox txtTenSV;
        private Label label4;
        private Label label3;
        private Label label2;
        private DataGridView dgvDiem;
        private ComboBox cbNamHoc;
        private ComboBox cbMonHoc;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btnLamMoi;
        private DataGridViewTextBoxColumn colMaMH;
        private DataGridViewTextBoxColumn colTenMH;
        private DataGridViewTextBoxColumn colHocKy;
        private DataGridViewTextBoxColumn colNamHoc;
        private DataGridViewTextBoxColumn colDiemTP;
        private DataGridViewTextBoxColumn colDiemThi;
        private DataGridViewTextBoxColumn colDiemTK;
        private DataGridViewTextBoxColumn colDiemChu;
        private Label label1;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label lbTen;
        private Label lbKhoa;
        private Label lbLop;
        private Label lbMSV;
        private Label lbXL;
        private GroupBox groupBox1;
        private Label label9;
        private Label lbTB;
        private Panel panel1;
        private Button btnThoat;
    }
}