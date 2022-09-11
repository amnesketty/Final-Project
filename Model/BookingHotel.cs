using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Model
{
    public class BookingHotel
    {
        public int Id { get; set; }
        public DateOnly BookingDate { get; set; }
        public int TotalRoom { get; set; }
        public int TotalPrice { get; set; }
    }
}