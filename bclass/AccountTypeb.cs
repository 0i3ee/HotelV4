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
        ClassconnectDB ccd = new ClassconnectDB();
        SqlDataReader dr;
        DataTable dataTable = new DataTable();

        private AccountTypeb()
        {
            ccd.connectDatabase();
        }
        internal DataTable LoadFullStaffType()
        {
            
            ccd.cmd = new SqlCommand("select * from StaffType", ccd.conn);
            dr = ccd.cmd.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(dr);
            return dataTable;
        }
        public static AccountTypeb Instance
        {
            get { if (instance == null) instance = new AccountTypeb(); return instance; }
            private set => instance = value;
        }
    }
}

