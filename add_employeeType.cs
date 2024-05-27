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
    public partial class add_employeeType : Form
    {
        private int idStaffType = -1;

        public add_employeeType()
        {
            InitializeComponent();
            FormMover.Moveform(this);
            btn.Text = "Add new";
            title.Text = "Add Employee Type";
        }

        public add_employeeType(int idStaffType, string name)
        {
            InitializeComponent();
            FormMover.Moveform(this);
            this.idStaffType = idStaffType;
            btn.Text = "Update";
            txbName.Text = name;
            title.Text = "Update Employee Typen";
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (idStaffType == -1 && !string.IsNullOrWhiteSpace(txbName.Text))
            {
                if (AccountTypeb.Instance.Insert(txbName.Text))
                {
                    MessageBox.Show("Add employee type successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Add Failed", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                if (AccountTypeb.Instance.Update(idStaffType, txbName.Text))
                {
                    MessageBox.Show("Update successful", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update Failed", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                btnClose_Click(sender, e);
            else if (e.KeyChar == 13)
                btn_Click(sender, e);
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
