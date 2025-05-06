namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_Menu
{
    partial class QuanLyPhieuDatCho
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
            Column5 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            pnlNavigate = new Panel();
            panel3 = new Panel();
            label3 = new Label();
            btnXoa = new PictureBox();
            panel2 = new Panel();
            label2 = new Label();
            btnXem = new PictureBox();
            panel1 = new Panel();
            label1 = new Label();
            btnEdit = new PictureBox();
            btnReset = new Button();
            txtSearch = new TextBox();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            pnlNavigate.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnXoa).BeginInit();
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
            DataGrid.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column5, Column4 });
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            DataGrid.RowTemplate.Height = 30;
            DataGrid.RowTemplate.ReadOnly = true;
            DataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGrid.Size = new Size(1479, 923);
            DataGrid.TabIndex = 1;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "Mã phiếu đặt chỗ";
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
            Column3.HeaderText = "Thời gian đặt";
            Column3.Name = "Column3";
            // 
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column5.HeaderText = "Thời gian lập phiếu";
            Column5.Name = "Column5";
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.HeaderText = "Trạng thái";
            Column4.Name = "Column4";
            // 
            // pnlNavigate
            // 
            pnlNavigate.BackColor = Color.White;
            pnlNavigate.Controls.Add(panel3);
            pnlNavigate.Controls.Add(panel2);
            pnlNavigate.Controls.Add(panel1);
            pnlNavigate.Controls.Add(btnReset);
            pnlNavigate.Controls.Add(txtSearch);
            pnlNavigate.Dock = DockStyle.Top;
            pnlNavigate.Location = new Point(0, 0);
            pnlNavigate.Margin = new Padding(4, 3, 4, 3);
            pnlNavigate.Name = "pnlNavigate";
            pnlNavigate.Size = new Size(1479, 138);
            pnlNavigate.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Controls.Add(btnXoa);
            panel3.Location = new Point(1357, 14);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(117, 115);
            panel3.TabIndex = 3;
            panel3.Paint += panel3_Paint;
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
            label3.Text = "Xóa";
            label3.TextAlign = ContentAlignment.MiddleCenter;
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
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(btnXem);
            panel2.Location = new Point(1212, 14);
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
            btnXem.Click += pictureBox1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnEdit);
            panel1.Location = new Point(1068, 14);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(117, 115);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
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
            label1.Click += label1_Click;
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
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(0, 123, 181);
            btnReset.Cursor = Cursors.Hand;
            btnReset.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(371, 53);
            btnReset.Margin = new Padding(4, 3, 4, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(76, 37);
            btnReset.TabIndex = 1;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
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
            // QuanLyPhieuDatCho
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1479, 1061);
            Controls.Add(pnlContent);
            Margin = new Padding(4, 3, 4, 3);
            Name = "QuanLyPhieuDatCho";
            Text = "QuanLyPhieuDatCho";
            Load += QuanLyPhieuDatCho_Load;
            pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            pnlNavigate.ResumeLayout(false);
            pnlNavigate.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnXoa).EndInit();
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
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox btnXoa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnXem;
        private System.Windows.Forms.DataGridView DataGrid;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column4;
    }
} 