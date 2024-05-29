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
    public partial class AddCustomerType : Form
    {
        public AddCustomerType()
        {
            InitializeComponent();
            FormMover.Moveform(this);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to add a new Customer type?", "Result", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                InsertCustomerType();
        }
        private void InsertCustomerType()
        {
            if (fCustomer.CheckFillInText(new Control[] { txtcus }))
            {
                try
                {
                    CustomerType customerTypeNow = GetCustomerTypeNow();
                    if (CustomerTypeDAO.Instance.InsertCustomerType(customerTypeNow.Name))
                    {
                        MessageBox.Show("Added successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtcus.Text = string.Empty;
                    }
                    else
                        MessageBox.Show("Data entry error", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Service type error already exists", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Cannot be left blank", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private CustomerType GetCustomerTypeNow()
        {
            CustomerType customerType = new CustomerType();
            customerType.Name = txtcus.Text.Trim();
            return customerType;
        }
    }
}
