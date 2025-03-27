namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    partial class SuaDauThietBi
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
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(139, 18);
            label1.Name = "label1";
            label1.Size = new Size(183, 27);
            label1.TabIndex = 0;
            label1.Text = "Sửa đầu thiết bị";
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
            label3.Location = new Point(43, 143);
            label3.Name = "label3";
            label3.Size = new Size(92, 22);
            label3.TabIndex = 2;
            label3.Text = "Trạng thái";
            // 
            // txtMaDauThietBi
            // 
            txtMaDauThietBi.Enabled = false;
            txtMaDauThietBi.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaDauThietBi.Location = new Point(235, 80);
            txtMaDauThietBi.Name = "txtMaDauThietBi";
            txtMaDauThietBi.Size = new Size(198, 29);
            txtMaDauThietBi.TabIndex = 3;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(189, 196);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(98, 46);
            btnSua.TabIndex = 5;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Khả dụng", "Đang mượn", "Đặt trước", "Bảo trì", "Thanh lý", "Thất lạc", "Đã thất lạc" });
            comboBox1.Location = new Point(235, 140);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(198, 30);
            comboBox1.TabIndex = 6;
            // 
            // SuaDauThietBi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(476, 271);
            Controls.Add(comboBox1);
            Controls.Add(btnSua);
            Controls.Add(txtMaDauThietBi);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SuaDauThietBi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SuaDauThietBi";
            Load += SuaDauThietBi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtMaDauThietBi;
        private Button btnSua;
        private ComboBox comboBox1;
    }
}