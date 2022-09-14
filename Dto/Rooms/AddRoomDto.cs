using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Dto.Rooms
{
    public class AddRoomDto
    {
        public string Type { get; set; } = string.Empty;
        public int Price { get; set; }
        public int HotelId {get; set;}
    }
}