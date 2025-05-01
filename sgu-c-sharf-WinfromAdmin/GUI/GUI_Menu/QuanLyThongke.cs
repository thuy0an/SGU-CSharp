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
using Google.Protobuf.Collections;
using System.Xml.Linq;

namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_Menu
{
    public partial class QuanLyThongKe : Form
    {
        // thống kê thành viên
        private ThanhVienService thanhVienService = new ThanhVienService();
        private CheckInService checkInService = new CheckInService();
        private List<ThanhVien> listTV;
        private List<CheckIn> listCheckIn;
        private int count = 0;

        // thống kê thiết bị
        private ThietBiService thietBiService = new ThietBiService();
        private List<ThietBi> listTB;
        private List<DauThietBi> listDTB;
        private int countSum = 0, countKD = 0, countSD = 0;

        public QuanLyThongKe()
        {
            InitializeComponent();
            LoadData();
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;

        }

        private async void TabControl1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            TabControl cur = (TabControl)sender;
            if (cur.SelectedTab == tabTKThanhVien)
            {

                LoadDataTV();
            }
            else if (cur.SelectedTab == tabTKThietBi)
            {
                LoadDataTB();
            }
            else if (cur.SelectedTab == tabTKXuPhat)
            {
                LoadDataPM();
            }

        }

        private async void LoadData()
        {
            listTV = await thanhVienService.GetAll();
            listCheckIn = await checkInService.GetAll();
            LoadDataTV();
        }

        private async void LoadDataTV()
        {
            // load thông tin cho combobox
            var listHoTen = listTV.Select(tv => tv.HoTen).ToList();
            cbbThanhVien.Items.Clear();
            listHoTen.Insert(0, "Tất cả");
            cbbThanhVien.Items.AddRange(listHoTen.Cast<object>().ToArray());
            cbbThanhVien.SelectedIndex = 0;
            // load datagrid
            LoadTableForTV(await checkInService.GetAll());

        }
        private async void LoadDataTB()
        {
            listTB = await thietBiService.GetAll();
            listDTB = await thietBiService.GetDauThietBi();
            cbbThietBi.Items.Clear();
            cbbThietBi.Items.Add("Tất cả");
            var listTenTB = listTB.Select(tb => tb.TenThietBi).ToList();
            cbbThietBi.Items.AddRange(listTenTB.Cast<object>().ToArray());
            cbbThietBi.SelectedIndex = 0;
            LoadTableForTB(listDTB);
        }
        private void LoadDataPM()
        {
        }

        private void QuanLyThongKe_Load(object sender, EventArgs e)
        {

        }

        private void LoadTableForTV(List<CheckIn> listCheck)
        {
            int stt = 1;
            DataGridTV.Rows.Clear();
            foreach (var checkin in listCheck)
            {
                ThanhVien tv = listTV.FirstOrDefault(tv => tv.Id == checkin.IdThanhVien);
                DataGridTV.Rows.Add(stt++, tv.Id, tv.HoTen, checkin.ThoiGianCheckIn);
            }
            count = listCheck.Select(c => c.IdThanhVien).Distinct().Count();
            lblCount.Text = $"Tổng số thành viên đã đến quán: {count}";

        }

        private void LoadTableForTB(List<DauThietBi> listDTB)
        {
            int stt = 1;
            DataGridTB.Rows.Clear();
            foreach (var dtb in listDTB)
            {
                ThietBi tb = listTB.FirstOrDefault(tv => tv.Id == dtb.IdThietBi);
                DataGridTB.Rows.Add(stt++, tb.TenThietBi, dtb.Id, dtb.TrangThai.ToString());
            }
            countSum = listDTB.Count;
            countKD = listDTB.Where(tb => tb.TrangThai == DauThietBi.TrangThaiDauThietBi.KHADUNG).Count();
            countSD = listDTB.Count(tb => tb.TrangThai == DauThietBi.TrangThaiDauThietBi.DANGMUON || tb.TrangThai == DauThietBi.TrangThaiDauThietBi.DATTRUOC);
            lblTong.Text = $"Tổng số thiết bị: {countSum}";
            lblKD.Text = $"Thiết bị khả dụng: {countKD}";
            lblSD.Text = $"Thiết bị đang sử dụng: {countSD}";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbbThanhVien.SelectedIndex = 0;
            fromDate.Value = DateTime.Now;
            toDate.Value = DateTime.Now;
            LoadDataTV();
        }

        private async void cbbThanhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            String name = cbbThanhVien.SelectedItem.ToString();
            if (name == "Tất cả")
            {
                listCheckIn = await checkInService.GetAll();
                LoadTableForTV(listCheckIn);
            }
            else
            {
                List<CheckIn> listCheck = listCheckIn.Where(check => listTV.FirstOrDefault(tv => tv.HoTen == name).Id == check.IdThanhVien).ToList();
                LoadTableForTV(listCheck);
            }

        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            // Chuẩn hóa thời gian
            DateTime fromD = fromDate.Value.Date;
            DateTime toD = toDate.Value.Date.AddDays(1).AddTicks(-1);

            if (fromD > toD)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fromDate.Focus();
                return;
            }

            List<CheckIn> listCheck = new List<CheckIn>();
            foreach (var check in listCheckIn)
                if (check.ThoiGianCheckIn >= fromD && check.ThoiGianCheckIn <= toD)
                    listCheck.Add(check);
            LoadTableForTV(listCheck);
        }

        private async void cbbThietBi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nameTB = cbbThietBi.SelectedItem.ToString();
            if (nameTB == "Tất cả")
            {
                listDTB = await thietBiService.GetDauThietBi();
                LoadTableForTB(listDTB);
            }
            else
            {
                List<DauThietBi> lists = listDTB.Where(cur => listTB.FirstOrDefault(tb => tb.TenThietBi == nameTB).Id == cur.IdThietBi).ToList();
                LoadTableForTB(lists);
            }
        }
    }
}
