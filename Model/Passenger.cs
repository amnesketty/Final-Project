using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Model
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string IdCard { get; set; } = string.Empty;
        public BookingFlight? BookingFlight { get; set; }
        public int BookingFlightId {get; set;}
    }
}