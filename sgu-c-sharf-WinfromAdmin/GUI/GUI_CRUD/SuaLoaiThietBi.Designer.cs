namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    partial class FormSuaLoaiThietBi
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
            btnThem = new Button();
            panel3 = new Panel();
            txtTenLoaiThietBi = new TextBox();
            lblTenLoaiThietBi = new Label();
            panel1 = new Panel();
            txtMaLoaiThietBi = new TextBox();
            lblMaLoaiThietBi = new Label();
            label1 = new Label();
            panel2 = new Panel();
            txtSoLuongThietBi = new TextBox();
            label2 = new Label();
            pnlContent.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(panel2);
            pnlContent.Controls.Add(btnThem);
            pnlContent.Controls.Add(panel3);
            pnlContent.Controls.Add(panel1);
            pnlContent.Controls.Add(label1);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 0);
            pnlContent.Margin = new Padding(4, 3, 4, 3);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(740, 561);
            pnlContent.TabIndex = 0;
            pnlContent.Paint += pnlContent_Paint;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(0, 123, 181);
            btnThem.Cursor = Cursors.Hand;
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(285, 471);
            btnThem.Margin = new Padding(4, 3, 4, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(189, 47);
            btnThem.TabIndex = 7;
            btnThem.Text = "Sửa";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(txtTenLoaiThietBi);
            panel3.Controls.Add(lblTenLoaiThietBi);
            panel3.Location = new Point(56, 356);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(629, 73);
            panel3.TabIndex = 3;
            panel3.Paint += panel3_Paint;
            // 
            // txtTenLoaiThietBi
            // 
            txtTenLoaiThietBi.Dock = DockStyle.Bottom;
            txtTenLoaiThietBi.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenLoaiThietBi.Location = new Point(0, 44);
            txtTenLoaiThietBi.Margin = new Padding(4, 3, 4, 3);
            txtTenLoaiThietBi.Name = "txtTenLoaiThietBi";
            txtTenLoaiThietBi.Size = new Size(629, 29);
            txtTenLoaiThietBi.TabIndex = 1;
            txtTenLoaiThietBi.Text = "abc";
            // 
            // lblTenLoaiThietBi
            // 
            lblTenLoaiThietBi.AutoSize = true;
            lblTenLoaiThietBi.Dock = DockStyle.Top;
            lblTenLoaiThietBi.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenLoaiThietBi.Location = new Point(0, 0);
            lblTenLoaiThietBi.Margin = new Padding(4, 0, 4, 0);
            lblTenLoaiThietBi.Name = "lblTenLoaiThietBi";
            lblTenLoaiThietBi.Size = new Size(137, 22);
            lblTenLoaiThietBi.TabIndex = 0;
            lblTenLoaiThietBi.Text = "Tên loại thiết bị";
            lblTenLoaiThietBi.Click += label4_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtMaLoaiThietBi);
            panel1.Controls.Add(lblMaLoaiThietBi);
            panel1.Location = new Point(56, 117);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(629, 73);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // txtMaLoaiThietBi
            // 
            txtMaLoaiThietBi.Dock = DockStyle.Bottom;
            txtMaLoaiThietBi.Enabled = false;
            txtMaLoaiThietBi.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaLoaiThietBi.Location = new Point(0, 44);
            txtMaLoaiThietBi.Margin = new Padding(4, 3, 4, 3);
            txtMaLoaiThietBi.Name = "txtMaLoaiThietBi";
            txtMaLoaiThietBi.Size = new Size(629, 29);
            txtMaLoaiThietBi.TabIndex = 1;
            txtMaLoaiThietBi.Text = "abc";
            txtMaLoaiThietBi.TextChanged += txtMaThanhVien_TextChanged;
            // 
            // lblMaLoaiThietBi
            // 
            lblMaLoaiThietBi.AutoSize = true;
            lblMaLoaiThietBi.Dock = DockStyle.Top;
            lblMaLoaiThietBi.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaLoaiThietBi.Location = new Point(0, 0);
            lblMaLoaiThietBi.Margin = new Padding(4, 0, 4, 0);
            lblMaLoaiThietBi.Name = "lblMaLoaiThietBi";
            lblMaLoaiThietBi.Size = new Size(129, 22);
            lblMaLoaiThietBi.TabIndex = 0;
            lblMaLoaiThietBi.Text = "Mã loại thiết bị";
            lblMaLoaiThietBi.Click += label2_Click;
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
            label1.Text = "Cập nhật thông tin";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtSoLuongThietBi);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(56, 233);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(629, 73);
            panel2.TabIndex = 2;
            // 
            // txtSoLuongThietBi
            // 
            txtSoLuongThietBi.Dock = DockStyle.Bottom;
            txtSoLuongThietBi.Enabled = false;
            txtSoLuongThietBi.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoLuongThietBi.Location = new Point(0, 44);
            txtSoLuongThietBi.Margin = new Padding(4, 3, 4, 3);
            txtSoLuongThietBi.Name = "txtSoLuongThietBi";
            txtSoLuongThietBi.Size = new Size(629, 29);
            txtSoLuongThietBi.TabIndex = 1;
            txtSoLuongThietBi.Text = "abc";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(268, 22);
            label2.TabIndex = 0;
            label2.Text = "Số lượng thiết bị thuộc loại này";
            // 
            // FormSuaLoaiThietBi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 561);
            Controls.Add(pnlContent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormSuaLoaiThietBi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SuaLoaiThietBi";
            Load += FormSuaLoaiThietBi_Load;
            pnlContent.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMaLoaiThietBi;
        private System.Windows.Forms.TextBox txtMaLoaiThietBi;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtTenLoaiThietBi;
        private System.Windows.Forms.Label lblTenLoaiThietBi;
        private System.Windows.Forms.Button btnThem;
        private Panel panel2;
        private TextBox txtSoLuongThietBi;
        private Label label2;
    }
}