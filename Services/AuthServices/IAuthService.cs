using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Model;

namespace Lounga.Services.AuthServices
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>>Register (User User, string Password);
        Task<ServiceResponse<string>>Login (string Username, string Password);
        Task<bool>IsRegistered (string Username);
         
    }
}