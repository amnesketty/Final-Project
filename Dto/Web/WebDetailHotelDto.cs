using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.BookingHotels;
using lounga.Dto.Hotels;

namespace lounga.Dto.Web
{
    public class WebDetailHotelDto
    {
        public DateTime bookingDate {get; set;}
        public string name {get; set; } = string.Empty;
        public int totalRoom {get; set;}
        public int hotelId {get; set; }
        public GetHotelDto? getHotelDto {get; set;}
    }
}