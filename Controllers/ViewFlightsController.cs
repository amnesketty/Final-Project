using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.BookingFlight;
using lounga.Dto.Flight;
using lounga.Dto.Web;
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

        public IActionResult BookingFlight()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookingFlight([Bind("Title, Name, IdCard")] AddPassengerDto addPassengerDto, int id)
        {
            
            // WebBookingFlightDto webBookingFlightDto = new WebBookingFlightDto
            // {
            //     getFlightDto = getFlightDto,
            //     // addPassengerDto = addPassengerDto
            // };
            WebBookingFlightDto webBookingFlightDto = new WebBookingFlightDto{
                    addPassengerDto = addPassengerDto,
            };
            var response = await _flightService.GetFlightDtoById(id);
            GetFlightDto getFlightbyId = response.Data;
            return View(getFlightbyId);
            if (ModelState.IsValid)
            {
                return RedirectToAction("BookFlight", webBookingFlightDto);
                // var response = await _authService.Login(userLoginDto);
                // UserProfileDto user = response.Data;
                // HttpContext.Session.SetString("Token", user.Token);
                // return RedirectToAction("Main", "ViewHome");
            }
            return RedirectToAction(nameof(BookingFlight));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}