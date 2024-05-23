using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;


using HotelV4.aclass;

namespace HotelV4.aclass
{
    class querycon
    {
        ClassconnectDB ccd = new ClassconnectDB();
        DataTable dataTable = new DataTable();
        SqlDataReader dr;

        private static querycon instance;
        internal string HashPass(string text)
        {
            MD5 md5 = MD5.Create();
            byte[] temp = Encoding.ASCII.GetBytes(text);
            byte[] hashData = md5.ComputeHash(temp);
            string hashPass = "";
            foreach (var item in hashData)
            {
                hashPass += item.ToString("x2");
            }
            return hashPass;
        }

        internal string Login(string userName, string passWord)
        {
            string displayName = null;
            string hashPass = HashPass(passWord);

            using (SqlConnection conn = new SqlConnection("your_connection_string_here"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select DisplayName from Staff where UserName=@user and PassWord=@pass", conn))
                {
                    cmd.Parameters.AddWithValue("@user", userName);
                    cmd.Parameters.AddWithValue("@pass", hashPass);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            displayName = dr["DisplayName"].ToString();
                        }
                    }
                }
                conn.Close();
            }
            return displayName;
        }

        internal DataTable LoadFullStaffType()
        {
            ccd.cmd = new SqlCommand("select * from StaffType", ccd.conn);
            dr = ccd.cmd.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(dr);
            return dataTable;
        }

        internal Accout LoadStaffInforByUserName(string username)
        {

            ccd.cmd = new SqlCommand("select * from Staff where UserName='" + username + "'", ccd.conn);
            dr = ccd.cmd.ExecuteReader();
            if (dr.HasRows) {
                dataTable.Load(dr);
                Accout account = new Accout(dataTable.Rows[0]);
                return account;
            }
            return null;
        }

        internal bool InsertAccount(Accout account)
        {

            ccd.cmd = new SqlCommand("insert into Staff Values(@UserName , @DisplayName , @pass , @idStaffType , @idCard , @dateOfBirth , @sex , @address , @phoneNumber , @startDay)", ccd.conn);
            ccd.cmd.Parameters.AddWithValue("@UserName", account.UserName);
            ccd.cmd.Parameters.AddWithValue("@DisplayName", account.DisplayName);
            ccd.cmd.Parameters.AddWithValue("@pass", account.PassWord);
            ccd.cmd.Parameters.AddWithValue("@idStaffType", int.Parse(account.IdStaffType.ToString()));
            ccd.cmd.Parameters.AddWithValue("@idCard", account.IdCard);
            ccd.cmd.Parameters.AddWithValue("@dateOfBirth", account.DateOfBirth.ToString("yyyy-MM-dd"));
            ccd.cmd.Parameters.AddWithValue("@sex", account.Sex);
            ccd.cmd.Parameters.AddWithValue("@address", account.Address);
            ccd.cmd.Parameters.AddWithValue("@phoneNumber", account.PhoneNumber);
            ccd.cmd.Parameters.AddWithValue("@startDay", account.StartDay.ToString("yyyy-MM-dd"));

            
            return ccd.cmd.ExecuteNonQuery() > 0;
        }




        internal static querycon Instance
        {
            get { if (instance == null) instance = new querycon(); return instance; }
            private set => instance = value;
        }
        private querycon() {
            ccd.connectDatabase();
        }
    }
}
