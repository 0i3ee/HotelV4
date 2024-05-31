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
    public partial class Bookroom_Detail : Form
    {
        int idBookRoom;
        string idCard;
        public Bookroom_Detail(int _idBookRoom, string _idCard)
        {
            idBookRoom = _idBookRoom;
            idCard = _idCard;
            InitializeComponent();
            FormMover.Moveform(this);
            LoadRoomType();
            LoadCustomerType();
            LoadData();
            LoadDays();
            txbIDBookRoom.Text = _idBookRoom.ToString();
        }
        public void LoadRoomType()
        {
            cbRoomType.DataSource = RoomTypeDAO.Instance.LoadListRoomType();
            cbRoomType.DisplayMember = "Name";
        }
        public void LoadData()
        {
            DataRow data = bookroomb.Instance.ShowBookRoomInfo(idBookRoom);
            DateCheckIn.Value = (DateTime)data["DateCheckIn"];
            DateCheckOut.Value = (DateTime)data["DateCheckOut"];

            cbRoomType.Text = RoomTypeDAO.Instance.GetRoomTypeByIdBookRoom(idBookRoom).Name;

            GetInfoByIdCard(idCard);
        }
        public void GetInfoByIdCard(string idCard)
        {
            Customer customer = CustomerDAO.Instance.GetInfoByIdCard(idCard);
            txbIDCard.Text = customer.IdCard.ToString();
            txbFullName.Text = customer.Name;
            txbAddress.Text = customer.Address;
            DateOfBirth.Value = customer.DateOfBirth;
            cbSex.Text = customer.Sex;
            txbPhoneNumber.Text = customer.PhoneNumber.ToString();
            cbNationality.Text = customer.Nationality;
            cbCustomerType.Text = CustomerTypeDAO.Instance.GetNameByIdCard(idCard);
        }
        public void LoadCustomerType()
        {
            cbCustomerType.DataSource = CustomerTypeDAO.Instance.LoadListCustomerType();
            cbCustomerType.DisplayMember = "Name";
        }
        public void LoadDays()
        {
            txtDays.Text = (DateCheckOut.Value.Date - DateCheckIn.Value.Date).Days.ToString();
        }

        public bool IsIdCardExists(string idCard)
        {
            return CustomerDAO.Instance.IsIdCardExists(idCard);
        }
        public void UpdateCustomer()
        {
            int idCustomerType = (cbCustomerType.SelectedItem as CustomerType).Id;
            CustomerDAO.Instance.UpdateCustomer(CustomerDAO.Instance.GetInfoByIdCard(idCard).Id, txbFullName.Text, txbIDCard.Text, idCustomerType, int.Parse(txbPhoneNumber.Text), DateOfBirth.Value, txbAddress.Text, cbSex.Text, cbNationality.Text);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DateCheckIn_ValueChanged(object sender, EventArgs e)
        {
            if (DateCheckIn.Value <= DateTime.Now)
                LoadData();
            if (DateCheckOut.Value <= DateCheckIn.Value)
                LoadData();
            LoadDays();
        }

        private void DateCheckOut_ValueChanged(object sender, EventArgs e)
        {
            if (DateCheckOut.Value < DateTime.Now)
                LoadData();
            if (DateCheckOut.Value <= DateCheckIn.Value)
                LoadData();
            LoadDays();
        }
        public void ClearData()
        {
            txbIDCard.Text = txbFullName.Text = txbAddress.Text = txbPhoneNumber.Text = cbNationality.Text = String.Empty;
        }

        private void btnCusUpdate_Click(object sender, EventArgs e)
        {
            if (txbFullName.Text != string.Empty && txbIDCard.Text != string.Empty && txbAddress.Text != string.Empty && cbNationality.Text != string.Empty && txbPhoneNumber.Text != string.Empty)
            {
                //Kiểm tra IDCard có trùng không
                if (!IsIdCardExists(txbIDCard.Text) || txbIDCard.Text == idCard)
                {
                    UpdateCustomer();

                }
                else
                    MessageBox.Show("ID card/ID card is invalid.\nPlease re-enter.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please enter complete information.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            MessageBox.Show("Successfully updated customer information!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }

        private void txbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            bookroomb.Instance.UpdateBookRoom(idBookRoom, (cbRoomType.SelectedItem as RoomType).Id, DateCheckIn.Value, DateCheckOut.Value);
            MessageBox.Show("Successfully updated booking information!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }

        private void btnCusDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deleting a customer will result in the booking being also deleted!\nDo you want to continue?", "Result", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (bookroomb.Instance.IsIDBookRoomExists(idBookRoom))
                {
                    bookroomb.Instance.DeleteBookRoom(idBookRoom);
                    MessageBox.Show("Successfully deleted customer information!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Delete customer information failed!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
