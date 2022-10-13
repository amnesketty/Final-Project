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
                if (response.Success == true)
                {
                    UserProfileDto user = response.Data;
                    HttpContext.Session.SetString("Token", user.Token);
                    ViewData["loginStatus"] = response.Message;
                    return RedirectToAction("Main", "ViewHome");
                }                
                ViewData["loginStatus"] = response.Message;
                return View();
            }
            return View();
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("Token") != null)
            {
                HttpContext.Session.Remove("Token");
                return RedirectToAction(nameof(Login));
            }
            return RedirectToAction(nameof(Login));
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
                if (response.Success == true)
                {
                    int user = response.Data;
                    ViewData["registerStatus"] = response.Message;
                    return RedirectToAction(nameof(Login));
                }
                ViewData["registerStatus"] = response.Message;
                return View();
            }
            return View();
        }
        public async Task<IActionResult> Profile()
        {
            var responseUser = await _authService.Profile();
            //UserProfileDto userProfileDto = responseUser.Data;
            ViewData["userProfileDto"] = responseUser.Data;
            var responseTransaction = await _authService.GetUserTransaction();
            ViewData["userTransactionDto"] = responseTransaction.Data;
            //UserTransactionDto userTransactionDto = responseTransaction.Data;
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}