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
    public partial class FormXemLoaiThietBi : Form
    {
        private LoaiThietbi loaiThietbi;
        private LoaiThietBiService loaiThietBiService = new LoaiThietBiService();
        public FormXemLoaiThietBi(LoaiThietbi ltb)
        {
            InitializeComponent();
            loaiThietbi = ltb;
            LoadData();
        }

        private async void LoadData(){
            txtMaLoaiThietBi.Text = loaiThietbi.Id.ToString();
            txtSoLuongThietBi.Text = (await loaiThietBiService.CountTB(loaiThietbi.Id)).ToString();
            txtTenLoaiThietBi.Text = loaiThietbi.TenLoaiThietBi;
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

        private void FormXemLoaiThietBi_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtMaThanhVien_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
