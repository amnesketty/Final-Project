using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Data;
using lounga.Model;
using Microsoft.EntityFrameworkCore;

namespace Lounga.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        public AuthService(DataContext context)
        {
            _context = context;
            
        }
        public async Task<bool> IsRegistered(string username)
        {
            if (await _context.Users.AnyAsync(item => item.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        public Task<ServiceResponse<string>> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            if (await IsRegistered(user.Username))
            {
                response.Success = false;
                response.Message = "Username already exist!";
                return response;
            }
            CreatePasswordHash (password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            response.Message = "Account registered successfully";
            return response;
        }

        private void CreatePasswordHash (string Password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            }
        }
        private bool VerifyPasswordHash (string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var ComputeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return ComputeHash.SequenceEqual(passwordHash);
            }
        }
    }
}