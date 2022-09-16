using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Model
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City {get; set;} = string.Empty;
        public int Rating { get; set; }
        public List<Photo>? Photos {get; set; }
        public FacilitiesHotel? FacilitiesHotel {get; set;}
        public List<Room>? Rooms {get; set;}
        public List<BookingHotel>? BookingHotels {get; set;}
        
    }
}