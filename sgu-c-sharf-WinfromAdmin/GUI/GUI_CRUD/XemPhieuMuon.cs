using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sgu_c_sharf_WinfromAdmin.Services;

namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    public partial class FormXemPhieuMuon : Form
    {
        private readonly int _idPhieuMuon;
        private readonly PhieuMuonService _phieuMuonService;
        private readonly ChiTietPhieuMuonService _chiTietPhieuMuonService;
        private readonly DauThietBiService _dauThietBiService;

        public FormXemPhieuMuon(int IdPhieuMuon)
        {
            InitializeComponent();
            _idPhieuMuon = IdPhieuMuon;
            _phieuMuonService = new PhieuMuonService();
            _chiTietPhieuMuonService = new ChiTietPhieuMuonService();
            _dauThietBiService = new DauThietBiService();
        }
        private async void FormXemPhieuMuon_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var detail = await _phieuMuonService.GetById(_idPhieuMuon);

            if (detail == null)
            {
                MessageBox.Show("Không tìm thấy phiếu mượn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Hiển thị thông tin phiếu mượn
            txtMaPhieu.Text = detail.Id.ToString();
            txtMaThanhVien.Text = detail.IdThanhVien.ToString();
            txtTenNguoiDung.Text = detail.TenThanhVien;
            txtNgayTao.Text = detail.NgayTao.ToString("dd/MM/yyyy HH:mm:ss");
            txtTrangThai.Text = detail.TrangThai.ToString();
            // Bind danh sách chi tiết phiếu mượn vào DataGridView

            var chiTietPhieuMuons = await _chiTietPhieuMuonService.GetAllByPhieuMuonId(_idPhieuMuon);
            dataGrid.Rows.Clear();
            foreach (var item in chiTietPhieuMuons)
            {
                var dauThietBi = await _dauThietBiService.GetDauThietBiById(item.IdDauThietBi);
                dataGrid.Rows.Add(
                    dauThietBi.TenThietBi,
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

        private void btnThemDauThietBi_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaDauThietBi_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                //SuaMuonDauThietBi form = new SuaMuonDauThietBi();
                //if (form.ShowDialog() == DialogResult.OK)
                //{
                //    // cập nhật thông tin
                //}
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void txtMaPhieu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaThanhVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
