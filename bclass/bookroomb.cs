using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using HotelV4.aclass;
using HotelV4.bclass;

namespace HotelV4.bclass
{
    class bookroomb
    {
        private static bookroomb instance;
        private bookroomb() { }
        public bool InsertBookRoom(int idCustomer, int idRoomType, DateTime datecheckin, DateTime datecheckout, DateTime datebookroom)
        {
            string query = "USP_InsertBookRoom @idCustomer , @idRoomType , @datecheckin , @datecheckout , @datebookroom";
            return cdb.Instance.ExecuteNoneQuery(query, new object[] { idCustomer, idRoomType, datecheckin, datecheckout, datebookroom }) > 0;
        }
        public DataTable LoadListBookRoom(DateTime dateTime)
        {
            string query = "USP_LoadBookRoomsByDate @date";
            return cdb.Instance.ExecuteQuery(query, new object[] { dateTime });

        }
        public int GetCurrentIDBookRoom(DateTime dateTime)
        {
            string query = "USP_LoadBookRoomsByDate @date";
            DataRow dataRow = cdb.Instance.ExecuteQuery(query, new object[] { dateTime }).Rows[0];
            return (int)dataRow["ReceiveRoomID"];
        }
        public bool IsIDBookRoomExists(int idBookRoom)
        {
            string query = "USP_IsIDBookRoomExists @idBookRoom , @dateNow";
            DataTable dataTable = cdb.Instance.ExecuteQuery(query, new object[] { idBookRoom, DateTime.Now.Date });
            return dataTable.Rows.Count > 0;
        }
        public DataRow ShowBookRoomInfo(int idBookRoom)
        {
            string query = "ShowBookRoomInfo @idBookRoom";
            return cdb.Instance.ExecuteQuery(query, new object[] { idBookRoom }).Rows[0];
        }
        public bool UpdateBookRoom(int id, int idRoomType, DateTime datecheckin, DateTime datecheckout)
        {
            string query = "USP_UpdateBookRoom @id , @idRoomType , @dateCheckIn , @datecheckOut";
            return cdb.Instance.ExecuteNoneQuery(query, new object[] { id, idRoomType, datecheckin, datecheckout }) > 0;
        }
        public bool DeleteBookRoom(int id)
        {
            string query = "USP_DeleteBookRoom @id";
            return cdb.Instance.ExecuteNoneQuery(query, new object[] { id }) > 0;
        }
        public static bookroomb Instance
        {
            get { if (instance == null) instance = new bookroomb(); return instance; }
            private set => instance = value;
        }
    }
}
