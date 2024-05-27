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
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
            LoadFullCustomerType();
        }
        private void LoadFullCustomerType()
        {
            DataTable table = GetFullCustomerType();
            cbCusType.DataSource = table;
            cbCusType.DisplayMember = "Name";
            if (table.Rows.Count > 0)
                cbCusType.SelectedIndex = 0;
        }
        private DataTable GetFullCustomerType()
        {
            return CustomerTypeDAO.Instance.LoadFullCustomerType();
        }
        private void Clean()
        {
            txtFullname.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtIDcard.Text = string.Empty;
            cbNationality.Text = string.Empty;
            txtPhonenumber.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to add a new customer?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                if (CheckDate())
                {
                    InsertCustomer();
                }
                else
                {
                    MessageBox.Show("The date of birth must be earlier than the current date", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private bool CheckDate()
        {
            if (DateTime.Now.Subtract(datepickerDateOfBirth.Value).Days <= 0)
                return false;
            else return true;
        }
        private void InsertCustomer()
        {
            if (!CheckFillInText(new Control[] { txtPhonenumber, txtFullname, txtIDcard, cbNationality, txtAddress, cbCusType }))
            {
                MessageBox.Show("Fields cannot be left empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Customer customer = GetCustomerNow();
                if (CustomerDAO.Instance.InsertCustomer(customer))
                {
                    MessageBox.Show("Insert successful", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clean();
                }
                else
                {
                    MessageBox.Show("Customer already exists\nDuplicate ID card number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch
            {
                MessageBox.Show("Error inserting customer", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
        private Customer GetCustomerNow()
        {
            employee.Trim(new TextBox[] { txtAddress, txtFullname, txtIDcard });
            Customer customer = new Customer();
            customer.IdCard = txtIDcard.Text;
            int id = cbCusType.SelectedIndex;
            customer.IdCustomerType = (int)((DataTable)cbCusType.DataSource).Rows[id]["id"];
            customer.Name = txtFullname.Text;
            customer.Sex = cbSex.Text;
            customer.PhoneNumber = int.Parse(txtPhonenumber.Text);
            customer.DateOfBirth = datepickerDateOfBirth.Value;
            customer.Nationality = cbNationality.Text;
            customer.Address = txtAddress.Text;
            return customer;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPhonenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
