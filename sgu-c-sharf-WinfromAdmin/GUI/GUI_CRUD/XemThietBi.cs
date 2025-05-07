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

        private async void HienThiThongTin()
        {
            if (thietBi != null)
            {
                txtMaThietBi.Text = thietBi.Id.ToString();
                txtTenThietBi.Text = thietBi.TenThietBi;
                txtTenLoaiThietBi.Text = thietBi.TenLoaiThietBi;

                // Lấy tên ảnh
                string tenFileAnh = await thietBiService.GetHinhAnhById(thietBi.Id);

                // Đường dẫn tương đối đến thư mục ảnh
                string duongDanThuMucAnh = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "sgu-c-sharf-frontend", "img");
                string duongDanAnhDayDu = Path.Combine(duongDanThuMucAnh, tenFileAnh);

                duongDanAnhDayDu = Path.GetFullPath(duongDanAnhDayDu);

                if (!File.Exists(duongDanAnhDayDu))
                {
                    MessageBox.Show($"Không tìm thấy ảnh tại: {duongDanAnhDayDu}");
                    picMinhHoa.Image = null;
                    return;
                }
                try
                {
                    picMinhHoa.Image = Image.FromFile(duongDanAnhDayDu);
                    picMinhHoa.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}");
                    picMinhHoa.Image = null;
                }
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
                        dataGrid.Rows.Add(dauThietBi.Id, dauThietBi.TrangThai, dauThietBi.ThoiGianMua.ToString("yyyy-MM-dd"));
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