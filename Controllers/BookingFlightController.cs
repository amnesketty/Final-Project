using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.BookingFlight;
using lounga.Model;
using lounga.Services.BookingFlightService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lounga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BookingFlightController : ControllerBase
    {
        private readonly IBookingFlightService _bookingFlightService;  
        private readonly IPassengerService _passengerService;
        private readonly IGetBookedFlightService _getBookedFlightService;
        private readonly IHttpContextAccessor _httpContextAccesor;
        public BookingFlightController(IBookingFlightService bookingFlightService, IPassengerService passengerService, IGetBookedFlightService getBookedFlightService, IHttpContextAccessor httpContextAccesor)
        {
            _bookingFlightService = bookingFlightService;
            _passengerService = passengerService;
            _getBookedFlightService = getBookedFlightService;
            _httpContextAccesor = httpContextAccesor;
        }

        [HttpPost("AddBookingFlight")]
        public async Task<ActionResult<ServiceResponse<List<GetBookingFlightDto>>>> AddBookingFlight (AddBookingFlightDto newBookingFlight)
        {
            return Ok(await _bookingFlightService.AddBookingFlight(newBookingFlight));
        }

        [HttpPost("AddPassenger")]
        public async Task<ActionResult<ServiceResponse<List<GetPassengerDto>>>> AddPassenger (AddPassengerDto newPassenger)
        {
            return Ok(await _passengerService.AddPassenger(newPassenger));
        }


        [AllowAnonymous]
        [HttpGet("GetBookingFlight")]
        public async Task<ActionResult<ServiceResponse<List<GetBookingFlightDto>>>> GetBookedFlights (string date)
        {
            return Ok(await _getBookedFlightService.GetBookedFlights(date));
        }
    }
}