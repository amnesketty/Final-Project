using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Model
{
    public class Flight
    {
        public int Id {get; set;}
        public string Airline {get; set;} = string.Empty;
        public string SeatClass {get; set;} = string.Empty;
        public string Aircraft { get; set; } = string.Empty;
        public string AircraftsType {get; set;} = string.Empty;
        public string SeatLayout {get; set;} = string.Empty;
        public string SeatPitch {get; set;} = string.Empty;
        public int SeatCapacity {get;set;}
        public int AmountPassenger { get; set; } = 0;
        public int Price { get; set; }
        public string DestinationFrom {get; set;} = string.Empty;
        public string DestinationTo {get; set;} = string.Empty;
        public DateTime DepartureTime {get; set;}
        public DateTime ArrivalTime {get; set;}
        public FacilitiesFlight? FacilitiesFlight {get; set;}
        public List<BookingFlight>? BookingFlights {get; set; }
    }
}