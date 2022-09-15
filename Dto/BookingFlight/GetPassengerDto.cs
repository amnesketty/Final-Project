using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Dto.BookingFlight
{
    public class GetPassengerDto
    {
        public int Id {get; set;}
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string IdCard { get; set; } = string.Empty;
        public int BookingFlightId { get; set; }
    }
}