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
using System.Net.Http;
using System.Text.Json;
using sgu_c_sharf_WinfromAdmin.Services;
using sgu_c_sharf_WinfromAdmin.Models;
using OfficeOpenXml;


namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_Menu
{
    public partial class QuanLyThanhVien : Form
    {
        private List<ThanhVien> listTV;
        private ThanhVienService thanhVienService = new ThanhVienService();
        private Dictionary<TrangThaiEnum, string> HienThiTrangThai = new Dictionary<TrangThaiEnum, string>
        {
            { TrangThaiEnum.HOATDONG, "Hoạt động" },
            { TrangThaiEnum.DINHCHI, "Đình chỉ" },
            { TrangThaiEnum.CAM, "Cấm" }
        };


        public QuanLyThanhVien()
        {
            InitializeComponent();
            SetPlaceholder(txtSearch, "Tìm kiếm", Color.Gray);
            GetList();
        }

        public async void GetList()
        {
            try
            {
                listTV = await thanhVienService.GetAll();
                LoadData(listTV);
            }
            catch (JsonException ex)
            {
                MessageBox.Show("Lỗi phân tích dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void LoadData(List<ThanhVien> danhsach)
        {
            DataGrid.Rows.Clear();
            DataGrid.Columns["Column5"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            foreach (var tv in danhsach)
                DataGrid.Rows.Add(tv.Id, tv.HoTen, tv.Email, HienThiTrangThai[tv.TrangThai], tv.ThoiGianDangKy);
        }



        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            List<ThanhVien> filterList = new List<ThanhVien>();
            foreach (var tv in listTV)
                if (tv.HoTen.ToLower().Contains(searchText)
                    || tv.Id.ToString().Contains(searchText)
                    || tv.Email.ToLower().Contains(searchText)
                    || HienThiTrangThai[tv.TrangThai].ToLower().Contains(searchText))
                    filterList.Add(tv);
            LoadData(filterList);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count > 0)
            {
                ThanhVien tv = await thanhVienService.GetById(int.Parse(DataGrid.SelectedRows[0].Cells[0].Value.ToString()));

                FormXemThanhVien form = new FormXemThanhVien(tv);
                form.ShowDialog();
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count > 0)
            {
                ThanhVien tv = await thanhVienService.GetById(int.Parse(DataGrid.SelectedRows[0].Cells[0].Value.ToString()));
                if ( tv.Quyen == QuyenEnum.ADMIN)
                {
                    MessageBox.Show("Không thể chỉnh sửa thông tin admin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FormSuaThanhVien form = new FormSuaThanhVien(tv, this);
                form.ShowDialog();
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            SetPlaceholder(txtSearch, "Tìm kiếm", Color.Gray);
            LoadData(this.listTV);

        }

        private void QuanLyThanhVien_Load(object sender, EventArgs e)
        {

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

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemThanhVien form = new FormThemThanhVien(this);
            form.ShowDialog();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            ThemCheckIn form = new ThemCheckIn(listTV);
            form.ShowDialog();

        }

        private async void btnExcel_Click(object sender, EventArgs e)
        {
        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            string huongDan = "Nội dung file Excel gồm các cột sau:\n\n" +
                              "1. Họ tên\n" +
                              "2. Ngày sinh\n" +
                              "3. Email\n" +
                              "4. Số điện thoại\n" +
                              "5. Quyền \n" +
                              "6. Mật khẩu";
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
                    using (var pack = new ExcelPackage(new FileInfo(path)))
                    {
                        var worksheet = pack.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension.Rows;
                        int done = 0;
                        for (int row = 1; row <= rowCount; row++)
                        {
                            string hoten = worksheet.Cells[row, 1].Text.Trim();
                            string ngaySinhStr = worksheet.Cells[row, 2].Text.Trim();
                            string email = worksheet.Cells[row, 3].Text.Trim();
                            string soDienThoai = worksheet.Cells[row, 4].Text.Trim();
                            string quyen = worksheet.Cells[row, 5].Text.Trim();
                            string matKhau = worksheet.Cells[row, 6].Text.Trim();

                            if (string.IsNullOrEmpty(hoten) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(soDienThoai))
                                continue;

                            if (listTV.Any(x => x.Email == email || x.SoDienThoai == soDienThoai))
                                continue;

                            if (!DateTime.TryParse(ngaySinhStr, out DateTime ngaySinh))
                                continue;

                            if ((DateTime.Now.Year - ngaySinh.Year) < 18)
                                continue;
                            ThanhVien thanhVien = new ThanhVien()
                            {
                                HoTen = hoten,
                                NgaySinh = ngaySinh,
                                Email = email,
                                SoDienThoai = soDienThoai,
                                ThoiGianDangKy = DateTime.Now,
                                MatKhau = matKhau,
                                TrangThai = TrangThaiEnum.HOATDONG
                            };

                            bool resu = await thanhVienService.Add(thanhVien);
                            if (resu)
                                done++;
                        }
                        MessageBox.Show($"Thêm thành công {done} thành viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(await thanhVienService.GetAll());
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
