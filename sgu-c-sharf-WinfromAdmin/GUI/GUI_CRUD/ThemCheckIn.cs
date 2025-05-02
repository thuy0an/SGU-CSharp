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
using sgu_c_sharf_WinfromAdmin.Services;

namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    public partial class ThemCheckIn : Form
    {

        private CheckInService checkInService = new CheckInService();
        private ThanhVienService thanhVienService = new ThanhVienService();
        private List<ThanhVien> listTV;

        public ThemCheckIn()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {

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

        private async void button1_Click(object sender, EventArgs e)
        {
            listTV = await thanhVienService.GetAll();
            foreach (ThanhVien tv in listTV)
            {
                if (tv.Id.ToString().Equals(txtCheckIn.Text.Trim()))
                {
                    switch (tv.TrangThai)
                    {
                        case TrangThaiEnum.HOATDONG:
                            string time = await checkInService.AddCheckIn(tv.Id);
                            MessageBox.Show("Check in thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMaThanhVien.Text = tv.Id.ToString();
                            txtTenNguoiDung.Text = tv.HoTen;
                            txtEmail.Text = tv.Email;
                            txtNgaySinh.Text = tv.NgaySinh.ToString("dd/MM/yyyy");
                            txtSoDienThoai.Text = tv.SoDienThoai;
                            txtThoiGianDangKy.Text = tv.ThoiGianDangKy.ToString("dd/MM/yyyy HH:mm:ss");
                            txtNow.Text = time;

                            txtCheckIn.Text="";
                            break;

                        case TrangThaiEnum.DINHCHI:
                            MessageBox.Show("Thành viên đang bị đình chỉ, vẫn được phép check in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            string time1 = await checkInService.AddCheckIn(tv.Id);
                            MessageBox.Show("Check in thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMaThanhVien.Text = tv.Id.ToString();
                            txtTenNguoiDung.Text = tv.HoTen;
                            txtEmail.Text = tv.Email;
                            txtNgaySinh.Text = tv.NgaySinh.ToString("dd/MM/yyyy");
                            txtSoDienThoai.Text = tv.SoDienThoai;
                            txtThoiGianDangKy.Text = tv.ThoiGianDangKy.ToString("dd/MM/yyyy HH:mm:ss");
                            txtNow.Text = time1;

                            txtCheckIn.Text="";
                            break;

                        case TrangThaiEnum.CAM:
                            MessageBox.Show("Thành viên đã bị cấm, không thể check in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCheckIn.Text="";
                            break;
                    }
                    return;
                }
            }
            MessageBox.Show("Không phải mã thành viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCheckIn.Focus();
        }
    }
}
