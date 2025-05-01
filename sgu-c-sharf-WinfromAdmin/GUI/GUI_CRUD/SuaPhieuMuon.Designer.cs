namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    partial class FormSuaPhieuMuon
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
            pnlContent = new Panel();
            panel5 = new Panel();
            cbbTrangThai = new ComboBox();
            label6 = new Label();
            panel4 = new Panel();
            dateTimeNgayTao = new DateTimePicker();
            label5 = new Label();
            btnSuaDauThietBi = new Button();
            panel2 = new Panel();
            txtMaPhieu = new TextBox();
            label3 = new Label();
            btnXoaDauThietBi = new Button();
            btnSua = new Button();
            btnThemDauThietBi = new Button();
            dataGrid = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            cbbNguoiDung = new ComboBox();
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
            pnlContent.Controls.Add(btnSuaDauThietBi);
            pnlContent.Controls.Add(panel2);
            pnlContent.Controls.Add(btnXoaDauThietBi);
            pnlContent.Controls.Add(btnSua);
            pnlContent.Controls.Add(btnThemDauThietBi);
            pnlContent.Controls.Add(dataGrid);
            pnlContent.Controls.Add(panel3);
            pnlContent.Controls.Add(panel1);
            pnlContent.Controls.Add(label1);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 0);
            pnlContent.Margin = new Padding(4, 3, 4, 3);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(884, 687);
            pnlContent.TabIndex = 0;
            pnlContent.Paint += pnlContent_Paint;
            // 
            // panel5
            // 
            panel5.Controls.Add(cbbTrangThai);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(332, 170);
            panel5.Margin = new Padding(4, 3, 4, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(220, 73);
            panel5.TabIndex = 4;
            // 
            // cbbTrangThai
            // 
            cbbTrangThai.Dock = DockStyle.Bottom;
            cbbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTrangThai.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbbTrangThai.FormattingEnabled = true;
            cbbTrangThai.Items.AddRange(new object[] { "Đang sử dụng", "Đã trả thiết bị", "Hủy" });
            cbbTrangThai.Location = new Point(0, 43);
            cbbTrangThai.Name = "cbbTrangThai";
            cbbTrangThai.Size = new Size(220, 30);
            cbbTrangThai.TabIndex = 1;
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
            panel4.Controls.Add(dateTimeNgayTao);
            panel4.Controls.Add(label5);
            panel4.Location = new Point(32, 170);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(220, 73);
            panel4.TabIndex = 3;
            // 
            // dateTimeNgayTao
            // 
            dateTimeNgayTao.Dock = DockStyle.Bottom;
            dateTimeNgayTao.Enabled = false;
            dateTimeNgayTao.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimeNgayTao.Location = new Point(0, 51);
            dateTimeNgayTao.Name = "dateTimeNgayTao";
            dateTimeNgayTao.Size = new Size(220, 22);
            dateTimeNgayTao.TabIndex = 1;
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
            // btnSuaDauThietBi
            // 
            btnSuaDauThietBi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSuaDauThietBi.Location = new Point(692, 352);
            btnSuaDauThietBi.Name = "btnSuaDauThietBi";
            btnSuaDauThietBi.Size = new Size(100, 50);
            btnSuaDauThietBi.TabIndex = 14;
            btnSuaDauThietBi.Text = "Sửa đầu thiết bị";
            btnSuaDauThietBi.UseVisualStyleBackColor = true;
            btnSuaDauThietBi.Click += btnSuaDauThietBi_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtMaPhieu);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(32, 68);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(220, 73);
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
            txtMaPhieu.Size = new Size(220, 29);
            txtMaPhieu.TabIndex = 1;
            txtMaPhieu.Text = "abc";
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
            // btnXoaDauThietBi
            // 
            btnXoaDauThietBi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoaDauThietBi.Location = new Point(692, 432);
            btnXoaDauThietBi.Name = "btnXoaDauThietBi";
            btnXoaDauThietBi.Size = new Size(100, 50);
            btnXoaDauThietBi.TabIndex = 13;
            btnXoaDauThietBi.Text = "Xóa đầu thiết bị";
            btnXoaDauThietBi.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(387, 635);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(120, 40);
            btnSua.TabIndex = 11;
            btnSua.Text = "Sửa  phiếu";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnThem_Click;
            // 
            // btnThemDauThietBi
            // 
            btnThemDauThietBi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThemDauThietBi.Location = new Point(692, 272);
            btnThemDauThietBi.Name = "btnThemDauThietBi";
            btnThemDauThietBi.Size = new Size(100, 50);
            btnThemDauThietBi.TabIndex = 9;
            btnThemDauThietBi.Text = "Thêm đầu thiết bị";
            btnThemDauThietBi.UseVisualStyleBackColor = true;
            btnThemDauThietBi.Click += btnThemDauThietBi_Click;
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
            dataGrid.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGrid.ImeMode = ImeMode.NoControl;
            dataGrid.Location = new Point(32, 272);
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
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.Size = new Size(594, 300);
            dataGrid.TabIndex = 8;
            // 
            // Column1
            // 
            Column1.HeaderText = "Mã đầu thiết bị";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Trạng thái";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Ngày mượn";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Ngày trả";
            Column4.Name = "Column4";
            // 
            // panel3
            // 
            panel3.Controls.Add(cbbNguoiDung);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(632, 68);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(220, 73);
            panel3.TabIndex = 3;
            panel3.Paint += panel3_Paint;
            // 
            // cbbNguoiDung
            // 
            cbbNguoiDung.Dock = DockStyle.Bottom;
            cbbNguoiDung.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbNguoiDung.Enabled = false;
            cbbNguoiDung.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbbNguoiDung.FormattingEnabled = true;
            cbbNguoiDung.Location = new Point(0, 43);
            cbbNguoiDung.Name = "cbbNguoiDung";
            cbbNguoiDung.Size = new Size(220, 30);
            cbbNguoiDung.TabIndex = 1;
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
            panel1.Location = new Point(332, 68);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 73);
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
            txtMaThanhVien.Size = new Size(220, 29);
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
            label1.Size = new Size(884, 43);
            label1.TabIndex = 0;
            label1.Text = "Sửa phiếu mượn";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormSuaPhieuMuon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 687);
            Controls.Add(pnlContent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormSuaPhieuMuon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Suaphieumuon";
            Load += FormSuaThanhVien_Load;
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
        private Button btnThemDauThietBi;
        private Button btnSua;
        private Button btnXoaDauThietBi;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private ComboBox cbbNguoiDung;
        private Button btnSuaDauThietBi;
        private Panel panel2;
        private TextBox txtMaPhieu;
        private Label label3;
        private Panel panel4;
        private DateTimePicker dateTimeNgayTao;
        private Label label5;
        private Panel panel5;
        private ComboBox cbbTrangThai;
        private Label label6;
    }
}