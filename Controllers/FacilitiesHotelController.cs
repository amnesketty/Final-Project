using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.FacilityHotelDto;
using lounga.Model;
using lounga.Services.FacilitiesHotelServices;
using Microsoft.AspNetCore.Mvc;

namespace lounga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacilitiesHotelController : ControllerBase
    {
        private readonly IFacilitiesHotelService _FacilitiesHotelService;
        public FacilitiesHotelController(IFacilitiesHotelService FacilitiesHotelService)
        {
            _FacilitiesHotelService = FacilitiesHotelService;
            
        }

        [HttpPost("addfacilitieshotel")]
        public async Task<ActionResult<ServiceResponse<GetFacilityHotelDto>>> AddFacilitiesHotel(AddFacilityHotelDto addFacilityHotel)
        {
           return Ok(await _FacilitiesHotelService.AddFacilityHotel(addFacilityHotel));
        }
    }
}