using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sgu_c_sharf_WinfromAdmin.Models; // Thêm namespace để dùng ThietBi

namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    public partial class FormXemThietBi : Form
    {
        private ThietBi thietBi; 

        // Constructor mặc định
        public FormXemThietBi()
        {
            InitializeComponent();
        }

        // Constructor nhận tham số ThietBi
        public FormXemThietBi(ThietBi thietBi)
        {
            InitializeComponent();
            this.thietBi = thietBi; // Lưu đối tượng ThietBi
            HienThiThongTin(); // Gọi phương thức để hiển thị thông tin
        }

        // Phương thức hiển thị thông tin thiết bị
        private void HienThiThongTin()
        {
            if (thietBi != null)
            {
                txtMaThietBi.Text = thietBi.Id.ToString(); 
                txtTenThietBi.Text = thietBi.TenThietBi;
                txtTenLoaiThietBi.Text = thietBi.TenLoaiThietBi;
                // txtTrangThai.Text = thietBi.DaXoa ? "Đã xóa" : "Chưa xóa";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void FormSuaThanhVien_Load(object sender, EventArgs e)
        {
        }

        private void btnThemDauThietBi_Click(object sender, EventArgs e)
        {
            ThemDauThietBi form = new ThemDauThietBi();
            form.ShowDialog();
        }
    }
}