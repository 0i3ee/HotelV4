﻿using System;
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
           
            if (Login())
            {
                this.Hide();
                menu frm = new menu();
                frm.Show();
            }
            else {
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
    }
}
