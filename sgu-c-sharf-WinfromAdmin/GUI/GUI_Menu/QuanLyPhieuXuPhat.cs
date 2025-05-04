using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD;
using System.Windows.Forms;
using sgu_c_sharf_WinfromAdmin.Models;
using sgu_c_sharf_WinfromAdmin.Services;
using ZstdSharp.Unsafe;
using Mysqlx.Crud;
using System.Drawing.Printing;

namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_Menu
{
    public partial class QuanLyPhieuXuPhat : Form
    {
        private readonly PhieuXuPhatService _phieuXuPhatService;
        private List<PhieuXuPhatDetailDTO> _phieuXuPhatList;
        private PhieuXuPhatDetailDTO? _selectedPhieuXuPhat;
        private int _currentPage = 1;
        private int _pageSize = 10;
        private int _totalPages = 0;

        public QuanLyPhieuXuPhat()
        {
            _phieuXuPhatService = new PhieuXuPhatService();
            _phieuXuPhatList = new List<PhieuXuPhatDetailDTO>();
            _selectedPhieuXuPhat = null;
            InitializeComponent();
            SetPlaceholder(txtSearch, "Tìm kiếm", Color.Gray);
            runLoad();
        }

        private async void runLoad()
        {
            LoadTrangThaiComboBox();
            txtSearch.Text = "";
            comboBoxTrangThai.SelectedIndex = 0;
            fromDate.Checked = false;
            toDate.Checked = false;
            await LoadData(1);
        }

        private async Task LoadData(int page = 1)
        {
            try
            {
                string searchKeyword = txtSearch.Text.Trim().ToLower();
                TrangThaiPhieuXuPhatEnum? selectedTrangThai = comboBoxTrangThai.SelectedIndex != 0 ? (TrangThaiPhieuXuPhatEnum?)comboBoxTrangThai.SelectedItem : null;

                DateTime? fromDateQr = fromDate.Checked ? fromDate.Value.Date : null;
                DateTime? toDateQr = toDate.Checked ? toDate.Value.Date : null;

                if (fromDateQr != null && toDateQr != null && fromDateQr > toDateQr)
                {
                    toDateQr = fromDateQr;
                    toDate.Value = fromDateQr.Value;
                }

                PhieuXuPhatPagingResponse response = await _phieuXuPhatService.GetAllPagingAsync(page, _pageSize, selectedTrangThai, fromDateQr, toDateQr, searchKeyword);
                _currentPage = response.Page;
                _totalPages = (int)Math.Ceiling((double)response.TotalItems / _pageSize);
                _phieuXuPhatList = response.Items;

                DataGrid.Rows.Clear();
                foreach (var item in _phieuXuPhatList)
                {
                    DataGrid.Rows.Add(item.Id, item.IdThanhVien, item.TenThanhVien, item.TrangThai, item.NgayViPham, item.ThoiHanXuPhat);
                }

                lblCurrentPage.Text = $"{_currentPage} / {_totalPages}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu phân trang: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTrangThaiComboBox()
        {
            var trangThaiEnumValues = Enum.GetValues(typeof(TrangThaiPhieuXuPhatEnum));

            comboBoxTrangThai.Items.Clear();

            comboBoxTrangThai.Items.Add("Tất cả");

            foreach (var value in trangThaiEnumValues)
            {
                if ((TrangThaiPhieuXuPhatEnum)value == TrangThaiPhieuXuPhatEnum.DAXOA)
                {
                    continue;
                }
                comboBoxTrangThai.Items.Add(value);
            }

            comboBoxTrangThai.SelectedIndex = 0;
        }

        private async void QuanLyPhieuXuPhat_Load(object sender, EventArgs e)
        {
            // Load data into DataGridView
            LoadTrangThaiComboBox();
            txtSearch.Text = "";
            comboBoxTrangThai.SelectedIndex = 0;
            fromDate.Checked = false;
            toDate.Checked = false;
            await LoadData(1);
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
                int selectedRowIndex = DataGrid.SelectedRows[0].Index;

                string idPhieuStr = DataGrid.Rows[selectedRowIndex].Cells["Id"].Value.ToString();

                if (uint.TryParse(idPhieuStr, out uint Id))
                {
                    FormXemPhieuXuphat form = new FormXemPhieuXuphat(Id);
                    form.Show();
                }
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count > 0)
            {
                FormSuaPhieuXuphat form = new FormSuaPhieuXuphat();
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
            FormThemPhieuXuphat form = new FormThemPhieuXuphat();
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                await LoadData(1);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    int selectedRowIndex = DataGrid.SelectedRows[0].Index;

                    string idPhieuStr = DataGrid.Rows[selectedRowIndex].Cells["Id"].Value.ToString();
                    if (uint.TryParse(idPhieuStr, out uint Id))
                    {
                        var isDeleted = await _phieuXuPhatService.DeleteAsync(Id);
                        if (isDeleted)
                        {
                            DataGrid.Rows.RemoveAt(selectedRowIndex);
                            MessageBox.Show("Xóa phiếu xử phạt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Xóa phiếu xử phạt thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            comboBoxTrangThai.SelectedIndex = 0;
            fromDate.Checked = false;
            toDate.Checked = false;
            await LoadData(1);
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void comboBoxTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadData(1);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnLast_Click(object sender, EventArgs e)
        {
            _currentPage = _totalPages;
            await LoadData(_currentPage);
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await LoadData(_currentPage);
            }
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await LoadData(_currentPage);
            }
        }

        private async void btnFirst_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            await LoadData(_currentPage);
        }

        private async void fromDate_ValueChanged(object sender, EventArgs e)
        {
            fromDate.Checked = true;
            await LoadData(1);
        }

        private async void toDate_ValueChanged(object sender, EventArgs e)
        {
            toDate.Checked = true;
            await LoadData(1);
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            await LoadData(1);
        }
    }
}
