namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    partial class FormXemPhieuDatCho
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
            panel2 = new Panel();
            txtThoiGianDat = new TextBox();
            label3 = new Label();
            panel4 = new Panel();
            txtTenThanhVien = new TextBox();
            label6 = new Label();
            panel5 = new Panel();
            txtNgayTaoPhieu = new TextBox();
            label7 = new Label();
            panel7 = new Panel();
            cbbTrangThai = new ComboBox();
            label8 = new Label();
            dataGrid = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            txtMaThanhVien = new TextBox();
            label4 = new Label();
            panel1 = new Panel();
            txtMaPhieu = new TextBox();
            label2 = new Label();
            label1 = new Label();
            pnlContent.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(panel2);
            pnlContent.Controls.Add(panel4);
            pnlContent.Controls.Add(panel5);
            pnlContent.Controls.Add(panel7);
            pnlContent.Controls.Add(dataGrid);
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
            // panel2
            // 
            panel2.Controls.Add(txtThoiGianDat);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(439, 224);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 73);
            panel2.TabIndex = 9;
            // 
            // txtThoiGianDat
            // 
            txtThoiGianDat.Dock = DockStyle.Bottom;
            txtThoiGianDat.Enabled = false;
            txtThoiGianDat.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtThoiGianDat.Location = new Point(0, 44);
            txtThoiGianDat.Margin = new Padding(4, 3, 4, 3);
            txtThoiGianDat.Name = "txtThoiGianDat";
            txtThoiGianDat.Size = new Size(250, 29);
            txtThoiGianDat.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(119, 22);
            label3.TabIndex = 0;
            label3.Text = "Thời gian đặt";
            // 
            // panel4
            // 
            panel4.Controls.Add(txtTenThanhVien);
            panel4.Controls.Add(label6);
            panel4.Location = new Point(439, 135);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(250, 73);
            panel4.TabIndex = 8;
            // 
            // txtTenThanhVien
            // 
            txtTenThanhVien.Dock = DockStyle.Bottom;
            txtTenThanhVien.Enabled = false;
            txtTenThanhVien.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenThanhVien.Location = new Point(0, 44);
            txtTenThanhVien.Margin = new Padding(4, 3, 4, 3);
            txtTenThanhVien.Name = "txtTenThanhVien";
            txtTenThanhVien.Size = new Size(250, 29);
            txtTenThanhVien.TabIndex = 1;
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
            panel5.Controls.Add(txtNgayTaoPhieu);
            panel5.Controls.Add(label7);
            panel5.Location = new Point(439, 46);
            panel5.Margin = new Padding(4, 3, 4, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(250, 73);
            panel5.TabIndex = 7;
            // 
            // txtNgayTaoPhieu
            // 
            txtNgayTaoPhieu.Dock = DockStyle.Bottom;
            txtNgayTaoPhieu.Enabled = false;
            txtNgayTaoPhieu.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNgayTaoPhieu.Location = new Point(0, 44);
            txtNgayTaoPhieu.Margin = new Padding(4, 3, 4, 3);
            txtNgayTaoPhieu.Name = "txtNgayTaoPhieu";
            txtNgayTaoPhieu.Size = new Size(250, 29);
            txtNgayTaoPhieu.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Top;
            label7.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(0, 0);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(135, 22);
            label7.TabIndex = 0;
            label7.Text = "Ngày tạo phiếu";
            // 
            // panel7
            // 
            panel7.Controls.Add(cbbTrangThai);
            panel7.Controls.Add(label8);
            panel7.Location = new Point(51, 224);
            panel7.Margin = new Padding(4, 3, 4, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(250, 73);
            panel7.TabIndex = 6;
            // 
            // cbbTrangThai
            // 
            cbbTrangThai.Dock = DockStyle.Bottom;
            cbbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTrangThai.Enabled = false;
            cbbTrangThai.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbbTrangThai.FormattingEnabled = true;
            cbbTrangThai.Items.AddRange(new object[] { "Đang chờ", "Đang sử dụng", "Đã trả chỗ", "Hủy" });
            cbbTrangThai.Location = new Point(0, 43);
            cbbTrangThai.Name = "cbbTrangThai";
            cbbTrangThai.Size = new Size(250, 30);
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
            label8.Size = new Size(92, 22);
            label8.TabIndex = 0;
            label8.Text = "Trạng thái";
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
            dataGrid.Columns.AddRange(new DataGridViewColumn[] { Column1, Column3 });
            dataGrid.ImeMode = ImeMode.NoControl;
            dataGrid.Location = new Point(0, 326);
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
            dataGrid.Size = new Size(740, 300);
            dataGrid.TabIndex = 8;
            // 
            // Column1
            // 
            Column1.HeaderText = "Mã đầu thiết bị";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Tên thiết bị";
            Column3.Name = "Column3";
            // 
            // panel3
            // 
            panel3.Controls.Add(txtMaThanhVien);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(51, 135);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(250, 73);
            panel3.TabIndex = 3;
            panel3.Paint += panel3_Paint;
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
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(124, 22);
            label4.TabIndex = 0;
            label4.Text = "Mã thành viên";
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
            label1.Text = "Xem phiếu đặt chỗ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormXemPhieuDatCho
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 746);
            Controls.Add(pnlContent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormXemPhieuDatCho";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xemphieudatcho";
            Load += FormSuaThanhVien_Load;
            pnlContent.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
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
        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtMaThanhVien;
        private System.Windows.Forms.Label label4;
        private DataGridView dataGrid;
        private Panel panel7;
        private Label label8;
        private ComboBox cbbTrangThai;
        private Button btnThemDauThietBi;
        private Panel panel4;
        private TextBox txtTenThanhVien;
        private Label label6;
        private Panel panel5;
        private TextBox txtNgayTaoPhieu;
        private Label label7;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column3;
        private Panel panel2;
        private TextBox txtThoiGianDat;
        private Label label3;
    }
}