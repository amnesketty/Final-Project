using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Model
{
    public class Aircraft
    {
        public int Id {get; set;}
        public string Name { get; set; } = string.Empty;
        public string AircraftsType {get; set;} = string.Empty;
        public string SeatLayout {get; set;} = string.Empty;
        public string SeatPitch {get; set;} = string.Empty;
        public int SeatCapacity {get;set;}
        public int AmountPassenger { get; set; }
        public int Price { get; set; }
        public Airline? Airline {get; set;}
        public FacilitiesAircraft? FacilitiesAircraft {get; set;}
        public List<BookingFlight>? BookingFlights {get; set; }
    }
}