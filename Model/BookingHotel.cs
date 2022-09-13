using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Model
{
    public class BookingHotel
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int TotalRoom { get; set; }
        public int Price { get; set; }
        public Hotel? Hotel {get; set;}
        public List<Room>? Room {get; set;}
        public User? User {get; set;}
        public Guest? Guest {get; set;}
    }
}