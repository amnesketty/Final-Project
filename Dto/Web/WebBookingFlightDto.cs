using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.BookingFlight;
using lounga.Dto.Flight;

namespace lounga.Dto.Web
{
    public class WebBookingFlightDto
    {
        public GetFlightDto getFlightDto {get; set;}
        public AddPassengerDto addPassengerDto {get; set;}
    }
}