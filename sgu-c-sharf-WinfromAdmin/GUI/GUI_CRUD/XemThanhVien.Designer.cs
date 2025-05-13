namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    partial class FormXemThanhVien
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnlContent = new Panel();
            panel7 = new Panel();
            cbbTrangThai = new ComboBox();
            label8 = new Label();
            dataGrid = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
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
            pnlContent.Controls.Add(dataGrid);
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
            pnlContent.Size = new Size(740, 746);
            pnlContent.TabIndex = 0;
            pnlContent.Paint += pnlContent_Paint;
            // 
            // panel7
            // 
            panel7.Controls.Add(cbbTrangThai);
            panel7.Controls.Add(label8);
            panel7.Location = new Point(413, 296);
            panel7.Margin = new Padding(4, 3, 4, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(295, 73);
            panel7.TabIndex = 6;
            // 
            // cbbTrangThai
            // 
            cbbTrangThai.Dock = DockStyle.Bottom;
            cbbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTrangThai.Enabled = false;
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
            // dataGrid
            // 
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            dataGrid.Dock = DockStyle.Bottom;
            dataGrid.ImeMode = ImeMode.NoControl;
            dataGrid.Location = new Point(0, 507);
            dataGrid.Name = "dataGrid";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGrid.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.Size = new Size(740, 239);
            dataGrid.TabIndex = 8;
            // 
            // Column1
            // 
            Column1.HeaderText = "STT";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Thời gian checkin";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // panel6
            // 
            panel6.Controls.Add(txtEmail);
            panel6.Controls.Add(label7);
            panel6.Location = new Point(413, 193);
            panel6.Margin = new Padding(4, 3, 4, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(295, 73);
            panel6.TabIndex = 6;
            panel6.Paint += panel6_Paint;
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
            panel5.Location = new Point(36, 399);
            panel5.Margin = new Padding(4, 3, 4, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(295, 73);
            panel5.TabIndex = 5;
            panel5.Paint += panel5_Paint;
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
            panel4.Location = new Point(36, 296);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(295, 73);
            panel4.TabIndex = 4;
            panel4.Paint += panel4_Paint;
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
            panel3.Location = new Point(36, 193);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(295, 73);
            panel3.TabIndex = 3;
            panel3.Paint += panel3_Paint;
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
            panel2.Location = new Point(413, 90);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(295, 73);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
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
            panel1.Location = new Point(36, 90);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(295, 73);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
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
            label1.Text = "Xem Thông Tin";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormXemThanhVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 746);
            Controls.Add(pnlContent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormXemThanhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "XemThanhVien";
            Load += FormSuaThanhVien_Load;
            pnlContent.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
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
        private DataGridView dataGrid;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private Panel panel7;
        private Label label8;
        private ComboBox cbbTrangThai;
    }
}