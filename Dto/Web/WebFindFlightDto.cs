using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.Flight;

namespace lounga.Dto.Web
{
    public class WebFindFlightDto
    {
        public FindFlightDto? findFlightDto {get; set;}
        public List<GetFlightDto>? getFlightDtos {get; set;}
    }
}