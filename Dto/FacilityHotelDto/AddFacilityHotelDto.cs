using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Dto.FacilityHotelDto
{
    public class AddFacilityHotelDto
    {
        public bool AirConditioner { get; set; } = true;
        public bool Television { get; set; } = true;
        public bool Wifi { get; set; } = true;
        public bool Restaurant { get; set; } = true;
        public bool Spa { get; set; } = true;
        public bool Pool { get; set; } = true;
        public bool Playground { get; set; } = true;
        public bool Gym { get; set; } = true;
        public bool Parking { get; set; } = true;
        public int HotelId {get; set;}
    }
}