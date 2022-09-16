using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Data;
using lounga.Dto.BookingHotels;
using lounga.Dto.Hotels;
using lounga.Model;
using Microsoft.EntityFrameworkCore;

namespace lounga.Services.BookingHotelServices
{
    public class BookingHotelService : IBookingHotelService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BookingHotelService(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
            
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));
        
        public async Task<ServiceResponse<GetBookingHotelDto>> AddBookingHotel(AddBookingHotelDto addBookingHotel)
        {
            var response = new ServiceResponse<GetBookingHotelDto>();
            BookingHotel bookingHotel = _mapper.Map<BookingHotel>(addBookingHotel);
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == addBookingHotel.HotelId);
            // bookingHotel.BookingDate = addBookingHotel.BookingDate;
            bookingHotel.Hotel = hotel;

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            bookingHotel.User = user;

            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == addBookingHotel.RoomId);
            bookingHotel.Room = room;
            
            _context.BookingHotels.Add(bookingHotel);
            await _context.SaveChangesAsync();

            
            response.Data = _mapper.Map<GetBookingHotelDto>(bookingHotel);
            response.Message = "Booking has been created!";
            return response;
        }

        // public async Task<ServiceResponse<List<FindHotelDto>>> FindHotel(string date, string city)
        // {
        //     DateOnly dateOnly = DateOnly.Parse(date);
        //     var response = new ServiceResponse<List<FindHotelDto>>();
        //     var hotel = await _context.Hotels
        //         .Where(h => h.City.ToLower() == city.ToLower())
        //         //.Include(h => h.BookingHotels.Where( b => (DateOnly.FromDateTime(b.BookingDate.Date)) != dateOnly))
        //         //.Include(h => h.Photos)
        //         //.Include(h => h.FacilitiesHotel)
        //         .Include(h => h.Rooms)
        //             .ThenInclude(r => r.BookingHotels)
        //         .ToListAsync();
        //     response.Data = hotel.Select(h => _mapper.Map<FindHotelDto>(h)).ToList();
        //     return response;
        // }
    }
}