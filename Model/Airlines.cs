using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lounga.Models
{
    public class Airlines
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public string? SeatClass {get; set;}
        public DateTime DepartureDate {get; set;}
        public DateTime DepartureTime {get; set;}
        public DateTime ArrivalTime {get; set;}
        public string? DepartureAirport {get; set;}
        public string? ArrivalAirport {get; set;}
        public string? DestinationFrom {get; set;}
        public string? DestinationTo {get; set;}
        public int AmountPassenger {get; set;}
        public string? TravelRoute {get; set;}
        public int FlightDuration {get; set;}
        public string? FacilitiesFlight {get; set;}
        public int Price {get; set;}
        public bool TransitFlight {get; set;} = true;
    }
}