using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.BookingFlight;
using lounga.Model;
using lounga.Services.BookingFlightService;
using Microsoft.AspNetCore.Mvc;

namespace lounga.Controllers
{
    public class BookingFlightController : ControllerBase
    {
        private readonly IBookingFlightService _bookingFlightService;  
        private readonly IPassengerService _passengerService;
        public BookingFlightController(IBookingFlightService bookingFlightService, IPassengerService passengerService)
        {
            _bookingFlightService = bookingFlightService;
            _passengerService = passengerService;
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
    }
}