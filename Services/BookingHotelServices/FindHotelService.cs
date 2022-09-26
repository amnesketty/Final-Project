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
        public async Task<ServiceResponse<List<FindHotelDto>>> FindHotel(SearchHotelDto searchHotelDto)
        {
            DateOnly dateOnly = DateOnly.FromDateTime(searchHotelDto.BookingDate);
            var response = new ServiceResponse<List<FindHotelDto>>();
            try
            {
                var hotels = await _context.Hotels
                    .Where(h => h.City.ToLower() == searchHotelDto.City.ToLower())
                    .Include(r => r.Rooms)
                        .ThenInclude(r => r.BookingHotels.Where(b => (DateOnly.FromDateTime(b.BookingDate.Date)) == dateOnly))
                    .Include(f => f.FacilitiesHotel)
                    .Include(p => p.Photos)
                    .ToListAsync();
                response.Data = hotels.Select(h => _mapper.Map<FindHotelDto>(h)).ToList();
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