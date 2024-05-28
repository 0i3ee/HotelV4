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
            //LoadRoomType();
            //LoadCustomerType();
            //LoadData();
            //LoadDays();
            //txbIDBookRoom.Text = _idBookRoom.ToString();
        }
    }
}
