namespace QuanLyDiemSinhVien.GUI
{
    partial class fDoiMatKhau
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
            txtMatKhauMoi = new TextBox();
            label2 = new Label();
            txtMatKhauCu = new TextBox();
            label1 = new Label();
            btnCapNhat = new Button();
            btn = new Button();
            label3 = new Label();
            label4 = new Label();
            txtNhapLaiMatKhau = new TextBox();
            SuspendLayout();
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(25, 200);
            txtMatKhauMoi.Margin = new Padding(4);
            txtMatKhauMoi.MaxLength = 225;
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.Size = new Size(357, 35);
            txtMatKhauMoi.TabIndex = 1;
            txtMatKhauMoi.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 169);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(156, 27);
            label2.TabIndex = 8;
            label2.Text = "Mật khẩu Mới:";
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Location = new Point(25, 108);
            txtMatKhauCu.Margin = new Padding(4);
            txtMatKhauCu.MaxLength = 225;
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.Size = new Size(357, 35);
            txtMatKhauCu.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 77);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(149, 27);
            label1.TabIndex = 6;
            label1.Text = "Mật Khẩu Cũ:";
            // 
            // btnCapNhat
            // 
            btnCapNhat.Location = new Point(32, 346);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(156, 45);
            btnCapNhat.TabIndex = 10;
            btnCapNhat.Text = "Cập Nhật";
            btnCapNhat.UseVisualStyleBackColor = true;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // btn
            // 
            btn.Location = new Point(226, 346);
            btn.Name = "btn";
            btn.Size = new Size(156, 45);
            btn.TabIndex = 11;
            btn.Text = "Thoát";
            btn.UseVisualStyleBackColor = true;
            btn.Click += btn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(87, 20);
            label3.Name = "label3";
            label3.Size = new Size(261, 36);
            label3.TabIndex = 12;
            label3.Text = "ĐỔI MẬT KHẨU";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 257);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(240, 27);
            label4.TabIndex = 13;
            label4.Text = "Nhập lại mật khẩu Mới:";
            // 
            // txtNhapLaiMatKhau
            // 
            txtNhapLaiMatKhau.Location = new Point(25, 288);
            txtNhapLaiMatKhau.Margin = new Padding(4);
            txtNhapLaiMatKhau.MaxLength = 225;
            txtNhapLaiMatKhau.Name = "txtNhapLaiMatKhau";
            txtNhapLaiMatKhau.Size = new Size(357, 35);
            txtNhapLaiMatKhau.TabIndex = 14;
            txtNhapLaiMatKhau.TabStop = false;
            // 
            // fDoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 413);
            Controls.Add(txtNhapLaiMatKhau);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btn);
            Controls.Add(btnCapNhat);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(label2);
            Controls.Add(txtMatKhauCu);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "fDoiMatKhau";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đổi Mật Khẩu";
            Load += fDoiMatKhau_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMatKhauMoi;
        private Label label2;
        private TextBox txtMatKhauCu;
        private Label label1;
        private Button btnCapNhat;
        private Button btn;
        private Label label3;
        private Label label4;
        private TextBox txtNhapLaiMatKhau;
    }
}