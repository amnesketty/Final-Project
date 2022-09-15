using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.BookingFlight;
using lounga.Model;

namespace lounga.Services.BookingFlightService
{
    public interface IBookingFlightService
    {
        // Task<ServiceResponse<List<GetBookingFlightDto>>> GetAllBookingFlight ();
        // Task<ServiceResponse<GetBookingFlightDto>> GetBookingFlightById (int id);
        Task<ServiceResponse<GetBookingFlightDto>> AddBookingFlight (AddBookingFlightDto newBookingFlight);
    }
}