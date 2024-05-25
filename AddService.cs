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
            InitializeComponent();
            txtPrice.Text = IntToString("100000");
            LoadFullServiceType();
        }
        private void ChangePrice(DataTable table)
        {
            table.Columns.Add("price_New", typeof(string));
            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["price_New"] = ((int)table.Rows[i]["price"]).ToString("C0", CreateLaoNumberFormat());
            }
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

        private static string IntToString(string text)
        {
            NumberFormatInfo laoFormat = CreateLaoNumberFormat();

            if (string.IsNullOrWhiteSpace(text))
                return 0.ToString("C0", laoFormat);
            if (text.Contains(".") || text.Contains(" "))
                return text;
            else
                return int.Parse(text).ToString("C0", laoFormat);
        }

        private Service GetServiceNow()
        {
            Service service = new Service();
            txtservicename.Text = txtservicename.Text.Trim();
            service.Name = txtservicename.Text; // Corrected assignment
            service.Price = int.Parse(StringToInt(txtPrice.Text)); // Corrected method
            int index = cbtypeservice.SelectedIndex;
            service.IdServiceType = (int)((DataTable)cbtypeservice.DataSource).Rows[index]["id"];
            return service;
        }
        private void LoadFullServiceType()
        {
            DataTable table = GetFullServiceType();
            if (table != null)
            {
                DataView view = new DataView(table);
                DataTable distinctTable = view.ToTable(true, "id", "name"); // Ensure unique rows based on "id" and "name"
                cbtypeservice.DataSource = distinctTable;
                cbtypeservice.DisplayMember = "name";
                if (distinctTable.Rows.Count > 0)
                    cbtypeservice.SelectedIndex = 0;
            }
        }

        private DataTable GetFullServiceType()
        {
            try
            {
                DataTable table = ServiceTypeDao.Instance.LoadFullServiceType();
                return RemoveDuplicates(table, "id", "name");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading service types: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private DataTable RemoveDuplicates(DataTable table, params string[] keyColumns)
        {
            return table.DefaultView.ToTable(true, keyColumns);
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

        private void InsertService()
        {
            if (!fCustomer.CheckFillInText(new Control[] { txtservicename, cbtypeservice, txtPrice }))
            {
                DialogResult result = MessageBox.Show("Please Enter data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //try
            //{
                //Service serviceNow = GetServiceNow();
                //if (ServiceDao.Instance.InsertService(serviceNow))
                //{
                //    MessageBox.Show("Success", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtservicename.Text = string.Empty;
                //    txtPrice.Text = IntToString("100000");
                //}
                //else
                //    MessageBox.Show("ServiceName Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ເກີດຂໍ້ຜິດພາດ" + ex.Message, "ແຈ້ງເຕືອນ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to add data?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                InsertService();
            add_service frm = new add_service();
            frm.Show();
            this.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            add_service frm = new add_service();
            frm.Show();
            this.Close();
        }
    }
}
