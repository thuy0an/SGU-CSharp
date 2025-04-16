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
    public partial class QuanLyLoaiThietBi : Form
    {
        private List<LoaiThietbi> listLTB;
        private LoaiThietBiService loaiThietBiService = new LoaiThietBiService();
        private Dictionary<DaXoaEnum, string> HienThiTrangThai = new Dictionary<DaXoaEnum, string>
        {
            { DaXoaEnum.CHUAXOA, "Chưa xóa" },
            { DaXoaEnum.DAXOA, "Đã xóa" }
        };
        public QuanLyLoaiThietBi()
        {
            InitializeComponent();
            SetPlaceholder(txtSearch, "Tìm kiếm", Color.Gray);
            GetList();
        }

        public async void GetList()
        {
            try
            {
                listLTB = await loaiThietBiService.GetAll();
                LoadData(listLTB);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public async void LoadData(List<LoaiThietbi> danhsach)
        {
            DataGrid.Rows.Clear();
            foreach (var ltb in danhsach)
                DataGrid.Rows.Add(ltb.Id, ltb.TenLoaiThietBi, ltb.TrangThai);
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
                int selectedRow = int.Parse(DataGrid.SelectedRows[0].Cells[0].Value.ToString());
                LoaiThietbi cur = await loaiThietBiService.GetById(selectedRow);
                FormXemLoaiThietBi form = new FormXemLoaiThietBi(cur);
                form.ShowDialog();
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count > 0)
            {
                int selectedRow = int.Parse(DataGrid.SelectedRows[0].Cells[0].Value.ToString());
                LoaiThietbi cur = await loaiThietBiService.GetById(selectedRow);
                FormSuaLoaiThietBi form = new FormSuaLoaiThietBi(cur, this);
                form.ShowDialog();

            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemLoaiThietBi form = new FormThemLoaiThietBi(listLTB, this);
            form.ShowDialog();
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count > 0)
            {
                int selectedRow = int.Parse(DataGrid.SelectedRows[0].Cells[0].Value.ToString());

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa loại thiết bị này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int soluong = await loaiThietBiService.CountTB(selectedRow);
                    if (soluong != 0)
                    {
                        MessageBox.Show("Không thể xóa loại thiết đang có " + soluong + " thiết bị thuộc loại này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    bool check = await loaiThietBiService.Delete(selectedRow);
                    if (check)
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetList();
                    }
                    else
                        MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            SetPlaceholder(txtSearch, "Tìm kiếm", Color.Gray);
            this.listLTB = await loaiThietBiService.GetAll();
            LoadData(this.listLTB);

        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            List<LoaiThietbi> filter = new List<LoaiThietbi>();
            foreach (var ltb in listLTB)
                if (ltb.TenLoaiThietBi.ToLower().Contains(searchText) || ltb.Id.ToString().Contains(searchText))
                    filter.Add(ltb);
            LoadData(filter);
        }

        private void QuanLyLoaiThietBi_Load(object sender, EventArgs e)
        {

        }
    }
}
