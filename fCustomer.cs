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
using System.Text.RegularExpressions;


namespace HotelV4
{
    public partial class fCustomer : Form
    {
        public fCustomer()
        {
            InitializeComponent();
            FormMover.Moveform(this);
            cbOptionsearch.SelectedIndex = 3;
            LoadFullCustomerType();
            LoadFullCustomer(GetFullCustomer());
            cbSex.SelectedIndex = 0;
            cbid.DisplayMember = "id";
            FormClosing += FCustomer_FormClosing;
            btnSearch.Click += btnSearch_Click;
            btnCancel.Click += btnCancel_Click;
            txtSearch.KeyPress += txtSearch_KeyPress;

        }
        private void LoadFullCustomer(DataTable table)
        {
            BindingSource source = new BindingSource();
            source.DataSource = table;
            DGV.DataSource = source;
            bindingCustomer.BindingSource = source;
            cbid.DataSource = source;
        }
        private void LoadFullCustomerType()
        {
            DataTable table = GetFullCustomerType();
            cbCusType.DataSource = table;
            cbCusType.DisplayMember = "Name";
            if (table.Rows.Count > 0)
                cbCusType.SelectedIndex = 0;
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new AddCustomer().ShowDialog();
            if (btnCancel.Visible == false)
                LoadFullCustomer(GetFullCustomer());
            else
                btnCancel_Click(null, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadFullCustomer(GetFullCustomer());
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            txtFullname.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtIDcard.Text = string.Empty;
            cbNationality.Text = string.Empty;
            txtPhonenumber.Text = string.Empty;
        }
        private int ParsePhoneNumber(string maskedPhoneNumber)
        {
            // Remove non-numeric characters using regular expressions
            string numericPhoneNumber = Regex.Replace(maskedPhoneNumber, @"[^\d]", "");

            // Convert the cleaned string to an integer
            return int.Parse(numericPhoneNumber);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to update this customer?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                if (CheckDate())
                {
                    UpdateCustomer();
                    cbid.Focus();
                }
                else
                {
                    MessageBox.Show("The date of birth must be earlier than the current date", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                // Clear input fields
                txtAddress.Text = string.Empty;
                txtFullname.Text = string.Empty;
                txtIDcard.Text = string.Empty;
                txtPhonenumber.Text = string.Empty;
                cbNationality.Text = string.Empty;

                // Toggle visibility of buttons
                btnSearch.Visible = false;
                btnCancel.Visible = true;

                // Perform the search operation
                Search();
            }
            else
            {
                MessageBox.Show("Search field cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        //private void InsertCustomer()
        //{
        //    if (!CheckFillInText(new Control[] { txtPhonenumber, txtFullname, txtIDcard, cbNationality, txtAddress, cbCusType }))
        //    {
        //        MessageBox.Show("Fields cannot be left empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    try
        //    {
        //        Customer customer = GetCustomerNow();
        //        if (CustomerDAO.Instance.InsertCustomer(customer))
        //        {
        //            MessageBox.Show("Insert successful", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            if (btnCancel.Visible == false)
        //                LoadFullCustomer(GetFullCustomer());
        //            else
        //                btnCancel_Click(null, null);
        //            cbid.SelectedIndex = DGV.RowCount - 1;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Customer already exists\nDuplicate ID card number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error inserting customer", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void UpdateCustomer()
        {
            if (cbid.Text == string.Empty)
            {
                MessageBox.Show("This customer does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (!CheckFillInText(new Control[] { txtPhonenumber, txtFullname, txtIDcard, cbNationality, txtAddress, cbCusType }))
            {
                MessageBox.Show("Fields cannot be left empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Customer customerPre = groupCustomer.Tag as Customer;
                try
                {
                    Customer customerNow = GetCustomerNow();
                    if (customerNow.Equals(customerPre))
                    {
                        MessageBox.Show("You have not changed any data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        bool check = CustomerDAO.Instance.UpdateCustomer(customerNow, customerPre);
                        if (check)
                        {
                            MessageBox.Show("Update successful", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupCustomer.Tag = customerNow;
                            int index = DGV.SelectedRows[0].Index;
                            LoadFullCustomer(GetFullCustomer());
                            cbid.SelectedIndex = index;
                        }
                        else
                        {
                            MessageBox.Show("This customer already exists (Duplicate ID card number)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Update error", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                txtFullname.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtIDcard.Text = string.Empty;
                cbNationality.Text = string.Empty;
                txtPhonenumber.Text = string.Empty;
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorMovePreviousItem.Enabled = false;
            }
            else
            {
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
                txtFullname.Text = row.Cells["colNameCustomer"].Value.ToString();
                txtAddress.Text = row.Cells["colAddress"].Value.ToString();
                txtIDcard.Text = row.Cells["colIDCard"].Value.ToString();
                cbNationality.Text = row.Cells["colNationality"].Value.ToString();
                txtPhonenumber.Text = row.Cells["colPhone"].Value.ToString();
                cbCusType.SelectedIndex = (int)row.Cells["colIdCustomerType"].Value - 1;
                cbSex.SelectedItem = row.Cells["colSex"].Value;
                datepickerDateOfBirth.Value = (DateTime)row.Cells["colDateOfBirth"].Value;
                Customer customer = new Customer(((DataRowView)row.DataBoundItem).Row);
                groupCustomer.Tag = customer;
            }
        }
        private void Search()
        {
            string searchString = txtSearch.Text;
            int mode = cbOptionsearch.SelectedIndex;
            DataTable searchResults = GetSearchCustomer(searchString, mode);
            LoadFullCustomer(searchResults);
        }


        #region GetData
        private Customer GetCustomerNow()
        {
            employee.Trim(new TextBox[] { txtAddress, txtFullname, txtIDcard });
            Customer customer = new Customer();
            if (cbid.Text == string.Empty)
                customer.Id = 0;
            else
                customer.Id = int.Parse(cbid.Text);
            customer.IdCard = txtIDcard.Text;
            int id = cbCusType.SelectedIndex;
            customer.IdCustomerType = (int)((DataTable)cbCusType.DataSource).Rows[id]["id"];
            customer.Name = txtFullname.Text;
            customer.Sex = cbCusType.Text;
            customer.PhoneNumber = ParsePhoneNumber(txtPhonenumber.Text);
            customer.DateOfBirth = datepickerDateOfBirth.Value;
            customer.Nationality = cbNationality.Text;
            customer.Address = txtAddress.Text;
            return customer;
        }
        private DataTable GetFullCustomer()
        {
            return CustomerDAO.Instance.LoadFullCustomer();
        }
        private DataTable GetFullCustomerType()
        {
            return CustomerTypeDAO.Instance.LoadFullCustomerType();
        }
        private DataTable GetSearchCustomer(string @string, int mode)
        {
            return CustomerDAO.Instance.Search(@string, mode);
        }

        #endregion

        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count > 0)
            {
                DataGridViewRow row = DGV.SelectedRows[0];
                ChangeText(row);
            }
        }

        private bool CheckDate()
        {
            if (DateTime.Now.Subtract(datepickerDateOfBirth.Value).Days <= 0)
                return false;
            else return true;
        }
        #region Enter
        #endregion
        #region Close
        private void FCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadFullCustomer(GetFullCustomer());
        }
        #endregion

        private void txtPhonenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == '\b'))
                e.Handled = true;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Prevent "ding" sound
                btnSearch.PerformClick(); // Simulate button click
            }
             else if (e.KeyChar == (char)Keys.Escape)
            {
                txtSearch.Text = string.Empty;
                btnCancel_Click(sender, e);
            }
        }

        private void fCustomer_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                btnCancel_Click(sender, null);
        }
        #region Enter
        private void txt_Enter(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            text.Tag = text.Text;
        }
        #endregion

        #region Leave
        private void txt_Leave(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text.Text == string.Empty)
                text.Text = text.Tag as string;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            new AddCustomerType().ShowDialog();
            if (btnCancel.Visible == false)
            {
                LoadFullCustomerType();
            }
            else
            {
                btnCancel_Click(null, null);
            }
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
