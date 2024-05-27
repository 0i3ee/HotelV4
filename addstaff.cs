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
        public addstaff()
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
            DialogResult result = MessageBox.Show("Do you want to add new employees?", "Result", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {

                if (CheckDate())
                {
                    InsertStaff();
                    cleardata();
                }
            }
            
                      
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

        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.' || e.KeyChar == '-' ||
                e.KeyChar == '_' || e.KeyChar == '@'))
                e.Handled = true;
        }
        private bool CheckDate()
        {
            if (!CheckTrueDate(dob.Value, DateTime.Now))
            {
                MessageBox.Show("Invalid date of birth (Age must be greater than 18)", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                if (!CheckTrueDate(dob.Value, doe.Value))
            {
                MessageBox.Show("Invalid employment date (Older than 18 years old)", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool CheckTrueDate(DateTime date1, DateTime date2)
        {
            if (date2.Subtract(date1).Days < 6574)
                return false;
            return true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
