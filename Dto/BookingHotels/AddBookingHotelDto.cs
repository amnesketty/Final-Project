using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Dto.BookingHotels
{
    public class AddBookingHotelDto
    {
        public DateTime BookingDate { get; set; }
        public int TotalRoom { get; set; }
        public int Price { get; set; } 
        public int HotelId {get; set;}
        public int RoomId {get; set;}
    }
}