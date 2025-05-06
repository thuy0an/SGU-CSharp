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
using static sgu_c_sharf_WinfromAdmin.Models.DauThietBi;

namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    public partial class FormSuaPhieuMuon : Form
    {
        private readonly int _idPhieuMuon;
        private readonly PhieuMuonService _phieuMuonService;
        private readonly ChiTietPhieuMuonService _chiTietPhieuMuonService;
        private readonly ThietBiService _thietBiService;
        private readonly DauThietBiService _dauThietBiService;
        private readonly TrangThaiPhieuMuonService _trangThaiPhieuMuonService;
        List<ChiTietPhieuMuonDetailDTO> _chiTietPhieuMuons;
        PhieuMuonDetailDTO _phieuMuonDetailDTO;

        List<ThietBiListAvailabilityDTO> _thietBis;

        public FormSuaPhieuMuon(int IdPhieuMuon)
        {
            InitializeComponent();
            _idPhieuMuon = IdPhieuMuon;
            _phieuMuonService = new PhieuMuonService();
            _chiTietPhieuMuonService = new ChiTietPhieuMuonService();
            _trangThaiPhieuMuonService = new TrangThaiPhieuMuonService();
            _phieuMuonDetailDTO = new PhieuMuonDetailDTO();
            _chiTietPhieuMuons = new List<ChiTietPhieuMuonDetailDTO>();
            _thietBis = new List<ThietBiListAvailabilityDTO>();
            _thietBiService = new ThietBiService();
            _dauThietBiService = new DauThietBiService();
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

            txtMaPhieu.Text = _phieuMuonDetailDTO.Id.ToString();
            txtMaThanhVien.Text = _phieuMuonDetailDTO.IdThanhVien.ToString();
            txtTenNguoiDung.Text = _phieuMuonDetailDTO.TenThanhVien;
            txtNgayTao.Text = _phieuMuonDetailDTO.NgayTao.ToString("dd/MM/yyyy HH:mm:ss");

            cbbTrangThai.DataSource = Enum.GetValues(typeof(TrangThaiPhieuMuonEnum));

            cbbTrangThai.SelectedItem = _phieuMuonDetailDTO.TrangThai;

            _chiTietPhieuMuons = await _chiTietPhieuMuonService.GetAllByPhieuMuonId(_idPhieuMuon);
            loadDataGrid();
            _thietBis = await _thietBiService.GetAllWithAvailability();
        }

        private void loadDataGrid()
        {
            dataGrid.Rows.Clear();
            foreach (var item in _chiTietPhieuMuons)
            {
                dataGrid.Rows.Add(
                    item.IdDauThietBi,
                    item.TrangThai.ToString(),
                    item.ThoiGianMuon?.ToString("dd/MM/yyyy HH:mm:ss") ?? "",
                    item.ThoiGianTra?.ToString("dd/MM/yyyy HH:mm:ss") ?? ""
                );
            }
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

        private async void btnThemDauThietBi_Click(object sender, EventArgs e)
        {
            _thietBis = await _thietBiService.GetAllWithAvailability();
            MuonDauThietBi form = new MuonDauThietBi(_thietBis);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ThietBiListAvailabilityDTO thietBi = form.thietBiListAvailabilityDTO;
                if (thietBi != null)
                {
                    List<DauThietBi> list = await _dauThietBiService.GetDauThietBiByIdVaSoLuong(thietBi.Id, thietBi.SoLuongKhaDung);
                    List<ChiTietPhieuMuonCreateDTO> chiTietPhieuMuonCreateDTOs = new List<ChiTietPhieuMuonCreateDTO>();
                    foreach (var dauThietBi in list)
                    {
                        chiTietPhieuMuonCreateDTOs.Add(new ChiTietPhieuMuonCreateDTO
                        {
                            IdPhieuMuon = _idPhieuMuon,
                            IdDauThietBi = dauThietBi.Id,
                            TrangThai = TrangThaiChiTietPhieuMuonEnum.DANGMUON,
                            ThoiGianMuon = DateTime.Now
                        });
                    }
                    bool isCreate = await _chiTietPhieuMuonService.Add(chiTietPhieuMuonCreateDTOs);
                    if (isCreate)
                    {
                        // Load lại danh sách chi tiết phiếu mượn từ server
                        _chiTietPhieuMuons = await _chiTietPhieuMuonService.GetAllByPhieuMuonId(_idPhieuMuon);
                        loadDataGrid();
                        MessageBox.Show("Thêm chi tiết phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (cbbTrangThai.SelectedItem != null)
            {
                TrangThaiPhieuMuonEnum trangThaiMoi = (TrangThaiPhieuMuonEnum)cbbTrangThai.SelectedItem;
                if (trangThaiMoi != _phieuMuonDetailDTO.TrangThai)
                {
                    var chiTietUpdates = _chiTietPhieuMuons.Select(ct => new ChiTietPhieuMuonUpdateDTO
                    {
                        IdPhieuMuon = _idPhieuMuon,
                        IdDauThietBi = ct.IdDauThietBi,
                        TrangThai = (ct.TrangThai == TrangThaiChiTietPhieuMuonEnum.DATHATLAC)
                                    ? ct.TrangThai
                                    : (trangThaiMoi == TrangThaiPhieuMuonEnum.HUY || trangThaiMoi == TrangThaiPhieuMuonEnum.DATRATHIETBI)
                                        ? TrangThaiChiTietPhieuMuonEnum.DATRATHIETBI
                                        : (trangThaiMoi == TrangThaiPhieuMuonEnum.DATCHO || trangThaiMoi == TrangThaiPhieuMuonEnum.DANGSUDUNG)
                                            ? TrangThaiChiTietPhieuMuonEnum.DANGMUON
                                            : (trangThaiMoi == TrangThaiPhieuMuonEnum.CHODUYET)
                                                ? (TrangThaiChiTietPhieuMuonEnum.CHODUYET)
                                                : ct.TrangThai,
                        ThoiGianTra = (trangThaiMoi == TrangThaiPhieuMuonEnum.DATRATHIETBI) ? DateTime.Now : ct.ThoiGianTra
                    }).ToList();

                    var dauThietBiUpdates = chiTietUpdates.Select(ct => new DauThietBi
                    {
                        Id = ct.IdDauThietBi,
                        TrangThai = ct.TrangThai switch
                        {
                            TrangThaiChiTietPhieuMuonEnum.CHODUYET => TrangThaiDauThietBi.DATTRUOC,
                            TrangThaiChiTietPhieuMuonEnum.DANGMUON => TrangThaiDauThietBi.DANGMUON,
                            TrangThaiChiTietPhieuMuonEnum.DATRATHIETBI => TrangThaiDauThietBi.KHADUNG,
                            TrangThaiChiTietPhieuMuonEnum.DATHATLAC => TrangThaiDauThietBi.THATLAC,
                            _ => TrangThaiDauThietBi.KHADUNG
                        }
                    }).ToList();


                    // Gọi update
                    bool isUpdatedChiTiet = await _chiTietPhieuMuonService.Update(chiTietUpdates);
                    bool isUpdatedDauThietBi = await _dauThietBiService.UpdateDanhSachDauThietBi(dauThietBiUpdates);
                    bool isAddedTrangThai = await _trangThaiPhieuMuonService.Add(new TrangThaiPhieuMuonCreateDTO
                    {
                        IdPhieuMuon = _idPhieuMuon,
                        TrangThai = trangThaiMoi,
                        ThoiGianCapNhat = DateTime.Now
                    });

                    if (isUpdatedChiTiet && isUpdatedDauThietBi && isAddedTrangThai)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi cập nhật.");
                    }
                }
                else
                {
                    MessageBox.Show("Trạng thái không thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn trạng thái hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSuaDauThietBi_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                int idDauThietBi = Convert.ToInt32(dataGrid.SelectedRows[0].Cells["IdDauThietBi"].Value);
                ChiTietPhieuMuonDetailDTO chiTietPhieuMuonDetail = _chiTietPhieuMuons.FirstOrDefault(x => x.IdDauThietBi == idDauThietBi);
                SuaMuonDauThietBi form = new SuaMuonDauThietBi(chiTietPhieuMuonDetail);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    loadDataGrid();
                }
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cbbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btnXoaDauThietBi_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa thiết bị này khỏi phiếu mượn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                // 1️⃣ Lấy IdDauThietBi từ dataGrid
                int idDauThietBi = Convert.ToInt32(dataGrid.SelectedRows[0].Cells["IdDauThietBi"].Value);

                // 2️⃣ Tạo DTO để xóa
                var deleteList = new List<ChiTietPhieuMuonDeleteDTO>
                {
                    new ChiTietPhieuMuonDeleteDTO
                    {
                        IdPhieuMuon = _idPhieuMuon,
                        IdDauThietBi = idDauThietBi
                    }
                };

                // 3️⃣ Gọi hàm Delete
                bool isDeleted = await _chiTietPhieuMuonService.Delete(deleteList);
                if (!isDeleted)
                {
                    MessageBox.Show("Không thể xóa chi tiết phiếu mượn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 4️⃣ Tạo đối tượng DauThietBi cần update trạng thái
                var updatedDauThietBiList = new List<DauThietBi>
                {
                    new DauThietBi
                    {
                        Id = idDauThietBi,
                        TrangThai = DauThietBi.TrangThaiDauThietBi.KHADUNG,
                    }
                };

                // 5️⃣ Gọi hàm UpdateDanhSachDauThietBi
                bool isUpdated = await _dauThietBiService.UpdateDanhSachDauThietBi(updatedDauThietBiList);
                if (!isUpdated)
                {
                    MessageBox.Show("Không thể cập nhật trạng thái đầu thiết bị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // 6️⃣ Xóa dòng khỏi dataGrid
                dataGrid.Rows.RemoveAt(dataGrid.SelectedRows[0].Index);

                MessageBox.Show("Xóa thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
