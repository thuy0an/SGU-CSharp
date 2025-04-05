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
    public partial class FormSuaLoaiThietBi : Form
    {
        private LoaiThietbi loaiThietbi;
        private QuanLyLoaiThietBi menu;
        private LoaiThietBiService loaiThietBiService = new LoaiThietBiService();
        public FormSuaLoaiThietBi(LoaiThietbi ltb, QuanLyLoaiThietBi menu)
        {
            InitializeComponent();
            this.loaiThietbi = ltb;
            this.menu = menu;
            LoadData();

        }

        private async void LoadData()
        {
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

        private void FormSuaLoaiThietBi_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtMaThanhVien_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            string tenLoai = txtTenLoaiThietBi.Text.Trim();
            if( tenLoai == "")
            {
                MessageBox.Show("Tên loại thiết bị không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if( loaiThietbi.TenLoaiThietBi != tenLoai){
                List<LoaiThietbi> listLTB = await loaiThietBiService.GetAll();
                foreach (var ltb in listLTB)
                    if (ltb.TenLoaiThietBi == tenLoai)
                    {
                        MessageBox.Show("Tên loại thiết bị đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                loaiThietbi.TenLoaiThietBi = tenLoai;
                bool check = await loaiThietBiService.Update(loaiThietbi);
                if ( check){
                    MessageBox.Show("Đã cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    menu.GetList();
                    this.Close();
                }
                else
                    MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
