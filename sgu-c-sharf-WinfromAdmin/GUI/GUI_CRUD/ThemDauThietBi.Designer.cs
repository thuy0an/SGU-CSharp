namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    partial class ThemDauThietBi
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
            txtSoLuong = new TextBox();
            dateTimePicker = new DateTimePicker();
            btnThem = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(139, 18);
            label1.Name = "label1";
            label1.Size = new Size(199, 27);
            label1.TabIndex = 0;
            label1.Text = "Thêm đầu thiết bị";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(43, 80);
            label2.Name = "label2";
            label2.Size = new Size(89, 22);
            label2.TabIndex = 1;
            label2.Text = "Số lượng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(43, 134);
            label3.Name = "label3";
            label3.Size = new Size(129, 22);
            label3.TabIndex = 2;
            label3.Text = "Thời gian mua";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoLuong.Location = new Point(235, 80);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(198, 29);
            txtSoLuong.TabIndex = 3;
            // 
            // dateTimePicker
            // 
            dateTimePicker.CalendarFont = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker.Location = new Point(235, 134);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(198, 23);
            dateTimePicker.TabIndex = 4;
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(189, 196);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(98, 46);
            btnThem.TabIndex = 5;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // ThemDauThietBi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(476, 271);
            Controls.Add(btnThem);
            Controls.Add(dateTimePicker);
            Controls.Add(txtSoLuong);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ThemDauThietBi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ThemDauThietBi";
            Load += ThemDauThietBi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtSoLuong;
        private DateTimePicker dateTimePicker;
        private Button btnThem;
    }
}