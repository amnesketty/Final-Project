using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Dto.Flight
{
    public class FindFlightDto
    {
        
        public string SeatClass {get; set;} = string.Empty;
        public int AmountPassenger { get; set; }
        public string DestinationFrom {get; set;} = string.Empty;
        public string DestinationTo {get; set;} = string.Empty;
        public DateTime DepartureDate {get; set;}
    }
}