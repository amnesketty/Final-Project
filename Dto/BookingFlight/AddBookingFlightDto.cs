using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Dto.BookingFlight
{
    public class AddBookingFlightDto
    {
        public DateTime BookingDate {get; set;}
        public string DestinationFrom {get; set;} = string.Empty;
        public string DestinationTo {get; set;} = string.Empty;
        public int AmountPassenger { get; set; }
        public int TotalPrice {get; set;}
        public int FlightId {get; set;}
    }
}