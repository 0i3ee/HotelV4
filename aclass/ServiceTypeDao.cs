using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HotelV4.aclass
{
    class ServiceTypeDao
    {
        private static ServiceTypeDao instance;
        ClassconnectDB ccd = new ClassconnectDB();
        
        DataTable dataTable = new DataTable();
        SqlDataReader dr = null;
        
        //internal bool InsertServiceType(string name)
        //{
        //    string query = "USP_InsertServiceType @name";
        //    return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { name }) > 0;
        //}
        //internal bool InsertServiceType(ServiceType serviceTypeNow)
        //{
        //    return InsertServiceType(serviceTypeNow.Name);
        //}
        //internal bool UpdateServiceType(int id, string name)
        //{
        //    string query = "USP_UpdateServiceType @id , @name";
        //    return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id, name }) > 0;
        //}
        //internal bool UpdateServiceType(ServiceType serviceTypeNow)
        //{
        //    return UpdateServiceType(serviceTypeNow.Id, serviceTypeNow.Name);
        //}
        private ServiceTypeDao() {
            ccd.connectDatabase();
        } // Private constructor to enforce singleton pattern

        internal DataTable LoadFullServiceType()
        {
            

            try
            {
                // Ensure the connection is open
                if (ccd.conn.State == ConnectionState.Closed)
                {
                    ccd.conn.Open();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ServiceType", ccd.conn))
                {
                    dr = cmd.ExecuteReader();
                    dataTable.Load(dr);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (logging, rethrowing, etc.)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure the reader is closed
                dr?.Close();

                // Ensure the connection is closed
                if (ccd.conn.State == ConnectionState.Open)
                {
                    ccd.conn.Close();
                }
            }

            return dataTable;
        }

        public static ServiceTypeDao Instance
        {
            get { if (instance == null) instance = new ServiceTypeDao(); return instance; }
            private set => instance = value;
        }

        internal DataTable Search(string name, int id)
        {
            // Define the query to search for service based on name or ID
            ccd.cmd = new SqlCommand("SELECT * from dbo.ServiceType WHERE dbo.Service.Name LIKE @Name OR dbo.Service.ID = @ID", ccd.conn);
            ccd.cmd.Parameters.AddWithValue("@Name", "%" + name + "%"); // Add wildcard characters for partial matching
            ccd.cmd.Parameters.AddWithValue("@ID", id);

            // Execute the command
            dr = ccd.cmd.ExecuteReader();

            // Load search results into a DataTable
            DataTable searchResults = new DataTable();
            searchResults.Load(dr);

            // Close the DataReader
            dr.Close();

            // Return search results (or an empty DataTable if no results found)
            return searchResults;
        }

        //public static ServiceTypeDAO Instance
        //{
        //    get { if (instance == null) instance = new ServiceTypeDAO(); return instance; }
        //    private set => instance = value;
        //}

        //public List<ServiceType> GetServiceTypes()
        //{
        //    string query = "select * from ServiceType";
        //    List<ServiceType> serviceTypes = new List<ServiceType>();
        //    DataTable data = ccd.cmd.Instance.ExecuteQuery(query);
        //    foreach (DataRow item in data.Rows)
        //    {
        //        ServiceType serviceType = new ServiceType(item);
        //        serviceTypes.Add(serviceType);
        //    }
        //    return serviceTypes;
        //}
    }
}
