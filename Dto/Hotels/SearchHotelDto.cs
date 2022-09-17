using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Dto.Hotels
{
    public class SearchHotelDto
    {
        public string City {get; set;} = string.Empty;
        public DateTime BookingDate {get; set; }
        public int TotalRoom {get; set; } = 1;
        public int Duration {get; set; } = 1;
    }
}