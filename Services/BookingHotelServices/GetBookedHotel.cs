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
    public class GetBookedHotelService : IGetBookedHotelService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        public GetBookedHotelService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;            
        }
        public async Task<ServiceResponse<List<GetBookingHotelDto>>> GetBookedHotels(string date)
        {
            DateOnly dateOnly = DateOnly.Parse(date);
            var response = new ServiceResponse<List<GetBookingHotelDto>>();
            try
            {
                var hotel = await _context.BookingHotels
                    .Where(b => (DateOnly.FromDateTime(b.BookingDate.Date)) == dateOnly)
                    .ToListAsync();
                response.Data = hotel.Select(h => _mapper.Map<GetBookingHotelDto>(h)).ToList();
                response.Message = "Data successfully retrieved!";
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