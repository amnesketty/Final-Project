using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.User;
using lounga.Services.AuthServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lounga.Controllers
{
    // [Route("[controller]")]
    public class ViewUsersController : Controller
    {
        private readonly ILogger<ViewUsersController> _logger;
        private readonly IAuthService _authService;
        public ViewUsersController(ILogger<ViewUsersController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Username, Password")] UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _authService.Login(userLoginDto);
                UserProfileDto user = response.Data;
                HttpContext.Session.SetString("Token", user.Token);
                return RedirectToAction(nameof(HistoryTransaction));
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("FirstName, LastName, Username, Email, Phone, Password")] UserRegisterDto userRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _authService.Register(userRegisterDto);
                int user = response.Data;
                return RedirectToAction(nameof(Login));
            }
            return View();
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