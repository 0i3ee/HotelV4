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
    public partial class Check_inRoomDetail : Form
    {
        int idReceiveRoom;
        public Check_inRoomDetail(int _idReceiRoom)
        {
            InitializeComponent();
            FormMover.Moveform(this);
            idReceiveRoom = _idReceiRoom;
            ShowReceiveRoom(_idReceiRoom);
            ShowCustomers(_idReceiRoom);
        }
        public void ShowReceiveRoom(int idReceiveRoom)
        {
            DataRow data = check_inb.Instance.ShowReceiveRoom(idReceiveRoom).Rows[0];
            txtIDBookRoom.Text = ((int)data["ReceiveRoomID"]).ToString();
            txtRoom.Text = data["Room name"].ToString();
            txtDateCheckIn.Text = ((DateTime)data["Check In Date"]).ToString().Split(' ')[0];
            txtDateCheckOut.Text = ((DateTime)data["Check Out Date"]).ToString().Split(' ')[0];
        }
        public void ShowCustomers(int idReceiveRoom)
        {
            dgv.DataSource = check_inb.Instance.ShowCusomers(idReceiveRoom);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCus_Click(object sender, EventArgs e)
        {
            AddCustomerInfo AddCustomerInfo = new AddCustomerInfo();
            AddCustomerInfo.ShowDialog();
            this.Show();
            if (AddCustomerInfo.ListIdCustomer.Count > 0)
                foreach (var item in AddCustomerInfo.ListIdCustomer)
                {
                    checkinRoomDetailb.Instance.InsertReceiveRoomDetails(idReceiveRoom, item);
                }
            ShowCustomers(idReceiveRoom);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string idCard = dgv.SelectedRows[0].Cells[1].Value.ToString();
            int idCustomer = CustomerDAO.Instance.GetInfoByIdCard(idCard).Id;
            if (idCustomer != CustomerDAO.Instance.GetIDCustomerFromBookRoom(idReceiveRoom))
            {
                checkinRoomDetailb.Instance.DeleteReceiveRoomDetails(idReceiveRoom, idCustomer);
                MessageBox.Show("Successfully deleted customer!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowCustomers(idReceiveRoom);
            }
            else
                MessageBox.Show("Can not delete!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string idCard = dgv.SelectedRows[0].Cells[1].Value.ToString();
            int idCustomer = CustomerDAO.Instance.GetInfoByIdCard(idCard).Id;
            UpdateCustomerInfo f = new UpdateCustomerInfo(idCard);
            f.ShowDialog();
            Show();
            ShowCustomers(idReceiveRoom);
        }

        private void btnChangeRoom_Click(object sender, EventArgs e)
        {
            ChangeRoom f = new ChangeRoom(RoomDAO.Instance.GetIdRoomFromReceiveRoom(idReceiveRoom), idReceiveRoom);
            f.ShowDialog();
            Show();
            ShowReceiveRoom(idReceiveRoom);
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
