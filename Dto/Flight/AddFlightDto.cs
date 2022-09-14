using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Model;

namespace lounga.Dto.Flight
{
    public class AddFlightDto
    {
        public string Airline {get; set;} = string.Empty;
        public string SeatClass {get; set;} = string.Empty;
        public string Aircraft { get; set; } = string.Empty;
        public string AircraftsType {get; set;} = string.Empty;
        public string SeatLayout {get; set;} = string.Empty;
        public string SeatPitch {get; set;} = string.Empty;
        public int SeatCapacity {get;set;}
        public int AmountPassenger { get; set; }
        public int Price { get; set; }
        public string DestinationFrom {get; set;} = string.Empty;
        public string DestinationTo {get; set;} = string.Empty;
        public DateTime DepartureDate {get; set;}
        public DateTime DepartureTime {get; set;}
        public DateTime ArrivalTime {get; set;}
    }
}