using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Dto.Web
{
    public class WebBookingHotelDto
    {
        public DateTime bookingDate {get; set;}
        public string name {get; set; } = string.Empty;
        public int totalRoom {get; set;}
        public int price {get; set;}
        public int hotelId {get; set;}
        public int roomId {get; set;}
        public string guestName {get; set;} = string.Empty;
        public string email {get; set; } = string.Empty;
        public string phone {get; set; } = string.Empty;
    }
}