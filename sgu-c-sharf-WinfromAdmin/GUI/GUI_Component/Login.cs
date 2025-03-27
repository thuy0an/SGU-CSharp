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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login.ActiveForm.Hide();
            MainFrame mF = new MainFrame();
            mF.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
