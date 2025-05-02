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
using OfficeOpenXml;

namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_Menu
{
    public partial class QuanLyThietBi : Form
    {
        private List<ThietBi> listTB;
        private ThietBiService thietBiService = new ThietBiService();
        private LoaiThietBiService loaiThietBiService = new LoaiThietBiService();
        private List<LoaiThietbi> listLTB;
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
                listLTB = await loaiThietBiService.GetAll();
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

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnExcel_Click(object sender, EventArgs e)
        {
            ExcelPackage.License.SetNonCommercialPersonal("ToiDay");
            string huongDan = "Nội dung file Excel gồm các cột sau:\n\n" +
                              "1. Tên thiết bị (Không được trùng với thiết bị trong hệ thống)\n" +
                              "2. Tên loại thiết bị\n" +
                              "3. Ảnh minh họa (nếu có)\n" +
                              "4. Số lượng đầu thiết bị\n";
            var res = MessageBox.Show(huongDan, "Định dạng excel", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (res == DialogResult.Cancel)
                return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = openFileDialog.FileName;
                try
                {
                    using (ExcelPackage pack = new ExcelPackage(new FileInfo(path)))
                    {
                        ExcelWorksheet worksheet = pack.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension.Rows;
                        int done = 0;
                        for (int row = 1; row <= rowCount; row++)
                        {
                            string tenTB = worksheet.Cells[row, 1].Text.Trim();
                            string tenLTB = worksheet.Cells[row, 2].Text.Trim();
                            string anhMinhHoa = worksheet.Cells[row, 3].Text.Trim();
                            string soluong = worksheet.Cells[row, 4].Text.Trim();

                            if (string.IsNullOrEmpty(tenTB) || string.IsNullOrEmpty(tenLTB) || string.IsNullOrEmpty(soluong))
                                continue;

                            if (listTB.Any(x => x.TenThietBi == tenTB))
                                continue;

                            if (!listLTB.Any(x => x.TenLoaiThietBi == tenLTB))
                                continue;


                            ThietBiCreateDTO cur = new ThietBiCreateDTO()
                            {
                                TenThietBi = tenTB,
                                IdLoaiThietBi = listLTB.FirstOrDefault(x => x.TenLoaiThietBi == tenLTB).Id,
                                SoLuongDauThietBi = int.Parse(soluong)
                            };

                            var resu = await  thietBiService.Add(cur);
                            if( resu.Success)
                                done++;
                        }
                        MessageBox.Show($"Thêm thành công {done} thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}