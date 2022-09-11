using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lounga.Models
{
    public class Airline
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public string SeatClass {get; set;} = string.Empty;
        public DateTime DepartureDate {get; set;}
        public DateTime DepartureTime {get; set;}
        public DateTime ArrivalTime {get; set;}
        public string DepartureAirport {get; set;} = string.Empty;
        public string ArrivalAirport {get; set;} = string.Empty;
        public string DestinationFrom {get; set;} = string.Empty;
        public string DestinationTo {get; set;} = string.Empty;
        public int AmountPassenger {get; set;}
        public string TravelRoute {get; set;} = string.Empty;
        public int FlightDuration {get; set;}
        public string FacilitiesFlight {get; set;} = string.Empty;
        public int Price {get; set;}
        public bool TransitFlight {get; set;} = true;
    }
}