using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.Flight;
using lounga.Model;
using lounga.Services.FlightService;
using Microsoft.AspNetCore.Mvc;

namespace lounga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpPost("AddFlight")]
        public async Task<ActionResult<ServiceResponse<List<AddFlightDto>>>> AddFlight (AddFlightDto newFlight)
        {
            return Ok(await _flightService.AddFlight(newFlight));
        }

    }
}