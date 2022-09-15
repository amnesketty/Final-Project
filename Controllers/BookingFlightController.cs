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
        public BookingFlightController(IBookingFlightService bookingFlightService)
        {
            _bookingFlightService = bookingFlightService;
        }

        [HttpPost("AddBookingFlight")]
        public async Task<ActionResult<ServiceResponse<List<AddBookingFlightDto>>>> AddBookingFlight (AddBookingFlightDto newBookingFlight)
        {
            return Ok(await _bookingFlightService.AddBookingFlight(newBookingFlight));
        }
    }
}