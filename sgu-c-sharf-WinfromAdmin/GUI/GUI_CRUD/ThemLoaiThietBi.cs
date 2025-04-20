using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sgu_c_sharf_WinfromAdmin.GUI.GUI_Menu;
using sgu_c_sharf_WinfromAdmin.Models;
using sgu_c_sharf_WinfromAdmin.Services;

namespace sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD
{
    public partial class FormThemLoaiThietBi : Form
    {
        QuanLyLoaiThietBi menu;
        public List<LoaiThietbi> listLTB;
        private LoaiThietBiService loaiThietBiService = new LoaiThietBiService();
        public FormThemLoaiThietBi(List<LoaiThietbi> listLTB, QuanLyLoaiThietBi menu)
        {
            InitializeComponent();
            this.menu = menu;
            this.listLTB = listLTB;
            LoadData();
        }

        private void LoadData(){
            
            var cur = loaiThietBiService.GetNextIndex();
            this.txtMaLoaiThietBi.Text = cur.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormThemLoaiThietBi_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtMaThanhVien_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            string ten = txtTenLoaiThietBi.Text.Trim();
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Vui lòng nhập tên loại thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (var cur in listLTB)
            {
                if( cur.TenLoaiThietBi.Equals(ten)){
                MessageBox.Show("Tên loại thiết bị đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                }
            }
            LoaiThietbi loaiThietBi = new LoaiThietbi();
            loaiThietBi.TenLoaiThietBi = ten;
            bool check = await loaiThietBiService.Add(loaiThietBi);
            if (check)
            {
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                menu.GetList();
                this.Close();
            }
            else
                MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
