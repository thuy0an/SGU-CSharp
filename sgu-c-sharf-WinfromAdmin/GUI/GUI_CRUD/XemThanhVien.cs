using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sgu_c_sharf_WinfromAdmin.Models;

namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    public partial class FormXemThanhVien : Form
    {
        private ThanhVien thanhVien;
        private Dictionary<TrangThaiEnum, string> HienThiTrangThai = new Dictionary<TrangThaiEnum, string>
        {
            { TrangThaiEnum.HOATDONG, "Hoạt động" },
            { TrangThaiEnum.DINHCHI, "Đình chỉ" },
            { TrangThaiEnum.CAM, "Cấm" }
        };

        public FormXemThanhVien(ThanhVien tv)
        {
            InitializeComponent();
            this.thanhVien = tv;
            LoadData();
        }

        private void LoadData(){
            cbbTrangThai.DataSource = new BindingSource(HienThiTrangThai, null);
            cbbTrangThai.DisplayMember = "Value";
            cbbTrangThai.ValueMember = "Key";

            txtMaThanhVien.Text = thanhVien.Id.ToString();
            txtTenNguoiDung.Text = thanhVien.HoTen;
            txtEmail.Text = thanhVien.Email;
            txtNgaySinh.Text = thanhVien.NgaySinh.ToString("dd/MM/yyyy");
            txtSoDienThoai.Text = thanhVien.SoDienThoai;
            txtThoiGianDangKy.Text = thanhVien.ThoiGianDangKy.ToString("dd/MM/yyyy HH:mm:ss");
            Console.WriteLine(thanhVien.TrangThai);
            cbbTrangThai.SelectedValue = thanhVien.TrangThai;
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
    }
}
