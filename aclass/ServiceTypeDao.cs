using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using HotelV4.bclass;
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

            // Initialize a new DataTable to ensure it's fresh
            DataTable dataTable = new DataTable();

            // Create the SqlCommand and set its connection
            ccd.cmd = new SqlCommand("SELECT * FROM ServiceType", ccd.conn);

            // Create a SqlDataAdapter to execute the query
            SqlDataAdapter da = new SqlDataAdapter(ccd.cmd);

            // Use the SqlDataAdapter to fill the DataTable directly
            da.Fill(dataTable);

            // Return the filled DataTable
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
            ccd.cmd = new SqlCommand("SELECT * from dbo.ServiceType WHERE dbo.ServiceType.Name LIKE @Name OR dbo.ServiceType.ID = @ID", ccd.conn);
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
        internal bool InsertServiceType(string name)
        {
            try
            {
                ccd.cmd = new SqlCommand("INSERT INTO ServiceType (Name) VALUES (@name)", ccd.conn);
                ccd.cmd.Parameters.AddWithValue("@name", name);
                return ccd.cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                // Handle the exception (logging, rethrowing, etc.)
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }
        internal bool UpdateServiceType(int id, string name)
        {
            try
            {
                ccd.cmd = new SqlCommand("UPDATE ServiceType SET Name = @Name WHERE ID = @ID", ccd.conn);
                ccd.cmd.Parameters.AddWithValue("@Name", name);
                ccd.cmd.Parameters.AddWithValue("@ID", id);
                

                int rowsAffected = ccd.cmd.ExecuteNonQuery();
                return rowsAffected > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating service: " + ex.Message);
                return false; // Return false if the update fails
            }
        }
        internal bool UpdateServiceType(ServiceType serviceTypeNow)
        {
            return UpdateServiceType(serviceTypeNow.Id, serviceTypeNow.Name);
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
