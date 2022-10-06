using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.BookingFlight;
using lounga.Dto.Data;
using lounga.Model;

namespace lounga.Services.BookingFlightService
{
    public interface IPassengerService
    {
        Task<ServiceResponse<GetPassengerDto>> AddPassenger (AddPassengerDto newPassenger);
        Task<ServiceResponse<List<GetPassengerDto>>> AddListPassenger (RequestData<AddPassengerDto> newPassenger);
    }
}