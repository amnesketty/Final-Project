using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.Flight;
using lounga.Dto.Hotels;
using lounga.Dto.User;
using lounga.Services.AuthServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lounga.Controllers
{
    public class VIewHomeController : Controller
    {
        private readonly ILogger<VIewHomeController> _logger;
        private readonly IAuthService _authService;

        public VIewHomeController(ILogger<VIewHomeController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }
        [Authorize]
        public IActionResult Main()
        {
            return View();
        }
        
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchFlight([Bind("SeatClass, AmountPassenger, DestinationFrom, DestinationTo, DepartureDate")] FindFlightDto findFlightDto)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("FindFlight", "ViewFlights", findFlightDto);
                // var response = await _authService.Login(userLoginDto);
                // UserProfileDto user = response.Data;
                // HttpContext.Session.SetString("Token", user.Token);
                // return RedirectToAction("Main", "ViewHome");
            }
            return RedirectToAction(nameof(Main));
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchHotel([Bind("City, BookingDate, TotalRoom, Duration")] SearchHotelDto searchHotelDto)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("FindHotel", "ViewHotels", searchHotelDto);
                // var response = await _authService.Login(userLoginDto);
                // UserProfileDto user = response.Data;
                // HttpContext.Session.SetString("Token", user.Token);
                // return RedirectToAction("Main", "ViewHome");
            }
            return RedirectToAction(nameof(Main));
        }

        [Authorize]
        public async Task<IActionResult> HistoryTransaction ()
        {
            var response = await _authService.GetUserTransaction();
            UserTransactionDto userTransactionDto = response.Data;
            return View(userTransactionDto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}