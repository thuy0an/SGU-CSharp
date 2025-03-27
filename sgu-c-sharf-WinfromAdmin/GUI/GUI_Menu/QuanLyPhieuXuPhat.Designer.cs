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
            pnlContent = new Panel();
            DataGrid = new DataGridView();
            pnlNavigate = new Panel();
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
            panel5 = new Panel();
            label5 = new Label();
            btnPDF = new PictureBox();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            pnlNavigate.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnXoa).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnThem).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnXem).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnEdit).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnPDF).BeginInit();
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
            DataGrid.Location = new Point(0, 138);
            DataGrid.Margin = new Padding(4, 3, 4, 3);
            DataGrid.Name = "DataGrid";
            DataGrid.RowHeadersVisible = false;
            DataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGrid.Size = new Size(1479, 923);
            DataGrid.TabIndex = 1;
            // 
            // pnlNavigate
            // 
            pnlNavigate.BackColor = Color.White;
            pnlNavigate.Controls.Add(panel5);
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
            pnlNavigate.Size = new Size(1479, 138);
            pnlNavigate.TabIndex = 0;
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
            panel4.Location = new Point(1228, 12);
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
            panel3.Location = new Point(835, 12);
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
            panel2.Location = new Point(1097, 12);
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
            panel1.Location = new Point(966, 12);
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
            // 
            // panel5
            // 
            panel5.Controls.Add(label5);
            panel5.Controls.Add(btnPDF);
            panel5.Location = new Point(1359, 12);
            panel5.Margin = new Padding(4, 3, 4, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(117, 115);
            panel5.TabIndex = 4;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Bottom;
            label5.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(0, 84);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(117, 31);
            label5.TabIndex = 1;
            label5.Text = "Xuất file";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPDF
            // 
            btnPDF.Cursor = Cursors.Hand;
            btnPDF.Dock = DockStyle.Top;
            btnPDF.Image = Properties.Resources.pdf;
            btnPDF.Location = new Point(0, 0);
            btnPDF.Margin = new Padding(4, 3, 4, 3);
            btnPDF.Name = "btnPDF";
            btnPDF.Size = new Size(117, 81);
            btnPDF.SizeMode = PictureBoxSizeMode.Zoom;
            btnPDF.TabIndex = 0;
            btnPDF.TabStop = false;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "Mã phiếu";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "Mã thành viên";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.HeaderText = "Trạng thái";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.HeaderText = "Ngày vi phạm";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column5.HeaderText = "Thời gian xử phạt";
            Column5.Name = "Column5";
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
            pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            pnlNavigate.ResumeLayout(false);
            pnlNavigate.PerformLayout();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnXoa).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnThem).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnXem).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnEdit).EndInit();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnPDF).EndInit();
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
        private Panel panel5;
        private Label label5;
        private PictureBox btnPDF;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
    }
}