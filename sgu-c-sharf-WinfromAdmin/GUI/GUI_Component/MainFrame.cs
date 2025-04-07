using sgu_c_sharf_WinfromAdmin.GUI.GUI_Component;
using sgu_c_sharf_WinfromAdmin.GUI.GUI_Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgu_c_sharf_WinfromAdmin.GUI
{
    public partial class MainFrame : Form
    {

        private MenuTaskBar menuTaskBar;
        public MainFrame()
        {
            InitializeComponent();
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {
            menuTaskBar = new MenuTaskBar(this);

            // Gọi hàm để hiển thị form trong panel bên trái
            EmbedFormInPanel(menuTaskBar, pnlLeft1);
            this.ChangePage(new QuanLyThanhVien());
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit(); // ensure complete shutdown
        }

        private void EmbedFormInPanel(Form form, Panel panel)
        {
            form.TopLevel = false; // Form con không phải là form chính
            form.FormBorderStyle = FormBorderStyle.None; // Ẩn viền form con
            form.Dock = DockStyle.Fill; // Lấp đầy panel

            panel.Controls.Clear(); // Xóa các control cũ trong panel
            panel.Controls.Add(form); // Thêm form con vào panel
            panel.Tag = form;

            form.Show(); // Hiển thị form
        }

        public void ChangePage(Form newForm)
        {
            pnlRight1.Controls.Clear(); // Xóa form cũ

            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;

            pnlRight1.Controls.Add(newForm);
            newForm.Show();
        }


    }


}
