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
namespace HotelV4
{
    public partial class check_in : Form
    {
        List<int> ListIDCustomer = new List<int>();
        int IDBookRoom = -1;
        //DateTime dateCheckIn;
        public check_in(int idBookRoom)
        {
            IDBookRoom = idBookRoom;
            InitializeComponent();
            //LoadData();
            //ShowBookRoomInfo(IDBookRoom);
        }
        public check_in()
        {
            InitializeComponent();
            //LoadData();

        }
    }
}
