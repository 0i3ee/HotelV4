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
        frmServiceType _fServiceType;
        
        public add_service()
        {
            this.DoubleBuffered = true;
            FormMover.Moveform(this);
            InitializeComponent();
            LoadFullServiceType();
            LoadFullService(GetFullService());
            cbcode.DisplayMember = "id";
            txtSearch.KeyPress += txtSearch_KeyPress;
            btnCancel.Click += btnCancel_Click;
            KeyPreview = true;
            KeyPress += FService_KeyPress;
            DGV.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);


        }
        
        private void FService_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                btnCancel_Click(sender, null);
        }
        private void LoadFullService(DataTable table)
        {
            BindingSource source = new BindingSource();
            ChangePrice(table);
            source.DataSource = table;
            DGV.DataSource = source;
            bindingservice.BindingSource = source;
            cbcode.DataSource = source;
        }
        private void LoadFullServiceType()
        {
            DataTable table = GetFullServiceType();
            cbtypeservice.DataSource = table;
            cbtypeservice.DisplayMember = "name";
            ;
            if (table.Rows.Count > 0)
                cbtypeservice.SelectedIndex = 0;
            _fServiceType = new frmServiceType(table);
        }
        private DataTable GetFullServiceType()
        {
            return ServiceTypeDAO.Instance.LoadFullServiceType();
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
        }

        private void ChangePrice(DataTable table)
        {
            table.Columns.Add("price_New", typeof(string));
            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["price_New"] = ((int)table.Rows[i]["price"]).ToString("C0", CultureInfo.CreateSpecificCulture("lo-LA"));
            }
        }



        private DataTable GetFullService()
        {
            return ServiceDao.Instance.LoadFullService();
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
            if (txtSearch.Text != string.Empty)
            {
                txtservicename.Text = string.Empty;
                txtprice.Text = string.Empty;
                btnSearch.Visible = false;
                btnCancel.Visible = true;
                Search();
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadFullService(GetFullService());
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }
        private void Search()
        {
            LoadFullService(GetSearchService());
        }
        private DataTable GetSearchService()
        {
            if (int.TryParse(txtSearch.Text, out int id))
                return ServiceDao.Instance.Search(txtSearch.Text, id);
            else
                return ServiceDao.Instance.Search(txtSearch.Text, 0);
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


        private string StringToInt(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "0";

            try
            {
                string[] vs = text.Split(new char[] { '.', ',', ' ', '₭' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder textNow = new StringBuilder();
                foreach (var part in vs)
                {
                    textNow.Append(part);
                }
                return textNow.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in StringToInt: {ex.Message}\nInput text: {text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private string IntToString(string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0.ToString("C0", CultureInfo.CreateSpecificCulture("lo-LA"));

            try
            {
                int parsedInt = int.Parse(StringToInt(text)); // Use StringToInt to ensure proper format
                return parsedInt.ToString("C0", CultureInfo.CreateSpecificCulture("lo-LA"));
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Price format error in IntToString: {ex.Message}\nInput text: {text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count > 0)
            {
                DataGridViewRow row = DGV.SelectedRows[0];
                ChangeText(row);
            }
        }
        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorMovePreviousItem.Enabled = false;
                txtservicename.Text = string.Empty;
                txtprice.Text = string.Empty;
            }
            else
            {
                txtservicename.Text = row.Cells["colName"].Value.ToString();
                cbtypeservice.SelectedIndex = (int)row.Cells["colIdServiceType"].Value - 1;
                txtprice.Text = ((int)row.Cells[col.Name].Value).ToString("C0", CultureInfo.CreateSpecificCulture("lo-LA")); 
                Service room = new Service(((DataRowView)row.DataBoundItem).Row);
                groupservice.Tag = room;
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
            }
        }


        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to update the service again?", "Notifications", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                UpdateService();
            cbcode.Focus();
        }
        private void UpdateService()
        {
            if (cbcode.Text == string.Empty)
                MessageBox.Show("Service does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            if (!fCustomer.CheckFillInText(new Control[] { txtservicename, cbtypeservice, txtprice }))
            {
                MessageBox.Show("Cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Service servicePre = groupservice.Tag as Service;
                try
                {
                    Service serviceNow = GetServiceNow();
                    if (serviceNow.Equals(servicePre))
                    {
                        MessageBox.Show("You have not changed the data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        bool check = ServiceDao.Instance.UpdateService(serviceNow, servicePre);
                        if (check)
                        {
                            MessageBox.Show("Success", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupservice.Tag = serviceNow;
                            if (btnCancel.Visible == false)
                            {
                                int index = DGV.SelectedRows[0].Index;
                                LoadFullService(GetFullService());
                                cbcode.SelectedIndex = index;
                            }
                            else
                                btnCancel_Click(null, null);
                        }
                        else
                            MessageBox.Show("Service does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch
                {
                    MessageBox.Show("Error", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        

        private void btnEditservicetype_Click(object sender, EventArgs e)
        {
            this.Hide();
            _fServiceType.ShowDialog();
            this.LoadFullService(GetFullService());
            cbtypeservice.DataSource = _fServiceType.TableSerViceType;
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

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            txtservicename.Text = string.Empty;
            txtprice.Text = string.Empty;
        }

        private void bindingservice_RefreshItems(object sender, EventArgs e)
        {

        }

        private void add_service_Load(object sender, EventArgs e)
        {


        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
