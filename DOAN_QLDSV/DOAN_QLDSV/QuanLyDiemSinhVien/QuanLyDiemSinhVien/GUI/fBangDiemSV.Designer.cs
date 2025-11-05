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
            ((System.ComponentModel.ISupportInitialize)dgvDiem).BeginInit();
            SuspendLayout();
            // 
            // cbHocKy
            // 
            cbHocKy.Enabled = false;
            cbHocKy.FormattingEnabled = true;
            cbHocKy.Location = new Point(930, 60);
            cbHocKy.Margin = new Padding(4);
            cbHocKy.Name = "cbHocKy";
            cbHocKy.Size = new Size(233, 30);
            cbHocKy.TabIndex = 3;
            cbHocKy.SelectedIndexChanged += cbHocKy_SelectedIndexChanged_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(468, 63);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(86, 22);
            label4.TabIndex = 43;
            label4.Text = "Năm học:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(850, 63);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(72, 22);
            label3.TabIndex = 42;
            label3.Text = "Học kỳ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 63);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(85, 22);
            label2.TabIndex = 41;
            label2.Text = "Môn học:";
            // 
            // dgvDiem
            // 
            dgvDiem.AllowUserToAddRows = false;
            dgvDiem.AllowUserToDeleteRows = false;
            dgvDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            dgvDiem.Dock = DockStyle.Bottom;
            dgvDiem.Location = new Point(0, 147);
            dgvDiem.Margin = new Padding(4);
            dgvDiem.MultiSelect = false;
            dgvDiem.Name = "dgvDiem";
            dgvDiem.ReadOnly = true;
            dgvDiem.RowHeadersVisible = false;
            dgvDiem.RowHeadersWidth = 62;
            dgvDiem.RowTemplate.Height = 30;
            dgvDiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiem.Size = new Size(1349, 446);
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
            cbNamHoc.FormattingEnabled = true;
            cbNamHoc.Location = new Point(561, 60);
            cbNamHoc.Name = "cbNamHoc";
            cbNamHoc.Size = new Size(223, 30);
            cbNamHoc.TabIndex = 53;
            cbNamHoc.SelectedIndexChanged += cbNamHoc_SelectedIndexChanged_1;
            // 
            // cbMonHoc
            // 
            cbMonHoc.FormattingEnabled = true;
            cbMonHoc.Location = new Point(147, 60);
            cbMonHoc.Name = "cbMonHoc";
            cbMonHoc.Size = new Size(225, 30);
            cbMonHoc.TabIndex = 54;
            cbMonHoc.SelectedIndexChanged += cbMonHoc_SelectedIndexChanged;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(1213, 48);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(124, 53);
            btnLamMoi.TabIndex = 55;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click_1;
            // 
            // fBangDiemSV
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1349, 593);
            Controls.Add(btnLamMoi);
            Controls.Add(cbMonHoc);
            Controls.Add(cbNamHoc);
            Controls.Add(dgvDiem);
            Controls.Add(cbHocKy);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Enabled = false;
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "fBangDiemSV";
            Text = "Bảng Điểm Sinh Viên:";
            Load += fBangDiemSV_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDiem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDiemthi;
        private TextBox txtDiemthanhphan;
        private TextBox txtNamhoc;
        private ComboBox cbHocKy;
        private TextBox txtMonhoc;
        private TextBox txtTenSV;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
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
    }
}