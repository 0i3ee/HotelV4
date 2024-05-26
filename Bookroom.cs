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
    public partial class Bookroom : Form
    {
        public Bookroom()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            LoadRoomType();
            LoadCustomerType();
            LoadDate();
            LoadDays();
            LoadListBookRoom();
        }
        public void LoadRoomType()
        {
            cbRoomType.DataSource = RoomTypeDAO.Instance.LoadListRoomType();
            cbRoomType.DisplayMember = "Name";
        }
        public void LoadRoomTypeInfo(int id)
        {
            RoomType roomType = RoomTypeDAO.Instance.LoadRoomTypeInfo(id);
            txtRoomTypeID.Text = roomType.Id.ToString();
            txtRoomTypeName.Text = roomType.Name;
            //CultureInfo cultureInfo = new CultureInfo("vi-vn");
            //txbPrice.Text = roomType.Price.ToString("c0", cultureInfo);
            txbAmountPeople.Text = roomType.LimitPerson.ToString();
        }
        public void LoadDate()
        {
            DateOfBirth.Value = new DateTime(1998, 4, 6);
            DateCheckIn.Value = DateTime.Now;
            DateCheckOut.Value = DateTime.Now.AddDays(1);
        }
        public void LoadDays()
        {
            txtDays.Text = (DateCheckOut.Value.Date - DateCheckIn.Value.Date).Days.ToString();
        }
        public void LoadCustomerType()
        {
            //cbCustomerType.DataSource = CustomerTypeDAO.Instance.LoadListCustomerType();
            cbCustomerType.DisplayMember = "Name";
        }
        //public bool IsIdCardExists(string idCard)
        //{
        //    return CustomerDAO.Instance.IsIdCardExists(idCard);
        //}
        public void InsertCustomer(string idCard, string name, int idCustomerType, DateTime dateofBirth, string address, int phonenumber, string sex, string nationality)
        {
            //CustomerDAO.Instance.InsertCustomer(idCard, name, idCustomerType, dateofBirth, address, phonenumber, sex, nationality);
        }
        public void GetInfoByIdCard(string idCard)
        {
            //Customer customer = CustomerDAO.Instance.GetInfoByIdCard(idCard);

            //txbIDCard.Text = customer.IdCard.ToString();
            //txbFullName.Text = customer.Name;
            //txbAddress.Text = customer.Address;
            //DateOfBirth.Value = customer.DateOfBirth;
            //cbSex.Text = customer.Sex;
            //txbPhoneNumber.Text = customer.PhoneNumber.ToString();
            //cbNationality.Text = customer.Nationality;
            //cbCustomerType.Text = CustomerTypeDAO.Instance.GetNameByIdCard(idCard);
        }
        public void InsertBookRoom(int idCustomer, int idRoomType, DateTime datecheckin, DateTime datecheckout, DateTime datebookroom)
        {
            bookroomb.Instance.InsertBookRoom(idCustomer, idRoomType, datecheckin, datecheckout, datebookroom);
        }
        public int GetCurrentIDBookRoom(DateTime dateTime)
        {
            return bookroomb.Instance.GetCurrentIDBookRoom(dateTime);
        }
        public void LoadListBookRoom()
        {
            dgvb.DataSource = bookroomb.Instance.LoadListBookRoom(DateTime.Now.Date);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoomTypeInfo((cbRoomType.SelectedItem as RoomType).Id);
        }

        private void DateCheckOut_onValueChanged(object sender, EventArgs e)
        {
            if (DateCheckOut.Value < DateTime.Now)
                LoadDate();
            if (DateCheckOut.Value <= DateCheckIn.Value)
                LoadDate();
            LoadDays();
        }

        private void DateCheckIn_onValueChanged(object sender, EventArgs e)
        {
            if (DateCheckIn.Value <= DateTime.Now)
                LoadDate();
            if (DateCheckOut.Value <= DateCheckIn.Value)
                LoadDate();
            LoadDays();
        }

        private void txbIDCardSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                btnSearch_Click(sender, null);
        }

        private void txbIDCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txbIDCardSearch.Text != String.Empty)
            {
                //if (IsIdCardExists(txbIDCardSearch.Text))
                //    GetInfoByIdCard(txbIDCardSearch.Text);
                //else
                //    MessageBox.Show("Thẻ căn cước/ CMND không tồn tại.\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ClearData()
        {
            txbIDCardSearch.Text = txbIDCard.Text = txbFullName.Text = txbAddress.Text = txbPhoneNumber.Text = cbNationality.Text = String.Empty;
            LoadDate();
        }
        private void btnBookRoom_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đặt phòng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txbIDCard.Text != String.Empty && txbFullName.Text != String.Empty && txbAddress.Text != String.Empty && txbPhoneNumber.Text != String.Empty && cbNationality.Text != String.Empty)
                {
                    //if (!IsIdCardExists(txbIDCard.Text))
                    //{
                    //    int idCustomerType = (cbCustomerType.SelectedItem as CustomerType).Id;
                    //    InsertCustomer(txbIDCard.Text, txbFullName.Text, idCustomerType, dpkDateOfBirth.Value, txbAddress.Text, int.Parse(txbPhoneNumber.Text), cbSex.Text, cbNationality.Text);
                    //}
                    //InsertBookRoom(CustomerDAO.Instance.GetInfoByIdCard(txbIDCard.Text).Id, (cbRoomType.SelectedItem as RoomType).Id, dpkDateCheckIn.Value, dpkDateCheckOut.Value, DateTime.Now);
                    MessageBox.Show("Đặt phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                    LoadListBookRoom();
                    //if (bunifuCheckbox1.Checked)
                    //{
                    //    this.Hide();
                    //    fReceiveRoom fReceiveRoom = new fReceiveRoom(GetCurrentIDBookRoom(DateTime.Now.Date));
                    //    fReceiveRoom.ShowDialog();
                    //}
                }
                else
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            //int idBookRoom = (int)dataGridViewBookRoom.SelectedRows[0].Cells[0].Value;
            //string idCard = dataGridViewBookRoom.SelectedRows[0].Cells[2].Value.ToString();
            //fBookRoomDetails f = new fBookRoomDetails(idBookRoom, idCard);
            //f.ShowDialog();
            Show();
            LoadListBookRoom();
        }

        private void txbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
