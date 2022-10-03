using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Dto.BookingHotels
{
    public class GetBookingHotelTransactionDto
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int TotalRoom { get; set; } = 0;
        public int Price { get; set; } = 0;
        public string BookingHotelNo { get; set; } = string.Empty;
    }
}