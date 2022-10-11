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
        public FindFlightDto findFlightDto{get; set;}
        public SearchHotelDto searchHotelDto{get; set;}
    }
}