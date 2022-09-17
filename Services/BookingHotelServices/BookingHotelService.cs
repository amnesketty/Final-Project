using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Data;
using lounga.Dto.BookingHotels;
using lounga.Dto.File;
using lounga.Dto.Hotels;
using lounga.Model;
using lounga.Services.FileService;
using Microsoft.EntityFrameworkCore;

namespace lounga.Services.BookingHotelServices
{
    public class BookingHotelService : IBookingHotelService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMailService _mailService;
        public BookingHotelService(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IMailService mailService)
        {
            _mailService = mailService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;            
        }
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));
        public async Task<ServiceResponse<GetBookingHotelDto>> AddBookingHotel(AddBookingHotelDto addBookingHotel)
        {
            var response = new ServiceResponse<GetBookingHotelDto>();
            try
            {
                BookingHotel bookingHotel = _mapper.Map<BookingHotel>(addBookingHotel);
                var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == addBookingHotel.HotelId);
                bookingHotel.Hotel = hotel;

                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
                var email = user?.Email;
                bookingHotel.User = user;

                var room = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == addBookingHotel.RoomId);
                bookingHotel.Room = room;

                var random = new Random().Next(100000,999999).ToString();
                string hl = "HL-";
                var bookingNo = hl+random;
                bookingHotel.BookingHotelNo = bookingNo;

                _context.BookingHotels.Add(bookingHotel);

                var mailRequest = new MailRequest();
                mailRequest.Body = "Your Hotel Booking Number is " + bookingNo;
                mailRequest.Subject = "Lounga Hotel Booking";
                mailRequest.ToEmail = email;
                await _context.SaveChangesAsync();
                await _mailService.SendEmailAsync(mailRequest);
                
                response.Data = _mapper.Map<GetBookingHotelDto>(bookingHotel);
                response.Message = "Booking has been created!";
            }            
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}