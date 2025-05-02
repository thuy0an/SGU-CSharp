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
    public partial class FormSuaPhieuMuon : Form
    {
        private readonly int _idPhieuMuon;
        private readonly PhieuMuonService _phieuMuonService;
        private readonly ChiTietPhieuMuonService _chiTietPhieuMuonService;
        private readonly ThietBiService _thietBiService = new ThietBiService();
        List<ChiTietPhieuMuonDetailDTO> _chiTietPhieuMuons;
        PhieuMuonDetailDTO _phieuMuonDetailDTO;
        List<DauThietBi> _dauThietBis;
        List<ThietBiListAvailabilityDTO> _thietBis;

        public FormSuaPhieuMuon(int IdPhieuMuon)
        {
            InitializeComponent();
            _idPhieuMuon = IdPhieuMuon;
            _phieuMuonService = new PhieuMuonService();
            _chiTietPhieuMuonService = new ChiTietPhieuMuonService();
            _phieuMuonDetailDTO = new PhieuMuonDetailDTO();
            _chiTietPhieuMuons = new List<ChiTietPhieuMuonDetailDTO>();
            _dauThietBis = new List<DauThietBi>();
            _thietBis = new List<ThietBiListAvailabilityDTO>();
        }

        private async void FormSuaPhieuMuon_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            _phieuMuonDetailDTO = await _phieuMuonService.GetById(_idPhieuMuon);

            if (_phieuMuonDetailDTO == null)
            {
                MessageBox.Show("Không tìm thấy phiếu mượn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Hiển thị thông tin phiếu mượn
            txtMaPhieu.Text = _phieuMuonDetailDTO.Id.ToString();
            txtMaThanhVien.Text = _phieuMuonDetailDTO.IdThanhVien.ToString();
            txtTenNguoiDung.Text = _phieuMuonDetailDTO.TenThanhVien;
            txtNgayTao.Text = _phieuMuonDetailDTO.NgayTao.ToString("dd/MM/yyyy HH:mm:ss");

            // Bind enum cho ComboBox
            cbbTrangThai.DataSource = Enum.GetValues(typeof(TrangThaiPhieuMuonEnum));

            // Đảm bảo SelectedItem chính xác
            cbbTrangThai.SelectedItem = _phieuMuonDetailDTO.TrangThai;

            // Hoặc nếu cần chọn theo string:
            // cbbTrangThai.SelectedItem = Enum.Parse(typeof(TrangThaiPhieuMuonEnum), detail.TrangThai.ToString());

            // Bind danh sách chi tiết phiếu mượn vào DataGridView
            _chiTietPhieuMuons = await _chiTietPhieuMuonService.GetAllByPhieuMuonId(_idPhieuMuon);
            dataGrid.Rows.Clear();
            foreach (var item in _chiTietPhieuMuons)
            {
                dataGrid.Rows.Add(
                    item.IdDauThietBi,
                    item.TrangThai.ToString(), // Hiển thị enum dưới dạng string
                    item.ThoiGianMuon?.ToString("dd/MM/yyyy HH:mm:ss") ?? "",
                    item.ThoiGianTra?.ToString("dd/MM/yyyy HH:mm:ss") ?? ""
                );
            }
            _thietBis = await _thietBiService.GetAllWithAvailability();
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
            MuonDauThietBi form = new MuonDauThietBi(thietBis);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ThietBiListAvailabilityDTO thietBi = form.thietBiListAvailabilityDTO;
                if (thietBi != null)
                {
                    DauThietBiService _dauThietBiService = new DauThietBiService();
                    List<DauThietBi> list = await _dauThietBiService.GetDauThietBiByIdVaSoLuong(thietBi.Id, thietBi.SoLuongKhaDung);
                    dauThietBis.AddRange(list);
                    dataGrid.Rows.Clear();
                    foreach (var item in dauThietBis)
                    {
                        int index = dataGrid.Rows.Add(item.IdThietBi, item.Id);
                        dataGrid.Rows[index].Cells["Column1"].Value = item.IdThietBi;
                        dataGrid.Rows[index].Cells["Column2"].Value = item.Id;
                    }
                }
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaDauThietBi_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                SuaMuonDauThietBi form = new SuaMuonDauThietBi();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // cập nhật thông tin
                }
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
