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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            label1 = new Label();
            label2 = new Label();
            txtTen = new TextBox();
            txtPass = new TextBox();
            btnLogin = new Button();
            label3 = new Label();
            btnThoat = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            panelLoading = new Panel();
            pictureBox4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panelLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.MediumSeaGreen;
            label1.ImageAlign = ContentAlignment.TopCenter;
            label1.Location = new Point(421, 133);
            label1.Name = "label1";
            label1.Size = new Size(160, 27);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập:";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.MediumSeaGreen;
            label2.Location = new Point(421, 225);
            label2.Name = "label2";
            label2.Size = new Size(110, 27);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu:";
            // 
            // txtTen
            // 
            txtTen.BorderStyle = BorderStyle.None;
            txtTen.Location = new Point(577, 126);
            txtTen.MaxLength = 255;
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(274, 28);
            txtTen.TabIndex = 0;
            // 
            // txtPass
            // 
            txtPass.BorderStyle = BorderStyle.None;
            txtPass.Location = new Point(577, 216);
            txtPass.MaxLength = 255;
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(274, 28);
            txtPass.TabIndex = 1;
            txtPass.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Bottom;
            btnLogin.BackColor = Color.Green;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.Transparent;
            btnLogin.Image = (Image)resources.GetObject("btnLogin.Image");
            btnLogin.ImageAlign = ContentAlignment.TopLeft;
            btnLogin.Location = new Point(546, 311);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(175, 43);
            btnLogin.TabIndex = 2;
            btnLogin.TabStop = false;
            btnLogin.Text = "Đăng nhập";
            btnLogin.TextAlign = ContentAlignment.MiddleRight;
            btnLogin.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click_1;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(483, 18);
            label3.Name = "label3";
            label3.Size = new Size(226, 41);
            label3.TabIndex = 5;
            label3.Text = "ĐĂNG NHẬP";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.DarkGreen;
            btnThoat.ForeColor = Color.White;
            btnThoat.Location = new Point(876, -1);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(39, 45);
            btnThoat.TabIndex = 2;
            btnThoat.TabStop = false;
            btnThoat.Text = "X";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 128, 0);
            panel1.Location = new Point(577, 152);
            panel1.Name = "panel1";
            panel1.Size = new Size(274, 2);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Lime;
            panel2.Location = new Point(577, 249);
            panel2.Name = "panel2";
            panel2.Size = new Size(274, 2);
            panel2.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(192, 255, 192);
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(-3, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(337, 423);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(393, 126);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 34);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(393, 217);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(32, 34);
            pictureBox3.TabIndex = 10;
            pictureBox3.TabStop = false;
            // 
            // panelLoading
            // 
            panelLoading.BackColor = Color.Transparent;
            panelLoading.Controls.Add(pictureBox4);
            panelLoading.Dock = DockStyle.Fill;
            panelLoading.Location = new Point(0, 0);
            panelLoading.Name = "panelLoading";
            panelLoading.Size = new Size(912, 413);
            panelLoading.TabIndex = 11;
            panelLoading.Visible = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Dock = DockStyle.Fill;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(0, 0);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(912, 413);
            pictureBox4.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            // 
            // FormLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(912, 413);
            Controls.Add(panelLoading);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnThoat);
            Controls.Add(label3);
            Controls.Add(btnLogin);
            Controls.Add(txtPass);
            Controls.Add(txtTen);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            Load += FormLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panelLoading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
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
        private Panel panel1;
        private Panel panel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Panel panelLoading;
        private PictureBox pictureBox4;
    }
}
