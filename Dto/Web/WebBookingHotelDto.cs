using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.BookingHotels;
using lounga.Dto.Hotels;

namespace lounga.Dto.Web
{
    public class WebBookingHotelDto
    {
        public SearchHotelDto? searchHotelDto {get; set;}
        public FindHotelDto? findHotelDto {get; set;}
    }
}