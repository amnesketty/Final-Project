using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.Flight;
using lounga.Model;

namespace lounga.Dto.BookingFlight
{
    public class GetBookingFlightDto
    {
        public int Id {get; set;}
        public DateTime BookingDate {get; set;}
        public string DestinationFrom {get; set;} = string.Empty;
        public string DestinationTo {get; set;} = string.Empty;
        public int Status { get; set; }
        public int AmountPassenger { get; set; }
        public int TotalPrice {get; set;}
        public List<GetPassengerDto>? Passengers { get; set; }
        public GetFlightDto? Flight { get; set; }
        public string BookingFlightNo { get; set; } = string.Empty;        
    }
}