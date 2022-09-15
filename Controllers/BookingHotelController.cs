using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.BookingHotels;
using lounga.Dto.Hotels;
using lounga.Model;
using lounga.Services.BookingHotelServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lounga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BookingHotelController : ControllerBase
    {
        private readonly IBookingHotelService _BookingHotelService;
        private readonly IGuestService _GuestService;
        private readonly IGetBookedHotelService _GetBookedHotelService;
<<<<<<< HEAD
        private readonly IFindHotelService _FindHotelService;
        public BookingHotelController(IBookingHotelService BookingHotelService, IGuestService GuestService, IGetBookedHotelService GetBookedHotelService, IFindHotelService FindHotelService)
=======
        private readonly IHttpContextAccessor _httpContextAccesor;
        public BookingHotelController(IBookingHotelService BookingHotelService, IGuestService GuestService, IGetBookedHotelService GetBookedHotelService, IHttpContextAccessor httpContextAccessor)
>>>>>>> 54f3a5c82babd319c2c85877f27cd4d6fe6e1dcc
        {
            _FindHotelService = FindHotelService;
            _GetBookedHotelService = GetBookedHotelService;
            _GuestService = GuestService;
            _BookingHotelService = BookingHotelService;
            _httpContextAccesor = httpContextAccessor;
            
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

        [AllowAnonymous]
        [HttpGet("GetBookingHotel")]
        public async Task<ActionResult<ServiceResponse<List<GetBookingHotelDto>>>> GetBookedHotels (string date)
        {
            return Ok(await _GetBookedHotelService.GetBookedHotels(date));
        }

        [AllowAnonymous]
        [HttpGet("FindHotel")]
        public async Task<ActionResult<ServiceResponse<List<GetHotelDto>>>> Get(string date, string city)
        {
            return Ok(await _FindHotelService.FindHotel(date,city));
        }
    }
}