using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Model
{
    public class BookingFlight
    {
        public int Id {get; set;}
        public DateTime BookingDate {get; set;}
        public int Status { get; set; } = 1;
        public int AmountPassenger { get; set; } = 0;
        public int TotalPrice {get; set;} = 0;
        public User? User {get; set;}
        public List<Passenger>? Passengers { get; set; }
        public Flight? Flight { get; set; }
        public FacilitiesFlight? FacilitiesFlight { get; set; }
        public string BookingFlightNo { get; set; } = string.Empty;
    }
}