using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Globalization;
using HotelV4.aclass;
using HotelV4.bclass;

namespace HotelV4
{
    public partial class ChangeRoom : Form
    {
        int idRoom, idReceiveRoom;
        public ChangeRoom(int _idRoom, int _idReceiveRoom)
        {
            InitializeComponent();
            FormMover.Moveform(this);
            idRoom = _idRoom;
            idReceiveRoom = _idReceiveRoom;
            LoadListRoomType();
            LoadRoomTypeInfo(_idRoom);
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomTypeName.Text = (cbRoomType.SelectedItem as RoomType).Name;
            LoadEmptyRoom((cbRoomType.SelectedItem as RoomType).Id);
            LoadRoomTypeInfo((cbRoom.SelectedItem as Room).Id);
        }

        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRoom.SelectedItem != null)
            {
                txtName.Text = (cbRoom.SelectedItem as Room).Name;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RoomDAO.Instance.UpdateStatusRoom(idRoom);
            check_inb.Instance.UpdateReceiveRoom(idReceiveRoom, (cbRoom.SelectedItem as Room).Id);
            MessageBox.Show("Room change successful!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadRoomTypeInfo(int idRoom)
        {
            CultureInfo cultureInfo = new CultureInfo("lo-LA");
            RoomType roomType = RoomTypeDAO.Instance.GetRoomTypeByIdRoom(idRoom);
            txtMaxPeople.Text = roomType.LimitPerson.ToString();
            txtPrice.Text = roomType.Price.ToString("c", cultureInfo);
            txtRoomTypeName.Text = roomType.Name;
        }


    }
}
