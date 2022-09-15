using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Dto.BookingFlight
{
    public class AddBookingFlightDto
    {
        public DateTime BookingDate {get; set;}
        public int Status { get; set; }
        public int AmountPassenger { get; set; }
        public int TotalPrice {get; set;}
        public int FlightId {get; set;}
        public int UserId { get; set; }
        public int FacilitiesFlightId { get; set; }
    }
}