using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.Hotels;
using lounga.Services.BookingHotelServices;
using lounga.Services.FacilitiesHotelServices;
using lounga.Services.HotelServices;
using lounga.Services.RoomServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using lounga.Dto.BookingHotels;

namespace lounga.Controllers
{
    // [Route("[controller]")]
    public class ViewHotelsController : Controller
    {
        private readonly ILogger<ViewHotelsController> _logger;
        private readonly IHotelService _hotelService;
        private readonly IFindHotelService _findHotelService;
        private readonly IBookingHotelService _bookingHotelService;
        private readonly IGuestService _guestService;

        public ViewHotelsController(ILogger<ViewHotelsController> logger, IHotelService hotelService, IFindHotelService findHotelService, IBookingHotelService bookingHotelService, IGuestService guestService)
        {
            _logger = logger;
            _hotelService = hotelService;
            _findHotelService = findHotelService;
            _bookingHotelService = bookingHotelService;
            _guestService = guestService;
        }

        public async Task<IActionResult> GetHotel(int id)
        {
            var response = await _hotelService.GetHotelById(id);
            GetHotelDto hotelDto = response.Data;
            return View(hotelDto);
        }
        
        [Authorize]
        public async Task<IActionResult> FindHotel(SearchHotelDto searchHotelDto)
        {
            string token = HttpContext.Session.GetString("Token");
            Console.WriteLine(token);
            var response = await _findHotelService.FindHotel(searchHotelDto);
            List<FindHotelDto> findHotelDto = response.Data;
            return View(findHotelDto);
        }

        public async Task<IActionResult> DetailHotel(int id)
        {
            var response = await _hotelService.GetHotelById(id);
            GetHotelDto hotelDto = response.Data;
            return View(hotelDto);

        }

        public async Task<IActionResult> BookingHotel(AddGuestDto addGuest)
        {
            var response = await _guestService.AddGuest(addGuest);
            GetGuestDto guestDto = response.Data;
            return View(addGuest);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}