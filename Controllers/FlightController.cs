using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.FacilitiesFlight;
using lounga.Dto.Flight;
using lounga.Model;
using lounga.Services.FacilitiesFlightService;
using lounga.Services.FlightService;
using Microsoft.AspNetCore.Mvc;

namespace lounga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly IFacilitiesFlightService _facilitiesFlightService;
        public FlightController(IFlightService flightService, IFacilitiesFlightService facilitiesFlightService)
        {
            _facilitiesFlightService = facilitiesFlightService;
            _flightService = flightService;
        }

        [HttpPost("AddFlight")]
        public async Task<ActionResult<ServiceResponse<List<AddFlightDto>>>> AddFlight (AddFlightDto newFlight)
        {
            return Ok(await _flightService.AddFlight(newFlight));
        }

        [HttpGet("GetFlight{id}")]
        public async Task<ActionResult<ServiceResponse<GetFlightDto>>> GetFlightDtoById (int id)
        {
            return Ok(await _flightService.GetFlightDtoById(id));
        }

        [HttpGet("GetAllFlight")]
        public async Task<ActionResult<ServiceResponse<List<GetFlightDto>>>> GetAllFlight()
        {
            return Ok(await _flightService.GetAllFlight());
        }

        [HttpPost("AddFacilitiesFlight")]
        public async Task<ActionResult<ServiceResponse<List<AddFacilitiesFlightDto>>>> AddFacilitiesFlight (AddFacilitiesFlightDto newFacilitiesFlight)
        {
            return Ok(await _facilitiesFlightService.AddFacilitiesFlight(newFacilitiesFlight));
        }
    }
}