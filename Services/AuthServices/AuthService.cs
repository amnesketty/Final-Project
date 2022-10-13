using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Data;
using lounga.Dto.User;
using lounga.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace lounga.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthService(DataContext context, IConfiguration configuration, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _configuration = configuration;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> IsRegistered(string username)
        {
            if (await _context.Users.AnyAsync(item => item.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }
        public async Task<ServiceResponse<int>> Register(UserRegisterDto userRegisterDto)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            try
            {
                if (await IsRegistered(userRegisterDto.Username))
                {
                    response.Success = false;
                    response.Message = "Username already exist!";
                    return response;
                }
                CreatePasswordHash (userRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                User user = _mapper.Map<User>(userRegisterDto);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                response.Message = "Account registered successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<ServiceResponse<UserProfileDto>> Login(UserLoginDto userLoginDto)
        {
            var response = new ServiceResponse<UserProfileDto>();
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(item => item.Username.ToLower() == userLoginDto.Username.ToLower());

                if (user == null)
                {
                    response.Success = false;
                    response.Message = "User not found!";
                }
                else if (!VerifyPasswordHash(userLoginDto.Password, user.PasswordHash, user.PasswordSalt))
                {
                    response.Success = false;
                    response.Message = "Password incorrect!";
                }
                else 
                {
                    var responDTO = _mapper.Map<UserRegisterDto>(user);
                    response.Data = _mapper.Map<UserProfileDto>(user);
                    response.Data.Token = CreateToken(user);
                    response.Message = "Login success!";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
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
        
        private string CreateToken (User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));            
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));
        public async Task<ServiceResponse<UserTransactionDto>> GetUserTransaction()
        {
            ServiceResponse<UserTransactionDto> response = new ServiceResponse<UserTransactionDto>();
            try
            {
                var user = await _context.Users
                    .Include(u => u.BookingFlights)
                    .Include(u => u.BookingHotels)
                    .FirstOrDefaultAsync(u => u.Id == GetUserId());
                response.Data = _mapper.Map<UserTransactionDto>(user);
                response.Message = "Data successfully retrieved!";
            } catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<UserProfileDto>> Profile()
        {
            ServiceResponse<UserProfileDto> response = new ServiceResponse<UserProfileDto>();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());   
                response.Data = _mapper.Map<UserProfileDto>(user);
                response.Message = "Data successfully retrieved!";
            } catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}