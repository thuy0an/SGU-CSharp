namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_Menu
{
    partial class QuanLyPhieuMuon
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
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            pnlNavigate = new Panel();
            panel6 = new Panel();
            lblCurrentPage = new Label();
            btnLast = new Button();
            btnNext = new Button();
            btnPrevious = new Button();
            btnFirst = new Button();
            label8 = new Label();
            label7 = new Label();
            toDate = new DateTimePicker();
            fromDate = new DateTimePicker();
            label6 = new Label();
            comboBoxTrangThai = new ComboBox();
            btnReset = new Button();
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
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            pnlNavigate.SuspendLayout();
            panel6.SuspendLayout();
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
            DataGrid.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            DataGrid.Dock = DockStyle.Fill;
            DataGrid.Location = new Point(0, 270);
            DataGrid.Margin = new Padding(4, 3, 4, 3);
            DataGrid.Name = "DataGrid";
            DataGrid.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            DataGrid.RowTemplate.Height = 30;
            DataGrid.RowTemplate.ReadOnly = true;
            DataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGrid.Size = new Size(1479, 791);
            DataGrid.TabIndex = 1;
            DataGrid.CellContentClick += DataGrid_CellContentClick;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.DataPropertyName = "Id";
            Column1.HeaderText = "Mã phiếu";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.DataPropertyName = "IdThanhVien";
            Column2.HeaderText = "Mã thành viên";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.DataPropertyName = "TenThanhVien";
            Column3.HeaderText = "Tên thành viên";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.DataPropertyName = "NgayTao";
            Column4.HeaderText = "Ngày tạo";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column5.DataPropertyName = "TrangThai";
            Column5.HeaderText = "Trạng thái";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // pnlNavigate
            // 
            pnlNavigate.BackColor = Color.White;
            pnlNavigate.Controls.Add(panel6);
            pnlNavigate.Controls.Add(label8);
            pnlNavigate.Controls.Add(label7);
            pnlNavigate.Controls.Add(toDate);
            pnlNavigate.Controls.Add(fromDate);
            pnlNavigate.Controls.Add(label6);
            pnlNavigate.Controls.Add(comboBoxTrangThai);
            pnlNavigate.Controls.Add(btnReset);
            pnlNavigate.Controls.Add(panel3);
            pnlNavigate.Controls.Add(panel2);
            pnlNavigate.Controls.Add(panel1);
            pnlNavigate.Controls.Add(txtSearch);
            pnlNavigate.Dock = DockStyle.Top;
            pnlNavigate.Location = new Point(0, 0);
            pnlNavigate.Margin = new Padding(4, 3, 4, 3);
            pnlNavigate.Name = "pnlNavigate";
            pnlNavigate.Size = new Size(1479, 270);
            pnlNavigate.TabIndex = 0;
            pnlNavigate.Paint += pnlNavigate_Paint;
            // 
            // panel6
            // 
            panel6.Controls.Add(lblCurrentPage);
            panel6.Controls.Add(btnLast);
            panel6.Controls.Add(btnNext);
            panel6.Controls.Add(btnPrevious);
            panel6.Controls.Add(btnFirst);
            panel6.Location = new Point(14, 196);
            panel6.Name = "panel6";
            panel6.Size = new Size(413, 37);
            panel6.TabIndex = 11;
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
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(653, 143);
            label8.Name = "label8";
            label8.Size = new Size(74, 18);
            label8.TabIndex = 10;
            label8.Text = "Den ngay";
            label8.Click += label8_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(322, 143);
            label7.Name = "label7";
            label7.Size = new Size(61, 18);
            label7.TabIndex = 9;
            label7.Text = "Tu ngay";
            // 
            // toDate
            // 
            toDate.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toDate.Location = new Point(733, 137);
            toDate.Name = "toDate";
            toDate.Size = new Size(262, 26);
            toDate.TabIndex = 8;
            toDate.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // fromDate
            // 
            fromDate.CalendarFont = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fromDate.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fromDate.Location = new Point(389, 137);
            fromDate.Name = "fromDate";
            fromDate.Size = new Size(255, 26);
            fromDate.TabIndex = 7;
            fromDate.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 143);
            label6.Name = "label6";
            label6.Size = new Size(76, 18);
            label6.TabIndex = 6;
            label6.Text = "Trang thai";
            label6.Click += label6_Click;
            // 
            // comboBoxTrangThai
            // 
            comboBoxTrangThai.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxTrangThai.FormattingEnabled = true;
            comboBoxTrangThai.Location = new Point(94, 137);
            comboBoxTrangThai.Name = "comboBoxTrangThai";
            comboBoxTrangThai.Size = new Size(200, 26);
            comboBoxTrangThai.TabIndex = 5;
            comboBoxTrangThai.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Controls.Add(btnThem);
            panel3.Location = new Point(1102, 12);
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
            panel2.Location = new Point(1352, 12);
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
            panel1.Location = new Point(1227, 12);
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
            // QuanLyPhieuMuon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1479, 1061);
            Controls.Add(pnlContent);
            Margin = new Padding(4, 3, 4, 3);
            Name = "QuanLyPhieuMuon";
            Text = "QuanLyPhieuMuon";
            Load += QuanLyPhieuMuon_Load;
            pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            pnlNavigate.ResumeLayout(false);
            pnlNavigate.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
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
        private Button btnReset;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private ComboBox comboBoxTrangThai;
        private Label label6;
        private DateTimePicker toDate;
        private DateTimePicker fromDate;
        private Label label8;
        private Label label7;
        private Panel panel6;
        private Button btnLast;
        private Button btnNext;
        private Button btnPrevious;
        private Button btnFirst;
        private Label lblCurrentPage;
    }
}