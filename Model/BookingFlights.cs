using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lounga.Models
{
    public class BookingFlights
    {
        public int Id {get; set;}
        public DateTime BookingDate {get; set;}
        public int TotalPrice {get; set;}
        public string? GateDeparture {get; set;}
        public string? GateArrival {get; set;}
    }
}