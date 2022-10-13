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
            return View(webFindHotelDto);
        }

        // [Authorize]
        public async Task<IActionResult> DetailHotel(DateTime bookingDate, int totalRoom, int hotelId)
        {
            var response = await _hotelService.GetHotelById(hotelId);
            WebDetailHotelDto webBookingHotelDto = new WebDetailHotelDto
            {
                bookingDate = bookingDate,
                name = response.Data.Name,
                totalRoom = totalRoom,
                hotelId = hotelId,
                getHotelDto = response.Data
            };
            return View(webBookingHotelDto);
        }
    
        // [Authorize]
        public IActionResult BookingHotel(DateTime bookingDate, string name, int totalRoom, int price, int hotelId, int roomId)
        {
            WebBookingHotelDto webBookingHotelDto = new WebBookingHotelDto
            {
                bookingDate = bookingDate,
                name = name,
                totalRoom = totalRoom,
                price = price,
                hotelId = hotelId,
                roomId = roomId
            };
            return View(webBookingHotelDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Authorize]
        public async Task<IActionResult> BookingHotel([Bind("bookingDate, name, totalRoom, price, hotelId, roomId, guestName, email, phone")] WebBookingHotelDto webBookingHotelDto)
        {
            if (ModelState.IsValid)
            {
                AddBookingHotelDto addBookingHotelDto = new AddBookingHotelDto
                {
                    BookingDate = webBookingHotelDto.bookingDate.ToUniversalTime(),
                    Name = webBookingHotelDto.name,
                    TotalRoom = webBookingHotelDto.totalRoom,
                    Price = webBookingHotelDto.price,
                    HotelId = webBookingHotelDto.hotelId,
                    RoomId = webBookingHotelDto.roomId
                };
                var responseAddBookingHotel = await _bookingHotelService.AddBookingHotel(addBookingHotelDto);
                int bookingHotelId = responseAddBookingHotel.Data.Id;
                AddGuestDto addGuestDto = new AddGuestDto
                {
                    Name = webBookingHotelDto.guestName,
                    Email = webBookingHotelDto.email,
                    Phone = webBookingHotelDto.phone,
                    BookingHotelId = bookingHotelId
                };
                var responseAddGuest = await _guestService.AddGuest(addGuestDto);
                return RedirectToAction("Main", "ViewHome");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}