namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_Menu
{
    partial class QuanLyPhieuXuPhat
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
            DataGrid = new DataGridView();
            pnlNavigate = new Panel();
            toDate = new DateTimePicker();
            label8 = new Label();
            fromDate = new DateTimePicker();
            label7 = new Label();
            label6 = new Label();
            comboBoxTrangThai = new ComboBox();
            panel6 = new Panel();
            lblCurrentPage = new Label();
            btnLast = new Button();
            btnNext = new Button();
            btnPrevious = new Button();
            btnFirst = new Button();
            btnReset = new Button();
            panel4 = new Panel();
            label4 = new Label();
            btnXoa = new PictureBox();
            panel3 = new Panel();
            label3 = new Label();
            btnThem = new PictureBox();
            panel2 = new Panel();
            label2 = new Label();
            btnXem = new PictureBox();
            panel1 = new Panel();
            label1 = new Label();
            btnEdit = new PictureBox();
            txtSearch = new TextBox();
            Id = new DataGridViewTextBoxColumn();
            IdThanhVien = new DataGridViewTextBoxColumn();
            TenThanhVien = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            NgayViPham = new DataGridViewTextBoxColumn();
            ThoiGianXuPhat = new DataGridViewTextBoxColumn();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            pnlNavigate.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnXoa).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnThem).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnXem).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnEdit).BeginInit();
            SuspendLayout();
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(DataGrid);
            pnlContent.Controls.Add(pnlNavigate);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 0);
            pnlContent.Margin = new Padding(4, 3, 4, 3);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1479, 1061);
            pnlContent.TabIndex = 0;
            // 
            // DataGrid
            // 
            DataGrid.AllowUserToAddRows = false;
            DataGrid.AllowUserToDeleteRows = false;
            DataGrid.AllowUserToOrderColumns = true;
            DataGrid.AllowUserToResizeColumns = false;
            DataGrid.AllowUserToResizeRows = false;
            DataGrid.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Gray;
            dataGridViewCellStyle1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGrid.Columns.AddRange(new DataGridViewColumn[] { Id, IdThanhVien, TenThanhVien, TrangThai, NgayViPham, ThoiGianXuPhat });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            DataGrid.Dock = DockStyle.Fill;
            DataGrid.Location = new Point(0, 274);
            DataGrid.Margin = new Padding(4, 3, 4, 3);
            DataGrid.Name = "DataGrid";
            DataGrid.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            DataGrid.RowTemplate.Height = 30;
            DataGrid.RowTemplate.ReadOnly = true;
            DataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGrid.Size = new Size(1479, 787);
            DataGrid.TabIndex = 1;
            DataGrid.CellContentClick += DataGrid_CellContentClick;
            // 
            // pnlNavigate
            // 
            pnlNavigate.BackColor = Color.White;
            pnlNavigate.Controls.Add(toDate);
            pnlNavigate.Controls.Add(label8);
            pnlNavigate.Controls.Add(fromDate);
            pnlNavigate.Controls.Add(label7);
            pnlNavigate.Controls.Add(label6);
            pnlNavigate.Controls.Add(comboBoxTrangThai);
            pnlNavigate.Controls.Add(panel6);
            pnlNavigate.Controls.Add(btnReset);
            pnlNavigate.Controls.Add(panel4);
            pnlNavigate.Controls.Add(panel3);
            pnlNavigate.Controls.Add(panel2);
            pnlNavigate.Controls.Add(panel1);
            pnlNavigate.Controls.Add(txtSearch);
            pnlNavigate.Dock = DockStyle.Top;
            pnlNavigate.Location = new Point(0, 0);
            pnlNavigate.Margin = new Padding(4, 3, 4, 3);
            pnlNavigate.Name = "pnlNavigate";
            pnlNavigate.Size = new Size(1479, 274);
            pnlNavigate.TabIndex = 0;
            // 
            // toDate
            // 
            toDate.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toDate.Location = new Point(794, 142);
            toDate.Name = "toDate";
            toDate.Size = new Size(262, 26);
            toDate.TabIndex = 18;
            toDate.ValueChanged += toDate_ValueChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(714, 148);
            label8.Name = "label8";
            label8.Size = new Size(74, 18);
            label8.TabIndex = 17;
            label8.Text = "Đến ngày";
            // 
            // fromDate
            // 
            fromDate.CalendarFont = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fromDate.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fromDate.Location = new Point(453, 142);
            fromDate.Name = "fromDate";
            fromDate.Size = new Size(255, 26);
            fromDate.TabIndex = 16;
            fromDate.ValueChanged += fromDate_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(345, 145);
            label7.Name = "label7";
            label7.Size = new Size(102, 18);
            label7.TabIndex = 15;
            label7.Text = "Ngày vi phạm";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 150);
            label6.Name = "label6";
            label6.Size = new Size(76, 18);
            label6.TabIndex = 14;
            label6.Text = "Trạng thái";
            // 
            // comboBoxTrangThai
            // 
            comboBoxTrangThai.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxTrangThai.FormattingEnabled = true;
            comboBoxTrangThai.Location = new Point(98, 142);
            comboBoxTrangThai.Name = "comboBoxTrangThai";
            comboBoxTrangThai.Size = new Size(200, 26);
            comboBoxTrangThai.TabIndex = 13;
            comboBoxTrangThai.SelectedIndexChanged += comboBoxTrangThai_SelectedIndexChanged;
            // 
            // panel6
            // 
            panel6.Controls.Add(lblCurrentPage);
            panel6.Controls.Add(btnLast);
            panel6.Controls.Add(btnNext);
            panel6.Controls.Add(btnPrevious);
            panel6.Controls.Add(btnFirst);
            panel6.Location = new Point(14, 214);
            panel6.Name = "panel6";
            panel6.Size = new Size(413, 37);
            panel6.TabIndex = 12;
            panel6.Paint += panel6_Paint;
            // 
            // lblCurrentPage
            // 
            lblCurrentPage.AutoSize = true;
            lblCurrentPage.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentPage.Location = new Point(204, 12);
            lblCurrentPage.Name = "lblCurrentPage";
            lblCurrentPage.Size = new Size(0, 18);
            lblCurrentPage.TabIndex = 4;
            // 
            // btnLast
            // 
            btnLast.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLast.Location = new Point(335, 10);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(75, 23);
            btnLast.TabIndex = 3;
            btnLast.Text = "Last";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += btnLast_Click;
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNext.ImageAlign = ContentAlignment.MiddleRight;
            btnNext.Location = new Point(254, 10);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 2;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrevious.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrevious.Location = new Point(84, 10);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(75, 23);
            btnPrevious.TabIndex = 1;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnFirst
            // 
            btnFirst.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFirst.Location = new Point(3, 10);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(75, 23);
            btnFirst.TabIndex = 0;
            btnFirst.Text = "First";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += btnFirst_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(0, 123, 181);
            btnReset.Cursor = Cursors.Hand;
            btnReset.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(371, 51);
            btnReset.Margin = new Padding(4, 3, 4, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(76, 37);
            btnReset.TabIndex = 4;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(label4);
            panel4.Controls.Add(btnXoa);
            panel4.Location = new Point(1349, 12);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(117, 115);
            panel4.TabIndex = 3;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Bottom;
            label4.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 84);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(117, 31);
            label4.TabIndex = 1;
            label4.Text = "Xóa";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnXoa
            // 
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.Dock = DockStyle.Top;
            btnXoa.Image = Properties.Resources.xoa;
            btnXoa.Location = new Point(0, 0);
            btnXoa.Margin = new Padding(4, 3, 4, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(117, 81);
            btnXoa.SizeMode = PictureBoxSizeMode.Zoom;
            btnXoa.TabIndex = 0;
            btnXoa.TabStop = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Controls.Add(btnThem);
            panel3.Location = new Point(974, 12);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(117, 115);
            panel3.TabIndex = 3;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Bottom;
            label3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 84);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(117, 31);
            label3.TabIndex = 1;
            label3.Text = "Thêm";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnThem
            // 
            btnThem.Cursor = Cursors.Hand;
            btnThem.Dock = DockStyle.Top;
            btnThem.Image = Properties.Resources.them;
            btnThem.Location = new Point(0, 0);
            btnThem.Margin = new Padding(4, 3, 4, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(117, 81);
            btnThem.SizeMode = PictureBoxSizeMode.Zoom;
            btnThem.TabIndex = 0;
            btnThem.TabStop = false;
            btnThem.Click += btnThem_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(btnXem);
            panel2.Location = new Point(1224, 12);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(117, 115);
            panel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Bottom;
            label2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 84);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(117, 31);
            label2.TabIndex = 1;
            label2.Text = "Xem";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnXem
            // 
            btnXem.Cursor = Cursors.Hand;
            btnXem.Dock = DockStyle.Top;
            btnXem.Image = Properties.Resources.chitiet;
            btnXem.Location = new Point(0, 0);
            btnXem.Margin = new Padding(4, 3, 4, 3);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(117, 81);
            btnXem.SizeMode = PictureBoxSizeMode.Zoom;
            btnXem.TabIndex = 0;
            btnXem.TabStop = false;
            btnXem.Click += btnXem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnEdit);
            panel1.Location = new Point(1099, 12);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(117, 115);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Bottom;
            label1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 84);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(117, 31);
            label1.TabIndex = 1;
            label1.Text = "Sửa";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnEdit
            // 
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Dock = DockStyle.Top;
            btnEdit.Image = Properties.Resources.sua;
            btnEdit.Location = new Point(0, 0);
            btnEdit.Margin = new Padding(4, 3, 4, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(117, 81);
            btnEdit.SizeMode = PictureBoxSizeMode.Zoom;
            btnEdit.TabIndex = 0;
            btnEdit.TabStop = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(14, 57);
            txtSearch.Margin = new Padding(4, 3, 4, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(349, 26);
            txtSearch.TabIndex = 0;
            txtSearch.Text = "Tìm kiếm";
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // Id
            // 
            Id.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Id.HeaderText = "Mã phiếu";
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // IdThanhVien
            // 
            IdThanhVien.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            IdThanhVien.HeaderText = "Mã thành viên";
            IdThanhVien.Name = "IdThanhVien";
            IdThanhVien.ReadOnly = true;
            // 
            // TenThanhVien
            // 
            TenThanhVien.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TenThanhVien.HeaderText = "Tên thành viên";
            TenThanhVien.Name = "TenThanhVien";
            TenThanhVien.ReadOnly = true;
            // 
            // TrangThai
            // 
            TrangThai.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TrangThai.HeaderText = "Trạng thái";
            TrangThai.Name = "TrangThai";
            // 
            // NgayViPham
            // 
            NgayViPham.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NgayViPham.HeaderText = "Ngày vi phạm";
            NgayViPham.Name = "NgayViPham";
            // 
            // ThoiGianXuPhat
            // 
            ThoiGianXuPhat.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ThoiGianXuPhat.HeaderText = "Số ngày xử phạt";
            ThoiGianXuPhat.Name = "ThoiGianXuPhat";
            // 
            // QuanLyPhieuXuPhat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1479, 1061);
            Controls.Add(pnlContent);
            Margin = new Padding(4, 3, 4, 3);
            Name = "QuanLyPhieuXuPhat";
            Text = "QuanLyPhieuXuPhat";
            Load += QuanLyPhieuXuPhat_Load;
            pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            pnlNavigate.ResumeLayout(false);
            pnlNavigate.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnXoa).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnThem).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnXem).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnEdit).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlNavigate;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnXem;
        private System.Windows.Forms.DataGridView DataGrid;
        private Panel panel3;
        private Label label3;
        private PictureBox btnThem;
        private Panel panel4;
        private Label label4;
        private PictureBox btnXoa;
        private Button btnReset;
        private Panel panel6;
        private Label lblCurrentPage;
        private Button btnLast;
        private Button btnNext;
        private Button btnPrevious;
        private Button btnFirst;
        private ComboBox comboBoxTrangThai;
        private Label label6;
        private Label label7;
        private DateTimePicker fromDate;
        private Label label8;
        private DateTimePicker toDate;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn IdThanhVien;
        private DataGridViewTextBoxColumn TenThanhVien;
        private DataGridViewTextBoxColumn TrangThai;
        private DataGridViewTextBoxColumn NgayViPham;
        private DataGridViewTextBoxColumn ThoiGianXuPhat;
    }
}