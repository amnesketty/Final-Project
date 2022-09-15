using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName {get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string AvatarImage {get; set; } = "https://res.cloudinary.com/du5w56akk/image/upload/v1662975057/sample.jpg";
        public byte[]? PasswordHash {get; set;}
        public byte[]? PasswordSalt {get; set;}
        public List<BookingHotel>? BookingHotels {get; set;}
        public List<BookingFlight>? BookingFlights {get; set;}
    }
}