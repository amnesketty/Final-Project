using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Dto.BookingFlight
{
    public class GetBookingFlightTransactionDto
    {
        public int Id {get; set;}
        public DateTime BookingDate {get; set;}
        public int Status { get; set; }
        public int AmountPassenger { get; set; }
        public int TotalPrice {get; set;}
        public string BookingFlightNo { get; set; } = string.Empty;  
    }
}