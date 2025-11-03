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
            SuspendLayout();
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(25, 98);
            txtMatKhauMoi.Margin = new Padding(4);
            txtMatKhauMoi.MaxLength = 225;
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.Size = new Size(205, 26);
            txtMatKhauMoi.TabIndex = 1;
            txtMatKhauMoi.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 75);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(99, 19);
            label2.TabIndex = 8;
            label2.Text = "Mật khẩu Mới:";
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Location = new Point(25, 39);
            txtMatKhauCu.Margin = new Padding(4);
            txtMatKhauCu.MaxLength = 225;
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.Size = new Size(205, 26);
            txtMatKhauCu.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 16);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(96, 19);
            label1.TabIndex = 6;
            label1.Text = "Mật Khẩu Cũ:";
            // 
            // btnCapNhat
            // 
            btnCapNhat.Location = new Point(83, 141);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(89, 30);
            btnCapNhat.TabIndex = 10;
            btnCapNhat.Text = "Cập Nhật";
            btnCapNhat.UseVisualStyleBackColor = true;
            // 
            // fDoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 199);
            Controls.Add(btnCapNhat);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(label2);
            Controls.Add(txtMatKhauCu);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "fDoiMatKhau";
            Text = "Đổi Mật Khẩu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMatKhauMoi;
        private Label label2;
        private TextBox txtMatKhauCu;
        private Label label1;
        private Button btnCapNhat;
    }
}