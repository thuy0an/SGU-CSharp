namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_Component
{
    partial class MenuTaskBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuTaskBar));
            pnlUser = new Panel();
            lblAdmin = new Label();
            pictureBox1 = new PictureBox();
            pnlQLThietBi = new Panel();
            label1 = new Label();
            pictureBox3 = new PictureBox();
            pnlQLLoaiThietBi = new Panel();
            label2 = new Label();
            pictureBox4 = new PictureBox();
            pnlQLXuPhat = new Panel();
            label4 = new Label();
            pictureBox6 = new PictureBox();
            pnlQLThanhVien = new Panel();
            pictureBox2 = new PictureBox();
            lblThanhvien = new Label();
            panel1 = new Panel();
            pnlQLPhieuMuon = new Panel();
            label6 = new Label();
            pictureBox8 = new PictureBox();
            pnlExit = new Panel();
            label5 = new Label();
            pictureBox7 = new PictureBox();
            pnlThongKe = new Panel();
            label3 = new Label();
            pictureBox5 = new PictureBox();
            pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlQLThietBi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            pnlQLLoaiThietBi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            pnlQLXuPhat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            pnlQLThanhVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            pnlQLPhieuMuon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            pnlExit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            pnlThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // pnlUser
            // 
            pnlUser.BackColor = SystemColors.Window;
            pnlUser.Controls.Add(lblAdmin);
            pnlUser.Controls.Add(pictureBox1);
            pnlUser.Location = new Point(31, 14);
            pnlUser.Margin = new Padding(4, 3, 4, 3);
            pnlUser.Name = "pnlUser";
            pnlUser.Size = new Size(287, 213);
            pnlUser.TabIndex = 0;
            pnlUser.Paint += pnlUser_Paint;
            // 
            // lblAdmin
            // 
            lblAdmin.Dock = DockStyle.Bottom;
            lblAdmin.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAdmin.Location = new Point(0, 158);
            lblAdmin.Margin = new Padding(4, 0, 4, 0);
            lblAdmin.Name = "lblAdmin";
            lblAdmin.Size = new Size(287, 55);
            lblAdmin.TabIndex = 1;
            lblAdmin.Text = "Xin chào Admin";
            lblAdmin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = Properties.Resources.admin;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(287, 155);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pnlQLThietBi
            // 
            pnlQLThietBi.BackColor = SystemColors.Info;
            pnlQLThietBi.Controls.Add(label1);
            pnlQLThietBi.Controls.Add(pictureBox3);
            pnlQLThietBi.Location = new Point(12, 112);
            pnlQLThietBi.Margin = new Padding(4, 3, 4, 3);
            pnlQLThietBi.Name = "pnlQLThietBi";
            pnlQLThietBi.Size = new Size(327, 69);
            pnlQLThietBi.TabIndex = 2;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.Window;
            label1.Cursor = Cursors.Hand;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(70, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(257, 69);
            label1.TabIndex = 1;
            label1.Text = "Quản lý thiết bị";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.Window;
            pictureBox3.Cursor = Cursors.Hand;
            pictureBox3.Dock = DockStyle.Left;
            pictureBox3.Image = Properties.Resources.qlsanpham;
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Margin = new Padding(4, 3, 4, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(70, 69);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // pnlQLLoaiThietBi
            // 
            pnlQLLoaiThietBi.BackColor = SystemColors.Info;
            pnlQLLoaiThietBi.Controls.Add(label2);
            pnlQLLoaiThietBi.Controls.Add(pictureBox4);
            pnlQLLoaiThietBi.Location = new Point(12, 201);
            pnlQLLoaiThietBi.Margin = new Padding(4, 3, 4, 3);
            pnlQLLoaiThietBi.Name = "pnlQLLoaiThietBi";
            pnlQLLoaiThietBi.Size = new Size(327, 69);
            pnlQLLoaiThietBi.TabIndex = 3;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.Window;
            label2.Cursor = Cursors.Hand;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(70, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(257, 69);
            label2.TabIndex = 1;
            label2.Text = "Quản lý loại thiết bị";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = SystemColors.Window;
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox4.Dock = DockStyle.Left;
            pictureBox4.Image = Properties.Resources.qlsanpham;
            pictureBox4.Location = new Point(0, 0);
            pictureBox4.Margin = new Padding(4, 3, 4, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(70, 69);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            // 
            // pnlQLXuPhat
            // 
            pnlQLXuPhat.BackColor = SystemColors.Info;
            pnlQLXuPhat.Controls.Add(label4);
            pnlQLXuPhat.Controls.Add(pictureBox6);
            pnlQLXuPhat.Location = new Point(12, 379);
            pnlQLXuPhat.Margin = new Padding(4, 3, 4, 3);
            pnlQLXuPhat.Name = "pnlQLXuPhat";
            pnlQLXuPhat.Size = new Size(327, 69);
            pnlQLXuPhat.TabIndex = 5;
            pnlQLXuPhat.Paint += pnlQLXuPhat_Paint;
            // 
            // label4
            // 
            label4.BackColor = SystemColors.Window;
            label4.Cursor = Cursors.Hand;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(70, 0);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(257, 69);
            label4.TabIndex = 1;
            label4.Text = "Quản lý phiếu xử phạt";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = SystemColors.Window;
            pictureBox6.Cursor = Cursors.Hand;
            pictureBox6.Dock = DockStyle.Left;
            pictureBox6.Image = Properties.Resources.qlxuphat;
            pictureBox6.Location = new Point(0, 0);
            pictureBox6.Margin = new Padding(4, 3, 4, 3);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(70, 69);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 0;
            pictureBox6.TabStop = false;
            // 
            // pnlQLThanhVien
            // 
            pnlQLThanhVien.BackColor = SystemColors.Info;
            pnlQLThanhVien.Controls.Add(pictureBox2);
            pnlQLThanhVien.Controls.Add(lblThanhvien);
            pnlQLThanhVien.Location = new Point(12, 23);
            pnlQLThanhVien.Margin = new Padding(4, 3, 4, 3);
            pnlQLThanhVien.Name = "pnlQLThanhVien";
            pnlQLThanhVien.Size = new Size(327, 69);
            pnlQLThanhVien.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.Window;
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Dock = DockStyle.Left;
            pictureBox2.Image = Properties.Resources.qlthanhvien;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(70, 69);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // lblThanhvien
            // 
            lblThanhvien.BackColor = SystemColors.Window;
            lblThanhvien.Cursor = Cursors.Hand;
            lblThanhvien.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblThanhvien.Location = new Point(70, 0);
            lblThanhvien.Margin = new Padding(4, 0, 4, 0);
            lblThanhvien.Name = "lblThanhvien";
            lblThanhvien.Size = new Size(257, 69);
            lblThanhvien.TabIndex = 1;
            lblThanhvien.Text = "Quản lý thành viên";
            lblThanhvien.TextAlign = ContentAlignment.MiddleCenter;
            lblThanhvien.Click += lblThanhvien_Click;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(0, 123, 181);
            panel1.Controls.Add(pnlThongKe);
            panel1.Controls.Add(pnlQLPhieuMuon);
            panel1.Controls.Add(pnlExit);
            panel1.Controls.Add(pnlQLThanhVien);
            panel1.Controls.Add(pnlQLXuPhat);
            panel1.Controls.Add(pnlQLLoaiThietBi);
            panel1.Controls.Add(pnlQLThietBi);
            panel1.Location = new Point(-1, 231);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(343, 1154);
            panel1.TabIndex = 1;
            // 
            // pnlQLPhieuMuon
            // 
            pnlQLPhieuMuon.BackColor = SystemColors.Info;
            pnlQLPhieuMuon.Controls.Add(label6);
            pnlQLPhieuMuon.Controls.Add(pictureBox8);
            pnlQLPhieuMuon.Location = new Point(12, 290);
            pnlQLPhieuMuon.Margin = new Padding(4, 3, 4, 3);
            pnlQLPhieuMuon.Name = "pnlQLPhieuMuon";
            pnlQLPhieuMuon.Size = new Size(327, 69);
            pnlQLPhieuMuon.TabIndex = 6;
            // 
            // label6
            // 
            label6.BackColor = SystemColors.Window;
            label6.Cursor = Cursors.Hand;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(70, 0);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(257, 69);
            label6.TabIndex = 1;
            label6.Text = "Quản lý phiếu mượn";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = SystemColors.Window;
            pictureBox8.Cursor = Cursors.Hand;
            pictureBox8.Dock = DockStyle.Left;
            pictureBox8.Image = Properties.Resources.qldatcho;
            pictureBox8.Location = new Point(0, 0);
            pictureBox8.Margin = new Padding(4, 3, 4, 3);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(70, 69);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 0;
            pictureBox8.TabStop = false;
            // 
            // pnlExit
            // 
            pnlExit.BackColor = SystemColors.Info;
            pnlExit.Controls.Add(label5);
            pnlExit.Controls.Add(pictureBox7);
            pnlExit.Location = new Point(12, 617);
            pnlExit.Margin = new Padding(4, 3, 4, 3);
            pnlExit.Name = "pnlExit";
            pnlExit.Size = new Size(327, 69);
            pnlExit.TabIndex = 6;
            // 
            // label5
            // 
            label5.BackColor = SystemColors.Window;
            label5.Cursor = Cursors.Hand;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(70, 0);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(257, 69);
            label5.TabIndex = 1;
            label5.Text = "Đăng xuất";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            label5.Click += label5_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = SystemColors.Window;
            pictureBox7.Cursor = Cursors.Hand;
            pictureBox7.Dock = DockStyle.Left;
            pictureBox7.Image = Properties.Resources.logout;
            pictureBox7.Location = new Point(0, 0);
            pictureBox7.Margin = new Padding(4, 3, 4, 3);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(70, 69);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 0;
            pictureBox7.TabStop = false;
            // 
            // pnlThongKe
            // 
            pnlThongKe.BackColor = SystemColors.Info;
            pnlThongKe.Controls.Add(label3);
            pnlThongKe.Controls.Add(pictureBox5);
            pnlThongKe.Location = new Point(12, 468);
            pnlThongKe.Margin = new Padding(4, 3, 4, 3);
            pnlThongKe.Name = "pnlThongKe";
            pnlThongKe.Size = new Size(327, 69);
            pnlThongKe.TabIndex = 6;
            // 
            // label3
            // 
            label3.BackColor = SystemColors.Window;
            label3.Cursor = Cursors.Hand;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(70, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(257, 69);
            label3.TabIndex = 1;
            label3.Text = "Quản lý thống kê";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = SystemColors.Window;
            pictureBox5.Cursor = Cursors.Hand;
            pictureBox5.Dock = DockStyle.Left;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(0, 0);
            pictureBox5.Margin = new Padding(4, 3, 4, 3);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(70, 69);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 0;
            pictureBox5.TabStop = false;
            // 
            // MenuTaskBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(0, 123, 181);
            ClientSize = new Size(355, 1109);
            Controls.Add(panel1);
            Controls.Add(pnlUser);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MenuTaskBar";
            Text = "MenuTaskBar";
            Load += MenuTaskBar_Load;
            pnlUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlQLThietBi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            pnlQLLoaiThietBi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            pnlQLXuPhat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            pnlQLThanhVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            pnlQLPhieuMuon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            pnlExit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            pnlThongKe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Panel pnlQLThietBi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel pnlQLLoaiThietBi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel pnlQLXuPhat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Panel pnlQLThanhVien;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblThanhvien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlExit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox7;
        private Panel pnlQLPhieuMuon;
        private Label label6;
        private PictureBox pictureBox8;
        private Panel pnlThongKe;
        private Label label3;
        private PictureBox pictureBox5;
    }
}