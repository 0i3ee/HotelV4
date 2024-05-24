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

    public partial class ServiceType : Form
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
                DGV.DataSource = source;
                bindingservice.BindingSource = source;
                cbtypeserviceID.DataSource = source;
            }
        }
        public ServiceType()
        {
            InitializeComponent();

        }
        public ServiceType(DataTable table)
        {
            InitializeComponent();
            this.TableSerViceType = table;
            this.cbtypeserviceID.DisplayMember = "id";
            LoadFullServiceType(GetFullServiceType());

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
            //DataTable searchData = GetSearchService(searchQuery);

            // Display search results in the DataGridView
            //DGV.DataSource = searchData;
        }
    }
}
