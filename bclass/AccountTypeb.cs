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
        SqlDataReader dr;
        DataTable dataTable = new DataTable();

        private AccountTypeb()
        {

        }
        internal DataTable LoadFullStaffType()
        {
            string query = "USP_LoadFullStaffType";
            return cdb.Instance.ExecuteQuery(query);
        }
        public static AccountTypeb Instance
        {
            get { if (instance == null) instance = new AccountTypeb(); return instance; }
            private set => instance = value;
        }
    }
}

