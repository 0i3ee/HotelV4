using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelV4.aclass;

namespace HotelV4.bclass
{
    class checkinRoomDetailb
    {
        private static checkinRoomDetailb instance;
        private checkinRoomDetailb() { }
        public bool InsertReceiveRoomDetails(int idReceiveRoom, int idCustomerOther)
        {
            string query = "InsertReceiveRoomDetails @idReceiveRoom , @idCustomer";
            int count = cdb.Instance.ExecuteNoneQuery(query, new object[] { idReceiveRoom, idCustomerOther });
            return count > 0;
        }
        public bool DeleteReceiveRoomDetails(int idReceiveRoom, int idCustomerOther)
        {
            string query = "USP_DeleteReceiveRoomDetails @idReceiveRoom , @idCustomer";
            int count = cdb.Instance.ExecuteNoneQuery(query, new object[] { idReceiveRoom, idCustomerOther });
            return count > 0;
        }
        public static checkinRoomDetailb Instance
        {
            get { if (instance == null) instance = new checkinRoomDetailb(); return instance; }
            private set => instance = value;
        }
    }
}
