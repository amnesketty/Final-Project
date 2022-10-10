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

        public async Task<IActionResult> GetUser (String username, String password)
        {
            UserLoginDto userLoginDto = new UserLoginDto
            {
                Username = username,
                Password = password
            };
            var response = await _authService.Login(userLoginDto);
            UserProfileDto user = response.Data;
            HttpContext.Session.SetString("Token", user.Token);
            return View(user);
        }
        [Authorize]
        public async Task<IActionResult> GetUserTransaction ()
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