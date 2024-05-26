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
using System.Globalization;
namespace HotelV4
{
    public partial class AddService : Form
    {
        public AddService()
        {
            FormMover.Moveform(this);
            InitializeComponent();
            LoadFullServiceType();
            txtPrice.Text = IntToString("100000");
        }
        

        private void LoadFullServiceType()
        {
            DataTable table = GetFullServiceType();
            cbtypeservice.DataSource = table;
            cbtypeservice.DisplayMember = "name";
            
            if (table.Rows.Count > 0)
                cbtypeservice.SelectedIndex = 0;
        }
        private DataTable GetFullServiceType()
        {
            return ServiceTypeDAO.Instance.LoadFullServiceType();
        }
        private Service GetServiceNow()
        {
            Service service = new Service();
            txtservicename.Text = txtservicename.Text.Trim();
            service.Name = txtservicename.Text;

            try
            {
                service.Price = int.Parse(StringToInt(txtPrice.Text));
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Price format error: {ex.Message}\nPrice text: {txtPrice.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            int index = cbtypeservice.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("No service type selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new InvalidOperationException("No service type selected.");
            }

            service.IdServiceType = (int)((DataTable)cbtypeservice.DataSource).Rows[index]["id"];
            return service;
        }
        private void ChangePrice(DataTable table)
        {
            table.Columns.Add("price_New", typeof(string));
            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["price_New"] = ((int)table.Rows[i]["price"]).ToString("C0", CultureInfo.CreateSpecificCulture("lo-LA"));
            }
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



        private void InsertService()
        {
            if (!fCustomer.CheckFillInText(new Control[] { txtservicename, cbtypeservice, txtPrice }))
            {
                MessageBox.Show("Cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Service serviceNow = GetServiceNow();
                bool isInserted = ServiceDao.Instance.InsertService(serviceNow);

                if (isInserted)
                {
                    MessageBox.Show("Success", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtservicename.Text = string.Empty;
                    txtPrice.Text = IntToString("100000");
                }
                else
                {
                    MessageBox.Show("Service already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to add a new service?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                InsertService();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPrice_Enter(object sender, EventArgs e)
        {
            txtPrice.Tag = txtPrice.Text;
            txtPrice.Text = StringToInt(txtPrice.Text);
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            if (txtPrice.Text == string.Empty)
                txtPrice.Text = txtPrice.Tag as string;
            else
                txtPrice.Text = IntToString(txtPrice.Text);
        }
    }
}
