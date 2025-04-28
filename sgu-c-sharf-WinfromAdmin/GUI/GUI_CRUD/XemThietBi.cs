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
    public partial class FormXemThietBi : Form
    {
        private ThietBi thietBi;
        private readonly ThietBiService thietBiService;

        public FormXemThietBi()
        {
            InitializeComponent();
            thietBiService = new ThietBiService();
        }

        public FormXemThietBi(ThietBi thietBi)
        {
            InitializeComponent();
            this.thietBi = thietBi;
            thietBiService = new ThietBiService();
            HienThiThongTin();
            HienThiDauThietBi();
        }

        private void HienThiThongTin()
        {
            if (thietBi != null)
            {
                txtMaThietBi.Text = thietBi.Id.ToString();
                txtTenThietBi.Text = thietBi.TenThietBi;
                txtTenLoaiThietBi.Text = thietBi.TenLoaiThietBi;
            }
        }

        private async void HienThiDauThietBi()
        {
            if (thietBi != null)
            {
                try
                {
                    var dauThietBis = await thietBiService.GetDauThietBiByThietBiId(thietBi.Id);
                    dataGrid.Rows.Clear();
                    foreach (var dauThietBi in dauThietBis)
                    {
                        string trangThaiText = dauThietBi.TrangThai switch
                        {
                            DauThietBi.TrangThaiDauThietBi.KHADUNG => "Có thể sử dụng",
                            DauThietBi.TrangThaiDauThietBi.DATTRUOC => "Đã đặt trước",
                            DauThietBi.TrangThaiDauThietBi.DANGMUON => "Đang mượn",
                            DauThietBi.TrangThaiDauThietBi.BAOTRI => "Bảo trì",
                            DauThietBi.TrangThaiDauThietBi.THATLAC => "Thất lạc",
                            _ => "Không xác định"
                        };
                        dataGrid.Rows.Add(dauThietBi.Id, trangThaiText, dauThietBi.ThoiGianMua.ToString("yyyy-MM-dd"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải danh sách đầu thiết bị: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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