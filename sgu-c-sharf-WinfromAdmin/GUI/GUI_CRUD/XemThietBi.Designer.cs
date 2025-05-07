namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    partial class FormXemThietBi
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
            label3 = new Label();
            panel7 = new Panel();
            txtTenLoaiThietBi = new TextBox();
            label8 = new Label();
            dataGrid = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            txtTenThietBi = new TextBox();
            label4 = new Label();
            panel1 = new Panel();
            txtMaThietBi = new TextBox();
            label2 = new Label();
            label1 = new Label();
            pnlContent.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(label3);
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(121, 326);
            label3.Name = "label3";
            label3.Size = new Size(230, 22);
            label3.TabIndex = 10;
            label3.Text = "Danh sách các đầu thiết bị";
            // 
            // panel7
            // 
            panel7.Controls.Add(txtTenLoaiThietBi);
            panel7.Controls.Add(label8);
            panel7.Location = new Point(120, 224);
            panel7.Margin = new Padding(4, 3, 4, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(500, 73);
            panel7.TabIndex = 6;
            // 
            // txtTenLoaiThietBi
            // 
            txtTenLoaiThietBi.Dock = DockStyle.Bottom;
            txtTenLoaiThietBi.Enabled = false;
            txtTenLoaiThietBi.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenLoaiThietBi.Location = new Point(0, 44);
            txtTenLoaiThietBi.Name = "txtTenLoaiThietBi";
            txtTenLoaiThietBi.Size = new Size(500, 29);
            txtTenLoaiThietBi.TabIndex = 1;
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
            dataGrid.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3 });
            dataGrid.ImeMode = ImeMode.NoControl;
            dataGrid.Location = new Point(0, 368);
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
            // Column2
            // 
            Column2.HeaderText = "Trạng thái";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Thời gian mua";
            Column3.Name = "Column3";
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
            panel3.Paint += panel3_Paint;
            // 
            // txtTenThietBi
            // 
            txtTenThietBi.Dock = DockStyle.Bottom;
            txtTenThietBi.Enabled = false;
            txtTenThietBi.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenThietBi.Location = new Point(0, 44);
            txtTenThietBi.Margin = new Padding(4, 3, 4, 3);
            txtTenThietBi.Name = "txtTenThietBi";
            txtTenThietBi.Size = new Size(500, 29);
            txtTenThietBi.TabIndex = 1;
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
            panel1.Paint += panel1_Paint;
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
            label1.Text = "Xem thiết bị";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormXemThietBi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 746);
            Controls.Add(pnlContent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormXemThietBi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "XemThietBi";
            Load += FormSuaThanhVien_Load;
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
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
        private System.Windows.Forms.TextBox txtMaThietBi;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtTenThietBi;
        private System.Windows.Forms.Label label4;
        private DataGridView dataGrid;
        private Panel panel7;
        private Label label8;
        private System.Windows.Forms.TextBox txtTenLoaiThietBi;
        private Label label3;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
    }
}