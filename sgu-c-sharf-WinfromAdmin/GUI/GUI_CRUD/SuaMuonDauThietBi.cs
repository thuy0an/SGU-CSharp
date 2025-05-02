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

namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    public partial class SuaMuonDauThietBi : Form
    {
        private ChiTietPhieuMuonDetailDTO _chiTietPhieuMuonDetail;
        public SuaMuonDauThietBi(ChiTietPhieuMuonDetailDTO chiTietPhieuMuonDetail)
        {
            InitializeComponent();
            _chiTietPhieuMuonDetail = chiTietPhieuMuonDetail;
        }

        private void SuaMuonDauThietBi_Load(object sender, EventArgs e)
        {
            txtMaDauThietBi.Text = _chiTietPhieuMuonDetail.IdDauThietBi.ToString();
            dateMuon.Value = _chiTietPhieuMuonDetail.ThoiGianMuon ?? DateTime.Now;
            dateTra.Value = _chiTietPhieuMuonDetail.ThoiGianTra ?? DateTime.Now;
            cbbTrangThai.DataSource = Enum.GetValues(typeof(TrangThaiChiTietPhieuMuonEnum));
            cbbTrangThai.SelectedItem = _chiTietPhieuMuonDetail.TrangThai;
        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTrangThai.SelectedItem is TrangThaiChiTietPhieuMuonEnum trangThai)
            {
                if (trangThai == TrangThaiChiTietPhieuMuonEnum.DATRATHIETBI)
                {
                    dateTra.Value = DateTime.Now;
                    _chiTietPhieuMuonDetail.ThoiGianTra = DateTime.Now;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_chiTietPhieuMuonDetail.ThoiGianTra < _chiTietPhieuMuonDetail.ThoiGianMuon)
            {
                MessageBox.Show("Thời gian trả không thể nhỏ hơn thời gian mượn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbbTrangThai.SelectedItem is TrangThaiChiTietPhieuMuonEnum selectedTrangThai)
            {
                _chiTietPhieuMuonDetail.TrangThai = selectedTrangThai;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
