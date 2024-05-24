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
<<<<<<< HEAD
            
            
=======
>>>>>>> 6b9fe74d445280b872a06f6c5abf367707e8aa46
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (Login())
            {
                string username = txtUsername.Text;
                this.Hide();
                menu frm = new menu(username);

                frm.Show();
            }
            else
            {
                MessageBox.Show("Username or PassWord Uncorrect", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public bool Login()
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
