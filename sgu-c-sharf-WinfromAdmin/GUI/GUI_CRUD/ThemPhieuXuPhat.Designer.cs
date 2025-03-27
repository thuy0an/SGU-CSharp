namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    partial class FormThemPhieuXuphat
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
            panel6 = new Panel();
            txtMoTa = new TextBox();
            label5 = new Label();
            panel2 = new Panel();
            dataTimeXuPhat = new DateTimePicker();
            label3 = new Label();
            btnThem = new Button();
            panel4 = new Panel();
            cbbThanhVien = new ComboBox();
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
            pnlContent.Controls.Add(panel6);
            pnlContent.Controls.Add(panel2);
            pnlContent.Controls.Add(btnThem);
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
            pnlContent.Size = new Size(740, 746);
            pnlContent.TabIndex = 0;
            pnlContent.Paint += pnlContent_Paint;
            // 
            // panel6
            // 
            panel6.Controls.Add(txtMoTa);
            panel6.Controls.Add(label5);
            panel6.Location = new Point(51, 353);
            panel6.Margin = new Padding(4, 3, 4, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(638, 300);
            panel6.TabIndex = 2;
            // 
            // txtMoTa
            // 
            txtMoTa.Dock = DockStyle.Fill;
            txtMoTa.Location = new Point(0, 22);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(638, 278);
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
            panel2.Controls.Add(dataTimeXuPhat);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(439, 224);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 73);
            panel2.TabIndex = 9;
            // 
            // dataTimeXuPhat
            // 
            dataTimeXuPhat.Dock = DockStyle.Bottom;
            dataTimeXuPhat.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataTimeXuPhat.Location = new Point(0, 51);
            dataTimeXuPhat.Name = "dataTimeXuPhat";
            dataTimeXuPhat.Size = new Size(250, 22);
            dataTimeXuPhat.TabIndex = 1;
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
            // btnThem
            // 
            btnThem.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(310, 694);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 40);
            btnThem.TabIndex = 11;
            btnThem.Text = "Tạo phiếu";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(cbbThanhVien);
            panel4.Controls.Add(label6);
            panel4.Location = new Point(439, 135);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(250, 73);
            panel4.TabIndex = 8;
            // 
            // cbbThanhVien
            // 
            cbbThanhVien.Dock = DockStyle.Bottom;
            cbbThanhVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbThanhVien.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbbThanhVien.FormattingEnabled = true;
            cbbThanhVien.Items.AddRange(new object[] { "tên người 1", "tên người 2", "tên người 3" });
            cbbThanhVien.Location = new Point(0, 43);
            cbbThanhVien.Name = "cbbThanhVien";
            cbbThanhVien.Size = new Size(250, 30);
            cbbThanhVien.TabIndex = 1;
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
            panel5.Location = new Point(439, 46);
            panel5.Margin = new Padding(4, 3, 4, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(250, 73);
            panel5.TabIndex = 7;
            // 
            // txtMaThanhVien
            // 
            txtMaThanhVien.Dock = DockStyle.Bottom;
            txtMaThanhVien.Enabled = false;
            txtMaThanhVien.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaThanhVien.Location = new Point(0, 44);
            txtMaThanhVien.Margin = new Padding(4, 3, 4, 3);
            txtMaThanhVien.Name = "txtMaThanhVien";
            txtMaThanhVien.Size = new Size(250, 29);
            txtMaThanhVien.TabIndex = 1;
            txtMaThanhVien.Text = "abc";
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
            panel7.Location = new Point(51, 224);
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
            panel3.Location = new Point(51, 135);
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
            txtMucPhat.Text = "100";
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
            panel1.Location = new Point(51, 46);
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
            txtMaPhieu.Text = "01";
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
            label1.Size = new Size(740, 43);
            label1.TabIndex = 0;
            label1.Text = "Tạo phiếu xử phạt";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormThemPhieuXuphat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 746);
            Controls.Add(pnlContent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormThemPhieuXuphat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Themphieuxuphat";
            Load += FormSuaThanhVien_Load;
            pnlContent.ResumeLayout(false);
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
        private Button btnThem;
        private Panel panel4;
        private Label label6;
        private Panel panel5;
        private TextBox txtMaThanhVien;
        private Label label7;
        private Panel panel2;
        private Label label3;
        private DateTimePicker dataTimeXuPhat;
        private ComboBox cbbThanhVien;
        private DateTimePicker dataTimeViPham;
        private Panel panel6;
        private TextBox txtMoTa;
        private Label label5;
    }
}