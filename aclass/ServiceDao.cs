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
    public class ServiceDao
    {
        private static ServiceDao instance;
        public List<Service> GetServices(int idServiceType)
        {
            List<Service> services = new List<Service>();
            string query = "USP_LoadServiceByServiceType @idServiceType";
            DataTable dataTable = cdb.Instance.ExecuteQuery(query, new object[] { idServiceType });
            foreach (DataRow item in dataTable.Rows)
            {
                Service service = new Service(item);
                services.Add(service);
            }
            return services;
        }
        internal bool InsertService(string name, int idtype, int price)
        {
            string query = "USP_InsertService @name , @idServiceType , @price";
            return cdb.Instance.ExecuteNoneQuery(query, new object[]
            {
                name, idtype, price
            }) > 0;
        }
        internal bool InsertService(Service serviceNow)
        {
            return InsertService(serviceNow.Name, serviceNow.IdServiceType, serviceNow.Price);
        }
        internal bool UpdateService(int id, string name, int idServiceType, int price)
        {
            try
            {
                string query = "USP_UpdateService @id , @name , @idServiceType , @price";
                int result = cdb.Instance.ExecuteNoneQuery(query, new object[] { id, name, idServiceType, price });
                return result > 0;
            }
            catch (Exception ex)
            {
                // Log exception (implement logging according to your logging framework)
                Console.WriteLine($"An error occurred while updating the service: {ex.Message}");
                return false;
            }
        }

        internal bool UpdateService(Service serviceNow, Service servicePre)
        {
            // Assuming servicePre is not needed for the update logic
            return UpdateService(serviceNow.Id, serviceNow.Name, serviceNow.IdServiceType, serviceNow.Price);
        }
        internal DataTable LoadFullService()
        {
            string query = "USP_LoadFullService";
            return cdb.Instance.ExecuteQuery(query);
        }
        internal DataTable Search(string name, int id)
        {
            string query = "USP_SearchService @string , @int";
            return cdb.Instance.ExecuteQuery(query, new object[] { name, id });
        }
        public static ServiceDao Instance
        {
            get { if (instance == null) instance = new ServiceDao(); return instance; }
            private set => instance = value;
        }
    }
}





