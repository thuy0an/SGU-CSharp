using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sgu_c_sharf_WinfromAdmin.GUI.GUI_Menu;

namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_Component
{
    public partial class MenuTaskBar : Form
    {
        private MainFrame mainFrame;
        private List<Panel> panelList = new List<Panel>();
        private Panel selectedPanel = null;

        public MenuTaskBar(MainFrame parent)
        {
            mainFrame = parent;
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            // Thêm tất cả panel vào danh sách để dễ truy xuất
            panelList.Add(pnlQLThanhVien);
            panelList.Add(pnlQLLoaiThietBi);
            panelList.Add(pnlQLThietBi);
            panelList.Add(pnlQLDatCho);
            panelList.Add(pnlQLXuPhat);

            // Gán sự kiện cho từng panel
            foreach (var panel in panelList)
            {
                AttachPanelEvents(panel);
            }
        }

        private void AttachPanelEvents(Panel pnl)
        {
            Color enterColor = ColorTranslator.FromHtml("#FFFFE1");
            Color leaveColor = Color.White;

            foreach (Control ctrl in pnl.Controls)
            {
                ctrl.MouseEnter += (s, e) =>
                {
                    if (selectedPanel != pnl) // Chỉ đổi màu khi panel chưa được chọn
                    {
                        foreach (Control child in pnl.Controls)
                            child.BackColor = enterColor;
                    }
                };

                ctrl.MouseLeave += (s, e) =>
                {
                    if (selectedPanel != pnl) // Không đổi màu nếu panel đang được chọn
                    {
                        foreach (Control child in pnl.Controls)
                            child.BackColor = leaveColor;
                    }
                };

                ctrl.Click += (s, e) => Panel_Click(pnl);
            }
        }

        // Hàm xử lý sự kiện click trên Panel
        private void Panel_Click(Panel pnl)
        {
            Color enterColor = ColorTranslator.FromHtml("#FFFFE1");
            Color leaveColor = Color.White;

            // Reset màu của panel trước (nếu có)
            if (selectedPanel != null && selectedPanel != pnl)
            {
                foreach (Control child in selectedPanel.Controls)
                    child.BackColor = leaveColor;
            }
            // Đổi màu cho panel được nhấn
            foreach (Control child in pnl.Controls)
                child.BackColor = enterColor;
            selectedPanel = pnl;

            switch (pnl.Name)
            {
                case "pnlQLThanhVien":
                    mainFrame.ChangePage(new QuanLyThanhVien());
                    break;
                case "pnlQLLoaiThietBi":
                    mainFrame.ChangePage(new QuanLyLoaiThietBi());
                    break;
                case "pnlQLThietBi":
                    mainFrame.ChangePage(new QuanLyThietBi());
                    break;
                //case "pnlQLDatCho":
                //    mainFrame.ChangePage(new QuanLyDatCho());
                //    break;
                //case "pnlQLXuPhat":
                //    mainFrame.ChangePage(new QuanLyXuPhat());
                //    break;
                default:
                    MessageBox.Show("Đây là giao diện quản lý: " + pnl.Name);
                    break;
            }
        }

        private void MenuTaskBar_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblThanhvien_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pnlUser_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.mainFrame.Dispose();
                Login loginForm = new Login();
                loginForm.Show();
            }
        }
    }
}
