﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelV4.bclass;

using System.Data;


namespace HotelV4.aclass
{
    public class RoomTypeDAO
    {
        private static RoomTypeDAO instance;
        public List<RoomType> GetRoomType(int idRoomType)
        {
            List<RoomType> roomTypes = new List<RoomType>();
            string query = "USP_LoadRoomTypeByType @idRoomType";
            DataTable dataTable = cdb.Instance.ExecuteQuery(query, new object[] { idRoomType });
            foreach (DataRow row in dataTable.Rows)
            {
                RoomType roomType = new RoomType(row);
                roomTypes.Add(roomType);
            }
            return roomTypes;
        }
        internal DataTable LoadFullRoomType()
        {
            return cdb.Instance.ExecuteQuery("USP_LoadFullRoomType");
        }
        internal bool InsertRoomType(string name, int price, int limitPerson)
        {
            string query = "USP_InsertRoomType @name , @price , @limitPerson";
            return cdb.Instance.ExecuteNoneQuery(query, new object[] { name, price, limitPerson }) > 0;

        }
        internal bool CheckRoomTypeExists(string name)
        {
            string query = "SELECT COUNT(*) FROM RoomType WHERE Name = @name";
            int count = Convert.ToInt32(cdb.Instance.ExecuteScalar(query, new object[] { name }));
            return count > 0;
        }

        internal bool InsertRoomType(RoomType roomTypeNow)
        {
            // Check if a room type with the same name already exists
            bool roomTypeExists = CheckRoomTypeExists(roomTypeNow.Name);

            if (roomTypeExists)
            {
                // If the room type already exists, return false to indicate insertion failure
                return false;
            }
            else
            {
                // If the room type doesn't exist, insert it into the database
                // Use the first overload to perform the insertion
                return InsertRoomType(roomTypeNow.Name, roomTypeNow.Price, roomTypeNow.LimitPerson);
            }
        }

        internal bool UpdateRoomType(RoomType roomNow, RoomType roomPre)
        {
            string query = "USP_UpdateRoomType @id , @name , @price , @limitPerson";
            return cdb.Instance.ExecuteNoneQuery(query, new object[] { roomNow.Id, roomNow.Name, roomNow.Price, roomNow.LimitPerson }) > 0;
        }
        internal DataTable Search(string text, int id)
        {
            string query = "USP_SearchRoomType @string , @id";
            return cdb.Instance.ExecuteQuery(query, new object[] { text, id });
        }
        internal int GetMaxPersonByRoomType(int idRoomType)
        {
            string query = "USP_GetMaxPersonByRoomType @idRoomType";
            DataRow data = cdb.Instance.ExecuteQuery(query, new object[] { idRoomType }).Rows[0];
            return Convert.ToInt32((double)data["Value"]);
        }
        public static RoomTypeDAO Instance
        {
            get { if (instance == null) instance = new RoomTypeDAO(); return instance; }
            private set => instance = value;
        }
        public RoomTypeDAO() { }
        public RoomType LoadRoomTypeInfo(int id)
        {
            string query = "USP_RoomTypeInfo @id";
            DataTable data = cdb.Instance.ExecuteQuery(query, new object[] { id });
            RoomType roomType = new RoomType(data.Rows[0]);
            return roomType;
        }
        public List<RoomType> LoadListRoomType()
        {
            string query = "select * from RoomType";
            DataTable data = cdb.Instance.ExecuteQuery(query);
            List<RoomType> listRoomType = new List<RoomType>();
            foreach (DataRow item in data.Rows)
            {
                RoomType roomType = new RoomType(item);
                listRoomType.Add(roomType);
            }
            return listRoomType;
        }
        public RoomType GetRoomTypeByIdRoom(int idRoom)
        {
            string query = "USP_GetRoomTypeByIdRoom @idRoom";
            DataTable data = cdb.Instance.ExecuteQuery(query, new object[] { idRoom });
            RoomType roomType = new RoomType(data.Rows[0]);
            return roomType;
        }
        public RoomType GetRoomTypeByIdBookRoom(int idBookRoom)
        {
            string query = "USP_GetRoomTypeByIdBookRoom @idBookRoom";
            DataTable data = cdb.Instance.ExecuteQuery(query, new object[] { idBookRoom });
            RoomType roomType = new RoomType(data.Rows[0]);
            return roomType;
        }

    }
}