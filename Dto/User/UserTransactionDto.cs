using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.BookingFlight;
using lounga.Dto.BookingHotels;

namespace lounga.Dto.User
{
    public class UserTransactionDto
    {
        public string Username { get; set; } = string.Empty;
        public List<GetBookingHotelTransactionDto>? BookingHotels {get; set;}
        public List<GetBookingFlightTransactionDto>? BookingFlights {get; set;}
    }
}