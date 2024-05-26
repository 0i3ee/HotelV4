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
        internal int LoadStaffTypeidByName(string name)
        {
            string query = "SELECT id FROM StaffType WHERE Name = @Name";
            object[] parameters = { "@Name", name };
            DataTable dataTable = cdb.Instance.ExecuteQuery(query, parameters);
            if (dataTable.Rows.Count > 0)
            {
                return Convert.ToInt32(dataTable.Rows[0]["id"]);
            }
            else
            {
                return 0;
            }
        }
        public static AccountTypeb Instance
        {
            get { if (instance == null) instance = new AccountTypeb(); return instance; }
            private set => instance = value;
        }
    }
}

