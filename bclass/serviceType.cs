using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HotelV4.bclass
{
    class ServiceType
    {
        private int id;
        private string name;
        public ServiceType() { }
        public ServiceType(DataRow dataRow)
        {
            Id = (int)dataRow["id"];
            Name = dataRow["name"].ToString();
        }
        public override bool Equals(object obj)
        {
            // If the object is null, consider it unequal
            if (obj == null || !(obj is ServiceType))
            {
                return false;
            }

            // Compare the names if the object is a ServiceType instance
            return this.name == ((ServiceType)obj).name;
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
