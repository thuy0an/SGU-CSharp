using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sgu_c_sharf_WinfromAdmin.GUI.GUI_Menu;
using sgu_c_sharf_WinfromAdmin.Models;
using sgu_c_sharf_WinfromAdmin.Services;

namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    public partial class FormSuaThanhVien : Form
    {
        private ThanhVien thanhVien;
        private QuanLyThanhVien menu;
        private ThanhVienService thanhVienService = new ThanhVienService();

        private Dictionary<TrangThaiEnum, string> HienThiTrangThai = new Dictionary<TrangThaiEnum, string>
        {
            { TrangThaiEnum.HOATDONG, "Hoạt động" },
            { TrangThaiEnum.DINHCHI, "Đình chỉ" },
            { TrangThaiEnum.CAM, "Cấm" }
        };

        public FormSuaThanhVien(ThanhVien tv, QuanLyThanhVien quanly)
        {
            InitializeComponent();
            this.thanhVien = tv;
            this.menu = quanly;
            LoadData();
        }

        private void LoadData()
        {
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

        private void FormSuaThanhVien_Load(object sender, EventArgs e)
        {

        }

        private async void btnCapNhat_Click(object sender, EventArgs e)
        {
            // xác nhận cập nhật
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if( result == DialogResult.Yes){
                thanhVien.TrangThai = (TrangThaiEnum)cbbTrangThai.SelectedValue;
                bool isUpdate = await thanhVienService.Update(thanhVien);
                if(isUpdate){
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.menu.GetList();
                    this.Close();
                }
                else
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
