using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sgu_c_sharf_WinfromAdmin.Models;
using sgu_c_sharf_WinfromAdmin.Services;

namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    public partial class FormThemPhieuMuon : Form
    {
        List<DauThietBi> dauThietBis;
        List<ThietBiListAvailabilityDTO> thietBis;
        public FormThemPhieuMuon()
        {
            InitializeComponent();
            dauThietBis = new List<DauThietBi>();
            loadData();
        }

        public async void loadData()
        {
            ThietBiService _thietBiService = new ThietBiService();
            thietBis = await _thietBiService.GetAllWithAvailability();
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

        private void btnSuaDauThietBi_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                SuaDauThietBi form = new SuaDauThietBi();
                if (form.ShowDialog() == DialogResult.OK)
                {

                }
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaThanhVien.Text.Trim(), out int idThanhVien))
            {
                MessageBox.Show("Vui lòng nhập ID thành viên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ThanhVienService thanhVienService = new ThanhVienService();
            var thanhVien = await thanhVienService.GetById(idThanhVien);

            if (thanhVien == null)
            {
                MessageBox.Show("Không tìm thấy thành viên với ID này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PhieuMuonService phieuMuonService = new PhieuMuonService();

            PhieuMuonCreateDTO createDTO = new PhieuMuonCreateDTO
            {
                IdThanhVien = idThanhVien,
                NgayTao = DateTime.Now
            };

            int? idPhieuMuon = await phieuMuonService.Add(createDTO);
            if (idPhieuMuon.HasValue)
            {
                TrangThaiPhieuMuonService trangThaiService = new TrangThaiPhieuMuonService();
                TrangThaiPhieuMuonCreateDTO trangThaiDTO = new TrangThaiPhieuMuonCreateDTO
                {
                    IdPhieuMuon = idPhieuMuon.Value,
                    TrangThai = TrangThaiPhieuMuonEnum.DANGSUDUNG,
                    ThoiGianCapNhat = DateTime.Now
                };

                bool isTrangThaiAdded = await trangThaiService.Add(trangThaiDTO);

                if (!isTrangThaiAdded)
                {
                    MessageBox.Show("Không thể thêm trạng thái phiếu mượn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ChiTietPhieuMuonService chiTietService = new ChiTietPhieuMuonService();

                List<ChiTietPhieuMuonCreateDTO> chiTietList = new List<ChiTietPhieuMuonCreateDTO>();
                foreach (var dauThietBi in dauThietBis) 
                {
                    chiTietList.Add(new ChiTietPhieuMuonCreateDTO
                    {
                        IdPhieuMuon = idPhieuMuon.Value,
                        IdDauThietBi = dauThietBi.Id,
                        ThoiGianMuon = DateTime.Now,
                        TrangThai = TrangThaiChiTietPhieuMuonEnum.DANGMUON
                    });

                    dauThietBi.TrangThai = DauThietBi.TrangThaiDauThietBi.DANGMUON;
                }
                bool isChiTietAdded = await chiTietService.Add(chiTietList);

                // Cập nhật trạng thái đầu thiết bị
                DauThietBiService dauThietBiService = new DauThietBiService();
                bool isDauThietBiUpdated = await dauThietBiService.UpdateDanhSachDauThietBi(dauThietBis);

                if (isTrangThaiAdded && isChiTietAdded && isDauThietBiUpdated)
                {
                    MessageBox.Show("Tạo phiếu mượn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Tạo phiếu mượn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Tạo phiếu mượn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtMaThanhVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXoaDauThietBi_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đầu thiết bị để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy Id từ cột "Column1" của dòng đang chọn
            int idDauThietBi = Convert.ToInt32(dataGrid.SelectedRows[0].Cells["Column2"].Value);
            int idThietBi = Convert.ToInt32(dataGrid.SelectedRows[0].Cells["Column1"].Value);

            // Xác nhận xóa
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa đầu thiết bị Id = {idDauThietBi}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa khỏi danh sách
                var itemToRemove = dauThietBis.FirstOrDefault(x => x.Id == idDauThietBi);
                if (itemToRemove != null)
                {
                    dauThietBis.Remove(itemToRemove);
                }
                var thietBi = thietBis.FirstOrDefault(tb => tb.Id == idThietBi);
                if (thietBi != null)
                {
                    thietBi.SoLuongKhaDung += 1;
                }

                // Xóa dòng trên DataGridView
                dataGrid.Rows.RemoveAt(dataGrid.SelectedRows[0].Index);

                MessageBox.Show("Đã xóa đầu thiết bị khỏi danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbbNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
