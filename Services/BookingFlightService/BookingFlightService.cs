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
    public class BookingFlightService : IBookingFlightService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        
        public BookingFlightService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public async Task<ServiceResponse<GetBookingFlightDto>> AddBookingFlight(AddBookingFlightDto newBookingFlight)
        {
            ServiceResponse<GetBookingFlightDto> response = new ServiceResponse<GetBookingFlightDto>();
            try
            {
                BookingFlight bookingFlight = _mapper.Map<BookingFlight>(newBookingFlight);
                bookingFlight.BookingDate = newBookingFlight.BookingDate;
                var flight = await _context.Flights.FirstOrDefaultAsync(f => f.Id == newBookingFlight.FlightId);
                bookingFlight.Flight = flight;

                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == newBookingFlight.UserId);
                bookingFlight.User = user;

                var facilitiesFlight = await _context.FacilitiesFlights.FirstOrDefaultAsync(ff => ff.Id == newBookingFlight.FacilitiesFlightId);
                bookingFlight.FacilitiesFlight = facilitiesFlight;

                _context.BookingFlights.Add(bookingFlight);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetBookingFlightDto>(bookingFlight);
                response.Message = "Data Booking succesfully added";
                return response;
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