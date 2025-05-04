namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    partial class FormSuaPhieuXuphat
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
            panel8 = new Panel();
            cbbTrangThai = new ComboBox();
            label9 = new Label();
            panel6 = new Panel();
            txtMoTa = new TextBox();
            label5 = new Label();
            panel2 = new Panel();
            txtHanXuPhat = new TextBox();
            label3 = new Label();
            btnSua = new Button();
            panel4 = new Panel();
            txtTenThanhVien = new TextBox();
            label6 = new Label();
            panel5 = new Panel();
            txtMaThanhVien = new TextBox();
            label7 = new Label();
            panel7 = new Panel();
            dataTimeViPham = new DateTimePicker();
            label8 = new Label();
            panel3 = new Panel();
            txtMucPhat = new TextBox();
            label4 = new Label();
            panel1 = new Panel();
            txtMaPhieu = new TextBox();
            label2 = new Label();
            label1 = new Label();
            pnlContent.SuspendLayout();
            panel8.SuspendLayout();
            panel6.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(panel8);
            pnlContent.Controls.Add(panel6);
            pnlContent.Controls.Add(panel2);
            pnlContent.Controls.Add(btnSua);
            pnlContent.Controls.Add(panel4);
            pnlContent.Controls.Add(panel5);
            pnlContent.Controls.Add(panel7);
            pnlContent.Controls.Add(panel3);
            pnlContent.Controls.Add(panel1);
            pnlContent.Controls.Add(label1);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 0);
            pnlContent.Margin = new Padding(4, 3, 4, 3);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(889, 746);
            pnlContent.TabIndex = 0;
            pnlContent.Paint += pnlContent_Paint;
            // 
            // panel8
            // 
            panel8.Controls.Add(cbbTrangThai);
            panel8.Controls.Add(label9);
            panel8.Location = new Point(603, 210);
            panel8.Margin = new Padding(4, 3, 4, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(250, 73);
            panel8.TabIndex = 9;
            // 
            // cbbTrangThai
            // 
            cbbTrangThai.Dock = DockStyle.Bottom;
            cbbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTrangThai.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbbTrangThai.FormattingEnabled = true;
            cbbTrangThai.Items.AddRange(new object[] { "Đã xử lý", "Chưa xử lý" });
            cbbTrangThai.Location = new Point(0, 43);
            cbbTrangThai.Name = "cbbTrangThai";
            cbbTrangThai.Size = new Size(250, 30);
            cbbTrangThai.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Top;
            label9.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(0, 0);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(92, 22);
            label9.TabIndex = 0;
            label9.Text = "Trạng thái";
            // 
            // panel6
            // 
            panel6.Controls.Add(txtMoTa);
            panel6.Controls.Add(label5);
            panel6.Location = new Point(319, 357);
            panel6.Margin = new Padding(4, 3, 4, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(534, 300);
            panel6.TabIndex = 2;
            // 
            // txtMoTa
            // 
            txtMoTa.Dock = DockStyle.Fill;
            txtMoTa.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMoTa.Location = new Point(0, 22);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(534, 278);
            txtMoTa.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(56, 22);
            label5.TabIndex = 0;
            label5.Text = "Mô tả";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtHanXuPhat);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(319, 210);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 73);
            panel2.TabIndex = 9;
            // 
            // txtHanXuPhat
            // 
            txtHanXuPhat.BackColor = SystemColors.Window;
            txtHanXuPhat.Dock = DockStyle.Bottom;
            txtHanXuPhat.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHanXuPhat.Location = new Point(0, 44);
            txtHanXuPhat.Margin = new Padding(4, 3, 4, 3);
            txtHanXuPhat.Name = "txtHanXuPhat";
            txtHanXuPhat.Size = new Size(250, 29);
            txtHanXuPhat.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(156, 22);
            label3.TabIndex = 0;
            label3.Text = "Thời gian xử phạt";
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(384, 694);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(120, 40);
            btnSua.TabIndex = 11;
            btnSua.Text = "Sửa phiếu";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(txtTenThanhVien);
            panel4.Controls.Add(label6);
            panel4.Location = new Point(603, 84);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(250, 73);
            panel4.TabIndex = 8;
            // 
            // txtTenThanhVien
            // 
            txtTenThanhVien.BackColor = SystemColors.Window;
            txtTenThanhVien.Dock = DockStyle.Bottom;
            txtTenThanhVien.Enabled = false;
            txtTenThanhVien.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenThanhVien.Location = new Point(0, 44);
            txtTenThanhVien.Margin = new Padding(4, 3, 4, 3);
            txtTenThanhVien.Name = "txtTenThanhVien";
            txtTenThanhVien.ReadOnly = true;
            txtTenThanhVien.Size = new Size(250, 29);
            txtTenThanhVien.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(0, 0);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(132, 22);
            label6.TabIndex = 0;
            label6.Text = "Tên thành viên";
            // 
            // panel5
            // 
            panel5.Controls.Add(txtMaThanhVien);
            panel5.Controls.Add(label7);
            panel5.Location = new Point(319, 84);
            panel5.Margin = new Padding(4, 3, 4, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(250, 73);
            panel5.TabIndex = 7;
            // 
            // txtMaThanhVien
            // 
            txtMaThanhVien.Dock = DockStyle.Bottom;
            txtMaThanhVien.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaThanhVien.Location = new Point(0, 44);
            txtMaThanhVien.Margin = new Padding(4, 3, 4, 3);
            txtMaThanhVien.Name = "txtMaThanhVien";
            txtMaThanhVien.Size = new Size(250, 29);
            txtMaThanhVien.TabIndex = 1;
            txtMaThanhVien.TextChanged += txtMaThanhVien_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Top;
            label7.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(0, 0);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(124, 22);
            label7.TabIndex = 0;
            label7.Text = "Mã thành viên";
            // 
            // panel7
            // 
            panel7.Controls.Add(dataTimeViPham);
            panel7.Controls.Add(label8);
            panel7.Location = new Point(35, 210);
            panel7.Margin = new Padding(4, 3, 4, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(250, 73);
            panel7.TabIndex = 6;
            // 
            // dataTimeViPham
            // 
            dataTimeViPham.Dock = DockStyle.Bottom;
            dataTimeViPham.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataTimeViPham.Location = new Point(0, 51);
            dataTimeViPham.Name = "dataTimeViPham";
            dataTimeViPham.Size = new Size(250, 22);
            dataTimeViPham.TabIndex = 1;
            dataTimeViPham.ValueChanged += dataTimeViPham_ValueChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(0, 0);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(123, 22);
            label8.TabIndex = 0;
            label8.Text = "Ngày vi phạm";
            // 
            // panel3
            // 
            panel3.Controls.Add(txtMucPhat);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(35, 357);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(250, 73);
            panel3.TabIndex = 3;
            panel3.Paint += panel3_Paint;
            // 
            // txtMucPhat
            // 
            txtMucPhat.Dock = DockStyle.Bottom;
            txtMucPhat.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMucPhat.Location = new Point(0, 44);
            txtMucPhat.Margin = new Padding(4, 3, 4, 3);
            txtMucPhat.Name = "txtMucPhat";
            txtMucPhat.Size = new Size(250, 29);
            txtMucPhat.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(89, 22);
            label4.TabIndex = 0;
            label4.Text = "Mức phạt";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtMaPhieu);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(35, 84);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 73);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // txtMaPhieu
            // 
            txtMaPhieu.Dock = DockStyle.Bottom;
            txtMaPhieu.Enabled = false;
            txtMaPhieu.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaPhieu.Location = new Point(0, 44);
            txtMaPhieu.Margin = new Padding(4, 3, 4, 3);
            txtMaPhieu.Name = "txtMaPhieu";
            txtMaPhieu.Size = new Size(250, 29);
            txtMaPhieu.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(86, 22);
            label2.TabIndex = 0;
            label2.Text = "Mã phiếu";
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
            label1.Size = new Size(889, 43);
            label1.TabIndex = 0;
            label1.Text = "Sửa phiếu xử phạt";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormSuaPhieuXuphat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(889, 746);
            Controls.Add(pnlContent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormSuaPhieuXuphat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Suaphieuxuphat";
            Load += FormSuaThanhVien_Load;
            pnlContent.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtMucPhat;
        private System.Windows.Forms.Label label4;
        private Panel panel7;
        private Label label8;
        private Button btnThemDauThietBi;
        private Button btnSua;
        private Panel panel4;
        private Label label6;
        private Panel panel5;
        private TextBox txtMaThanhVien;
        private Label label7;
        private Panel panel2;
        private Label label3;
        private DateTimePicker dataTimeViPham;
        private Panel panel6;
        private TextBox txtMoTa;
        private Label label5;
        private Panel panel8;
        private ComboBox cbbTrangThai;
        private Label label9;
        private TextBox txtTenThanhVien;
        private TextBox txtHanXuPhat;
    }
}