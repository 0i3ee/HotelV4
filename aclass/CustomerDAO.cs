using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HotelV4.bclass;

namespace HotelV4.aclass
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;
        private CustomerDAO() { }
        #region Method
        public bool IsIdCardExists(string idCard)
        {
            string query = "USP_IsIdCardExists @idCard";
            int count = cdb.Instance.ExecuteQuery(query, new object[] { idCard }).Rows.Count;
            return count > 0;
        }
        public bool InsertCustomer(string idCard, string name, int idCustomerType, DateTime dateofBirth, string address, int phonenumber, string sex, string nationality)
        {
            string query = "USP_InsertCustomer_ @idCard , @name , @idCustomerType , @dateOfBirth , @address , @phoneNumber , @sex , @nationality";
            return cdb.Instance.ExecuteNoneQuery(query, new object[] { idCard, name, idCustomerType, dateofBirth, address, phonenumber, sex, nationality }) > 0;
        }
        public Customer GetInfoByIdCard(string idCard)
        {
            string query = "USP_IsIdCardExists @idCard";
            Customer customer = new Customer(cdb.Instance.ExecuteQuery(query, new object[] { idCard }).Rows[0]);
            return customer;

        }

        internal bool InsertCustomer(string customerName, int idCustomerType, string idCard, string address, DateTime dateOfBirth, int phoneNumber, string sex, string nationality)
        {
            string query = "exec USP_InsertCustomer @customerName , @idCustomerType , @idCard , @address , @dateOfBirth , @phoneNumber , @sex , @nationality";
            int count = cdb.Instance.ExecuteNoneQuery(query, new object[] { customerName, idCustomerType, idCard, address, dateOfBirth, phoneNumber, sex, nationality });
            return count > 0;
        }
        internal bool InsertCustomer(Customer customer)
        {
            return InsertCustomer(customer.Name, customer.IdCustomerType, customer.IdCard, customer.Address,
                customer.DateOfBirth, customer.PhoneNumber, customer.Sex, customer.Nationality);
        }


        internal bool UpdateCustomer(Customer customerNow, Customer customerPre)
        {
            string query = "USP_UpdateCustomer @id , @customerName , @idCustomerType ," +
                            " @idCardNow , @address , @dateOfBirth , " +
                            "@phoneNumber , @sex , @nationality , @idCardPre";
            object[] parameter = new object[] {customerNow.Id, customerNow.Name, customerNow.IdCustomerType, customerNow.IdCard,
                                    customerNow.Address, customerNow.DateOfBirth, customerNow.PhoneNumber,
                                    customerNow.Sex, customerNow.Nationality, customerPre.IdCard};
            return cdb.Instance.ExecuteNoneQuery(query, parameter) > 0;
        }
        public bool UpdateCustomer(int id, string name, string idCard, int idCustomerType, int phoneNumber, DateTime dateOfBirth, string address, string sex, string nationality)
        {
            string query = "USP_UpdateCustomer_ @id , @name , @idCard , @idCustomerType , @phoneNumber , @dateOfBirth , @address , @sex , @nationality";
            return cdb.Instance.ExecuteNoneQuery(query, new object[] { id, name, idCard, idCustomerType, phoneNumber, dateOfBirth, address, sex, nationality }) > 0;
        }

        internal DataTable LoadFullCustomer()
        {
            string query = "USP_LoadFullCustomer";
            return cdb.Instance.ExecuteQuery(query);
        }
        internal DataTable Search(string text, int phoneNumber)
        {
            string query = "USP_SearchCustomer @string , @int";
            return cdb.Instance.ExecuteQuery(query, new object[] { text, phoneNumber });
        }
        public int GetIDCustomerFromBookRoom(int idReceiveRoom)
        {
            string query = "USP_GetIDCustomerFromBookRoom @idReceiveRoom";
            return (int)cdb.Instance.ExecuteScalar(query, new object[] { idReceiveRoom });
        }
        #endregion
        public static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return instance; }
            private set => instance = value;
        }

    }
}
