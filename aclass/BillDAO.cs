using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HotelV4.bclass;

namespace HotelV4.aclass
{
    public class BillDAO
    {
        private static BillDAO instance;
        internal int GetIdBillMax()
        {
            string query = "USP_GetIdBillMax";
            return (int)cdb.Instance.ExecuteScalar(query);
        }
        internal int GetIdBillFromIdRoom(int idRoom)
        {
            string query = "USP_GetIdBillFromIdRoom @idRoom";
            DataRow dataRow = cdb.Instance.ExecuteQuery(query, new object[] { idRoom }).Rows[0];
            Bill bill = new Bill(dataRow);
            return bill.Id;
        }
        internal bool IsExistsBill(int idRoom)// > 0 Tồn tại Bill
        {
            string query = "USP_IsExistBillOfRoom @idRoom";
            return cdb.Instance.ExecuteQuery(query, new object[] { idRoom }).Rows.Count > 0;
        }
        internal bool InsertBill(int idReceiveRoom, string staffSetUp)
        {
            string query = "USP_InsertBill @idReceiveRoom , @staffSetUp";
            return cdb.Instance.ExecuteNoneQuery(query, new object[] { idReceiveRoom, staffSetUp }) > 0;
        }
        internal DataTable ShowBill(int idRoom)
        {
            string query = "USP_ShowBill @idRoom";
            return cdb.Instance.ExecuteQuery(query, new object[] { idRoom });
        }
        internal DataTable ShowBillPreView(int idBill)
        {
            string query = "USP_ShowBillPreView @idRoom";
            return cdb.Instance.ExecuteQuery(query, new object[] { idBill });
        }
        internal DataRow ShowBillRoom(int idRoom)
        {
            string query = "USP_ShowBillRoom @getToday , @idRoom";
            return cdb.Instance.ExecuteQuery(query, new object[] { DateTime.Now.Date, idRoom }).Rows[0];
        }
        internal bool UpdateRoomPrice(int idBill)
        {
            string query = "USP_UpdateBill_RoomPrice @idBill";
            return cdb.Instance.ExecuteNoneQuery(query, new object[] { idBill }) > 0;
        }
        internal bool UpdateServicePrice(int idBill)
        {
            string query = "USP_UpdateBill_ServicePrice @idBill";
            return cdb.Instance.ExecuteNoneQuery(query, new object[] { idBill }) > 0;
        }
        internal bool UpdateOther(int idBill, int discount)
        {
            string query = "USP_UpdateBill_Other @idBill , @discount";
            return cdb.Instance.ExecuteNoneQuery(query, new object[] { idBill, discount }) > 0;
        }
        internal DataTable LoaddFullBill()
        {
            string query = "USP_LoadFullBill";
            return cdb.Instance.ExecuteQuery(query);
        }

        internal DataTable SearchBill(string text, int mode)
        {
            string query = "USP_SearchBill @string , @mode";
            return cdb.Instance.ExecuteQuery(query, new object[] { text, mode });
        }

        internal static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set => instance = value;
        }
    }
}
