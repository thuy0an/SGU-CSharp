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
    public partial class FormXemPhieuXuphat : Form
    {
        private readonly PhieuXuPhatService _phieuXuPhatService;
        private PhieuXuPhatDetailDTO _phieuXuPhatDetailDTO;
        private uint _Id;

        public FormXemPhieuXuphat(uint Id)
        {
            InitializeComponent();
            _Id = Id;
            _phieuXuPhatService = new PhieuXuPhatService();
            LoadData();
        }

        private async void LoadData()
        {
            var phieuXuPhatDetail = await _phieuXuPhatService.GetByIdAsync(_Id);
            if (phieuXuPhatDetail != null)
            {
                _phieuXuPhatDetailDTO = phieuXuPhatDetail;
                txtMaPhieu.Text = _phieuXuPhatDetailDTO.Id.ToString();
                txtMaThanhVien.Text = _phieuXuPhatDetailDTO.IdThanhVien.ToString();
                txtTenThanhVien.Text = _phieuXuPhatDetailDTO.TenThanhVien;
                txtHanXuPhat.Text = _phieuXuPhatDetailDTO.ThoiHanXuPhat.ToString();
                txtMoTa.Text = _phieuXuPhatDetailDTO.MoTa;
                txtTrangThai.Text = _phieuXuPhatDetailDTO.TrangThai.ToString();
                txtNgayViPham.Text = _phieuXuPhatDetailDTO.NgayViPham.ToString();
                txtMucPhat.Text = _phieuXuPhatDetailDTO.MucPhat.ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin phiếu xử phạt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ThemDauThietBi form = new ThemDauThietBi();
            form.ShowDialog();
        }
    }
}
