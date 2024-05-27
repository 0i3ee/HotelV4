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
    class permissionB
    {
        private static permissionB instance = new permissionB();
        internal static permissionB Instance { get => instance; }
        private permissionB() { }


        public DataTable GetFullAccessNow(int idStaffType)
        {
            string query = "USP_LoadFullAccessNow @idStaffType";
            return cdb.Instance.ExecuteQuery(query, new object[] { idStaffType });
        }
        public DataTable GetFullAccessRest(int idStaffType)
        {
            string query = "USP_LoadFullAccessRest @idStaffType";
            return cdb.Instance.ExecuteQuery(query, new object[] { idStaffType });
        }


        internal void Insert(object idJob, int idStaffType)
        {
            string query = "USP_InsertAccess @idjob , @idStafftype";
            cdb.Instance.ExecuteNoneQuery(query, new object[] { idJob, idStaffType });
        }

        internal void Delete(int idJob, int idStaffType)
        {
            if (idJob == 6 && idStaffType == 1) return;
            string query = "USP_DeleteAccess @idjob , @idStafftype";
            cdb.Instance.ExecuteNoneQuery(query, new object[] { idJob, idStaffType });
        }

        internal bool CheckAccess(string username, string formName)
        {
            string query = "USP_ChekcAccess @username , @formname";
            return !(cdb.Instance.ExecuteScalar(query, new object[] { username, formName }) is null);
        }
    }
}
