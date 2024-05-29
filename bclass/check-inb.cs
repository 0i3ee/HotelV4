using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using HotelV4.aclass;

namespace HotelV4.bclass
{
    class check_inb
    {
        private static check_inb instance;
        private check_inb() { }
        public bool InsertReceiveRoom(int idBookRoom, int idRoom)
        {
            string query = "InsertReceiveRoom @idBookRoom , @idRoom";
            int count = cdb.Instance.ExecuteNoneQuery(query, new object[] { idBookRoom, idRoom });
            return count > 0;
        }
        public int GetIDCurrent()
        {
            string query = "GetIDReceiveRoomCurrent";
            return (int)cdb.Instance.ExecuteScalar(query);
        }
        public DataTable LoadReceiveRoomInfo()
        {
            string query = "USP_LoadReceiveRoomsByDate @date";
            return cdb.Instance.ExecuteQuery(query, new object[] { DateTime.Now.Date });
        }
        public int GetIdReceiveRoomFromIdRoom(int idRoom)
        {
            string query = "USP_GetIdReceiRoomFromIdRoom @idRoom";
            DataTable dataTable = cdb.Instance.ExecuteQuery(query, new object[] { idRoom });
            check_ina receiveRoom = new check_ina(dataTable.Rows[0]);
            return receiveRoom.Id;
        }
        public DataTable ShowReceiveRoom(int id)
        {
            string query = "USP_ShowReceiveRoom @idReceiveRoom";
            return cdb.Instance.ExecuteQuery(query, new object[] { id });
        }
        public DataTable ShowCusomers(int id)
        {
            string query = "USP_ShowCustomerFromReceiveRoom @idReceiveRoom";
            return cdb.Instance.ExecuteQuery(query, new object[] { id });
        }
        public bool UpdateReceiveRoom(int id, int idRoom)
        {
            string query = "USP_UpdateReceiveRoom @id , @idRoom";
            return cdb.Instance.ExecuteNoneQuery(query, new object[] { id, idRoom }) > 0;
        }
        public static check_inb Instance
        {
            get { if (instance == null) instance = new check_inb(); return instance; }
            private set => instance = value;
        }   
}
}
