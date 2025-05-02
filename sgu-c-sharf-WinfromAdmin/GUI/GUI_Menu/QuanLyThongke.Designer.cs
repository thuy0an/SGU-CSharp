namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_Menu
{
    partial class QuanLyThongKe
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            tabTKThanhVien = new TabPage();
            btnTK = new Button();
            DataGridTV = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            lblCount = new Label();
            btnReset = new Button();
            label8 = new Label();
            label7 = new Label();
            toDate = new DateTimePicker();
            fromDate = new DateTimePicker();
            label6 = new Label();
            cbbThanhVien = new ComboBox();
            tabTKThietBi = new TabPage();
            DataGridTB = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            lblSD = new Label();
            lblKD = new Label();
            lblTong = new Label();
            label1 = new Label();
            cbbThietBi = new ComboBox();
            tabTKXuPhat = new TabPage();
            comboBox1 = new ComboBox();
            label2 = new Label();
            lblTongTien = new Label();
            dataGridView1 = new DataGridView();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            tabControl1.SuspendLayout();
            tabTKThanhVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridTV).BeginInit();
            tabTKThietBi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridTB).BeginInit();
            tabTKXuPhat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabTKThanhVien);
            tabControl1.Controls.Add(tabTKThietBi);
            tabControl1.Controls.Add(tabTKXuPhat);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1479, 1061);
            tabControl1.TabIndex = 0;
            // 
            // tabTKThanhVien
            // 
            tabTKThanhVien.BackColor = Color.White;
            tabTKThanhVien.Controls.Add(btnTK);
            tabTKThanhVien.Controls.Add(DataGridTV);
            tabTKThanhVien.Controls.Add(lblCount);
            tabTKThanhVien.Controls.Add(btnReset);
            tabTKThanhVien.Controls.Add(label8);
            tabTKThanhVien.Controls.Add(label7);
            tabTKThanhVien.Controls.Add(toDate);
            tabTKThanhVien.Controls.Add(fromDate);
            tabTKThanhVien.Controls.Add(label6);
            tabTKThanhVien.Controls.Add(cbbThanhVien);
            tabTKThanhVien.Location = new Point(4, 31);
            tabTKThanhVien.Name = "tabTKThanhVien";
            tabTKThanhVien.Padding = new Padding(3);
            tabTKThanhVien.Size = new Size(1471, 1026);
            tabTKThanhVien.TabIndex = 0;
            tabTKThanhVien.Text = "Thống kê thành viên";
            // 
            // btnTK
            // 
            btnTK.BackColor = Color.FromArgb(0, 123, 181);
            btnTK.Cursor = Cursors.Hand;
            btnTK.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTK.ForeColor = Color.White;
            btnTK.Location = new Point(1174, 117);
            btnTK.Margin = new Padding(4, 3, 4, 3);
            btnTK.Name = "btnTK";
            btnTK.Size = new Size(95, 37);
            btnTK.TabIndex = 21;
            btnTK.Text = "Thống kê";
            btnTK.UseVisualStyleBackColor = false;
            btnTK.Click += btnTK_Click;
            // 
            // DataGridTV
            // 
            DataGridTV.AllowUserToAddRows = false;
            DataGridTV.AllowUserToDeleteRows = false;
            DataGridTV.AllowUserToOrderColumns = true;
            DataGridTV.AllowUserToResizeColumns = false;
            DataGridTV.AllowUserToResizeRows = false;
            DataGridTV.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Gray;
            dataGridViewCellStyle1.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DataGridTV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DataGridTV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridTV.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column5 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DataGridTV.DefaultCellStyle = dataGridViewCellStyle2;
            DataGridTV.Dock = DockStyle.Bottom;
            DataGridTV.Location = new Point(3, 298);
            DataGridTV.Margin = new Padding(4, 3, 4, 3);
            DataGridTV.Name = "DataGridTV";
            DataGridTV.RowHeadersVisible = false;
            DataGridTV.RowTemplate.Height = 30;
            DataGridTV.RowTemplate.ReadOnly = true;
            DataGridTV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridTV.Size = new Size(1465, 725);
            DataGridTV.TabIndex = 20;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.DataPropertyName = "Id";
            Column1.HeaderText = "STT";
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
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column5.DataPropertyName = "TrangThai";
            Column5.HeaderText = "Thời gian CheckIn";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Font = new Font("Arial", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCount.ForeColor = Color.FromArgb(0, 123, 181);
            lblCount.Location = new Point(510, 210);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(450, 32);
            lblCount.TabIndex = 19;
            lblCount.Text = "Tổng số thành viên đã đến quán:";
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(0, 123, 181);
            btnReset.Cursor = Cursors.Hand;
            btnReset.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(693, 35);
            btnReset.Margin = new Padding(4, 3, 4, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(95, 37);
            btnReset.TabIndex = 17;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 14.25F);
            label8.Location = new Point(693, 123);
            label8.Name = "label8";
            label8.Size = new Size(95, 22);
            label8.TabIndex = 16;
            label8.Text = "Đến ngày:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 14.25F);
            label7.Location = new Point(202, 123);
            label7.Name = "label7";
            label7.Size = new Size(85, 22);
            label7.TabIndex = 15;
            label7.Text = "Từ ngày:";
            // 
            // toDate
            // 
            toDate.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toDate.Location = new Point(816, 120);
            toDate.Name = "toDate";
            toDate.Size = new Size(334, 29);
            toDate.TabIndex = 14;
            // 
            // fromDate
            // 
            fromDate.CalendarFont = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fromDate.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fromDate.Location = new Point(320, 120);
            fromDate.Name = "fromDate";
            fromDate.Size = new Size(334, 29);
            fromDate.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 14.25F);
            label6.Location = new Point(202, 45);
            label6.Name = "label6";
            label6.Size = new Size(106, 22);
            label6.TabIndex = 12;
            label6.Text = "Thành viên:";
            // 
            // cbbThanhVien
            // 
            cbbThanhVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbThanhVien.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbbThanhVien.FormattingEnabled = true;
            cbbThanhVien.Location = new Point(320, 41);
            cbbThanhVien.Name = "cbbThanhVien";
            cbbThanhVien.Size = new Size(334, 26);
            cbbThanhVien.TabIndex = 11;
            cbbThanhVien.SelectedIndexChanged += cbbThanhVien_SelectedIndexChanged;
            // 
            // tabTKThietBi
            // 
            tabTKThietBi.BackColor = Color.White;
            tabTKThietBi.Controls.Add(DataGridTB);
            tabTKThietBi.Controls.Add(lblSD);
            tabTKThietBi.Controls.Add(lblKD);
            tabTKThietBi.Controls.Add(lblTong);
            tabTKThietBi.Controls.Add(label1);
            tabTKThietBi.Controls.Add(cbbThietBi);
            tabTKThietBi.Location = new Point(4, 31);
            tabTKThietBi.Name = "tabTKThietBi";
            tabTKThietBi.Padding = new Padding(3);
            tabTKThietBi.Size = new Size(1471, 1026);
            tabTKThietBi.TabIndex = 1;
            tabTKThietBi.Text = "Thống kê thiết bị";
            // 
            // DataGridTB
            // 
            DataGridTB.AllowUserToAddRows = false;
            DataGridTB.AllowUserToDeleteRows = false;
            DataGridTB.AllowUserToOrderColumns = true;
            DataGridTB.AllowUserToResizeColumns = false;
            DataGridTB.AllowUserToResizeRows = false;
            DataGridTB.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.Gray;
            dataGridViewCellStyle3.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            DataGridTB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            DataGridTB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridTB.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            DataGridTB.DefaultCellStyle = dataGridViewCellStyle4;
            DataGridTB.Dock = DockStyle.Bottom;
            DataGridTB.Location = new Point(3, 298);
            DataGridTB.Margin = new Padding(4, 3, 4, 3);
            DataGridTB.Name = "DataGridTB";
            DataGridTB.RowHeadersVisible = false;
            DataGridTB.RowTemplate.Height = 30;
            DataGridTB.RowTemplate.ReadOnly = true;
            DataGridTB.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridTB.Size = new Size(1465, 725);
            DataGridTB.TabIndex = 21;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            dataGridViewTextBoxColumn1.HeaderText = "STT";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn2.DataPropertyName = "IdThanhVien";
            dataGridViewTextBoxColumn2.HeaderText = "Tên thiết bị";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn3.DataPropertyName = "TenThanhVien";
            dataGridViewTextBoxColumn3.HeaderText = "Mã đầu thiết bị";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn4.DataPropertyName = "TrangThai";
            dataGridViewTextBoxColumn4.HeaderText = "Trạng thái";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // lblSD
            // 
            lblSD.AutoSize = true;
            lblSD.Font = new Font("Arial", 14.25F);
            lblSD.Location = new Point(878, 195);
            lblSD.Name = "lblSD";
            lblSD.Size = new Size(247, 22);
            lblSD.TabIndex = 17;
            lblSD.Text = "Số lượng đang đặt/sử dụng:";
            // 
            // lblKD
            // 
            lblKD.AutoSize = true;
            lblKD.Font = new Font("Arial", 14.25F);
            lblKD.Location = new Point(554, 195);
            lblKD.Name = "lblKD";
            lblKD.Size = new Size(175, 22);
            lblKD.TabIndex = 16;
            lblKD.Text = "Số lượng khả dụng:";
            // 
            // lblTong
            // 
            lblTong.AutoSize = true;
            lblTong.Font = new Font("Arial", 14.25F);
            lblTong.Location = new Point(205, 195);
            lblTong.Name = "lblTong";
            lblTong.Size = new Size(200, 22);
            lblTong.TabIndex = 15;
            lblTong.Text = "Tổng số lượng thiết bị:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F);
            label1.Location = new Point(249, 95);
            label1.Name = "label1";
            label1.Size = new Size(156, 22);
            label1.TabIndex = 14;
            label1.Text = "Thiết bị thư quán:";
            // 
            // cbbThietBi
            // 
            cbbThietBi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbThietBi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbbThietBi.FormattingEnabled = true;
            cbbThietBi.Location = new Point(509, 93);
            cbbThietBi.Name = "cbbThietBi";
            cbbThietBi.Size = new Size(334, 26);
            cbbThietBi.TabIndex = 13;
            cbbThietBi.SelectedIndexChanged += cbbThietBi_SelectedIndexChanged;
            // 
            // tabTKXuPhat
            // 
            tabTKXuPhat.BackColor = Color.White;
            tabTKXuPhat.Controls.Add(comboBox1);
            tabTKXuPhat.Controls.Add(label2);
            tabTKXuPhat.Controls.Add(lblTongTien);
            tabTKXuPhat.Controls.Add(dataGridView1);
            tabTKXuPhat.Location = new Point(4, 31);
            tabTKXuPhat.Name = "tabTKXuPhat";
            tabTKXuPhat.Padding = new Padding(3);
            tabTKXuPhat.Size = new Size(1471, 1026);
            tabTKXuPhat.TabIndex = 2;
            tabTKXuPhat.Text = "Xử lý vi phạm";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(338, 86);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(334, 26);
            comboBox1.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(79, 88);
            label2.Name = "label2";
            label2.Size = new Size(240, 24);
            label2.TabIndex = 26;
            label2.Text = "Trạng thái phiếu xử phạt:";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongTien.ForeColor = Color.FromArgb(0, 123, 181);
            lblTongTien.Location = new Point(523, 234);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(424, 32);
            lblTongTien.TabIndex = 23;
            lblTongTien.Text = "Tổng số tiền đã được bồi thường:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.Gray;
            dataGridViewCellStyle5.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, Column4, Column6, Column7 });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(3, 298);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.RowTemplate.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1465, 725);
            dataGridView1.TabIndex = 22;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn5.DataPropertyName = "Id";
            dataGridViewTextBoxColumn5.HeaderText = "STT";
            dataGridViewTextBoxColumn5.MinimumWidth = 50;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn6.DataPropertyName = "IdThanhVien";
            dataGridViewTextBoxColumn6.HeaderText = "Mã vi phạm";
            dataGridViewTextBoxColumn6.MinimumWidth = 140;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn7.DataPropertyName = "TenThanhVien";
            dataGridViewTextBoxColumn7.HeaderText = "Tên thành viên";
            dataGridViewTextBoxColumn7.MinimumWidth = 300;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn8.DataPropertyName = "TrangThai";
            dataGridViewTextBoxColumn8.HeaderText = "Mô tả";
            dataGridViewTextBoxColumn8.MinimumWidth = 400;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Ngày vi phạm";
            Column4.MinimumWidth = 200;
            Column4.Name = "Column4";
            Column4.Width = 200;
            // 
            // Column6
            // 
            Column6.HeaderText = "Mức phạt";
            Column6.MinimumWidth = 200;
            Column6.Name = "Column6";
            Column6.Width = 200;
            // 
            // Column7
            // 
            Column7.HeaderText = "Trạng thái";
            Column7.MinimumWidth = 200;
            Column7.Name = "Column7";
            Column7.Width = 200;
            // 
            // QuanLyThongKe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1479, 1061);
            Controls.Add(tabControl1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "QuanLyThongKe";
            Text = "QuanLyThongKe";
            Load += QuanLyThongKe_Load;
            tabControl1.ResumeLayout(false);
            tabTKThanhVien.ResumeLayout(false);
            tabTKThanhVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridTV).EndInit();
            tabTKThietBi.ResumeLayout(false);
            tabTKThietBi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridTB).EndInit();
            tabTKXuPhat.ResumeLayout(false);
            tabTKXuPhat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabTKThanhVien;
        private TabPage tabTKThietBi;
        private TabPage tabTKXuPhat;
        private Label label8;
        private Label label7;
        private DateTimePicker toDate;
        private DateTimePicker fromDate;
        private Label label6;
        private ComboBox cbbThanhVien;
        private Button btnReset;
        private Label lblCount;
        private DataGridView DataGridTV;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column5;
        private Button btnTK;
        private Label lblSD;
        private Label lblKD;
        private Label lblTong;
        private Label label1;
        private ComboBox cbbThietBi;
        private DataGridView DataGridTB;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridView dataGridView1;
        private Label lblTongTien;
        private Label label2;
        private ComboBox comboBox1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
    }
}