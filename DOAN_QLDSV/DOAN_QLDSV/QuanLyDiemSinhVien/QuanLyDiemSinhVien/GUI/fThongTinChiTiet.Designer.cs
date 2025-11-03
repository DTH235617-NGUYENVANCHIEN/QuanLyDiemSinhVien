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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 21);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(109, 19);
            label1.TabIndex = 0;
            label1.Text = "Tên Đăng Nhập:";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Enabled = false;
            txtTenDangNhap.Location = new Point(13, 44);
            txtTenDangNhap.Margin = new Padding(4, 4, 4, 4);
            txtTenDangNhap.MaxLength = 255;
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(205, 26);
            txtTenDangNhap.TabIndex = 1;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Enabled = false;
            txtMatKhau.Location = new Point(13, 103);
            txtMatKhau.Margin = new Padding(4);
            txtMatKhau.MaxLength = 255;
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(205, 26);
            txtMatKhau.TabIndex = 3;
            txtMatKhau.Text = "********";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 80);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(70, 19);
            label2.TabIndex = 2;
            label2.Text = "Mật khẩu:";
            // 
            // txtQuyen
            // 
            txtQuyen.Enabled = false;
            txtQuyen.Location = new Point(13, 167);
            txtQuyen.Margin = new Padding(4);
            txtQuyen.MaxLength = 255;
            txtQuyen.Name = "txtQuyen";
            txtQuyen.Size = new Size(205, 26);
            txtQuyen.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 144);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(107, 19);
            label3.TabIndex = 4;
            label3.Text = "Loại Tài Khoản:";
            // 
            // fThongTinChiTiet
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(229, 231);
            Controls.Add(txtQuyen);
            Controls.Add(label3);
            Controls.Add(txtMatKhau);
            Controls.Add(label2);
            Controls.Add(txtTenDangNhap);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
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
    }
}