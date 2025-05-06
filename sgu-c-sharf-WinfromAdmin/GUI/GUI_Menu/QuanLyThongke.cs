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
using Microsoft.Office.Interop.Excel;

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

        // thống kê xử phạt
        private PhieuXuPhatService phieuXuPhatService = new PhieuXuPhatService();
        private List<PhieuXuPhatDetailDTO> listPXP;
        private int tienBoiThuong = 0;



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
        private async void LoadDataPM()
        {
            listPXP = await phieuXuPhatService.GetAllNoPagingAsync();
            listTV = await thanhVienService.GetAll();
            cbbXuPhat.Items.Clear();
            cbbXuPhat.Items.Add("Tất cả");

            // Thêm các giá trị enum vào ComboBox
            foreach (var status in Enum.GetNames(typeof(TrangThaiPhieuXuPhatEnum)))
                cbbXuPhat.Items.Add(status);
            cbbXuPhat.SelectedIndex = 0;
            LoadTableForXP(listPXP);
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

        private void LoadTableForXP(List<PhieuXuPhatDetailDTO> listpxp)
        {

            tienBoiThuong = 0;
            int stt = 1;
            dataGridXP.Rows.Clear();
            foreach (var cur in listpxp)
            {
                ThanhVien tv = listTV.FirstOrDefault(tv => tv.Id == cur.IdThanhVien);
                dataGridXP.Rows.Add(stt++, cur.Id, tv.HoTen, cur.MoTa, cur.NgayViPham, cur.MucPhat, cur.TrangThai);
                if (cur.TrangThai == TrangThaiPhieuXuPhatEnum.DAXULY)
                    tienBoiThuong += (int)cur.MucPhat;
            }
            lblTongTien.Text = $"Tổng số tiền đã được bồi thường: {tienBoiThuong}";

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
            txtSearch1.Text = "";
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

        private async void cbbXuPhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string trangthaiXP = cbbXuPhat.SelectedItem.ToString();
            if (trangthaiXP == "Tất cả")
            {
                listPXP = await phieuXuPhatService.GetAllNoPagingAsync();
                LoadTableForXP(listPXP);
            }
            else
            {
                Dictionary<string, TrangThaiPhieuXuPhatEnum> map = new Dictionary<string, TrangThaiPhieuXuPhatEnum>()
                {
                    { "DAXOA", TrangThaiPhieuXuPhatEnum.DAXOA },
                    { "CHUAXULY", TrangThaiPhieuXuPhatEnum.CHUAXULY },
                    { "DAXULY", TrangThaiPhieuXuPhatEnum.DAXULY }
                };
                TrangThaiPhieuXuPhatEnum enumTrangThai = map[trangthaiXP];
                List<PhieuXuPhatDetailDTO> lists = listPXP.Where(xp => xp.TrangThai == enumTrangThai).ToList();
                LoadTableForXP(lists);
            }
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch1.Text.ToLower();
            List<CheckIn> filterList = new List<CheckIn>();
            foreach (var cur in listTV)
            {
                if (cur.Id.ToString().Contains(searchText) || cur.HoTen.ToLower().Contains(searchText))
                {
                    var tv = listCheckIn
                        .Where(check => check.IdThanhVien == cur.Id)
                        .ToList();

                    filterList.AddRange(tv); // Thêm danh sách các CheckIn phù hợp
                }
            }

            LoadTableForTV(filterList);
        }

        private void btnReset2_Click(object sender, EventArgs e)
        {
            cbbThietBi.SelectedIndex = 0;
            LoadTableForTB(listDTB);
            txtSearch2.Text = "";
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch2.Text.ToLower();
            List<DauThietBi> filterList = new List<DauThietBi>();
            foreach (var tb in listTB)
            {
                if (tb.TenThietBi.ToLower().Contains(searchText))
                {
                    var listDau = listDTB
                        .Where(dtb => dtb.IdThietBi == tb.Id)
                        .ToList();

                    filterList.AddRange(listDau);
                }
            }
            LoadTableForTB(filterList);
        }

        private void btnReset3_Click(object sender, EventArgs e)
        {
            cbbXuPhat.SelectedIndex = 0;
            LoadTableForXP(listPXP);
            txtSearch3.Text = "";
        }

        private void txtSearch3_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch3.Text.ToLower();
            List<PhieuXuPhatDetailDTO> filterList = listPXP.Where(xp =>{
                    ThanhVien tv = listTV.FirstOrDefault(t => t.Id == xp.IdThanhVien);
                    return tv != null && tv.HoTen.ToLower().Contains(searchText);
                })
                .ToList();

            LoadTableForXP(filterList);
        }
    }
}
