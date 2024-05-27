using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HotelV4.aclass;
using HotelV4.bclass;

namespace HotelV4
{
    public partial class menu : Form
    {
        private string username;
        public menu(string username)
        {
            InitializeComponent();
            FormMover.Moveform(this);
            btnuser.Text = username;


        }


        private void lbExit_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Do you want to logout?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                login frm = new login();
                frm.Show();
            }

            
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            employee frm = new employee();
            frm.Show();
            this.Close();
        }

        private void btnBookroom_Click(object sender, EventArgs e)
        {
            Bookroom frm = new Bookroom();
            frm.Show();
            this.Close();

        }

        private void btnCheckin_Click(object sender, EventArgs e)
        {
            check_in frm = new check_in();
            frm.Show();
            this.Close();

        }

        private void btnaddRoom_Click(object sender, EventArgs e)
        {
            add_room frm = new add_room();
            frm.Show();
            this.Close();

        }

        private void btninvoice_Click(object sender, EventArgs e)
        {
            invoice frm = new invoice();
            frm.Show();
            this.Close();

        }

        private void btnservice_Click(object sender, EventArgs e)
        {
            add_service frm = new add_service();
            frm.Show();
            this.Close();

        }

        private void btbSerandpay_Click(object sender, EventArgs e)
        {
            service_payment frm = new service_payment();
            frm.Show();
            this.Close();

        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            fCustomer frm = new fCustomer();
            frm.Show();
            this.Close();

        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            Revenue frm = new Revenue();
            frm.Show();
            this.Close();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            
        }
    }
}
