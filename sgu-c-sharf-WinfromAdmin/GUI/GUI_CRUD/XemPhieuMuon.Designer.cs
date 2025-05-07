namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    partial class FormXemPhieuMuon
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
            pnlContent = new Panel();
            panel5 = new Panel();
            txtTrangThai = new TextBox();
            label6 = new Label();
            panel4 = new Panel();
            txtNgayTao = new TextBox();
            label5 = new Label();
            panel2 = new Panel();
            txtMaPhieu = new TextBox();
            label3 = new Label();
            dataGrid = new DataGridView();
            Column5 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            txtTenNguoiDung = new TextBox();
            label4 = new Label();
            panel1 = new Panel();
            txtMaThanhVien = new TextBox();
            label2 = new Label();
            label1 = new Label();
            pnlContent.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(panel5);
            pnlContent.Controls.Add(panel4);
            pnlContent.Controls.Add(panel2);
            pnlContent.Controls.Add(dataGrid);
            pnlContent.Controls.Add(panel3);
            pnlContent.Controls.Add(panel1);
            pnlContent.Controls.Add(label1);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 0);
            pnlContent.Margin = new Padding(4, 3, 4, 3);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(884, 594);
            pnlContent.TabIndex = 0;
            pnlContent.Paint += pnlContent_Paint;
            // 
            // panel5
            // 
            panel5.Controls.Add(txtTrangThai);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(372, 161);
            panel5.Margin = new Padding(4, 3, 4, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(220, 73);
            panel5.TabIndex = 10;
            panel5.Paint += panel5_Paint_1;
            // 
            // txtTrangThai
            // 
            txtTrangThai.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTrangThai.Location = new Point(3, 47);
            txtTrangThai.Name = "txtTrangThai";
            txtTrangThai.ReadOnly = true;
            txtTrangThai.Size = new Size(214, 29);
            txtTrangThai.TabIndex = 1;
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
            label6.Text = "Trạng thái";
            // 
            // panel4
            // 
            panel4.Controls.Add(txtNgayTao);
            panel4.Controls.Add(label5);
            panel4.Location = new Point(26, 161);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(297, 73);
            panel4.TabIndex = 9;
            // 
            // txtNgayTao
            // 
            txtNgayTao.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNgayTao.Location = new Point(3, 47);
            txtNgayTao.Name = "txtNgayTao";
            txtNgayTao.ReadOnly = true;
            txtNgayTao.Size = new Size(294, 29);
            txtNgayTao.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(135, 22);
            label5.TabIndex = 0;
            label5.Text = "Ngày tạo phiếu";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtMaPhieu);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(26, 68);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 73);
            panel2.TabIndex = 2;
            // 
            // txtMaPhieu
            // 
            txtMaPhieu.Dock = DockStyle.Bottom;
            txtMaPhieu.Enabled = false;
            txtMaPhieu.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaPhieu.Location = new Point(0, 44);
            txtMaPhieu.Margin = new Padding(4, 3, 4, 3);
            txtMaPhieu.Name = "txtMaPhieu";
            txtMaPhieu.ReadOnly = true;
            txtMaPhieu.Size = new Size(250, 29);
            txtMaPhieu.TabIndex = 1;
            txtMaPhieu.TextChanged += txtMaPhieu_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(86, 22);
            label3.TabIndex = 0;
            label3.Text = "Mã phiếu";
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
            dataGrid.Columns.AddRange(new DataGridViewColumn[] { Column5, Column1, Column2, Column3, Column4 });
            dataGrid.ImeMode = ImeMode.NoControl;
            dataGrid.Location = new Point(26, 261);
            dataGrid.Name = "dataGrid";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGrid.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.Size = new Size(844, 300);
            dataGrid.TabIndex = 8;
            // 
            // Column5
            // 
            Column5.FillWeight = 449.2386F;
            Column5.HeaderText = "Tên thiết bị";
            Column5.MinimumWidth = 200;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.FillWeight = 12.6903543F;
            Column1.HeaderText = "Mã đầu thiết bị";
            Column1.MinimumWidth = 150;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.FillWeight = 12.6903543F;
            Column2.HeaderText = "Trạng thái";
            Column2.MinimumWidth = 150;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.FillWeight = 12.6903543F;
            Column3.HeaderText = "Ngày mượn";
            Column3.MinimumWidth = 150;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.FillWeight = 12.6903543F;
            Column4.HeaderText = "Ngày trả";
            Column4.MinimumWidth = 150;
            Column4.Name = "Column4";
            // 
            // panel3
            // 
            panel3.Controls.Add(txtTenNguoiDung);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(620, 68);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(250, 73);
            panel3.TabIndex = 3;
            panel3.Paint += panel3_Paint;
            // 
            // txtTenNguoiDung
            // 
            txtTenNguoiDung.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenNguoiDung.Location = new Point(3, 46);
            txtTenNguoiDung.Name = "txtTenNguoiDung";
            txtTenNguoiDung.ReadOnly = true;
            txtTenNguoiDung.Size = new Size(244, 29);
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
            // panel1
            // 
            panel1.Controls.Add(txtMaThanhVien);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(323, 68);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 73);
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
            txtMaThanhVien.ReadOnly = true;
            txtMaThanhVien.Size = new Size(250, 29);
            txtMaThanhVien.TabIndex = 1;
            txtMaThanhVien.TextChanged += txtMaThanhVien_TextChanged;
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
            label1.Size = new Size(884, 43);
            label1.TabIndex = 0;
            label1.Text = "Xem phiếu mượn";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormXemPhieuMuon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 594);
            Controls.Add(pnlContent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormXemPhieuMuon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xemphieumuon";
            Load += FormXemPhieuMuon_Load;
            pnlContent.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
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
        private System.Windows.Forms.TextBox txtMaThanhVien;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private DataGridView dataGrid;
        private Panel panel2;
        private TextBox txtMaPhieu;
        private Label label3;
        private Panel panel5;
        private Label label6;
        private Panel panel4;
        private Label label5;
        private TextBox txtTrangThai;
        private TextBox txtTenNguoiDung;
        private TextBox txtNgayTao;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
    }
}