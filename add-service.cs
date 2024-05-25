using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using HotelV4.aclass;
using HotelV4.bclass;

namespace HotelV4
{
    public partial class add_service : Form
    {
        private string username;
        public add_service()
        {
            InitializeComponent();
            FormMover.Moveform(this);
            LoadFullServiceType();
            LoadFullService(GetFullService());

            cbcode.DisplayMember = "id";

            btnCancel.Click += btnCancel_Click;
            KeyPreview = true;


        }
        frmServiceType _fServiceType;
        private void FService_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                btnCancel_Click(sender, null);
        }
        private void LoadFullServiceType()
        {
            DataTable table = GetFullServiceType();
            cbtypeservice.DataSource = table;
            cbtypeservice.DisplayMember = "name";
            ;
            if (table.Rows.Count > 0)
                cbtypeservice.SelectedIndex = 0;

        }
        private DataTable GetFullServiceType()
        {
            return ServiceTypeDao.Instance.LoadFullServiceType();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            new AddService().ShowDialog();
            if (btnCancel.Visible == false)
                LoadFullService(GetFullService());
            else
                btnCancel_Click(null, null);

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
            menu frm = new menu(username);
            frm.Show();
        }
        private void LoadFullService(DataTable table)
        {
            BindingSource source = new BindingSource();
            ChangePrice(table);
            source.DataSource = table;
            DGV.DataSource = source;
            bindingservice.BindingSource = source;
            cbcode.DataSource = source;
            DGV.Columns[1].Width = 150;
            DGV.Columns[2].Width = 160;


        }
        private void ChangePrice(DataTable table)
        {
            // Check if the column already exists
            if (!table.Columns.Contains("price_New"))
            {
                // Add the new column
                DataColumn newColumn = new DataColumn("price_New", typeof(string));
                table.Columns.Add(newColumn);

                // Populate the new column with Lao Kip formatting
                foreach (DataRow row in table.Rows)
                {
                    // Format the price with Lao Kip currency symbol and other specific formatting
                    row["price_New"] = FormatPrice((int)row["price"]);
                }
            }
        }

        private string FormatPrice(int price)
        {
            // Format the price with Lao Kip currency symbol and other specific formatting
            return price.ToString("C0", CreateLaoNumberFormat());
        }

        private static NumberFormatInfo CreateLaoNumberFormat()
        {
            return new NumberFormatInfo
            {
                CurrencySymbol = "₭",
                CurrencyDecimalDigits = 0,
                CurrencyGroupSeparator = ",",
                CurrencyDecimalSeparator = "."
            };
        }


        private DataTable GetFullService()
        {
            //return ServiceDao.Instance.LoadFullService();
            return null;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSearch_Click(sender, null);
            }

            else
               if (e.KeyChar == 27 && btnCancel.Visible == true)
                btnCancel_Click(sender, null);
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                // Clear the DataGridView
                DGV.DataSource = null;

                // Hide the search button and show the cancel button
                btnSearch.Visible = false;
                btnCancel.Visible = true;

