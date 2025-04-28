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
    public partial class FormThemThanhVien : Form
    {
        private QuanLyThanhVien menu;
        private ThanhVienService thanhVienService = new ThanhVienService();
        private List<ThanhVien> listTV = new List<ThanhVien>();


        public FormThemThanhVien(QuanLyThanhVien quanly)
        {
            InitializeComponent();
            this.menu = quanly;

            LoadData();
        }

        private async void LoadData()
        {
            this.listTV = await thanhVienService.GetAll();
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!CheckValidate())
                return;
            // gọi hàm đăng ký
            ThanhVien tv = new ThanhVien();
            tv.HoTen = txtTenNguoiDung.Text.Trim();
            tv.SoDienThoai = txtSoDienThoai.Text.Trim();
            tv.Email = txtEmail.Text.Trim();
            tv.MatKhau = txtMatKhau.Text.Trim();
            tv.NgaySinh = ngaySinh.Value;

            bool res = await thanhVienService.Add(tv);
            if( res){
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                menu.LoadData(await thanhVienService.GetAll());
                this.Close();
            }
            else
                MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void FormThemThanhVien_Load(object sender, EventArgs e)
        {

        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // chỉ cho phép nhập số
            }
        }

        private bool CheckValidate()
        {
            if( txtTenNguoiDung.Text.Trim() == "" || txtSoDienThoai.Text.Trim() == "" || txtMatKhau.Text.Trim() == "" || txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtMatKhau.Text.Trim().Length < 5)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 5 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return false;
            }
            if (txtSoDienThoai.Text.Trim().Length != 10 || txtSoDienThoai.Text.Trim()[0] != '0')
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return false;
            }
            if (!txtEmail.Text.Trim().Contains("@") || !txtEmail.Text.Trim().Contains("."))
            {
                MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            String sdt = txtSoDienThoai.Text.Trim();
            String email = txtEmail.Text.Trim();
            foreach (ThanhVien cur in listTV)
            {
                // trùng điện thoại
                if (cur.SoDienThoai == sdt)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoDienThoai.Focus();
                    return false;
                }
                if(cur.Email == email)
                {
                    MessageBox.Show("Email đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }
            // phải đủ 18 tuổi
            DateTime dateNow = DateTime.Now;
            DateTime ngaysinh = ngaySinh.Value;
            int tuoi = dateNow.Year - ngaysinh.Year;
            if (tuoi < 18)
            {
                MessageBox.Show("Tài khoản đăng ký phải từ 18 tuổi trở lên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ngaySinh.Focus();
                return false;
            }
            return true;
        }
    
        
    }
}
