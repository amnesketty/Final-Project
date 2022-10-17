using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.BookingFlight;
using lounga.Dto.Data;
using lounga.Dto.Flight;
using lounga.Dto.Web;
using lounga.Model;
using lounga.Services.BookingFlightService;
using lounga.Services.FacilitiesFlightService;
using lounga.Services.FlightService;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IFlightService _findFlightService;
        private readonly IBookingFlightService _bookingFlightService;
        private readonly IPassengerService _passengerService;
   
       
        public ViewFlightsController(ILogger<ViewFlightsController> logger, IFlightService flightService, IFacilitiesFlightService facilitiesFlightService, IFlightService findFlightService, IBookingFlightService bookingFlightService,IPassengerService passengerService)
        {
            _logger = logger;
            _facilitiesFlightService = facilitiesFlightService;
            _flightService = flightService;
            _findFlightService = findFlightService;
            _bookingFlightService = bookingFlightService;
            _passengerService = passengerService;
          ;
        }

        public async Task<IActionResult> GetAllFlight() 
        {
            var response = await _flightService.GetAllFlight();
            List<GetFlightDto> getFlightDtos = response.Data;
            return View(getFlightDtos);
        }
        [Authorize]
        public async Task<IActionResult> FindFlight(FindFlightDto findFlightDto)
        {
            var response = await _findFlightService.FindFlight(findFlightDto);
            List<GetFlightDto> getFlightDtos = response.Data;
            WebFindFlightDto webFindFlightDto = new WebFindFlightDto
            {
                findFlightDto = findFlightDto,
                getFlightDtos = getFlightDtos,
            };
            return View(webFindFlightDto);
        }
        [Authorize]
        public async Task<IActionResult> DetailFlights(DateTime departureDate, int amountPassenger, int flightId)
        {
            var response = await _flightService.GetFlightDtoById(flightId);
            GetFlightDto getFlightbyId = response.Data;
            return View(getFlightbyId);
        }
        [Authorize]
        public async Task<IActionResult> BookingFlight(DateTime departureDate, int amountPassenger, int flightId)
        {
            var response = await _flightService.GetFlightDtoById(flightId);
            WebBookingFlightDto webBookingFlightDto = new WebBookingFlightDto
            {
                bookingDate = departureDate,
                destinationFrom = response.Data.DestinationFrom,
                destinationTo = response.Data.DestinationTo,
                amountPassenger = amountPassenger,
                totalPrice = amountPassenger*response.Data.Price,
                flightId = flightId,
                getFlightDto = response.Data,
            };
            return View(webBookingFlightDto);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookingFlight(WebBookingFlightDto webBookingFlightDto)
        {
            AddBookingFlightDto addBookingFlightDto = new AddBookingFlightDto 
            {
                BookingDate= webBookingFlightDto.bookingDate.ToUniversalTime(),
                DestinationFrom = webBookingFlightDto.destinationFrom,
                DestinationTo = webBookingFlightDto.destinationTo,
                AmountPassenger = webBookingFlightDto.amountPassenger,
                TotalPrice = webBookingFlightDto.totalPrice,
                FlightId = webBookingFlightDto.flightId,
            };
            var responseAddBookingFlight = await _bookingFlightService.AddBookingFlight(addBookingFlightDto);
            int bookingFlightId = responseAddBookingFlight.Data.Id;
            List<AddPassengerDto> addPassengerDtos = new List<AddPassengerDto>();
            foreach( AddPassengerDto addPassengerDto in webBookingFlightDto.addPassengerDtos)
            {
                addPassengerDto.BookingFlightId = bookingFlightId;
                addPassengerDtos.Add(addPassengerDto);
            }
            RequestData<AddPassengerDto> data = new RequestData<AddPassengerDto>
            {
                data = addPassengerDtos
            };
            var responseAddPassenger = await _passengerService.AddListPassenger(data);

            return RedirectToAction("Main", "ViewHome");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}