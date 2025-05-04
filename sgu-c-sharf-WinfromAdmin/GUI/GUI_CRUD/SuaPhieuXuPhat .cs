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
    public partial class FormSuaPhieuXuphat : Form
    {
        private readonly PhieuXuPhatService _phieuXuPhatService;
        private readonly ThanhVienService _thanhVienService;
        private PhieuXuPhatDetailDTO _phieuXuPhatDetailDTO;
        private uint _Id;
        private PhieuXuPhatUpdateDTO _phieuXuPhatUpdateDTO;
        private bool _isThanhVienExist = false;
        public FormSuaPhieuXuphat(uint Id)
        {
            InitializeComponent();
            _Id = Id;
            _phieuXuPhatService = new PhieuXuPhatService();
            _thanhVienService = new ThanhVienService();
            LoadData();
        }

        private void LoadTrangThaiComboBox()
        {
            var trangThaiEnumValues = Enum.GetValues(typeof(TrangThaiPhieuXuPhatEnum));
            cbbTrangThai.Items.Clear();
            foreach (var value in trangThaiEnumValues)
            {
                cbbTrangThai.Items.Add(value);
            }
        }
        private async void LoadData()
        {
            var phieuXuPhatDetail = await _phieuXuPhatService.GetByIdAsync(_Id);
            LoadTrangThaiComboBox();
            if (phieuXuPhatDetail != null)
            {
                _phieuXuPhatDetailDTO = phieuXuPhatDetail;
                txtMaPhieu.Text = _phieuXuPhatDetailDTO.Id.ToString();
                txtMaThanhVien.Text = _phieuXuPhatDetailDTO.IdThanhVien.ToString();
                txtTenThanhVien.Text = _phieuXuPhatDetailDTO.TenThanhVien;
                txtHanXuPhat.Text = _phieuXuPhatDetailDTO.ThoiHanXuPhat.ToString();
                txtMoTa.Text = _phieuXuPhatDetailDTO.MoTa;
                cbbTrangThai.SelectedItem = _phieuXuPhatDetailDTO.TrangThai;
                dataTimeViPham.Value = _phieuXuPhatDetailDTO.NgayViPham;
                txtMucPhat.Text = _phieuXuPhatDetailDTO.MucPhat.ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin phiếu xử phạt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async void txtMaThanhVien_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaThanhVien.Text, out int id))
            {
                var thanhVien = await _thanhVienService.GetById(id);
                if (thanhVien != null && !string.IsNullOrEmpty(thanhVien.HoTen))
                {
                    txtTenThanhVien.Text = thanhVien.HoTen;
                    _isThanhVienExist = true;
                }
                else
                {
                    txtTenThanhVien.Text = "Không tìm thấy thành viên";
                    _isThanhVienExist = false;
                }
            }
            else
            {
                txtTenThanhVien.Text = "";
                _isThanhVienExist = false;
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string moTa = txtMoTa.Text.Trim();
                uint? thoiHanXuPhat = null;
                if (!string.IsNullOrEmpty(txtHanXuPhat.Text) && uint.TryParse(txtHanXuPhat.Text, out uint thoiHan))
                {
                    thoiHanXuPhat = thoiHan;
                }

                uint? mucPhat = null;
                if (!string.IsNullOrEmpty(txtMucPhat.Text) && uint.TryParse(txtMucPhat.Text, out uint muc))
                {
                    mucPhat = muc;
                }

                uint? idThanhVien = null;
                if (!string.IsNullOrEmpty(txtMaThanhVien.Text) && uint.TryParse(txtMaThanhVien.Text, out uint ma))
                {
                    idThanhVien = ma;
                }

                DateTime ngayViPham = dataTimeViPham.Value;

                TrangThaiPhieuXuPhatEnum? trangThai = null;
                if (cbbTrangThai.SelectedItem is TrangThaiPhieuXuPhatEnum selectedTrangThai)
                {
                    trangThai = selectedTrangThai;
                }

                _phieuXuPhatUpdateDTO = new PhieuXuPhatUpdateDTO
                {
                    MoTa = moTa,
                    ThoiHanXuPhat = thoiHanXuPhat,
                    MucPhat = mucPhat,
                    NgayViPham = ngayViPham,
                    TrangThai = trangThai,
                    IdThanhVien = idThanhVien
                };

                bool result = await _phieuXuPhatService.UpdateAsync(_Id, _phieuXuPhatUpdateDTO);

                if (result)
                {
                    MessageBox.Show("Cập nhật phiếu xử phạt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataTimeViPham_ValueChanged(object sender, EventArgs e)
        {
            dataTimeViPham.Checked = true;

            if (dataTimeViPham.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày vi phạm không được vượt quá hôm nay.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataTimeViPham.Value = DateTime.Now;
            }
        }
    }
}
