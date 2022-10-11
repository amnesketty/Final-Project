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
using lounga.Dto.Web;

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
        
        
        public async Task<IActionResult> FindHotel(SearchHotelDto searchHotelDto)
        {
            var response = await _findHotelService.FindHotel(searchHotelDto);
            List<FindHotelDto> findHotelDto = response.Data;
            WebFindHotelDto webFindHotelDto = new WebFindHotelDto
            {
                searchHotelDto = searchHotelDto,
                findHotelDtos = findHotelDto
            };
            //return View(findHotelDto);
            return View(webFindHotelDto);
        }

        // public async Task<IActionResult> DetailHotel(int id)
        // {
        //     var response = await _hotelService.GetHotelById(id);
        //     GetHotelDto hotelDto = response.Data;
        //     return View(hotelDto);
        // }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DetailHotel([Bind("SearchHotelDto, FindHotelDto")]WebBookingHotelDto webBookingHotelDto)
        {
            Console.WriteLine(webBookingHotelDto.searchHotelDto.City);
            return View(webBookingHotelDto);
        }

        public String DetailHotelFind(FindHotelDto findHotelDto)
        {
            return findHotelDto.Name;
        }

        public String DetailHotelSearch(SearchHotelDto searchHotelDto)
        {
            return searchHotelDto.City;
        }
        // public IActionResult DetailHotel(WebBookingHotelDto webBookingHotelDto)
        // {
        //     if (webBookingHotelDto.findHotelDto.Name != null)
        //     {
        //         Console.WriteLine(webBookingHotelDto.findHotelDto.Name);
        //     }
        //     Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        //     // WebBookingHotelDto webBookingHotelDto = new WebBookingHotelDto
        //     // {
        //     //     findHotelDto = findHotelDto,
        //     //     searchHotelDto = searchHotelDto
        //     // };
        //     return View(webBookingHotelDto);
        // }

        public async Task<IActionResult> BookingHotel(AddGuestDto addGuest)
        {
            var response = await _guestService.AddGuest(addGuest);
            //var responseAddBookingHotel = await _bookingHotelService.AddBookingHotel()
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