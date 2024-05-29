using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HotelV4.aclass
{
    class check_indetaila
    {
        private int idReceiveRoom;
        private int idCustomerOther;
        public check_indetaila(DataRow row)
        {
            IdReceiveRoom = (int)row["idReceiveRoom"];
            IdCustomerOther = (int)row["idCustomerOther"];
        }
        public int IdReceiveRoom { get => idReceiveRoom; set => idReceiveRoom = value; }
        public int IdCustomerOther { get => idCustomerOther; set => idCustomerOther = value; }
    }
}
