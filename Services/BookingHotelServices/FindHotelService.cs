using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Data;
using lounga.Dto.BookingHotels;
using lounga.Dto.Hotels;
using lounga.Model;
using Microsoft.EntityFrameworkCore;

namespace lounga.Services.BookingHotelServices
{
    public class FindHotelService : IFindHotelService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FindHotelService(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
            
        }
        
        public async Task<ServiceResponse<List<FindHotelDto>>> FindHotel(string date, string city)
        {
            DateOnly dateOnly = DateOnly.Parse(date);
            var response = new ServiceResponse<List<FindHotelDto>>();
            var hotel = await _context.Hotels
                .Where(h => h.City.ToLower() == city.ToLower())
                .Include(r => r.Rooms)
                    .ThenInclude(r => r.BookingHotels.Where(b => (DateOnly.FromDateTime(b.BookingDate.Date)) == dateOnly))
                //.Include(h => h.BookingHotels.Where( b => (DateOnly.FromDateTime(b.BookingDate.Date)) != dateOnly))
                //.Include(h => h.Photos)
                //.Include(h => h.FacilitiesHotel)
                //.Include(h => h.Rooms).ThenInclude(Room => Room.BookingHotels.Where(b => DateOnly.FromDateTime(b.BookingDate.Date) != dateOnly))
                //    .ThenInclude(r => r.BookingHotels.Where(b => (DateOnly.FromDateTime(b.BookingDate.Date)) != dateOnly).ToList())
                .ToListAsync();
            response.Data = hotel.Select(h => _mapper.Map<FindHotelDto>(h)).ToList();
            return response;
        }
        
    }
}