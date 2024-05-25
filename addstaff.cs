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
    
    
    public partial class addstaff : Form
    {
        private string username;
        public addstaff(string username)
        {
            InitializeComponent();
            FormMover.Moveform(this);
            LoadFullStaffType();

        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static bool CheckFillInText(Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control.Text == string.Empty)
                    return false;
            }
            return true;
        }

        private void InsertStaff()
        {
            bool isFill = CheckFillInText(new Control[] { txtname, cbtype, txtdis ,
                                                            txtid , cbsex , txtphone, txtaddress});
            if (isFill)
            {

                    Accout accountNow = GetStaffNow();
                    if (AccountB.Instance.InsertAccount(accountNow))
                    {
                        MessageBox.Show("AD Success" + txtname.Text +
                            "Pass : "+ mtpass.Text , "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Already Have", "Result", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            else
            {
                MessageBox.Show("Can't insert", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Accout GetStaffNow()
        {
            Accout account = new Accout();
            account.UserName = txtname.Text;
            account.DisplayName = txtdis.Text;
            account.PassWord = AccountB.Instance.HashPass(mtpass.Text);
            int index = cbtype.SelectedIndex;
            account.IdStaffType = (int)((DataTable)cbtype.DataSource).Rows[index]["id"];
            account.IdCard = txtid.Text;
            account.DateOfBirth = dob.Value;
            account.Sex = cbsex.Text;
            account.Address = txtaddress.Text;
            account.PhoneNumber = int.Parse(txtphone.Text);
            account.StartDay = doe.Value;

            return account;
        }
        void cleardata()
        {
            txtname.Clear();
            txtaddress.Clear();
            txtdis.Clear();
            txtid.Clear();
            txtphone.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            InsertStaff();
            employee frm = new employee(username);
            frm.Show();
            this.Close();
            


        }

        private void LoadFullStaffType()
        {

            cbsex.SelectedIndex = 0;
            DataTable table = GetFullStaffType();
            cbtype.DataSource = table;
            cbtype.DisplayMember = "Name";
            if (table.Rows.Count > 0)
                cbtype.SelectedIndex = 0;
        }

        private DataTable GetFullStaffType()
        {
            return AccountTypeb.Instance.LoadFullStaffType();
        }
    }
}
