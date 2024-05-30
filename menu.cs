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
            this.username = username;
            InitializeComponent();
            FormMover.Moveform(this);
            btnuser.Text = username;
            

        }
        public bool IsAdmin()
        {
            return AccountTypeb.Instance.GetStaffTypeByUserName(username).Id == 1;
        }
        void fLoad()
        {

            panelLeft.Width = 177;

        }
        private bool CheckAccess(string nameform)
        {
            return permissionB.Instance.CheckAccess(username, nameform);
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
            if (CheckAccess("employee"))
            {
                this.Hide();
                employee frm = new employee();
                frm.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("You Can't access.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        private void btnBookroom_Click(object sender, EventArgs e)
        {
            
            if (CheckAccess("Bookroom"))
            {
                this.Hide();
                Bookroom frm = new Bookroom();
                frm.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("You Can't access.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCheckin_Click(object sender, EventArgs e)
        {
            
            if (CheckAccess("check-in"))
            {
                this.Hide();
                check_in frm = new check_in();
                frm.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("You Can't access.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnaddRoom_Click(object sender, EventArgs e)
        {
            if (CheckAccess("invoice"))
            {
                this.Hide();
                add_room frm = new add_room();
                frm.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("You Can't access.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btninvoice_Click(object sender, EventArgs e)
        {
            
            if (CheckAccess("invoice"))
            {
                this.Hide();
                invoice frm = new invoice();
                frm.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("You Can't access.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnservice_Click(object sender, EventArgs e)
        {
            
            if (CheckAccess("add-service"))
            {
                this.Hide();
                add_service frm = new add_service();
                frm.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("You Can't access.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btbSerandpay_Click(object sender, EventArgs e)
        {
            
            if (CheckAccess("service-payment"))
            {
                this.Hide();
                service_payment frm = new service_payment(username);
                frm.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("You Can't access.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {

          
            if (CheckAccess("customer"))
            {
                this.Hide();
                fCustomer frm = new fCustomer();
                frm.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("You Can't access.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {            
            if (CheckAccess("Revenue"))
            {
                this.Hide();
                Revenue frm = new Revenue();
                frm.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("You Can't access.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void menu_Load(object sender, EventArgs e)
        {
            
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit", "Result", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            if (panelLeft.Width == 42)
            {
                panelLeft.Width = 177;
                this.Width = 1280;
            }
            else
            {
                panelLeft.Width = 42;
                this.Width = 1280;
            }
        }
    }
}
