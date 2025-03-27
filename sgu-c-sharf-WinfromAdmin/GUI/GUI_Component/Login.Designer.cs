namespace sgu_c_sharf_WinfromAdmin.GUI
{
    partial class Login
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
            lblLogin = new Label();
            panel1 = new Panel();
            txtTK = new TextBox();
            lblTK = new Label();
            panel2 = new Panel();
            txtMK = new TextBox();
            label1 = new Label();
            btnLogin = new Button();
            pictureBox1 = new PictureBox();
            chkMK = new CheckBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblLogin
            // 
            lblLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogin.ForeColor = Color.FromArgb(0, 123, 181);
            lblLogin.Location = new Point(177, 88);
            lblLogin.Margin = new Padding(4, 0, 4, 0);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(183, 37);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Đăng Nhập";
            lblLogin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtTK);
            panel1.Controls.Add(lblTK);
            panel1.Location = new Point(14, 207);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(513, 74);
            panel1.TabIndex = 1;
            // 
            // txtTK
            // 
            txtTK.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            txtTK.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTK.Location = new Point(160, 16);
            txtTK.Margin = new Padding(4, 3, 4, 3);
            txtTK.Name = "txtTK";
            txtTK.Size = new Size(353, 38);
            txtTK.TabIndex = 1;
            // 
            // lblTK
            // 
            lblTK.Dock = DockStyle.Left;
            lblTK.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTK.ForeColor = SystemColors.MenuHighlight;
            lblTK.Location = new Point(0, 0);
            lblTK.Margin = new Padding(4, 0, 4, 0);
            lblTK.Name = "lblTK";
            lblTK.Size = new Size(184, 74);
            lblTK.TabIndex = 0;
            lblTK.Text = "Tài khoản:";
            lblTK.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtMK);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(21, 287);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(513, 74);
            panel2.TabIndex = 2;
            // 
            // txtMK
            // 
            txtMK.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMK.Location = new Point(160, 15);
            txtMK.Margin = new Padding(4, 3, 4, 3);
            txtMK.Name = "txtMK";
            txtMK.Size = new Size(353, 40);
            txtMK.TabIndex = 1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(162, 74);
            label1.TabIndex = 0;
            label1.Text = "Mật khẩu:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 123, 181);
            btnLogin.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(218, 447);
            btnLogin.Margin = new Padding(4, 3, 4, 3);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(140, 46);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = Properties.Resources.login;
            pictureBox1.Location = new Point(565, 0);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(583, 647);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // chkMK
            // 
            chkMK.AutoSize = true;
            chkMK.Location = new Point(541, 316);
            chkMK.Margin = new Padding(4, 3, 4, 3);
            chkMK.Name = "chkMK";
            chkMK.Size = new Size(15, 14);
            chkMK.TabIndex = 5;
            chkMK.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1148, 647);
            Controls.Add(chkMK);
            Controls.Add(pictureBox1);
            Controls.Add(btnLogin);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Label lblTK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkMK;
    }
}