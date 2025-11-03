namespace QuanLyDiemSinhVien
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtTen = new TextBox();
            txtPass = new TextBox();
            btnLogin = new Button();
            label3 = new Label();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 63);
            label1.Name = "label1";
            label1.Size = new Size(160, 27);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 131);
            label2.Name = "label2";
            label2.Size = new Size(110, 27);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu:";
            // 
            // txtTen
            // 
            txtTen.Location = new Point(18, 93);
            txtTen.MaxLength = 255;
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(575, 35);
            txtTen.TabIndex = 0;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(18, 161);
            txtPass.MaxLength = 255;
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(575, 35);
            txtPass.TabIndex = 1;
            txtPass.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Bottom;
            btnLogin.Location = new Point(85, 227);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(151, 43);
            btnLogin.TabIndex = 2;
            btnLogin.TabStop = false;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click_1;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DodgerBlue;
            label3.Location = new Point(197, 9);
            label3.Name = "label3";
            label3.Size = new Size(226, 41);
            label3.TabIndex = 5;
            label3.Text = "ĐĂNG NHẬP";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnThoat
            // 
            btnThoat.Anchor = AnchorStyles.Bottom;
            btnThoat.BackColor = Color.White;
            btnThoat.ForeColor = Color.Black;
            btnThoat.Location = new Point(328, 227);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(151, 43);
            btnThoat.TabIndex = 2;
            btnThoat.TabStop = false;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // FormLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(605, 308);
            Controls.Add(btnThoat);
            Controls.Add(label3);
            Controls.Add(btnLogin);
            Controls.Add(txtPass);
            Controls.Add(txtTen);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtTen;
        private TextBox txtPass;
        private Button btnLogin;
        private Label label3;
        private Button btnThoat;
    }
}
