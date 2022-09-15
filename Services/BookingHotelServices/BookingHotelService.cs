using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Data;
using lounga.Dto.BookingHotels;
using lounga.Model;
using Microsoft.EntityFrameworkCore;

namespace lounga.Services.BookingHotelServices
{
    public class BookingHotelService : IBookingHotelService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public BookingHotelService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            
        }
        
        public async Task<ServiceResponse<GetBookingHotelDto>> AddBookingHotel(AddBookingHotelDto addBookingHotel)
        {
            var response = new ServiceResponse<GetBookingHotelDto>();
            BookingHotel bookingHotel = _mapper.Map<BookingHotel>(addBookingHotel);
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == addBookingHotel.HotelId);
            // bookingHotel.BookingDate = addBookingHotel.BookingDate;
            bookingHotel.Hotel = hotel;

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == addBookingHotel.UserId);
            bookingHotel.User = user;

            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == addBookingHotel.RoomId);
            bookingHotel.Room = room;
            
            _context.BookingHotels.Add(bookingHotel);
            await _context.SaveChangesAsync();

            
            response.Data = _mapper.Map<GetBookingHotelDto>(bookingHotel);
            response.Message = "Booking has been created!";
            return response;
        }

        
    }
}