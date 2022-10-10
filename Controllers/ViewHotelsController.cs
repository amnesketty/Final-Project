using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.Hotels;
using lounga.Services.FacilitiesHotelServices;
using lounga.Services.HotelServices;
using lounga.Services.RoomServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lounga.Controllers
{
    // [Route("[controller]")]
    public class ViewHotelsController : Controller
    {
        private readonly ILogger<ViewHotelsController> _logger;
        private readonly IHotelService _hotelService;
        private readonly IRoomService _roomService;
        private readonly IFacilitiesHotelService _FacilitiesHotelService;

        public ViewHotelsController(ILogger<ViewHotelsController> logger, IHotelService hotelService, IRoomService roomService, IFacilitiesHotelService facilitiesHotelService)
        {
            _logger = logger;
            _hotelService = hotelService;
            _roomService = roomService;
            _FacilitiesHotelService = facilitiesHotelService;
        }

        public async Task<IActionResult> GetHotel(int id)
        {
            var response = await _hotelService.GetHotelById(id);
            GetHotelDto hotelDto = response.Data;
            return View(hotelDto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}