using System.Data;

namespace HotelV4.bclass
{
    public class Service
    {
        int id;
        string name;
        int idServiceType;
        int price;
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
            if (servicePre.idServiceType != this.idServiceType) return false;
            if (servicePre.name != this.name) return false;
            if (servicePre.price != this.price) return false;
            return true;
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int IdServiceType { get => idServiceType; set => idServiceType = value; }
        public int Price { get => price; set => price = value; }
    }
}
