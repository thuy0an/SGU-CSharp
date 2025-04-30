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
using sgu_c_sharf_WinfromAdmin.Services;
using sgu_c_sharf_WinfromAdmin.Models;

namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_Menu
{
    public partial class QuanLyThietBi : Form
    {
        private List<ThietBi> listTB;
        private ThietBiService thietBiService = new ThietBiService();
        private Dictionary<DaXoaEnum, string> HienThiTrangThai = new Dictionary<DaXoaEnum, string>
        {
            { DaXoaEnum.CHUAXOA, "Chưa xóa" },
            { DaXoaEnum.DAXOA, "Đã xóa" }
        };

        public QuanLyThietBi()
        {
            InitializeComponent();
            SetPlaceholder(txtSearch, "Tìm kiếm", Color.Gray);
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                listTB = await thietBiService.GetAll();
                DataGrid.Rows.Clear();
                foreach (var tb in listTB)
                {
                    DataGrid.Rows.Add(tb.Id, tb.TenThietBi, tb.TenLoaiThietBi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private async void btnXem_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count > 0)
            {
                int selectedId = int.Parse(DataGrid.SelectedRows[0].Cells[0].Value.ToString());
                ThietBi tb = await thietBiService.GetById(selectedId);
                FormXemThietBi form = new FormXemThietBi(tb); // Truyền tb vào constructor
                form.ShowDialog();
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void RefreshDataGridView()
        {
            LoadData();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count > 0)
            {
                int selectedId = int.Parse(DataGrid.SelectedRows[0].Cells[0].Value.ToString());
                ThietBi tb = await thietBiService.GetById(selectedId);
                FormSuaThietBi form = new FormSuaThietBi(this, tb);
                form.ShowDialog();
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemThietBi form = new FormThemThietBi(this);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // Cập nhật danh sách sau khi thêm
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count > 0)
            {
                int selectedId = int.Parse(DataGrid.SelectedRows[0].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thiết bị này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    List<DauThietBi> listDTB = await thietBiService.GetDauThietBiByThietBiId(selectedId);
                    // kiểm tra tồn tại đầu thiết bị có trạng thái đang mượn hoặc đặt trước thì không thể xóa
                    if (listDTB.Any(dtb => dtb.TrangThai == DauThietBi.TrangThaiDauThietBi.DANGMUON || dtb.TrangThai == DauThietBi.TrangThaiDauThietBi.DATTRUOC))
                    {
                        MessageBox.Show("Không thể xóa thiết bị đang có đầu thiết bị thuộc trạng thái đã đặt trước, đang sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    bool check = await thietBiService.Delete(selectedId);
                    if (check)
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                        MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            SetPlaceholder(txtSearch, "Tìm kiếm", Color.Gray);
            LoadData();
        }
        private void LoadDataSearch(List<ThietBi> danhsach)
        {
            DataGrid.Rows.Clear();
            foreach (var tb in danhsach)
            {
                DataGrid.Rows.Add(tb.Id, tb.TenThietBi);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Bỏ qua nếu văn bản là placeholder
            if (txtSearch.Text == "Tìm kiếm" && txtSearch.ForeColor == Color.Gray)
            {
                return;
            }

            string searchText = txtSearch.Text.ToLower();
            List<ThietBi> filterList = new List<ThietBi>();
            foreach (var tb in listTB)
            {
                if (tb.Id.ToString().Contains(searchText) ||
                    (tb.TenThietBi?.ToLower().Contains(searchText) ?? false) ||
                    (tb.TenLoaiThietBi?.ToLower().Contains(searchText) ?? false))
                {
                    filterList.Add(tb);
                }
            }

            LoadDataSearch(filterList);
        }
        private void QuanLyThietBi_Load(object sender, EventArgs e)
        {

        }

    }
}