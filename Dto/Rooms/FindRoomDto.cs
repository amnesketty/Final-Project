using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.BookingHotels;

namespace lounga.Dto.Rooms
{
    public class FindRoomDto
    {
        public int id {get; set;}
        public string Type { get; set; } = string.Empty;
        public int Price { get; set; }
        public List<GetBookingHotelDto>? BookingHotels {get; set;}
    }
}