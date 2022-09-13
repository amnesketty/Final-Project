using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Model
{
    public class FacilitiesAircraft
    {
        public int Id {get; set;}
        public int Baggage {get; set;}
        public int CabinBaggage {get; set;}
        public bool Wifi {get; set;} = true;
        public bool PowerPort {get; set;} = true;
        public bool Entertainment {get; set;} = true;
        public Aircraft? Aircraft {get;set;}
        public int AircraftId {get; set;}
    }
}