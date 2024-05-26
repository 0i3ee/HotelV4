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
        DataTable _tableSerViceType;
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
            }
        }
        public frmServiceType()
        {
            InitializeComponent();
            FormMover.Moveform(this);
        }

        public frmServiceType(DataTable table)
        {
            InitializeComponent();
            FormMover.Moveform(this);
            this.TableSerViceType = table;
            this.cbtypeserviceID.DisplayMember = "id";
            DGVS.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        }
        private void LoadFullServiceType(DataTable table)
        {
            this.TableSerViceType = table;
        }
        private DataTable GetFullServiceType()
        {
            return ServiceTypeDAO.Instance.LoadFullServiceType();
        }


        private void ServiceType_Load(object sender, EventArgs e)
        {
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
            if (txtSearch.Text != string.Empty)
            {
                txtserviceName.Text = string.Empty;
                Search();
                btnSearch.Visible = false;
                btnCancel.Visible = true;
            }
        }
        private void Search()
        {
            LoadFullServiceType(GetSearchServiceType(txtSearch.Text));
        }

        private DataTable GetSearchServiceType(string text)
        {
            if (int.TryParse(text, out int id))
                return ServiceTypeDAO.Instance.Search(text, id);
            else
                return ServiceTypeDAO.Instance.Search(text, 0);
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
            new AddServiceType().ShowDialog();
            if (btnCancel.Visible == false)
                LoadFullServiceType(GetFullServiceType());
            else
                btnCancel_Click(null, null);
            cbtypeserviceID.SelectedIndex = DGVS.RowCount - 1;
        }

        private void DGVS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to update this type of service?", "Notifications", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
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
                        bool check = ServiceTypeDAO.Instance.UpdateServiceType(serviceTypeNow);
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
        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorMovePreviousItem.Enabled = false;
                txtserviceName.Text = string.Empty;
            }
            else
            {
                txtserviceName.Text = row.Cells["colName"].Value.ToString();
                ServiceType roomType = new ServiceType(((DataRowView)row.DataBoundItem).Row);
                groupServiceType.Tag = roomType;
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
            }
        }

        private void DGVS_SelectionChanged(object sender, EventArgs e)
        {
            if (DGVS.SelectedRows.Count > 0)
            {
                DataGridViewRow row = DGVS.SelectedRows[0];
                ChangeText(row);
            }
        }
    }
}
