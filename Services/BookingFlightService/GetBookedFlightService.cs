using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Data;
using lounga.Dto.BookingFlight;
using lounga.Model;
using Microsoft.EntityFrameworkCore;

namespace lounga.Services.BookingFlightService
{
    public class GetBookedFlightService : IGetBookedFlightService
    {
        
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        public GetBookedFlightService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            
        }
        public async Task<ServiceResponse<List<GetBookingFlightDto>>> GetBookedFlights(string date)
        {
            DateOnly dateOnly = DateOnly.Parse(date);
            var response = new ServiceResponse<List<GetBookingFlightDto>>();
            var flight = await _context.BookingFlights
                .Where(b => (DateOnly.FromDateTime(b.BookingDate.Date)) == dateOnly)
                .Include(b => b.Flight)
                .Include(b => b.FacilitiesFlight)
                .ToListAsync();
            response.Data = flight.Select(f => _mapper.Map<GetBookingFlightDto>(f)).ToList();
            return response;

        }
    }
}