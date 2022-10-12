using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.Flight;

namespace lounga.Dto.Web
{
    public class WebDetailFlightDto
    {
        public DateTime bookingDate {get; set;}
        public string airline {get; set; } = string.Empty;
        public int amountPassenger {get; set;}
        public int flightId {get; set; }
        public GetFlightDto? getFlightDto {get; set;}
    }
}