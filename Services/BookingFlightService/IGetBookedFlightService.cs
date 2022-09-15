using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.BookingFlight;
using lounga.Model;

namespace lounga.Services.BookingFlightService
{
    public interface IGetBookedFlightService
    {
        Task<ServiceResponse<List<GetBookingFlightDto>>> GetBookedFlights(string date);
    }
}