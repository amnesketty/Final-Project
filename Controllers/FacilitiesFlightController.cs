using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Model;
using lounga.Dto.FacilitiesFlight;
using lounga.Services.FacilitiesService;
using Microsoft.AspNetCore.Mvc;

namespace lounga.Controllers
{
    public class FacilitiesFlightController : ControllerBase
    {
        private readonly IFacilitiesService _facilitiesFlightService;
        public FacilitiesFlightController(IFacilitiesService facilitiesFlightService)
        {
            _facilitiesFlightService = facilitiesFlightService;
        }

        [HttpPost("AddFacilitiesFlight")]
        public async Task<ActionResult<ServiceResponse<List<AddFacilitiesFlightDto>>>> AddFacilitiesFlight (AddFacilitiesFlightDto newFacilitiesFlight)
        {
            return Ok(await _facilitiesFlightService.AddFacilitiesFlight(newFacilitiesFlight));
        }
    }
}