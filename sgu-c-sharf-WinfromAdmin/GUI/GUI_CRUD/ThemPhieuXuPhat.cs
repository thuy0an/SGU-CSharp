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
using ZstdSharp.Unsafe;

namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    public partial class FormThemPhieuXuphat : Form
    {
        private readonly PhieuXuPhatService _phieuXuPhatService;
        private readonly ThanhVienService _thanhVienService;
        private bool _isThanhVienExist = false;

        public FormThemPhieuXuphat()
        {
            InitializeComponent();
            _phieuXuPhatService = new PhieuXuPhatService();
            _thanhVienService = new ThanhVienService();
            LoadTrangThaiComboBox();
            dateTimeViPham.Checked = false;
        }

        private void LoadTrangThaiComboBox()
        {
            var trangThaiEnumValues = Enum.GetValues(typeof(TrangThaiPhieuXuPhatEnum));

            comboBoxTrangThai.Items.Clear();

            foreach (var value in trangThaiEnumValues)
            {
                if ((TrangThaiPhieuXuPhatEnum)value == TrangThaiPhieuXuPhatEnum.DAXOA)
                {
                    continue;
                }
                comboBoxTrangThai.Items.Add(value);
            }

            comboBoxTrangThai.SelectedIndex = 1;
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

        private async void txtMaThanhVien_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaThanhVien.Text, out int id))
            {
                var thanhVien = await _thanhVienService.GetById(id);
                if (thanhVien != null && !string.IsNullOrEmpty(thanhVien.HoTen))
                {
                    textTenThanhVien.Text = thanhVien.HoTen;
                    _isThanhVienExist = true;
                }
                else
                {
                    textTenThanhVien.Text = "Không tìm thấy thành viên";
                    _isThanhVienExist = false;
                }
            }
            else
            {
                textTenThanhVien.Text = "";
                _isThanhVienExist = false;
            }
        }

        private void dataTimeViPham_ValueChanged(object sender, EventArgs e)
        {
            dateTimeViPham.Checked = true;
        }

        private void dataTimeXuPhat_ValueChanged(object sender, EventArgs e)
        {

        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            string textMaThanhVien = txtMaThanhVien.Text.Trim();
            uint maThanhVien = 0;
            if (string.IsNullOrEmpty(textMaThanhVien))
            {
                MessageBox.Show("Vui lòng nhập mã thành viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!_isThanhVienExist)
            {
                MessageBox.Show("Vui lòng nhập mã thành viên hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (uint.TryParse(textMaThanhVien, out uint parsedMaThanhVien))
            {
                maThanhVien = parsedMaThanhVien;
            }

            uint? mucPhat = null;
            string mucPhatText = txtMucPhat.Text.Trim();
            if (!string.IsNullOrEmpty(mucPhatText))
            {
                if (uint.TryParse(mucPhatText, out uint parsedMucPhat))
                    mucPhat = parsedMucPhat;
                else
                {
                    MessageBox.Show("Mức phạt không hợp lệ!\nMức phạt là số ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string moTa = txtMoTa.Text.Trim();
            if (string.IsNullOrEmpty(moTa))
            {
                MessageBox.Show("Vui lòng nhập mô tả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngayViPham;
            if (dateTimeViPham.Checked)
            {
                ngayViPham = dateTimeViPham.Value;
            }
            else
            {
                ngayViPham = DateTime.Now;
            }

            uint? thoiHanXuPhat = null;
            string thoiHanText = txtThoiHan.Text.Trim();
            if (!string.IsNullOrEmpty(thoiHanText))
            {
                if (uint.TryParse(thoiHanText, out uint parsedThoiHan))
                    thoiHanXuPhat = parsedThoiHan;
                else
                {
                    MessageBox.Show("Thời hạn xử phạt không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (comboBoxTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Enum.TryParse(comboBoxTrangThai.SelectedItem.ToString(), out TrangThaiPhieuXuPhatEnum trangThai))
            {
                MessageBox.Show("Trạng thái không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = new PhieuXuPhatCreateDTO
            {
                IdThanhVien = maThanhVien,
                MucPhat = mucPhat,
                MoTa = moTa,
                NgayViPham = ngayViPham,
                ThoiHanXuPhat = thoiHanXuPhat,
                TrangThai = trangThai
            };
            var result = await _phieuXuPhatService.AddAsync(dto);
            if (result)
            {
                MessageBox.Show("Thêm phiếu xử phạt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm phiếu xử phạt thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
