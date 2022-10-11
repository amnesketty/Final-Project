using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.Flight;
using lounga.Model;
using lounga.Services.FacilitiesFlightService;
using lounga.Services.FlightService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lounga.Controllers
{
    //[Route("[controller]")]
    public class ViewFlightsController : Controller
    {
        private readonly ILogger<ViewFlightsController> _logger;
        private readonly IFacilitiesFlightService _facilitiesFlightService;
        private readonly IFlightService _flightService;
   
       
        public ViewFlightsController(ILogger<ViewFlightsController> logger, IFlightService flightService, IFacilitiesFlightService facilitiesFlightService)
        {
            _logger = logger;
            _facilitiesFlightService = facilitiesFlightService;
            _flightService = flightService;
          ;
        }

        public async Task<IActionResult> GetAllFlight() 
        {
            var response = await _flightService.GetAllFlight();
            List<GetFlightDto> getFlightDtos = response.Data;
            return View(getFlightDtos);
        }

        public async Task<IActionResult>FindFlight (FindFlightDto request)
        {
            var response = await _flightService.FindFlight(request);
            List<GetFlightDto> findFlightDtos = response.Data;
            return View(findFlightDtos);
        }


        public async Task<IActionResult> DetailFlights(int id)
        {

            var response = await _flightService.GetFlightDtoById(id);
            GetFlightDto getFlightbyId = response.Data;
            return View(getFlightbyId);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}