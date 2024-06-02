using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using HotelV4.aclass;
using HotelV4.bclass;

namespace HotelV4
{
    public partial class AddCustomerInfo : Form
    {
        private static List<int> listIdCustomer;
        public static List<int> ListIdCustomer { get => listIdCustomer; set => listIdCustomer = value; }
        public AddCustomerInfo()
        {
            InitializeComponent();
            FormMover.Moveform(this);
            LoadCustomerType();
            ListIdCustomer = new List<int>();
            txtPhonenumber.Text = "20";

        }
        public void LoadCustomerType()
        {
            cbCusType.DataSource = CustomerTypeDAO.Instance.LoadListCustomerType();
            cbCusType.DisplayMember = "Name";
        }
        public bool IsIdCardExists(string idCard)
        {
            return CustomerDAO.Instance.IsIdCardExists(idCard);
        }
        public void InsertCustomer(string idCard, string name, int idCustomerType, DateTime dateofBirth, string address, int phonenumber, string sex, string nationality)
        {
            CustomerDAO.Instance.InsertCustomer(idCard, name, idCustomerType, dateofBirth, address, phonenumber, sex, nationality);
        }
        public void GetInfoByIdCard(string idCard)
        {
            Customer customer = CustomerDAO.Instance.GetInfoByIdCard(idCard);
            txtIDcard.Text = customer.IdCard.ToString();
            txtFullname.Text = customer.Name;
            txtAddress.Text = customer.Address;
            txtPhonenumber.Text = customer.PhoneNumber.ToString();
            dbo.Value = customer.DateOfBirth;
            cbSex.Text = customer.Sex;            
            cbNationality.Text = customer.Nationality;
            cbCusType.Text = CustomerTypeDAO.Instance.GetNameByIdCard(idCard);
        }
       public void ClearData()
        {
            txtIDCardSearch.Text = txtIDcard.Text = txtFullname.Text = txtAddress.Text = txtPhonenumber.Text = cbNationality.Text = String.Empty;
        }
        public void AddIdCustomer(int idCustomer)
        {
            if (ListIdCustomer.Count != 0)
            {
                bool check = false;
                foreach (int item in ListIdCustomer)
                {
                    if (item == idCustomer)
                    {
                        check = true;
                        break;
                    }
                }
                if (!check) ListIdCustomer.Add(idCustomer);
            }
            else
                ListIdCustomer.Add(idCustomer);
        }
        private int ParsePhoneNumber(string maskedPhoneNumber)
        {
            // Remove non-numeric characters using regular expressions
            string numericPhoneNumber = Regex.Replace(maskedPhoneNumber, @"[^\d]", "");

            // Convert the cleaned string to an integer
            return int.Parse(numericPhoneNumber);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFullname.Text != string.Empty && txtIDcard.Text != string.Empty && txtAddress.Text != string.Empty && cbNationality.Text != string.Empty && txtPhonenumber.Text != string.Empty)
            {
                if (!IsIdCardExists(txtIDcard.Text))
                {
                    int idCustomerType = (cbCusType.SelectedItem as CustomerType).Id;
                    InsertCustomer(txtIDcard.Text, txtFullname.Text, idCustomerType, dbo.Value, txtAddress.Text, ParsePhoneNumber(txtPhonenumber.Text), cbSex.Text, cbNationality.Text);
                }
                MessageBox.Show("Successfully added customers.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AddIdCustomer(CustomerDAO.Instance.GetInfoByIdCard(txtIDcard.Text).Id);
                ClearData();
            }
            else
                MessageBox.Show("Please enter complete information.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtIDCardSearch.Text != String.Empty)
            {
                if (IsIdCardExists(txtIDCardSearch.Text))
                    GetInfoByIdCard(txtIDCardSearch.Text);
                else
                    MessageBox.Show("ID card/ID card does not exist.\nPlease re-enter.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIDCardSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtIDcard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtPhonenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhonenumber_TextChanged(object sender, EventArgs e)
        {
            if (!txtPhonenumber.Text.StartsWith("20"))
            {
                txtPhonenumber.Text = "20";
                txtPhonenumber.SelectionStart = txtPhonenumber.Text.Length;
            }
        }
    }
}
