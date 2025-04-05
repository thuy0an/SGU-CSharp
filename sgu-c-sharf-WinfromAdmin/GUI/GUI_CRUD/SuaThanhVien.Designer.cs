namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    partial class FormSuaThanhVien
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
            pnlContent = new Panel();
            panel7 = new Panel();
            cbbTrangThai = new ComboBox();
            label8 = new Label();
            btnCapNhat = new Button();
            panel6 = new Panel();
            txtEmail = new TextBox();
            label7 = new Label();
            panel5 = new Panel();
            txtNgaySinh = new TextBox();
            label6 = new Label();
            panel4 = new Panel();
            txtThoiGianDangKy = new TextBox();
            label5 = new Label();
            panel3 = new Panel();
            txtTenNguoiDung = new TextBox();
            label4 = new Label();
            panel2 = new Panel();
            txtSoDienThoai = new TextBox();
            label3 = new Label();
            panel1 = new Panel();
            txtMaThanhVien = new TextBox();
            label2 = new Label();
            label1 = new Label();
            pnlContent.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(panel7);
            pnlContent.Controls.Add(btnCapNhat);
            pnlContent.Controls.Add(panel6);
            pnlContent.Controls.Add(panel5);
            pnlContent.Controls.Add(panel4);
            pnlContent.Controls.Add(panel3);
            pnlContent.Controls.Add(panel2);
            pnlContent.Controls.Add(panel1);
            pnlContent.Controls.Add(label1);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 0);
            pnlContent.Margin = new Padding(4, 3, 4, 3);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(740, 611);
            pnlContent.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Controls.Add(cbbTrangThai);
            panel7.Controls.Add(label8);
            panel7.Location = new Point(411, 298);
            panel7.Margin = new Padding(4, 3, 4, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(295, 73);
            panel7.TabIndex = 6;
            // 
            // cbbTrangThai
            // 
            cbbTrangThai.Dock = DockStyle.Bottom;
            cbbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTrangThai.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbbTrangThai.FormattingEnabled = true;
            cbbTrangThai.Items.AddRange(new object[] { "Hoạt động", "Đình chỉ", "Cấm" });
            cbbTrangThai.Location = new Point(0, 43);
            cbbTrangThai.Name = "cbbTrangThai";
            cbbTrangThai.Size = new Size(295, 30);
            cbbTrangThai.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(0, 0);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(194, 22);
            label8.TabIndex = 0;
            label8.Text = "Trạng thái người dùng";
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = Color.FromArgb(0, 123, 181);
            btnCapNhat.Cursor = Cursors.Hand;
            btnCapNhat.ForeColor = Color.White;
            btnCapNhat.Location = new Point(276, 506);
            btnCapNhat.Margin = new Padding(4, 3, 4, 3);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(189, 47);
            btnCapNhat.TabIndex = 7;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = false;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // panel6
            // 
            panel6.Controls.Add(txtEmail);
            panel6.Controls.Add(label7);
            panel6.Location = new Point(411, 194);
            panel6.Margin = new Padding(4, 3, 4, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(295, 73);
            panel6.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Dock = DockStyle.Bottom;
            txtEmail.Enabled = false;
            txtEmail.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(0, 44);
            txtEmail.Margin = new Padding(4, 3, 4, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(295, 29);
            txtEmail.TabIndex = 1;
            txtEmail.Text = "abc";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Top;
            label7.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(0, 0);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(57, 22);
            label7.TabIndex = 0;
            label7.Text = "Email";
            // 
            // panel5
            // 
            panel5.Controls.Add(txtNgaySinh);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(34, 404);
            panel5.Margin = new Padding(4, 3, 4, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(295, 73);
            panel5.TabIndex = 5;
            // 
            // txtNgaySinh
            // 
            txtNgaySinh.Dock = DockStyle.Bottom;
            txtNgaySinh.Enabled = false;
            txtNgaySinh.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNgaySinh.Location = new Point(0, 44);
            txtNgaySinh.Margin = new Padding(4, 3, 4, 3);
            txtNgaySinh.Name = "txtNgaySinh";
            txtNgaySinh.Size = new Size(295, 29);
            txtNgaySinh.TabIndex = 1;
            txtNgaySinh.Text = "abc";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(0, 0);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(92, 22);
            label6.TabIndex = 0;
            label6.Text = "Ngày sinh";
            // 
            // panel4
            // 
            panel4.Controls.Add(txtThoiGianDangKy);
            panel4.Controls.Add(label5);
            panel4.Location = new Point(34, 298);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(295, 73);
            panel4.TabIndex = 4;
            // 
            // txtThoiGianDangKy
            // 
            txtThoiGianDangKy.Dock = DockStyle.Bottom;
            txtThoiGianDangKy.Enabled = false;
            txtThoiGianDangKy.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtThoiGianDangKy.Location = new Point(0, 44);
            txtThoiGianDangKy.Margin = new Padding(4, 3, 4, 3);
            txtThoiGianDangKy.Name = "txtThoiGianDangKy";
            txtThoiGianDangKy.Size = new Size(295, 29);
            txtThoiGianDangKy.TabIndex = 1;
            txtThoiGianDangKy.Text = "abc";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(158, 22);
            label5.TabIndex = 0;
            label5.Text = "Thời gian đăng ký";
            // 
            // panel3
            // 
            panel3.Controls.Add(txtTenNguoiDung);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(34, 194);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(295, 73);
            panel3.TabIndex = 3;
            // 
            // txtTenNguoiDung
            // 
            txtTenNguoiDung.Dock = DockStyle.Bottom;
            txtTenNguoiDung.Enabled = false;
            txtTenNguoiDung.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenNguoiDung.Location = new Point(0, 44);
            txtTenNguoiDung.Margin = new Padding(4, 3, 4, 3);
            txtTenNguoiDung.Name = "txtTenNguoiDung";
            txtTenNguoiDung.Size = new Size(295, 29);
            txtTenNguoiDung.TabIndex = 1;
            txtTenNguoiDung.Text = "abc";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(145, 22);
            label4.TabIndex = 0;
            label4.Text = "Tên người dùng";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtSoDienThoai);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(411, 90);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(295, 73);
            panel2.TabIndex = 2;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Dock = DockStyle.Bottom;
            txtSoDienThoai.Enabled = false;
            txtSoDienThoai.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoDienThoai.Location = new Point(0, 44);
            txtSoDienThoai.Margin = new Padding(4, 3, 4, 3);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(295, 29);
            txtSoDienThoai.TabIndex = 1;
            txtSoDienThoai.Text = "abc";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(120, 22);
            label3.TabIndex = 0;
            label3.Text = "Số điện thoại";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtMaThanhVien);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(34, 90);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(295, 73);
            panel1.TabIndex = 1;
            // 
            // txtMaThanhVien
            // 
            txtMaThanhVien.Dock = DockStyle.Bottom;
            txtMaThanhVien.Enabled = false;
            txtMaThanhVien.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaThanhVien.Location = new Point(0, 44);
            txtMaThanhVien.Margin = new Padding(4, 3, 4, 3);
            txtMaThanhVien.Name = "txtMaThanhVien";
            txtMaThanhVien.Size = new Size(295, 29);
            txtMaThanhVien.TabIndex = 1;
            txtMaThanhVien.Text = "abc";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(124, 22);
            label2.TabIndex = 0;
            label2.Text = "Mã thành viên";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 123, 181);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(740, 43);
            label1.TabIndex = 0;
            label1.Text = "Cập Nhật Thông Tin";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormSuaThanhVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 611);
            Controls.Add(pnlContent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormSuaThanhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SuaThanhVien";
            Load += FormSuaThanhVien_Load;
            pnlContent.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaThanhVien;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtNgaySinh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtThoiGianDangKy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtTenNguoiDung;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCapNhat;
        private Panel panel7;
        private ComboBox cbbTrangThai;
        private Label label8;
    }
}