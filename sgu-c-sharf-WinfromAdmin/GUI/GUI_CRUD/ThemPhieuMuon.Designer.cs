namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    partial class FormThemPhieuMuon
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
            btnXoaDauThietBi = new Button();
            btnThem = new Button();
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
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(btnXoaDauThietBi);
            pnlContent.Controls.Add(btnThem);
            pnlContent.Controls.Add(btnThemDauThietBi);
            pnlContent.Controls.Add(dataGrid);
            pnlContent.Controls.Add(panel3);
            pnlContent.Controls.Add(panel1);
            pnlContent.Controls.Add(label1);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 0);
            pnlContent.Margin = new Padding(4, 3, 4, 3);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(740, 594);
            pnlContent.TabIndex = 0;
            pnlContent.Paint += pnlContent_Paint;
            // 
            // btnXoaDauThietBi
            // 
            btnXoaDauThietBi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoaDauThietBi.Location = new Point(628, 224);
            btnXoaDauThietBi.Name = "btnXoaDauThietBi";
            btnXoaDauThietBi.Size = new Size(100, 50);
            btnXoaDauThietBi.TabIndex = 13;
            btnXoaDauThietBi.Text = "Xóa đầu thiết bị";
            btnXoaDauThietBi.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(310, 525);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 40);
            btnThem.TabIndex = 11;
            btnThem.Text = "Tạo phiếu";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnThemDauThietBi
            // 
            btnThemDauThietBi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThemDauThietBi.Location = new Point(628, 168);
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
            dataGrid.Location = new Point(3, 168);
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
            dataGrid.Size = new Size(620, 300);
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
            panel3.Location = new Point(417, 68);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(250, 73);
            panel3.TabIndex = 3;
            panel3.Paint += panel3_Paint;
            // 
            // cbbNguoiDung
            // 
            cbbNguoiDung.Dock = DockStyle.Bottom;
            cbbNguoiDung.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbNguoiDung.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbbNguoiDung.FormattingEnabled = true;
            cbbNguoiDung.Location = new Point(0, 43);
            cbbNguoiDung.Name = "cbbNguoiDung";
            cbbNguoiDung.Size = new Size(250, 30);
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
            panel1.Location = new Point(73, 68);
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
            txtMaThanhVien.Size = new Size(250, 29);
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
            label1.Size = new Size(740, 43);
            label1.TabIndex = 0;
            label1.Text = "Tạo phiếu mượn";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormThemPhieuMuon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 594);
            Controls.Add(pnlContent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormThemPhieuMuon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Themphieumuon";
            Load += FormSuaThanhVien_Load;
            pnlContent.ResumeLayout(false);
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
        private Button btnThem;
        private Button btnXoaDauThietBi;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private ComboBox cbbNguoiDung;
    }
}