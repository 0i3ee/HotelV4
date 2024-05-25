using System.Data;

namespace HotelV4.bclass
{
    class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdServiceType { get; set; }
        public int Price { get; set; }

        public Service() { }

        public Service(DataRow data)
        {
            Id = (int)data["id"];
            Name = data["Name"].ToString();
            IdServiceType = (int)data["idServiceType"];
            Price = (int)data["Price"];
        }

        public bool Equals(Service servicePre)
        {
            if (servicePre == null) return false;
            if (servicePre.IdServiceType != this.IdServiceType) return false;
            if (servicePre.Name != this.Name) return false;
            if (servicePre.Price != this.Price) return false;
            return true;
        }
    }
}
