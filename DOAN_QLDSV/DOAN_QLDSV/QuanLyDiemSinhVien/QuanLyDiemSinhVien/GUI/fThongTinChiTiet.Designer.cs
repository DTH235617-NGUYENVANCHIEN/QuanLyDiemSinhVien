namespace QuanLyDiemSinhVien.GUI
{
    partial class fThongTinChiTiet
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
            label1 = new Label();
            txtTenDangNhap = new TextBox();
            txtMatKhau = new TextBox();
            label2 = new Label();
            txtQuyen = new TextBox();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 96);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(170, 27);
            label1.TabIndex = 0;
            label1.Text = "Tên Đăng Nhập:";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Enabled = false;
            txtTenDangNhap.Location = new Point(191, 96);
            txtTenDangNhap.Margin = new Padding(4);
            txtTenDangNhap.MaxLength = 255;
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(250, 35);
            txtTenDangNhap.TabIndex = 1;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Enabled = false;
            txtMatKhau.Location = new Point(191, 184);
            txtMatKhau.Margin = new Padding(4);
            txtMatKhau.MaxLength = 255;
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(250, 35);
            txtMatKhau.TabIndex = 3;
            txtMatKhau.Text = "********";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 269);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(110, 27);
            label2.TabIndex = 2;
            label2.Text = "Mật khẩu:";
            // 
            // txtQuyen
            // 
            txtQuyen.Enabled = false;
            txtQuyen.Location = new Point(191, 269);
            txtQuyen.Margin = new Padding(4);
            txtQuyen.MaxLength = 255;
            txtQuyen.Name = "txtQuyen";
            txtQuyen.Size = new Size(250, 35);
            txtQuyen.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 184);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(169, 27);
            label3.TabIndex = 4;
            label3.Text = "Loại Tài Khoản:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(78, 24);
            label4.Name = "label4";
            label4.Size = new Size(344, 45);
            label4.TabIndex = 6;
            label4.Text = "Thông Tin Chi Tiết";
            // 
            // button1
            // 
            button1.Location = new Point(157, 327);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 7;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // fThongTinChiTiet
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 373);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(txtQuyen);
            Controls.Add(label3);
            Controls.Add(txtMatKhau);
            Controls.Add(label2);
            Controls.Add(txtTenDangNhap);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "fThongTinChiTiet";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông Tin Chi Tiết";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTenDangNhap;
        private TextBox txtMatKhau;
        private Label label2;
        private TextBox txtQuyen;
        private Label label3;
        private Label label4;
        private Button button1;
    }
}