using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.User;
using lounga.Model;
using Lounga.Services.AuthServices;
using Microsoft.AspNetCore.Mvc;

namespace lounga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register (UserRegisterDto UserRegisterDto)
        {
            var response = await _authService.Register(
                new User {Username = UserRegisterDto.Username}, UserRegisterDto.Password
            );
            if (response.Success == true)
            {
                return Ok(response);
            };
            return BadRequest(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<UserProfileDto>>> Login (UserLoginDto userLoginDto)
        {
            var response = await _authService.Login(userLoginDto);

            if (response.Success == true)
            {
                return Ok(response);
            };
            return BadRequest(response);

        }
    }
}