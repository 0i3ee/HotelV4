using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Data.SqlClient;

using HotelV4.aclass;

namespace HotelV4.bclass
{
    class AccountTypeb
    {
        private static AccountTypeb instance;
        //cdb ccd = new cdb();
        DataTable dataTable = new DataTable();

        private AccountTypeb()
        {

        }
        internal DataTable LoadFullStaffType()
        {
            string query = "USP_LoadFullStaffType";
            return cdb.Instance.ExecuteQuery(query);
        }
        public AccountType GetStaffTypeByUserName(string username)
        {
            string query = "USP_GetNameStaffTypeByUserName @username";
            AccountType staffType = new AccountType(cdb.Instance.ExecuteQuery(query, new object[] { username }).Rows[0]);
            return staffType;
        }
        internal bool Delete(int idStaffType)
        {
            string query = "USP_DeleteStaffType @id";
            return cdb.Instance.ExecuteNoneQuery(query, new object[] { idStaffType }) > 0;
        }
        internal bool Update(int idStaffType, string text)
        {
            string query = "USP_UpdateStaffType @id , @name";
            return cdb.Instance.ExecuteNoneQuery(query, new object[] { idStaffType, text }) > 0;
        }

        internal bool Insert(string text)
        {
            string query = "USP_InsertStaffType @name";
            return cdb.Instance.ExecuteNoneQuery(query, new object[] { text }) > 0;
        }
        public static AccountTypeb Instance
        {
            get { if (instance == null) instance = new AccountTypeb(); return instance; }
            private set => instance = value;
        }
    }
}

