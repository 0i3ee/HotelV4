using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

using HotelV4.aclass;
using HotelV4.bclass;

namespace HotelV4
{
    public partial class employee : Form
    {
        internal employee()
        {
            InitializeComponent();
            FormMover.Moveform(this);
            LoadFullStaffType();
            LoadFullStaff(GetFullStaff());
            hidecol();
            txtSearch.KeyPress += txtSearch_KeyPress;
            KeyPress += employee_KeyPress;
            dataGridStaff.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Phetsarath OT", 9.75F);
            txtphonenumber.Text = "20";
        }
        private void hidecol() {
            dataGridStaff.Columns[2].HeaderText = "Type";

            dataGridStaff.Columns[4].Visible = false;
            dataGridStaff.Columns[5].Visible = false;
            dataGridStaff.Columns[7].Visible = false;
            dataGridStaff.Columns[9].Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Trim();
            if (txtSearch.Text != string.Empty)
            {
                txtusername.Text = string.Empty;
                txtname.Text = string.Empty;
                txtidnumber.Text = string.Empty;
                txtphonenumber.Text = string.Empty;
                txtaddress.Text = string.Empty;

                btnSearch.Visible = false;
                btnCancel.Visible = true;
                Search();
            }
        }
      

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {


        }

        private void lbExit_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            new addstaff().ShowDialog();
            if (btnCancel.Visible == false)
                LoadFullStaff(GetFullStaff());
            else
                btnCancel_Click(null, null);

        }
        public static bool CheckFillInText(Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control.Text == string.Empty)
                    return false;
            }
            return true;
        }
        private string ParsePhoneNumber(string maskedPhoneNumber)
        {
            // Remove non-numeric characters using regular expressions
            string numericPhoneNumber = Regex.Replace(maskedPhoneNumber, @"[^\d]", "");

            // Convert the cleaned string to an integer
            return numericPhoneNumber;
        }
        private Accout GetStaffNow()
        {
            Accout account = new Accout();

            account.UserName = txtusername.Text.ToLower();
            int index = cbemptype.SelectedIndex;
            account.IdStaffType = (int)((DataTable)cbemptype.DataSource).Rows[index]["id"];
            account.DisplayName = txtname.Text;
            account.IdCard = txtidnumber.Text;
            account.Sex = cbbsex.Text;
            account.DateOfBirth = dob.Value;
            int phonenum = int.Parse(ParsePhoneNumber(txtphonenumber.Text));
            account.PhoneNumber = phonenum; 
            account.Address = txtaddress.Text;
            account.StartDay = dos.Value;
            return account;
        }
        internal static void Trim(TextBox[] textboxes)
        {
            for (int i = 0; i < textboxes.Length; i++)
            {
                textboxes[i].Text = textboxes[i].Text.Trim();
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            bool isFill = employee.CheckFillInText(new Control[] { txtusername, cbemptype, txtname ,
                                                            txtidnumber , cbbsex , txtphonenumber, txtaddress});
            if (!isFill)
            {
                MessageBox.Show("No data", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Accout accountPre = groupstaff.Tag as Accout;

                    Accout accountnow = GetStaffNow();
                    if (accountnow.Equals(accountPre))
                    {
                        MessageBox.Show("You Not chage anyting", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        bool check = AccountB.Instance.UpdateAccount(accountnow);
                        if (check)
                        {
                            MessageBox.Show("Update Success", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupstaff.Tag = accountnow;
                            if (btnCancel.Visible == false)
                            {
                                int index = dataGridStaff.SelectedRows[0].Index;
                                LoadFullStaff(GetFullStaff());
                                dataGridStaff.Rows[index].Selected = true;
                            }
                            else
                                btnCancel_Click(null, null);
                        }
                        else
                        {
                            if (accountnow.UserName == accountPre.UserName)
                                MessageBox.Show("Can't not Update(Card id already Have.)", "Result", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            else
                                MessageBox.Show("Can't not Update(Don't have this accout.)", "Result", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
            }
               
        }
        
        private DataTable GetFullStaff()
        {
            return AccountB.Instance.LoadFullStaff();
        }
        private DataTable GetFullStaffType()
        {
            return AccountTypeb.Instance.LoadFullStaffType();
        }

        private void LoadFullStaffType()
        {
            cbbsex.SelectedIndex = 0;
            DataTable table = GetFullStaffType();
            cbemptype.DataSource = table;
            cbemptype.DisplayMember = "Name";
            if (table.Rows.Count > 0)
                cbemptype.SelectedIndex = 0;
        }
        private void LoadFullStaff(DataTable table)
        {
            BindingSource source = new BindingSource();
            source.DataSource = table;
            dataGridStaff.DataSource =  source;
            bindingstaff.BindingSource = source;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadFullStaff(GetFullStaff());
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Search()
        {
            LoadFullStaff(GetSearchStaff());
        }
        private DataTable GetSearchStaff()
        {
            if (int.TryParse(txtSearch.Text, out int phoneNumber))
                return AccountB.Instance.Search(txtSearch.Text, phoneNumber);
            else
                return AccountB.Instance.Search(txtSearch.Text, -1);
        }

        private void txtphonenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private bool CheckTrueDate(DateTime date1, DateTime date2)
        {
            if (date2.Subtract(date1).Days < 6574)
                return false;
            return true;
        }
        private bool CheckDate()
        {
            if (!CheckTrueDate(dob.Value, DateTime.Now))
            {
                MessageBox.Show("Invalid date of birth (Age must be greater than 18)", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                if (!CheckTrueDate(dob.Value, dos.Value))
            {
                MessageBox.Show("Invalid employment date (Older than 18 years old)", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.' || e.KeyChar == '-' ||
               e.KeyChar == '_' || e.KeyChar == '@'))
                e.Handled = true;
        }

        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridStaff.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridStaff.SelectedRows[0];
                ChangeText(row);
            }
        }
        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                txtusername.Text = string.Empty;
                txtname.Text = string.Empty;
                txtidnumber.Text = string.Empty;
                txtphonenumber.Text = string.Empty;
                txtaddress.Text = string.Empty;
            }
            else
            {
                //txtusername.Text = dataGridStaff.CurrentRow.Cells[0].Value.ToString();
                //txtaddress.Text = dataGridStaff.CurrentRow.Cells[8].Value.ToString();
                //txtname.Text = dataGridStaff.CurrentRow.Cells[1].Value.ToString();
                //txtphonenumber.Text = dataGridStaff.CurrentRow.Cells[6].Value.ToString();
                //txtidnumber.Text = dataGridStaff.CurrentRow.Cells[3].Value.ToString();
                //dob.Text = dataGridStaff.CurrentRow.Cells[4].Value.ToString();
                //dos.Text = dataGridStaff.CurrentRow.Cells[7].Value.ToString();
                //cbbsex.Text = dataGridStaff.CurrentRow.Cells[5].Value.ToString();
                //cbemptype.Text = dataGridStaff.CurrentRow.Cells[2].Value.ToString();

                txtusername.Text = row.Cells[colUserName.Name].Value as string;
                txtaddress.Text = row.Cells[colAddress.Name].Value as string;
                txtname.Text = row.Cells[colname.Name].Value as string;
                txtphonenumber.Text =row.Cells[colPhone.Name].Value.ToString();
                txtidnumber.Text = row.Cells[colIDCard.Name].Value as string;
                dob.Text = row.Cells[colDateOfBirth.Name].Value as string;
                dos.Text = row.Cells[colStartDay.Name].Value as string;
                cbbsex.Text = row.Cells[colSex.Name].Value as string;
                cbemptype.SelectedIndex = (int)row.Cells[colIDStaffType.Name].Value - 1;



            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Btnresetpass_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            txtusername.Text = string.Empty;
            txtname.Text = string.Empty;
            txtidnumber.Text = string.Empty;
            txtphonenumber.Text = string.Empty;
            txtaddress.Text = string.Empty;
        }

        private void employee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                btnCancel_Click(sender, null);
        }

        private void btnPermission_Click(object sender, EventArgs e)
        {
            permission f = new permission();
            f.ShowDialog();
            LoadFullStaffType();
            if (btnCancel.Visible == false)
                LoadFullStaff(GetFullStaff());
            else
                btnCancel_Click(null, null);
        }

        private void employee_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnCancel_Click(null, null);
        }

        private void txtphonenumber_TextChanged(object sender, EventArgs e)
        {
            if (!txtphonenumber.Text.StartsWith("20"))
            {
                txtphonenumber.Text = "20";
                txtphonenumber.SelectionStart = txtphonenumber.Text.Length;
            }
        }
    }
}
