using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Model
{
    public class Airline
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public string SeatClass {get; set;} = string.Empty;
        public DateTime DepartureDate {get; set;}
        public DateTime DepartureTime {get; set;}
        public DateTime ArrivalTime {get; set;}
        public string DestinationFrom {get; set;} = string.Empty;
        public string DestinationTo {get; set;} = string.Empty;
        public List<Aircraft>? Aircrafts {get; set; }
        public List<BookingFlight>? BookingFlights {get; set; }
    }
}