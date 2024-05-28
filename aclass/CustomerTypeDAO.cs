using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HotelV4.bclass;


namespace HotelV4.aclass
{
    public class CustomerTypeDAO
    {
        private static CustomerTypeDAO instance;

        #region Method
        private CustomerTypeDAO() { }
        public List<CustomerType> LoadListCustomerType()
        {
            string query = "select * from CustomerType";
            DataTable data = cdb.Instance.ExecuteQuery(query);
            List<CustomerType> listCustomerType = new List<CustomerType>();
            foreach (DataRow item in data.Rows)
            {
                CustomerType CustomerType = new CustomerType(item);
                listCustomerType.Add(CustomerType);
            }
            return listCustomerType;
        }
        public string GetNameByIdCard(string idCard)
        {
            string query = "USP_GetCustomerTypeNameByIdCard @idCard";
            DataRow dataRow = cdb.Instance.ExecuteQuery(query, new object[] { idCard }).Rows[0];
            return dataRow["Name"].ToString();
        }
        internal bool UpdateCustomerType(CustomerType customerTypeNow)
        {
            string query = "USP_UpdateCustomerType @id , @name";
            return cdb.Instance.ExecuteNoneQuery(query, new object[] { customerTypeNow.Id, customerTypeNow.Name }) > 0;
        }

        internal bool InsertCustomerType(string name)
        {
            string query = "USP_InsertCustomerType @name";
            return cdb.Instance.ExecuteNoneQuery(query, new object[] { name }) > 0;
        }
        internal bool InsertCustomerType(AddCustomerType customerTypeNow)
        {
            return InsertCustomerType(customerTypeNow.Name);
        }

        internal DataTable LoadFullCustomerType()
        {
            return cdb.Instance.ExecuteQuery("USP_LoadFullCustomerType");
        }
        #endregion
        public static CustomerTypeDAO Instance
        {
            get { if (instance == null) instance = new CustomerTypeDAO(); return instance; }
            private set => instance = value;
        }


    }
}
