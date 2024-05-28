using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HotelV4.aclass
{
    class check_ina
    {
        private int id;
        private int idBookRoom;
        private int idRoom;
        public check_ina(DataRow row)
        {
            Id = (int)row["id"];
            IdBookRoom = (int)row["idBookRoom"];
            IdRoom = (int)row["idroom"];
        }
        public int Id { get => id; set => id = value; }
        public int IdBookRoom { get => idBookRoom; set => idBookRoom = value; }
        public int IdRoom { get => idRoom; set => idRoom = value; }
    }
}
