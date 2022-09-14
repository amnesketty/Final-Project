using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.FacilityHotelDto;
using lounga.Dto.File;
using lounga.Dto.Rooms;
using lounga.Model;

namespace lounga.Dto.Hotels
{
    public class GetHotelDto
    {
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City {get; set;} = string.Empty;
        public int Rating { get; set; }
        public GetFacilityHotelDto? FacilitiesHotel {get; set;}
        public List<GetPhotoDto>? Photos {get; set; }
        public List<GetRoomDto>? Rooms {get; set;}
    }
}