using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.Hotels;

namespace lounga.Dto.Web
{
    public class WebFindHotelDto
    {
        public SearchHotelDto? searchHotelDto {get; set;}
        public List<FindHotelDto>? findHotelDtos {get; set;}
    }
}