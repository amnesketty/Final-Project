using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.User;
using lounga.Model;

namespace Lounga.Services.AuthServices
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>>Register (User User, string Password);
        Task<ServiceResponse<UserProfileDto>>Login (UserLoginDto userLoginDto);
        Task<bool>IsRegistered (string Username);
         
    }
}