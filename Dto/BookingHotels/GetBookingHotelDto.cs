using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Dto.BookingHotels
{
    public class GetBookingHotelDto
    {
        public DateTime BookingDate { get; set; }
        public int TotalRoom { get; set; }
        public int Price { get; set; }
        public int HotelId {get; set;}
        public int RoomId {get; set;}
        public int UserId {get; set;}
        public int GuestId {get; set;}
<<<<<<< HEAD
        public string? BookingHoteltNo { get; set; }
=======
        public string? BookingHotelNo { get; set; }
>>>>>>> f6ee03088550494333c054a938d72638715a6654
    }
}