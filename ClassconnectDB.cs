using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
namespace HotelV4
{
    class ClassconnectDB
    {
        public string strcon = "Data source =.; Initial catalog=HotelManagement; integrated security=True";
        public SqlConnection conn = new SqlConnection();
        public SqlDataAdapter da = new SqlDataAdapter();
        public DataSet ds = new DataSet();
        public SqlCommand cmd = new SqlCommand();
        public void connectDatabase()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                
            }
            conn.ConnectionString = strcon;
            conn.Open();
        }
    }
}
