using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelV4.bclass;
using System.Data;
using System.Data.SqlClient;


namespace HotelV4.aclass
{
    class ServiceDao
    {
        ClassconnectDB ccd = new ClassconnectDB();
        DataTable dataTable = new DataTable();
        private static ServiceDao instance;
        SqlDataReader dr;

        //public List<Service> GetServices(int idServiceType)
        //{
        //    List<Service> services = new List<Service>();
        //    string query = "USP_LoadServiceByServiceType @idServiceType";
        //    dataTable dataTable = ccd.Instance.ExecuteQuery(query, new object[] { idServiceType });
        //    foreach (DataRow item in dataTable.Rows)
        //    {
        //        Service service = new Service(item);
        //        services.Add(service);
        //    }
        //    return services;
        //}
        internal bool InsertService(string name, int idtype, int price)
        {
            try
            {

                ccd.cmd = new SqlCommand("insert into Service Values(@name, @idServiceType, @price)", ccd.conn);
                
                    ccd.cmd.Parameters.AddWithValue("@name", name);
                    ccd.cmd.Parameters.AddWithValue("@idServiceType", idtype);
                    ccd.cmd.Parameters.AddWithValue("@price", price);
                    return ccd.cmd.ExecuteNonQuery() > 0;
                
            }
            catch (Exception ex)
            {
                // Handle the exception (logging, rethrowing, etc.)
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }

        }
        internal bool InsertService(Service serviceNow)
        {
            return InsertService(serviceNow.Name, serviceNow.IdServiceType, serviceNow.Price);
        }
        internal DataTable LoadFullService()
        {


            ccd.da = new SqlDataAdapter(" SELECT * from dbo.Service", ccd.conn);
            ccd.da.Fill(ccd.ds);
            ccd.ds.Tables[0].Clear(); // Clearing the first table in the DataSet
            ccd.da.Fill(ccd.ds); // Refill the DataSet with fresh data

            DataTable dataTable = ccd.ds.Tables[0]; // Accessing the first DataTable in the DataSet

            return dataTable;

        }
        public static ServiceDao Instance
        {
            get { if (instance == null) instance = new ServiceDao(); return instance; }
            private set => instance = value;
        }
        private ServiceDao()
        {
            ccd.connectDatabase();
        }
        internal DataTable Search(string name, int id)
        {
            // Define the query to search for service based on name or ID
            ccd.cmd = new SqlCommand("SELECT * from dbo.Service WHERE dbo.Service.Name LIKE @Name OR dbo.Service.ID = @ID", ccd.conn);
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
        internal bool UpdateService(int id, string name, int idServiceType, int price)
        {
            try
            {
                ccd.cmd = new SqlCommand("UPDATE Service SET Name = @Name, IDServiceType = @IDServiceType, Price = @Price WHERE ID = @ID", ccd.conn);
                ccd.cmd.Parameters.AddWithValue("@Name", name);
                ccd.cmd.Parameters.AddWithValue("@IDServiceType", idServiceType);
                ccd.cmd.Parameters.AddWithValue("@Price", price);
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

        internal bool UpdateService(Service serviceNow, Service servicePre)
        {
            return UpdateService(serviceNow.Id, serviceNow.Name, serviceNow.IdServiceType, serviceNow.Price);
        }
    }
}





