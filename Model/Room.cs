using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Model
{
    public class Room
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public int Price { get; set; }
        public Hotel? Hotel {get; set;}
        public List<BookingHotel> BookingHotels {get; set;}
    }
}