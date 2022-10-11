using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.Flight;
using lounga.Dto.Hotels;

namespace lounga.Dto.Web
{
    public class SearchDto
    {
        FindFlightDto? findFlightDto{get; set;}
        SearchHotelDto? searchHotelDto{get; set;}
    }
}