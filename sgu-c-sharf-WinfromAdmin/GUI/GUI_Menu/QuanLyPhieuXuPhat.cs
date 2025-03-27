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

namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_Menu
{
    public partial class QuanLyPhieuXuPhat : Form
    {
        public QuanLyPhieuXuPhat()
        {
            InitializeComponent();
            SetPlaceholder(txtSearch, "Tìm kiếm", Color.Gray);
            LoadData();
        }

        private void LoadData()
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

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count > 0)
            {
                FormXemPhieuXuphat form = new FormXemPhieuXuphat();
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
                FormSuaPhieuXuphat form = new FormSuaPhieuXuphat();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // cập nhật thông tin
                }
            }
            else
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemPhieuXuphat form = new FormThemPhieuXuphat();
            form.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}
