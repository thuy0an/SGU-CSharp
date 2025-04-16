namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    partial class FormThemThietBi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise</param>
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
            panel2 = new Panel();
            txtDauThietBi = new TextBox();
            label3 = new Label();
            btnThem = new Button();
            panel7 = new Panel();
            cbbLoaiThietBi = new ComboBox();
            label8 = new Label();
            panel3 = new Panel();
            txtTenThietBi = new TextBox();
            label4 = new Label();
            panel1 = new Panel();
            txtMaThietBi = new TextBox();
            label2 = new Label();
            label1 = new Label();
            pnlContent.SuspendLayout();
            panel2.SuspendLayout();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(panel2);
            pnlContent.Controls.Add(btnThem);
            pnlContent.Controls.Add(panel7);
            pnlContent.Controls.Add(panel3);
            pnlContent.Controls.Add(panel1);
            pnlContent.Controls.Add(label1);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 0);
            pnlContent.Margin = new Padding(4, 3, 4, 3);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(740, 591);
            pnlContent.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtDauThietBi);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(120, 339);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(500, 73);
            panel2.TabIndex = 4;
            // 
            // txtDauThietBi
            // 
            txtDauThietBi.Dock = DockStyle.Bottom;
            txtDauThietBi.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDauThietBi.Location = new Point(0, 44);
            txtDauThietBi.Margin = new Padding(4, 3, 4, 3);
            txtDauThietBi.Name = "txtDauThietBi";
            txtDauThietBi.Size = new Size(500, 29);
            txtDauThietBi.TabIndex = 1;
            txtDauThietBi.Text = "abc";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(185, 22);
            label3.TabIndex = 0;
            label3.Text = "Số lượng đầu thiết bị";
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(310, 493);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 40);
            btnThem.TabIndex = 11;
            btnThem.Text = "Tạo thiết bị";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // panel7
            // 
            panel7.Controls.Add(cbbLoaiThietBi);
            panel7.Controls.Add(label8);
            panel7.Location = new Point(120, 224);
            panel7.Margin = new Padding(4, 3, 4, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(500, 73);
            panel7.TabIndex = 6;
            // 
            // cbbLoaiThietBi
            // 
            cbbLoaiThietBi.Dock = DockStyle.Bottom;
            cbbLoaiThietBi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbLoaiThietBi.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbbLoaiThietBi.FormattingEnabled = true;
            cbbLoaiThietBi.Items.AddRange(new object[] { "Loại A", "Loại B", "Loại C", "Loại D" });
            cbbLoaiThietBi.Location = new Point(0, 43);
            cbbLoaiThietBi.Name = "cbbLoaiThietBi";
            cbbLoaiThietBi.Size = new Size(500, 30);
            cbbLoaiThietBi.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(0, 0);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(106, 22);
            label8.TabIndex = 0;
            label8.Text = "Loại thiết bị";
            // 
            // panel3
            // 
            panel3.Controls.Add(txtTenThietBi);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(120, 135);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(500, 73);
            panel3.TabIndex = 3;
            // 
            // txtTenThietBi
            // 
            txtTenThietBi.Dock = DockStyle.Bottom;
            txtTenThietBi.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenThietBi.Location = new Point(0, 44);
            txtTenThietBi.Margin = new Padding(4, 3, 4, 3);
            txtTenThietBi.Name = "txtTenThietBi";
            txtTenThietBi.Size = new Size(500, 29);
            txtTenThietBi.TabIndex = 1;
            txtTenThietBi.Text = "abc";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(103, 22);
            label4.TabIndex = 0;
            label4.Text = "Tên thiết bị";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtMaThietBi);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(120, 46);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 73);
            panel1.TabIndex = 1;
            // 
            // txtMaThietBi
            // 
            txtMaThietBi.Dock = DockStyle.Bottom;
            txtMaThietBi.Enabled = false;
            txtMaThietBi.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaThietBi.Location = new Point(0, 44);
            txtMaThietBi.Margin = new Padding(4, 3, 4, 3);
            txtMaThietBi.Name = "txtMaThietBi";
            txtMaThietBi.Size = new Size(500, 29);
            txtMaThietBi.TabIndex = 1;
            txtMaThietBi.Text = "abc";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(95, 22);
            label2.TabIndex = 0;
            label2.Text = "Mã thiết bị";
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
            label1.Text = "Tạo thiết bị";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormThemThietBi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 591);
            Controls.Add(pnlContent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormThemThietBi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ThemThietBi";
            pnlContent.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private System.Windows.Forms.TextBox txtMaThietBi;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtTenThietBi;
        private System.Windows.Forms.Label label4;
        private Panel panel7;
        private Label label8;
        private ComboBox cbbLoaiThietBi;
        private Button btnThem;
        private Panel panel2;
        private TextBox txtDauThietBi;
        private Label label3;
    }
}