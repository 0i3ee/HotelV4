using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelV4.bclass;
using System.Text.RegularExpressions;
using HotelV4.aclass;

namespace HotelV4
{
    public partial class user : Form
    {
        public user(string userName)
        {
            InitializeComponent();
            FormMover.Moveform(this);
            LoadProfile(userName);


        }
        string Password;
        public void LoadProfile(string username)
        {
            Accout staff = AccountB.Instance.LoadStaffInforByUserName(username);
            lblUserName.Text = txtUserName.Text = staff.UserName;
            lblDisplayName.Text = txtDisplayName.Text = staff.DisplayName;
            txtStaffType.Text = AccountTypeb.Instance.GetStaffTypeByUserName(username).Name;
            txtIDCard.Text = staff.IdCard.ToString();
            txtPhoneNumber.Text = staff.PhoneNumber.ToString();
            txtAddress.Text = staff.Address;
            dpkDateOfBirth.Value = staff.DateOfBirth;
            cbSex.Text = staff.Sex;
            txtStartDay.Text = staff.StartDay.ToShortDateString();
            Password = staff.PassWord;
        }
        public void UpdateDisplayName(string username, string displayname)
        {
            AccountB.Instance.UpdateDisplayName(username, displayname);
        }
        public void UpdatePassword(string username, string password)
        {
            AccountB.Instance.UpdatePassword(username, password);
        }
        public void UpdateInfo(string username, string address, int phonenumber, string idCard, DateTime dateOfBirth, string sex)
        {
            AccountB.Instance.UpdateInfo(username, address, phonenumber, idCard, dateOfBirth, sex);
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            if (txtDisplayName.Text != String.Empty)
            {
                UpdateDisplayName(txtUserName.Text, txtDisplayName.Text);
                MessageBox.Show("Updated account information successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProfile(txtUserName.Text);
            }
            else
                MessageBox.Show("Invalid display name.\n Please re-enter.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSavePass_Click(object sender, EventArgs e)
        {
            if (AccountB.Instance.HashPass(txtPass.Text) == Password && txtNewPass.Text != String.Empty && txtReNewPass.Text != String.Empty)
            {
                if (txtNewPass.Text == txtReNewPass.Text)
                {
                    UpdatePassword(txtUserName.Text, txtNewPass.Text);
                    MessageBox.Show("Password updated successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPass.Text = txtNewPass.Text = txtReNewPass.Text = String.Empty;
                    LoadProfile(txtUserName.Text);
                }
                else
                {
                    MessageBox.Show("The new password is not valid.\nPlease re-enter.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNewPass.Text = txtReNewPass.Text = String.Empty;
                }
            }
            else
            {
                MessageBox.Show("Invalid password.\nPlease re-enter.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Text = txtNewPass.Text = txtReNewPass.Text = String.Empty;
            }
        }

        private void btnSavebasicInfo_Click(object sender, EventArgs e)
        {
            int phoneNumber = ParsePhoneNumber(txtPhoneNumber.Text);
            if (txtAddress.Text != String.Empty && txtPhoneNumber.Text != String.Empty && cbSex.Text != string.Empty && dpkDateOfBirth.Value < DateTime.Now.Date)
            {
                if (AccountB.Instance.IsIdCardExists(txtIDCard.Text))
                {
                    UpdateInfo(txtUserName.Text, txtAddress.Text, phoneNumber, txtIDCard.Text, dpkDateOfBirth.Value, cbSex.Text);
                    MessageBox.Show("Basic information updated successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProfile(txtUserName.Text);
                }
                else
                    MessageBox.Show("ID card/ID card does not exist.\nPlease re-enter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Basic information is invalid.\nPlease re-enter.", "Warning" ,MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private int ParsePhoneNumber(string maskedPhoneNumber)
        {
            // Remove non-numeric characters using regular expressions
            string numericPhoneNumber = Regex.Replace(maskedPhoneNumber, @"[^\d]", "");

            // Convert the cleaned string to an integer
            return int.Parse(numericPhoneNumber);
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtPhoneNumber_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (e.Position < 2) // Prevent modification of the first two characters (the fixed "20")
            {
                ToolTip toolTip = new ToolTip();
                toolTip.ToolTipTitle = "Invalid Input";
                toolTip.Show("You cannot modify the fixed prefix '20'.", txtPhoneNumber, txtPhoneNumber.Location.X, txtPhoneNumber.Location.Y, 2000);
            }
        }

        private void txtPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtPhoneNumber.SelectionStart < 2 && (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete))
            {
                // Suppress the key press to prevent deletion of the fixed prefix
                e.SuppressKeyPress = true;
            }
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (!txtPhoneNumber.Text.StartsWith("20"))
            {
                txtPhoneNumber.Text = "20";
                txtPhoneNumber.SelectionStart = txtPhoneNumber.Text.Length;
            }
        }
    }
}
