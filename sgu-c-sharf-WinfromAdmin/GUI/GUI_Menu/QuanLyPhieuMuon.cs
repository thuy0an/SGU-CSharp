using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD;
using sgu_c_sharf_WinfromAdmin.Services;
using sgu_c_sharf_WinfromAdmin.Models;
using System.Windows.Forms;

namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_Menu
{
    public partial class QuanLyPhieuMuon : Form
    {
        int currentPage;
        int totalPages;
        List<PhieuMuonDetailDTO> phieuMuonDetailDTOs;
        PhieuMuonService phieuDatChoService = new PhieuMuonService();
        int limit = 10;

        public QuanLyPhieuMuon()
        {
            InitializeComponent();
            SetPlaceholder(txtSearch, "Tìm kiếm", Color.Gray);

        }

        private async void QuanLyPhieuMuon_Load(object sender, EventArgs e)
        {
            // Gọi hàm LoadData khi form được tải
            await LoadData(1, limit);
            LoadTrangThaiComboBox();
            fromDate.Checked = false;
            toDate.Checked = false;
        }

        private async Task LoadData(int page = 1, int limit = 10)
        {
            try
            {
                string searchKeyword = txtSearch.Text.Trim();
                TrangThaiPhieuMuonEnum? selectedTrangThai = comboBoxTrangThai.SelectedIndex != 0 ? (TrangThaiPhieuMuonEnum?)comboBoxTrangThai.SelectedItem : null;

                // Chỉ lấy ngày nếu Checked là true
                DateTime? fromDateQr = fromDate.Checked ? fromDate.Value.Date : null;
                DateTime? toDateQr = toDate.Checked ? toDate.Value.Date : null;

                if (fromDateQr != null && toDateQr != null && fromDateQr > toDateQr)
                {
                    toDateQr = fromDateQr;
                    toDate.Value = fromDateQr.Value;
                    toDate.Checked = true;
                }

                PhieuMuonPagingResponse response = await phieuDatChoService.GetAllWithPaging(page, limit, fromDateQr, toDateQr, selectedTrangThai);
                currentPage = response.CurrentPage;
                totalPages = response.TotalPages;
                phieuMuonDetailDTOs = response.Items;

                DataGrid.Rows.Clear();
                foreach (var item in phieuMuonDetailDTOs)
                {
                    DataGrid.Rows.Add(item.Id, item.IdThanhVien, item.TenThanhVien, item.NgayTao, item.TrangThai);
                }

                // Đặt tên cột (tùy theo model của bạn)
                //if (DataGrid.Columns.Contains("Id"))
                //    DataGrid.Columns["Id"].HeaderText = "Mã phiếu";
                //if (DataGrid.Columns.Contains("IdThanhVien"))
                //    DataGrid.Columns["IdThanhVien"].HeaderText = "Mã thành viên";
                //if (DataGrid.Columns.Contains("TenThanhVien"))
                //    DataGrid.Columns["TenThanhVien"].HeaderText = "Tên thành viên";
                //if (DataGrid.Columns.Contains("NgayTao"))
                //    DataGrid.Columns["NgayTao"].HeaderText = "Ngày tạo";
                //if (DataGrid.Columns.Contains("TrangThai"))
                //    DataGrid.Columns["TrangThai"].HeaderText = "Trạng thái";

                // (Tùy chọn) hiển thị phân trang lên giao diện
                lblCurrentPage.Text = $"{response.CurrentPage} / {response.TotalPages}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu phân trang: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadTrangThaiComboBox()
        {
            var trangThaiEnumValues = Enum.GetValues(typeof(TrangThaiPhieuMuonEnum));

            comboBoxTrangThai.Items.Clear();

            comboBoxTrangThai.Items.Add("Tất cả");

            foreach (var value in trangThaiEnumValues)
            {
                comboBoxTrangThai.Items.Add(value);
            }

            comboBoxTrangThai.SelectedIndex = 0;
        }
        private void SetPlaceholder(TextBox txt, string placeholder, Color placeholderColor)
        {
            txt.Text = placeholder;
            txt.ForeColor = placeholderColor;

            txt.Enter += (s, e) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                }
            };

            txt.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = placeholderColor;
                }
            };
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count > 0)
            {
                FormXemPhieuMuon form = new FormXemPhieuMuon();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // cập nhật thông tin
                }
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count > 0)
            {
                FormSuaPhieuMuon form = new FormSuaPhieuMuon();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // cập nhật thông tin
                }
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            FormThemPhieuMuon form = new FormThemPhieuMuon();
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                await LoadData(1, limit);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            comboBoxTrangThai.SelectedIndex = 0;
            fromDate.Checked = false;
            toDate.Checked = false;
            await LoadData(1, limit);
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadData(1, limit);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private async void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            await LoadData(1, limit);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private async void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            await LoadData(1, limit);
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            await LoadData(1, limit);
        }

        private async void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            await LoadData(currentPage, limit);
        }

        private async void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            await LoadData(currentPage, limit);
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                await LoadData(currentPage, limit);
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                await LoadData(currentPage, limit);
            }
        }
    }
}
