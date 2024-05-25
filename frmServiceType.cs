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

    public partial class frmServiceType : Form
    {
        private DataTable _tableSerViceType;
        public DataTable TableSerViceType
        {
            get => _tableSerViceType;
            private set
            {
                _tableSerViceType = value;
                BindingSource source = new BindingSource();
                source.DataSource = _tableSerViceType;
                DGVS.DataSource = source;
                bindingservice.BindingSource = source;
                cbtypeserviceID.DataSource = source;
                cbtypeserviceID.DisplayMember = "id"; 
            }
        }
        public frmServiceType()
        {
            InitializeComponent();

        }

        public frmServiceType(DataTable table) : this()
        {
            this.TableSerViceType = table;
        }
        private void LoadFullServiceType(DataTable table)
        {
            this.TableSerViceType = table;
        }
        private DataTable GetFullServiceType()
        {
            return ServiceTypeDao.Instance.LoadFullServiceType();
        }
        //private ServiceType GetServiceTypeNow()
        //{
        //    serviceType serviceType = new serviceType();
        //    if (cbtypeserviceID.Text == string.Empty)
        //        serviceType.Id = 0;
        //    else
        //        serviceType.Id = int.Parse(cbtypeserviceID.Text);
        //    txtserviceName.Text = txtserviceName.Text.Trim();
        //    serviceType.Name = txtserviceName.Text;
        //    return serviceType;
        //}
        //private DataTable GetSearchServiceType(string text)
        //{
        //    if (int.TryParse(text, out int id))
        //        return ServiceTypeDao.Instance.Search(text, id);
        //    else
        //        return ServiceTypeDao.Instance.Search(text, 0);
        //}

        private void ServiceType_Load(object sender, EventArgs e)
        {
            LoadFullServiceType();
            DGVS.Columns[0].Width = 250;
            DGVS.Columns[1].Width = 270;
       

            DGVS.Refresh();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadFullServiceType(GetFullServiceType());
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                // Clear the DataGridView
                DGVS.DataSource = null;

                // Hide the search button and show the cancel button
                btnSearch.Visible = false;
                btnCancel.Visible = true;

                // Load and display search results in DataGridView
                LoadSearchResults(txtSearch.Text);
                DGVS.Columns[0].Width = 250;
                DGVS.Columns[1].Width = 270;
                DGVS.Refresh();
            }
        }
        private void LoadFullServiceType()
        {
            // Load data into the DataTable
            DataTable table = GetFullServiceType();

            // Set the DataTable to the TableSerViceType property to bind it to the controls
            this.TableSerViceType = table;
        }
        private void LoadSearchResults(string searchQuery)
        {
            LoadFullServiceType(GetSearchServiceType(txtSearch.Text));
        }
        private DataTable GetSearchServiceType(string text)
        {
            if (int.TryParse(text, out int id))
                return ServiceTypeDao.Instance.Search(text, id);
            else
                return ServiceTypeDao.Instance.Search(text, 0);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(e.KeyChar == 13)
                btnSearch_Click(sender, null);
            else
                if (e.KeyChar == 27 && btnCancel.Visible == true)
                btnCancel_Click(sender, null);
        }

        private void ServiceType_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.btnCancel_Click(sender, null);
            this.txtSearch.Text = string.Empty;
        }

        private void ServiceType_KeyDown(object sender, KeyEventArgs e)
        {
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        BtnUpdateServiceType_Click(sender, e);
        //    }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private ServiceType GetServiceTypeNow()
        {
            ServiceType serviceType = new ServiceType();
            if (cbtypeserviceID.Text == string.Empty)
                serviceType.Id = 0;
            else
                serviceType.Id = int.Parse(cbtypeserviceID.Text);
            txtserviceName.Text = txtserviceName.Text.Trim();
            serviceType.Name = txtserviceName.Text;
            return serviceType;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Open the AddServiceType form as a dialog
            new AddServiceType().ShowDialog();

            // Reload the service types or handle the cancel click event
            if (btnCancel.Visible == false)
            {
                LoadFullServiceType(GetFullServiceType());
            }
            else
            {
                btnCancel_Click(null, null);
            }

            // Ensure the DataGridView has rows and the ComboBox has items
            if (DGVS.RowCount > 0 && cbtypeserviceID.Items.Count > 0)
            {
                int newIndex = DGVS.RowCount - 1;
                if (newIndex < cbtypeserviceID.Items.Count)
                {
                    cbtypeserviceID.SelectedIndex = newIndex;
                }
                else
                {
                    cbtypeserviceID.SelectedIndex = -1; // Reset if the index is out of range
                }
            }
            else
            {
                cbtypeserviceID.SelectedIndex = -1; // Reset if there are no rows or items
            }
        }

        private void DGVS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DGVS.Rows.Count)
            {
                DataGridViewRow row = DGVS.Rows[e.RowIndex];

                // Extract service type name from the second cell (index 1) and set it to txtserviceName
                txtserviceName.Text = row.Cells[1].Value?.ToString() ?? string.Empty;

                // Extract ID from the first cell (index 0) and set it to cbtypeserviceID
                if (row.Cells[0] != null && row.Cells[0].Value != DBNull.Value && int.TryParse(row.Cells[0].Value.ToString(), out int id))
                {
                    // Find the index of the item in the ComboBox with the corresponding ID
                    for (int i = 0; i < cbtypeserviceID.Items.Count; i++)
                    {
                        if (cbtypeserviceID.Items[i].ToString() == id.ToString())
                        {
                            cbtypeserviceID.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    cbtypeserviceID.SelectedIndex = -1; // Reset if the ID is invalid
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want update data?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                UpdateServiceType();
            cbtypeserviceID.Focus();
        }
        private void UpdateServiceType()
        {
            if (cbtypeserviceID.Text == string.Empty)
                MessageBox.Show("This service type does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
           if (!fCustomer.CheckFillInText(new Control[] { txtserviceName }))
            {
                MessageBox.Show("Cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ServiceType serviceTypePre = groupServiceType.Tag as ServiceType;
                try
                {
                    ServiceType serviceTypeNow = GetServiceTypeNow();
                    if (serviceTypeNow.Equals(serviceTypePre))
                        MessageBox.Show("You have not changed the data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        bool check = ServiceTypeDao.Instance.UpdateServiceType(serviceTypeNow);
                        if (check)
                        {
                            MessageBox.Show("Update successful", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (btnCancel.Visible == false)
                            {
                                int index = DGVS.SelectedRows[0].Index;
                                LoadFullServiceType(GetFullServiceType());
                                cbtypeserviceID.SelectedIndex = index;
                            }
                            else
                            {
                                btnCancel_Click(null, null);
                            }
                            groupServiceType.Tag = serviceTypeNow;
                        }
                        else
                        {
                            MessageBox.Show("This service type does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Service type error already exists", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DGVS_SelectionChanged(object sender, EventArgs e)
        {
            //if (DGVS.SelectedRows.Count > 0)
            //{
            //    DataGridViewRow row = DGVS.SelectedRows[0];
            //    ChangeText(row);
            //}
        }
    }
}
