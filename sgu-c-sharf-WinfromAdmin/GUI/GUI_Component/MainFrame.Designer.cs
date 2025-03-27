namespace sgu_c_sharf_WinfromAdmin.GUI
{
    partial class MainFrame
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
            pnlLeft1 = new Panel();
            pnlRight1 = new Panel();
            SuspendLayout();
            // 
            // pnlLeft1
            // 
            pnlLeft1.Dock = DockStyle.Left;
            pnlLeft1.Location = new Point(0, 0);
            pnlLeft1.Margin = new Padding(4, 3, 4, 3);
            pnlLeft1.Name = "pnlLeft1";
            pnlLeft1.Size = new Size(350, 1061);
            pnlLeft1.TabIndex = 0;
            // 
            // pnlRight1
            // 
            pnlRight1.BackColor = SystemColors.AppWorkspace;
            pnlRight1.Dock = DockStyle.Fill;
            pnlRight1.Location = new Point(350, 0);
            pnlRight1.Margin = new Padding(4, 3, 4, 3);
            pnlRight1.Name = "pnlRight1";
            pnlRight1.Size = new Size(1498, 1061);
            pnlRight1.TabIndex = 1;
            // 
            // MainFrame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1848, 1061);
            Controls.Add(pnlRight1);
            Controls.Add(pnlLeft1);
            IsMdiContainer = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainFrame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý thư quán";
            Load += MainFrame_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft1;
        private System.Windows.Forms.Panel pnlRight1;
    }
}