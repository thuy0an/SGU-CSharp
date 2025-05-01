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
    public partial class MuonDauThietBi : Form
    {
        List<ThietBiListAvailabilityDTO> thietBis;
        public ThietBiListAvailabilityDTO thietBiListAvailabilityDTO { get; set; }
        public MuonDauThietBi(List<ThietBiListAvailabilityDTO> thietBis)
        {
            InitializeComponent();
            this.thietBis = thietBis;
        }

        private async void MuonDauThietBi_Load(object sender, EventArgs e)
        {
            cbbThietBi.DataSource = thietBis;
            cbbThietBi.DisplayMember = "TenThietBi";
            cbbThietBi.ValueMember = "Id";
        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (cbbThietBi.SelectedItem is ThietBiListAvailabilityDTO selectedThietBi)
            {
                int soLuongKhaDung = selectedThietBi.SoLuongKhaDung;
                if (soLuongKhaDung == 0)
                {
                    MessageBox.Show("Thiết bị này hiện không còn khả dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuong.Text = "0";
                    return;
                }
                if (int.TryParse(txtSoLuong.Text, out int soLuongNhap))
                {
                    if (soLuongNhap > soLuongKhaDung)
                    {
                        MessageBox.Show($"Số lượng không được vượt quá {soLuongKhaDung}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSoLuong.Text = soLuongKhaDung.ToString();
                        txtSoLuong.SelectionStart = txtSoLuong.Text.Length;
                    }
                    else if (soLuongNhap < 1)
                    {
                        txtSoLuong.Text = "1";
                        txtSoLuong.SelectionStart = txtSoLuong.Text.Length;
                    }
                }
                else if (!string.IsNullOrEmpty(txtSoLuong.Text))
                {
                    MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuong.Text = "1";
                    txtSoLuong.SelectionStart = txtSoLuong.Text.Length;
                }
            }
        }

        private void cbbThietBi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimeTra_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnMuon_Click(object sender, EventArgs e)
        {
            // Khởi tạo đối tượng DTO
            thietBiListAvailabilityDTO = new ThietBiListAvailabilityDTO();

            if (cbbThietBi.SelectedItem is ThietBiListAvailabilityDTO selectedThietBi)
            {
                // Kiểm tra xem người dùng nhập số lượng hợp lệ không
                if (int.TryParse(txtSoLuong.Text, out int soLuongNhap))
                {
                    // Kiểm tra số lượng nhập vào có hợp lý không
                    if (soLuongNhap > selectedThietBi.SoLuongKhaDung)
                    {
                        MessageBox.Show($"Số lượng không được vượt quá {selectedThietBi.SoLuongKhaDung}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Dừng hàm nếu số lượng không hợp lệ
                    }

                    thietBiListAvailabilityDTO.Id = selectedThietBi.Id;
                    thietBiListAvailabilityDTO.TenThietBi = selectedThietBi.TenThietBi;
                    thietBiListAvailabilityDTO.SoLuongKhaDung = soLuongNhap;
                    ThietBiListAvailabilityDTO deviceInList = thietBis.FirstOrDefault(tb => tb.Id == selectedThietBi.Id);
                    if (deviceInList != null)
                    {
                        deviceInList.SoLuongKhaDung -= soLuongNhap;

                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Thông báo lỗi nếu số lượng không hợp lệ
                    MessageBox.Show("Vui lòng nhập số lượng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Thông báo lỗi nếu người dùng không chọn thiết bị
                MessageBox.Show("Vui lòng chọn thiết bị!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
