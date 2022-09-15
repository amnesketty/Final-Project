using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Dto.FacilitiesFlight
{
    public class GetFacilitiesFlightDto
    {
        public int Baggage {get; set;}
        public int CabinBaggage {get; set;}
        public bool Wifi {get; set;} = true;
        public bool PowerPort {get; set;} = true;
        public bool Entertainment {get; set;} = true;
    }
}