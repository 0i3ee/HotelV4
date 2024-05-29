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
    public partial class check_in : Form
    {
        List<int> ListIDCustomer = new List<int>();
        int IDBookRoom = -1;
        DateTime dateCheckIn;
        public check_in(int idBookRoom)
        {
            IDBookRoom = idBookRoom;
            InitializeComponent();
            LoadData();
            ShowBookRoomInfo(IDBookRoom);
        }
        public check_in()
        {
            InitializeComponent();
            FormMover.Moveform(this);
            LoadData();
        }
        public void LoadData()
        {
            LoadListRoomType();
            LoadReceiveRoomInfo();
        }
        public void LoadListRoomType()
        {
            List<RoomType> rooms = RoomTypeDAO.Instance.LoadListRoomType();
            cbRoomType.DataSource = rooms;
            cbRoomType.DisplayMember = "Name";
        }
        public void LoadEmptyRoom(int idRoomType)
        {
            List<Room> rooms = RoomDAO.Instance.LoadEmptyRoom(idRoomType);
            cbRoom.DataSource = rooms;
            cbRoom.DisplayMember = "Name";
        }
        public void ClearData()
        {
            txtFullName.Text = txtIDCard.Text = txtRoomTypeName.Text = txtDateCheckIn.Text = txtDateCheckOut.Text = txtAmountPeople.Text = txtPrice.Text = string.Empty;
        }
     
        public void ShowBookRoomInfo(int idBookRoom)
        {           
            DataRow dataRow = bookroomb.Instance.ShowBookRoomInfo(idBookRoom);
            txtFullName.Text = dataRow["FullName"].ToString();
            txtIDCard.Text = dataRow["IDCard"].ToString();
            txtRoomTypeName.Text = dataRow["RoomTypeName"].ToString();
            cbRoomType.Text = dataRow["RoomTypeName"].ToString();//
            txtDateCheckIn.Text = dataRow["DateCheckIn"].ToString().Split(' ')[0];
            dateCheckIn = (DateTime)dataRow["DateCheckIn"];
            txtDateCheckOut.Text = dataRow["DateCheckOut"].ToString().Split(' ')[0];
            txtAmountPeople.Text = dataRow["LimitPerson"].ToString();
            txtPrice.Text = dataRow["Price"].ToString();
        }
        public bool IsIDBookRoomExists(int idBookRoom)
        {
            return bookroomb.Instance.IsIDBookRoomExists(idBookRoom);
        }
        public bool InsertReceiveRoom(int idBookRoom, int idRoom)
        {
            return check_inb.Instance.InsertReceiveRoom(idBookRoom, idRoom);
        }
        public bool InsertReceiveRoomDetails(int idReceiveRoom, int idCustomerOther)
        {
            return check_indetailb.Instance.InsertReceiveRoomDetails(idReceiveRoom, idCustomerOther);
        }
        public void LoadReceiveRoomInfo()
        {
            dgv.DataSource = check_inb.Instance.LoadReceiveRoomInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomTypeName.Text = (cbRoomType.SelectedItem as RoomType).Name;
            LoadEmptyRoom((cbRoomType.SelectedItem as RoomType).Id);
        }

        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRoom.SelectedItem != null)
            {
                txtRoom.Text = (cbRoom.SelectedItem as Room).Name;
            }
        }

        private void txtIDBookRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                btnSearch_Click(sender, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtIDBookRoom.Text != string.Empty)
            {
                if (IsIDBookRoomExists(int.Parse(txtIDBookRoom.Text)))
                {
                    btnSearch.Tag = txtIDBookRoom.Text;
                    ShowBookRoomInfo(int.Parse(txtIDBookRoom.Text));
                }
                else
                    MessageBox.Show("Reservation code does not exist.\nPlease re-enter.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIDBookRoom.Text = string.Empty;
            }
        }

        private void btnAddCus_Click(object sender, EventArgs e)
        {
            if (txtRoom.Text != string.Empty && txtRoomTypeName.Text != string.Empty && txtFullName.Text != string.Empty && txtIDCard.Text != string.Empty && txtDateCheckIn.Text != string.Empty && txtDateCheckOut.Text != string.Empty && txtAmountPeople.Text != string.Empty && txtPrice.Text != string.Empty)
            {
                AddCustomer fAddCustomerInfo = new AddCustomer();
                fAddCustomerInfo.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Please re-enter your full information.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to check in?", "Result", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtRoom.Text != string.Empty && txtRoomTypeName.Text != string.Empty && txtFullName.Text != string.Empty && txtIDCard.Text != string.Empty && txtDateCheckIn.Text != string.Empty && txtDateCheckOut.Text != string.Empty && txtAmountPeople.Text != string.Empty && txtPrice.Text != string.Empty)
                {
                    if (dateCheckIn == DateTime.Now.Date)
                    {
                        int idBookRoom;
                        if (IDBookRoom != -1) idBookRoom = IDBookRoom;
                        else idBookRoom = int.Parse(btnSearch.Tag.ToString());
                        int idRoom = (cbRoom.SelectedItem as Room).Id;
                        if (InsertReceiveRoom(idBookRoom, idRoom))
                        {
                            if (AddCustomerInfo.ListIdCustomer != null)
                            {
                                foreach (int item in AddCustomerInfo.ListIdCustomer)
                                {
                                    if (item != int.Parse(txtIDCard.Text))
                                        InsertReceiveRoomDetails(check_inb.Instance.GetIDCurrent(), item);
                                }
                            }
                            MessageBox.Show("Check-in successful.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadEmptyRoom((cbRoomType.SelectedItem as RoomType).Id);
                        }
                        else
                            MessageBox.Show("Creation of check-in voucher failed.\nPlease re-enter.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Check-in date is invalid.\nPlease re-enter.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearData();
                    LoadReceiveRoomInfo();
                }
                else
                    MessageBox.Show("Please re-enter complete information.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Check_inRoomDetail frm = new Check_inRoomDetail((int)dgv.SelectedRows[0].Cells[0].Value);
                frm.ShowDialog();
                Show();
                LoadReceiveRoomInfo();
            }
            catch (Exception) { }
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
