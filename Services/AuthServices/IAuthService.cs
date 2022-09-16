using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.User;
using lounga.Model;

namespace lounga.Services.AuthServices
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register (UserRegisterDto userRegisterDto);
        Task<ServiceResponse<UserProfileDto>> Login (UserLoginDto userLoginDto);
        Task<bool> IsRegistered (string Username);
    }
}