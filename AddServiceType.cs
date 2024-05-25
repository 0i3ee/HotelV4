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
    public partial class AddServiceType : Form
    {
        public AddServiceType()
        {
            InitializeComponent();
        }
        private string GetServiceTypeNameNow()
        {
            return txtserviceName.Text.Trim();
        }
        private void InsertServiceType()
        {
            if (fCustomer.CheckFillInText(new Control[] { txtserviceName }))
            {
                try
                {
                    string serviceTypeNameNow = GetServiceTypeNameNow();
                    if (ServiceTypeDao.Instance.InsertServiceType(serviceTypeNameNow))
                    {
                        MessageBox.Show("Success", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtserviceName.Text = string.Empty;
                    }
                    else
                        MessageBox.Show("Add data Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ມີຄວາມຜິດພາດ: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("not make space", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want add data?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                InsertServiceType();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
