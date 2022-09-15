using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.BookingHotels;
using lounga.Model;
using lounga.Services.BookingHotelServices;
using Microsoft.AspNetCore.Mvc;

namespace lounga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingHotelController : ControllerBase
    {
        private readonly IBookingHotelService _BookingHotelService;
        private readonly IGuestService _GuestService;
        private readonly IGetBookedHotelService _GetBookedHotelService;
        public BookingHotelController(IBookingHotelService BookingHotelService, IGuestService GuestService, IGetBookedHotelService GetBookedHotelService)
        {
            _GetBookedHotelService = GetBookedHotelService;
            _GuestService = GuestService;
            _BookingHotelService = BookingHotelService;
            
        }

        [HttpPost("AddBookingHotel")]
        public async Task<ActionResult<ServiceResponse<List<AddBookingHotelDto>>>> AddBookingHotel (AddBookingHotelDto addBookingHotel)
        {
            return Ok(await _BookingHotelService.AddBookingHotel(addBookingHotel));
        }

        [HttpPost("AddGuest")]
        public async Task<ActionResult<ServiceResponse<List<AddGuestDto>>>> AddGuest (AddGuestDto addGuest)
        {
            return Ok(await _GuestService.AddGuest(addGuest));
        }

        
        [HttpGet("GetBookingHotel")]
        public async Task<ActionResult<ServiceResponse<List<GetBookingHotelDto>>>> GetBookedHotels (string date)
        {
            return Ok(await _GetBookedHotelService.GetBookedHotels(date));
        }
    }
}