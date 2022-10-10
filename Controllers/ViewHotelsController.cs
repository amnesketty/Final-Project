using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.BookingHotels;
using lounga.Dto.Hotels;
using lounga.Services.BookingHotelServices;
using lounga.Services.FacilitiesHotelServices;
using lounga.Services.HotelServices;
using lounga.Services.RoomServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lounga.Controllers
{
    // [Route("[controller]")]
    public class ViewHotelsController : Controller
    {
        private readonly ILogger<ViewHotelsController> _logger;
        private readonly IHotelService _hotelService;
        private readonly IFindHotelService _findHotelService;
        private readonly IGetBookedHotelService _GetBookedHotelService;

        public ViewHotelsController(ILogger<ViewHotelsController> logger, IHotelService hotelService, IFindHotelService findHotelService, IGetBookedHotelService GetBookedHotelService)
        {
            _logger = logger;
            _hotelService = hotelService;
            _findHotelService = findHotelService;
            _GetBookedHotelService = GetBookedHotelService;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}