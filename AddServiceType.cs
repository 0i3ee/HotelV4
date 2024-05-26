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
            FormMover.Moveform(this);
        }
        private ServiceType GetServiceTypeNow()
        {
            ServiceType serviceType = new ServiceType();
            serviceType.Name = txtserviceName.Text.Trim();
            return serviceType;
        }
        private void InsertServiceType()
        {
            if (fCustomer.CheckFillInText(new Control[] { txtserviceName }))
            {
                try
                {
                    ServiceType serviceTypeNow = GetServiceTypeNow();
                    if (ServiceTypeDAO.Instance.InsertServiceType(serviceTypeNow))
                    {
                        MessageBox.Show("Added successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtserviceName.Text = string.Empty;
                    }
                    else
                        MessageBox.Show("Data entry error", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Service type error already exists", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Cannot be left blank", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to add a new service type?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                InsertServiceType();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
