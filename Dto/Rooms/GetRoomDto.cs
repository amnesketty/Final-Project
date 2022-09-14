using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Model;

namespace lounga.Dto.Rooms
{
    public class GetRoomDto
    {
        public string Type { get; set; } = string.Empty;
        public int Price { get; set; }
        // public int HotelId {get; set;}
        // public List<BookingHotel>? BookingHotels {get; set;}
    }
}