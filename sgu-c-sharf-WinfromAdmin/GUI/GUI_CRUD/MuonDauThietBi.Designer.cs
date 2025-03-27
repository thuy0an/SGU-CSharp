namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    partial class MuonDauThietBi
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
            dateTimeMuon = new DateTimePicker();
            btnMuon = new Button();
            dateTimeTra = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            cbbThietBi = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(241, 18);
            label1.Name = "label1";
            label1.Size = new Size(203, 27);
            label1.TabIndex = 0;
            label1.Text = "Mượn đầu thiết bị";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(406, 77);
            label2.Name = "label2";
            label2.Size = new Size(89, 22);
            label2.TabIndex = 1;
            label2.Text = "Số lượng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(78, 180);
            label3.Name = "label3";
            label3.Size = new Size(144, 22);
            label3.TabIndex = 2;
            label3.Text = "Thời gian mượn";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoLuong.Location = new Point(406, 103);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(200, 29);
            txtSoLuong.TabIndex = 3;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;
            // 
            // dateTimeMuon
            // 
            dateTimeMuon.CalendarFont = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimeMuon.Location = new Point(78, 215);
            dateTimeMuon.Name = "dateTimeMuon";
            dateTimeMuon.Size = new Size(200, 23);
            dateTimeMuon.TabIndex = 4;
            dateTimeMuon.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // btnMuon
            // 
            btnMuon.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMuon.Location = new Point(293, 290);
            btnMuon.Name = "btnMuon";
            btnMuon.Size = new Size(98, 46);
            btnMuon.TabIndex = 5;
            btnMuon.Text = "Mượn";
            btnMuon.UseVisualStyleBackColor = true;
            // 
            // dateTimeTra
            // 
            dateTimeTra.CalendarFont = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimeTra.Location = new Point(406, 215);
            dateTimeTra.Name = "dateTimeTra";
            dateTimeTra.Size = new Size(200, 23);
            dateTimeTra.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(406, 180);
            label4.Name = "label4";
            label4.Size = new Size(114, 22);
            label4.TabIndex = 6;
            label4.Text = "Thời gian trả";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(78, 77);
            label5.Name = "label5";
            label5.Size = new Size(72, 22);
            label5.TabIndex = 8;
            label5.Text = "Thiết bị";
            // 
            // cbbThietBi
            // 
            cbbThietBi.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbbThietBi.FormattingEnabled = true;
            cbbThietBi.Location = new Point(78, 102);
            cbbThietBi.Name = "cbbThietBi";
            cbbThietBi.Size = new Size(200, 30);
            cbbThietBi.TabIndex = 9;
            // 
            // MuonDauThietBi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(684, 361);
            Controls.Add(cbbThietBi);
            Controls.Add(label5);
            Controls.Add(dateTimeTra);
            Controls.Add(label4);
            Controls.Add(btnMuon);
            Controls.Add(dateTimeMuon);
            Controls.Add(txtSoLuong);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MuonDauThietBi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MuonDauThietBi";
            Load += MuonDauThietBi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtSoLuong;
        private DateTimePicker dateTimeMuon;
        private Button btnMuon;
        private DateTimePicker dateTimeTra;
        private Label label4;
        private Label label5;
        private ComboBox cbbThietBi;
    }
}