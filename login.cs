using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

using HotelV4.aclass;
namespace HotelV4
{
    public partial class login : Form
    {
        ClassconnectDB ccd = new ClassconnectDB();
        public login()
        {
            InitializeComponent();
            FormMover.Moveform(this);
        }

        private void login_Load(object sender, EventArgs e)
        {
            ccd.connectDatabase();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string displayName = Login();
            if (displayName != null)
            {
                this.Hide();
                menu frm = new menu(displayName);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Username or Password Incorrect", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string Login()
        {
            txtPassword.Text.Trim();
            txtUsername.Text.Trim();
            return querycon.Instance.Login(txtUsername.Text, txtPassword.Text);
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnLogin.PerformClick();
            }
        }
    }
}
