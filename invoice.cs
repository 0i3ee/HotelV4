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
namespace HotelV4
{
    public partial class invoice : Form
    {
        private readonly fPrintBill fPrintBill = new fPrintBill();
        public invoice()
        {
            InitializeComponent();
            FormMover.Moveform(this);
            
            LoadFullBill(GetFullBill());
            comboboxID.DisplayMember = "ID";
            cbBillSearch.SelectedIndex = 0;

        }
        private void LoadFullBill(DataTable table)
        {
            BindingSource source = new BindingSource();
            ChangePrice(table);
            source.DataSource = table;
            DGV.DataSource = source;
            bindingInvoice.BindingSource = source;
            comboboxID.DataSource = source;

            txbDateCreated.DataBindings.Clear();
            txbName.DataBindings.Clear();
            txbPrice.DataBindings.Clear();
            txbStatusRoom.DataBindings.Clear();
            txbUser.DataBindings.Clear();
            txbDiscount.DataBindings.Clear();
            txbFinalPrice.DataBindings.Clear();

            txbDateCreated.DataBindings.Add("Text", source, "DateOfCreate");
            txbName.DataBindings.Add("Text", source, "roomName");
            txbPrice.DataBindings.Add("Text", source, "totalPrice");
            txbStatusRoom.DataBindings.Add("Text", source, "Name");
            txbUser.DataBindings.Add("Text", source, "StaffSetUp");
            txbDiscount.DataBindings.Add("Text", source, "discount");
            txbFinalPrice.DataBindings.Add("Text", source, "finalprice");
        }
        private void ChangePrice(DataTable table)
        {
            table.Columns.Add("totalPrice_New", typeof(string));
            table.Columns.Add("finalprice_New", typeof(string));
            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["finalprice_New"] = ((int)table.Rows[i]["finalprice"]).ToString("C0", CultureInfo.CreateSpecificCulture("lo-LA"));
                table.Rows[i]["totalPrice_New"] = ((int)table.Rows[i]["totalPrice"]).ToString("C0", CultureInfo.CreateSpecificCulture("lo-LA"));
            }
            table.Columns.Remove("finalprice");
            table.Columns.Remove("totalPrice");
            table.Columns["totalPrice_New"].ColumnName = "totalPrice";
            table.Columns["finalprice_New"].ColumnName = "finalprice";

        }

        private void btnInvoiceDetail_Click(object sender, EventArgs e)
        {
            if (comboboxID.Text != string.Empty)
            {
                if (!txbStatusRoom.Text.Contains("Ch"))
                {
                    fPrintBill.SetPrintBill(int.Parse(comboboxID.Text), txbDateCreated.Text);
                    fPrintBill.ShowDialog();
                }
                else
                    MessageBox.Show("Unpaid invoice\nYou do not have access rights", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
            if (txbSearch.Text != string.Empty)
            {
                txbDateCreated.Text = string.Empty;
                txbName.Text = string.Empty;
                txbPrice.Text = string.Empty;
                txbStatusRoom.Text = string.Empty;
                txbUser.Text = string.Empty;

                btnSearch.Visible = false;
                btnCancel.Visible = true;
                Search();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadFullBill(GetFullBill());
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }
        private void Search()
        {
            LoadFullBill(GetSearchBill(txbSearch.Text, cbBillSearch.SelectedIndex));
        }
        private DataTable GetFullBill()
        {
            return BillDAO.Instance.LoaddFullBill();
        }
        private DataTable GetSearchBill(string text, int mode)
        {
            return BillDAO.Instance.SearchBill(text, mode);
        }

        private void txbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSearch_Click(sender, null);
            else
               if (e.KeyChar == 27 && btnCancel.Visible == true)
                btnCancel_Click(sender, null);
        }

        private void invoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                btnCancel_Click(sender, null);
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
