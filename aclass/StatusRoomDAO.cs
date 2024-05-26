using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelV4.bclass;
using System.Data;

namespace HotelV4.aclass
{
    public class StatusRoomDAO
    {
        #region Properties & Constructor
        private static StatusRoomDAO instance;
        private StatusRoomDAO() { }
        public static StatusRoomDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new StatusRoomDAO();
                return instance;
            }
            private set => instance = value;
        }

        #endregion

        #region Method
        internal bool UpdateStatusRoom(int id, string name)
        {
            string query = "exec USP_UpdateStatusRoom @id , @name";
            return cdb.Instance.ExecuteNoneQuery(query, new object[] { id, name }) > 0;
        }
        internal bool UpdateStatusRoom(StatusRoom statusRoomNow)
        {
            return UpdateStatusRoom(statusRoomNow.Id, statusRoomNow.Name);
        }
        internal DataTable LoadFullStatusRoom()
        {
            return cdb.Instance.ExecuteQuery("USP_LoadFullStatusRoom");
        }
        #endregion
    }
}
