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
            txtSoLuong = new TextBox();
            btnMuon = new Button();
            label5 = new Label();
            cbbThietBi = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(102, 26);
            label1.Name = "label1";
            label1.Size = new Size(203, 27);
            label1.TabIndex = 0;
            label1.Text = "Mượn đầu thiết bị";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(78, 169);
            label2.Name = "label2";
            label2.Size = new Size(89, 22);
            label2.TabIndex = 1;
            label2.Text = "Số lượng";
            label2.Click += label2_Click;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoLuong.Location = new Point(78, 194);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(200, 29);
            txtSoLuong.TabIndex = 3;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;
            // 
            // btnMuon
            // 
            btnMuon.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMuon.Location = new Point(161, 271);
            btnMuon.Name = "btnMuon";
            btnMuon.Size = new Size(98, 46);
            btnMuon.TabIndex = 5;
            btnMuon.Text = "Mượn";
            btnMuon.UseVisualStyleBackColor = true;
            btnMuon.Click += btnMuon_Click;
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
            cbbThietBi.SelectedIndexChanged += cbbThietBi_SelectedIndexChanged;
            // 
            // MuonDauThietBi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(425, 361);
            Controls.Add(cbbThietBi);
            Controls.Add(label5);
            Controls.Add(btnMuon);
            Controls.Add(txtSoLuong);
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
        private TextBox txtSoLuong;
        private Button btnMuon;
        private Label label5;
        private ComboBox cbbThietBi;
    }
}