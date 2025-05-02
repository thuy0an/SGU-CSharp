namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    partial class SuaMuonDauThietBi
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtMaDauThietBi = new TextBox();
            btnSua = new Button();
            cbbTrangThai = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            dateMuon = new DateTimePicker();
            dateTra = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(131, 25);
            label1.Name = "label1";
            label1.Size = new Size(358, 27);
            label1.TabIndex = 0;
            label1.Text = "Sửa thông tin mượn đầu thiết bị";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(43, 80);
            label2.Name = "label2";
            label2.Size = new Size(131, 22);
            label2.TabIndex = 1;
            label2.Text = "Mã đầu thiết bị";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(43, 167);
            label3.Name = "label3";
            label3.Size = new Size(92, 22);
            label3.TabIndex = 2;
            label3.Text = "Trạng thái";
            label3.Click += label3_Click;
            // 
            // txtMaDauThietBi
            // 
            txtMaDauThietBi.Enabled = false;
            txtMaDauThietBi.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaDauThietBi.Location = new Point(43, 105);
            txtMaDauThietBi.Name = "txtMaDauThietBi";
            txtMaDauThietBi.ReadOnly = true;
            txtMaDauThietBi.Size = new Size(198, 29);
            txtMaDauThietBi.TabIndex = 3;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(264, 284);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(98, 46);
            btnSua.TabIndex = 5;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // cbbTrangThai
            // 
            cbbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTrangThai.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbbTrangThai.FormattingEnabled = true;
            cbbTrangThai.Items.AddRange(new object[] { "Đang mượn", "Đã trả thiết bị", "Đã thất lạc" });
            cbbTrangThai.Location = new Point(43, 192);
            cbbTrangThai.Name = "cbbTrangThai";
            cbbTrangThai.Size = new Size(198, 30);
            cbbTrangThai.TabIndex = 6;
            cbbTrangThai.SelectedIndexChanged += cbbTrangThai_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(297, 80);
            label4.Name = "label4";
            label4.Size = new Size(109, 22);
            label4.TabIndex = 7;
            label4.Text = "Ngày mượn";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(297, 167);
            label5.Name = "label5";
            label5.Size = new Size(79, 22);
            label5.TabIndex = 8;
            label5.Text = "Ngày trả";
            // 
            // dateMuon
            // 
            dateMuon.Checked = false;
            dateMuon.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateMuon.Location = new Point(297, 111);
            dateMuon.Name = "dateMuon";
            dateMuon.Size = new Size(315, 29);
            dateMuon.TabIndex = 9;
            // 
            // dateTra
            // 
            dateTra.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTra.Location = new Point(297, 192);
            dateTra.Name = "dateTra";
            dateTra.Size = new Size(315, 29);
            dateTra.TabIndex = 10;
            // 
            // SuaMuonDauThietBi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(624, 342);
            Controls.Add(dateTra);
            Controls.Add(dateMuon);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(cbbTrangThai);
            Controls.Add(btnSua);
            Controls.Add(txtMaDauThietBi);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SuaMuonDauThietBi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SuaMuonDauThietBi";
            Load += SuaMuonDauThietBi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtMaDauThietBi;
        private Button btnSua;
        private ComboBox cbbTrangThai;
        private Label label4;
        private Label label5;
        private DateTimePicker dateMuon;
        private DateTimePicker dateTra;
    }
}