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
        public DateTime bookingDate {get; set;}
        public string destinationFrom {get; set;} = string.Empty;
        public string destinationTo {get; set;} = string.Empty;
        public int amountPassenger {get; set;}
        public int totalPrice {get; set;}
        public int flightId {get; set;}
        // public string title {get; set;} = string.Empty;
        // public string name {get; set; } = string.Empty;
        // public string idCard {get; set; } = string.Empty;
        // public int bookingFlightId {get;set;}
        public GetFlightDto? getFlightDto{get;set;}
        public List<AddPassengerDto>? addPassengerDtos{get;set;}
    }
}