                // Load and display search results in DataGridView
                LoadSearchResults(txtSearch.Text);
                DGV.Columns[1].Width = 150;
                DGV.Columns[2].Width = 160;
                DGV.Refresh();
            }
        }
        private void LoadSearchResults(string searchQuery)
        {
            // Load search results from the database
            DataTable searchData = GetSearchService(searchQuery);

            // Display search results in the DataGridView
            DGV.DataSource = searchData;
        }

        private DataTable GetSearchService(string searchQuery)
        {
            // Retrieve search results from the database based on the search query
            // You need to implement this method according to your data access logic
            if (int.TryParse(searchQuery, out int id))
                //return ServiceDao.Instance.Search(searchQuery, id);
                return null;
            else
               //return ServiceDao.Instance.Search(searchQuery, 0);
             return null;
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            btnSearch.Visible = true;
            btnCancel.Visible = false;

            // Clear DataGridView
            DGV.DataSource = null;
            DGV.Refresh();

            // Reload full service data
            LoadFullService(GetFullService());
        }
        private void Search()
        {
            // Clear DataGridView
            DGV.DataSource = null;

            // Load search results
            DataTable searchData = GetSearchService();
            LoadFullService(searchData);
        }
        private DataTable GetSearchService()
        {
            if (int.TryParse(txtSearch.Text, out int id))
                //return ServiceDao.Instance.Search(txtSearch.Text, id);
                return null;
            else
                //return ServiceDao.Instance.Search(txtSearch.Text, 0);
                return null;
        }

        private string StringToInt(string text)
        {
            if (text.Contains(".") || text.Contains(" "))
            {
                string[] vs = text.Split(new char[] { '.', ' ' });
                StringBuilder textNow = new StringBuilder();
                for (int i = 0; i < vs.Length - 1; i++)
                {
                    textNow.Append(vs[i]);
                }
                return textNow.ToString();
            }
            else
            {
                // Remove currency symbol and separators
                text = text.Replace("₭", "").Replace(",", "").Trim();
                return text;
            }
        }
        private string IntToString(string text)
        {
            if (text == string.Empty)
                return 0.ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
            if (text.Contains(".") || text.Contains(" "))
                return text;
            else
                return (int.Parse(text).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN")));
        }

        private void DGV_SelectionChanged(object sender, EventArgs e)
        {

        }
        int price;

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DGV.Rows.Count)
            {
                DataGridViewRow row = DGV.Rows[e.RowIndex];

                // Extract data from the selected row
                txtservicename.Text = row.Cells[1].Value?.ToString(); // Handle DBNull

                // Handle DBNull and validate integer conversion
                int serviceTypeIndex;
                if (row.Cells[3].Value != DBNull.Value && int.TryParse(row.Cells[3].Value.ToString(), out int index))
                {
                    serviceTypeIndex = index;
                }
                else
                {
                    serviceTypeIndex = 0; // Default index if conversion fails or value is DBNull
                }

                // Validate integer conversion and handle DBNull

                if (row.Cells[3].Value != DBNull.Value && int.TryParse(row.Cells[3].Value.ToString(), out price))
                {
                    txtprice.Text = FormatPrice(price); // Format the price using Lao Kip formatting
                }
                else
                {
                    txtprice.Text = ""; // Set text box to empty if conversion fails or value is DBNull
                }

                // Create a Service object with the selected row data and set it to groupservice.Tag
                Service selectedService = new Service
                {
                    Id = (int)row.Cells[0].Value,
                    Name = row.Cells[1].Value?.ToString(),
                    IdServiceType = serviceTypeIndex,
                    Price = price
                };
                groupservice.Tag = selectedService;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want update data ?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                UpdateService();
            cbcode.Focus();
        }
        private void UpdateService()
        {
            if (string.IsNullOrEmpty(cbcode.Text))
            {
                MessageBox.Show("Please select the code to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (!fCustomer.CheckFillInText(new Control[] { txtservicename, cbcode, txtprice }))
            {
                MessageBox.Show("Please enter the required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Service servicePre = groupservice.Tag as Service;
            if (servicePre == null)
            {
                MessageBox.Show("Previous service data is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Service serviceNow = GetServiceNow();
                if (serviceNow.Equals(servicePre))
                {
                    MessageBox.Show("No changes detected in the data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //bool check = ServiceDao.Instance.UpdateService(serviceNow, servicePre);
                bool check = false;
                if (check)
                {
                    MessageBox.Show("Update successful.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupservice.Tag = serviceNow;

                    if (!btnCancel.Visible)
                    {
                        int index = DGV.SelectedRows[0].Index;
                        LoadFullService(GetFullService());
                        cbcode.SelectedIndex = index;
                    }
                    else
                    {
                        btnCancel_Click(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Service update failed. Service not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error details: {ex}"); // Log the full exception details for debugging purposes
            }
        }
        private Service GetServiceNow()
        {
            Service service = new Service();
            if (cbcode.Text == string.Empty)
                service.Id = 0;
            else
                service.Id = int.Parse(cbcode.Text);
            txtservicename.Text = txtservicename.Text.Trim();
            service.Name = txtservicename.Text;
            service.Price = int.Parse(StringToInt(txtprice.Text));
            int index = cbtypeservice.SelectedIndex;
            service.IdServiceType = (int)((DataTable)cbtypeservice.DataSource).Rows[index]["id"];
            return service;
        }

        private void btnEditservicetype_Click(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Check if _fServiceType is null and initialize it if necessary
            if (_fServiceType == null)
            {
                _fServiceType = new frmServiceType(); // Initialize _fServiceType if it's null
            }

            // Show the service type edit dialog
            _fServiceType.ShowDialog();

            // Reload full service data
            DataTable fullServiceData = GetFullService(); // Assuming GetFullService() retrieves full service data

            // Set the ComboBox DataSource to the updated service type data
            cbtypeservice.DataSource = _fServiceType.TableSerViceType;

            // Show the current form again
            this.Show();
        }

        private void add_service_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnCancel_Click(sender, null);
        }

        private void txtservicename_Leave(object sender, EventArgs e)
        {
            if (txtservicename.Text == string.Empty)
                txtservicename.Text = txtservicename.Tag as string;
        }

        private void txtprice_Leave(object sender, EventArgs e)
        {
            if (txtprice.Text == string.Empty)
                txtprice.Text = txtprice.Tag as string;
            else
                txtprice.Text = IntToString(txtprice.Text);
        }

        private void txtservicename_Enter(object sender, EventArgs e)
        {
            txtservicename.Tag = txtservicename.Text;

        }

        private void txtprice_Enter(object sender, EventArgs e)
        {
            txtprice.Tag = txtprice.Text;
            txtprice.Text = StringToInt(txtprice.Text);
        }
    }
}
