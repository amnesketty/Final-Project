using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Model;

namespace lounga.Dto.FacilitiesFlight
{
    public class AddFacilitiesFlightDto
    {
        public int Id {get; set;}
        public int Baggage {get; set;}
        public int CabinBaggage {get; set;}
        public bool Wifi {get; set;} = true;
        public bool PowerPort {get; set;} = true;
        public bool Entertainment {get; set;} = true;
        public int FlightId {get; set;}
    }
}