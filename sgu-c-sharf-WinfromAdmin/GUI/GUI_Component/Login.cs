using sgu_c_sharf_WinfromAdmin.GUI.GUI_CRUD;
using sgu_c_sharf_WinfromAdmin.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgu_c_sharf_WinfromAdmin.GUI
{
    public partial class Login : Form
    {
        private ThanhVienService TVService = new ThanhVienService();
        public Login()
        {
            InitializeComponent();
            this.FormClosing += Login_FormClosing;
            // Set txtMK to hide characters when entering a password.
            txtMK.UseSystemPasswordChar = true;
        }

        // New event handler: when the form is closing, exit the application.
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void chkMK_CheckedChanged(object sender, EventArgs e)
        {
            txtMK.UseSystemPasswordChar = !chkMK.Checked;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            //String phoneOrEmail = txtTK.Text.Trim();
            //String pass = txtMK.Text.Trim();
            //if (phoneOrEmail == "" || phoneOrEmail == "")
            //{
            //    MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //int res = await TVService.CheckRole(pass, phoneOrEmail);
            //if (res  == 0)
            //{
            //    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //else if (res  == 2 )
            //{
            //    MessageBox.Show("Tài khoản này không có quyền admin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            Login.ActiveForm.Hide();
            MainFrame mF = new MainFrame();
            mF.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            ThemCheckIn form = new ThemCheckIn();
            form.ShowDialog();
        }
    }
}
