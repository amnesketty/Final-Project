using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Model;

namespace lounga.Dto.Flight
{
    public class UpdateFlightDto
    {
        public string Name {get; set;} = string.Empty;
        public string SeatClass {get; set;} = string.Empty;
        public DateTime DepartureTime {get; set;}
        public DateTime ArrivalTime {get; set;}
        public string DestinationFrom {get; set;} = string.Empty;
        public string DestinationTo {get; set;} = string.Empty;
    }
}