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
    public partial class FormSuaThietBi : Form
    {
        private readonly QuanLyThietBi _parentForm;
        private readonly ThietBiService _thietBiService;
        private readonly LoaiThietBiService _loaiThietBiService;
        private readonly ThietBi curTB;
        public FormSuaThietBi(QuanLyThietBi parentForm, ThietBi thietBi)
        {
            InitializeComponent();
            _thietBiService = new ThietBiService();
            _loaiThietBiService = new LoaiThietBiService();
            _parentForm = parentForm;
            curTB = thietBi;
            LoadData();
        }


        private async void LoadData()
        {
            txtMaThietBi.Text = curTB.Id.ToString();
            txtTenThietBi.Text = curTB.TenThietBi;
            cbbLoaiThietBi.Text = curTB.TenLoaiThietBi;
            cbbLoaiThietBi.DataSource = await _loaiThietBiService.GetAll();
            cbbLoaiThietBi.DisplayMember = "TenLoaiThietBi";
            cbbLoaiThietBi.ValueMember = "Id";
            int index = cbbLoaiThietBi.FindStringExact(curTB.TenLoaiThietBi);
            cbbLoaiThietBi.SelectedIndex = index;

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtTenThietBi.Text == curTB.TenThietBi && txtDauThietBi.Text.Trim() == "")
            {
                this.Close();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenThietBi.Text))
            {
                MessageBox.Show("Vui lòng nhập tên thiết bị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenThietBi.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDauThietBi.Text) || !int.TryParse(txtDauThietBi.Text, out int soLuongDauThietBi) || soLuongDauThietBi < 1 || soLuongDauThietBi > 100)
            {
                MessageBox.Show("Số lượng đầu thiết bị phải là số nguyên từ 1 đến 100!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // xác nhận cập nhật thông tin
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin thiết bị này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // cập nhật thông tin thiết bị
                ThietBi thietBi = new ThietBi 
                {
                    Id = curTB.Id,
                    TenThietBi = txtTenThietBi.Text,
                    TenLoaiThietBi = cbbLoaiThietBi.Text,
                    IdLoaiThietBi = (int)cbbLoaiThietBi.SelectedValue
                };
                _thietBiService.Update(thietBi.Id, thietBi);

                // cập nhật số lượng đầu thiết bị thêm mới
                _thietBiService.AddDauThietBi(thietBi.Id, soLuongDauThietBi);


                MessageBox.Show("Cập nhật thông tin thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _parentForm.RefreshDataGridView();
                this.Close();

            }
        }

        private void txtDauThietBi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // chặn ký tự không hợp lệ
            }
        }
    }
}
