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
    public partial class permission : Form
    {
        private int idStaffType = -1;
        public permission()
        {
            InitializeComponent();
            FormMover.Moveform(this);
            cbbStaffType.DisplayMember = "Name";
            LoadFullStaffType();
        }

        private void LoadFullStaffType()
        {
            cbbStaffType.DataSource = GetFullStaffType();
        }
        private void LoadAccess()
        {
            dgvC.DataSource = GetFullAccessNow(idStaffType);
            dgvR.DataSource = GetFullAccessRest(idStaffType);
        }
        private DataTable GetFullStaffType()
        {
            return AccountTypeb.Instance.LoadFullStaffType();
        }
        private DataTable GetFullAccessNow(int idStaffType)
        {
            return permissionB.Instance.GetFullAccessNow(idStaffType);
        }
        private DataTable GetFullAccessRest(int idStaffType)
        {
            return permissionB.Instance.GetFullAccessRest(idStaffType);
        }
        private void AccessInsert(int idJob, int idStaffType)
        {
            permissionB.Instance.Insert(idJob, idStaffType);
        }
        private void AcccessDelete(int idJob, int idStaffType)
        {
            permissionB.Instance.Delete(idJob, idStaffType);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btndleft_Click(object sender, EventArgs e)
        {
       
            int count = dgvR.RowCount;
            for (int i = 0; i < count; i++)
            {
                int idJob = (int)dgvR.Rows[i].Cells[colIdRest.Name].Value;
                AccessInsert(idJob, idStaffType);
            }
            LoadAccess();
        }

        private void btndright_Click(object sender, EventArgs e)
        {
            int count = dgvC.RowCount;
            for (int i = 0; i < count; i++)
            {
                int idJob = (int)dgvC.Rows[i].Cells[colIdNow.Name].Value;
                AcccessDelete(idJob, idStaffType);
            }
            LoadAccess();
            
        }

        private void btnleft_Click(object sender, EventArgs e)
        {
            int count = dgvR.SelectedRows.Count;
            for (int i = 0; i < count; i++)
            {
                int idJob = (int)dgvR.SelectedRows[i].Cells[colIdRest.Name].Value;
                AccessInsert(idJob, idStaffType);
            }
            LoadAccess();
        }

        private void btnright_Click(object sender, EventArgs e)
        {
            int count = dgvC.SelectedRows.Count;
            for (int i = 0; i < count; i++)
            {
                int idJob = (int)dgvC.SelectedRows[i].Cells[colIdNow.Name].Value;
                AcccessDelete(idJob, idStaffType);
            }
            LoadAccess();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbbStaffType.SelectedIndex == -1) return;
            DialogResult result = MessageBox.Show("Do you want to delete this employee type?", "Result", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                if (AccountTypeb.Instance.Delete(idStaffType))
                {
                    MessageBox.Show("Deleted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Delete failed, this type of employee already exists", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            LoadFullStaffType();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int index = cbbStaffType.SelectedIndex;
            new add_employeeType(idStaffType, cbbStaffType.Text).ShowDialog();
            LoadFullStaffType();
            cbbStaffType.SelectedIndex = index;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new add_employeeType().ShowDialog();
            LoadFullStaffType();
            cbbStaffType.SelectedIndex = (cbbStaffType.DataSource as DataTable).Rows.Count - 1;
        }

        private void cbbStaffType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbbStaffType.SelectedIndex;
            idStaffType = (int)((DataTable)cbbStaffType.DataSource).Rows[index]["id"];
            LoadAccess();
        }
    }
}
