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
    public partial class UpdateCustomerInfo : Form
    {
        string idCard;
        public UpdateCustomerInfo(string _idCard)
        {
            InitializeComponent();
            FormMover.Moveform(this);
            idCard = _idCard;
            LoadCustomerType();
            LoadCustomerInfo(_idCard);
        }
        public void LoadCustomerType()
        {
            cbCusType.DataSource = CustomerTypeDAO.Instance.LoadListCustomerType();
            cbCusType.DisplayMember = "Name";
        }
        public void LoadCustomerInfo(string idCard)
        {
            Customer customer = CustomerDAO.Instance.GetInfoByIdCard(idCard);
            txtIDcard.Text = customer.IdCard.ToString();
            txtFullname.Text = customer.Name;
            txtAddress.Text = customer.Address;
            dbo.Value = customer.DateOfBirth;
            cbSex.Text = customer.Sex;
            txtPhonenumber.Text = customer.PhoneNumber.ToString();
            cbNationality.Text = customer.Nationality;
            cbCusType.Text = CustomerTypeDAO.Instance.GetNameByIdCard(idCard);
        }
        public void UpdateCustomer()
        {
            int idCustomerType = (cbCusType.SelectedItem as CustomerType).Id;
            CustomerDAO.Instance.UpdateCustomer(CustomerDAO.Instance.GetInfoByIdCard(idCard).Id, txtFullname.Text, txtIDcard.Text, idCustomerType, int.Parse(txtPhonenumber.Text), dbo.Value, txtAddress.Text, cbSex.Text, cbNationality.Text);
        }
        public void ClearData()
        {
            txtIDcard.Text = txtFullname.Text = txtAddress.Text = txtPhonenumber.Text = cbNationality.Text = String.Empty;
        }
        public bool IsIdCardExists(string idCard)
        {
            return CustomerDAO.Instance.IsIdCardExists(idCard);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void txtPhonenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtFullname.Text != string.Empty && txtIDcard.Text != string.Empty && txtAddress.Text != string.Empty && cbNationality.Text != string.Empty && txtPhonenumber.Text != string.Empty)
            {
                //Check if the IDCard is the same
                if (!IsIdCardExists(txtIDcard.Text) || txtIDcard.Text == idCard)
                {
                    UpdateCustomer();
                    MessageBox.Show("Updated customer information successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                    LoadCustomerInfo(idCard);
                }
                else
                    MessageBox.Show("ID card/ID card is invalid.\nPlease re-enter.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please enter complete information.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
