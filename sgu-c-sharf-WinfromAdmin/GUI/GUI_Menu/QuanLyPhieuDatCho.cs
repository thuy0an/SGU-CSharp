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
using sgu_c_sharf_WinfromAdmin.Models;
using sgu_c_sharf_WinfromAdmin.Services;

namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_Menu
{
    public partial class QuanLyPhieuDatCho : Form
    {
        private List<PhieuDatCho> listPDC;
        private PhieuDatChoService phieuDatChoService = new PhieuDatChoService();
        private Dictionary<PhieuDatChoEnum, string> HienThiTrangThai = new Dictionary<PhieuDatChoEnum, string>
        {
            { PhieuDatChoEnum.HUY, "Đã hủy" },
            { PhieuDatChoEnum.DANGCHO, "Đang chờ" },
            { PhieuDatChoEnum.DANGSUDUNG, "Đang sử dụng" },
            { PhieuDatChoEnum.DATRACHO, "Đã trả chỗ" }
        };
        public QuanLyPhieuDatCho()
        {
            InitializeComponent();
            SetPlaceholder(txtSearch, "Tìm kiếm", Color.Gray);
            LoadData();
        }

        private void LoadData()
        {
            listPDC = phieuDatChoService.GetAll();
            DataGrid.Rows.Clear();
            foreach (var pdc in listPDC)
                DataGrid.Rows.Add(pdc.Id, pdc.IdThanhVien, pdc.ThoiGianDat, pdc.ThoiGianLapPhieu, HienThiTrangThai[pdc.TrangThai]);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count > 0)
            {
                // lấy thông tin

                // mở form
                FormXemPhieuDatCho form = new FormXemPhieuDatCho();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // cập nhật thông tin
                }
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count > 0)
            {
                // lấy thông tin

                // mở form
                FormSuaPhieuDatCho form = new FormSuaPhieuDatCho();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // cập nhật thông tin
                }
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void QuanLyPhieuDatCho_Load(object sender, EventArgs e)
        {

        }
    }
}
