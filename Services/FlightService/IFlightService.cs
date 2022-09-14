using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.Flight;
using lounga.Model;

namespace lounga.Services.FlightService
{
    public interface IFlightService
    {
        //Data Airline
        Task<ServiceResponse<List<GetFlightDto>>> GetAllFlight ();
        Task<ServiceResponse<GetFlightDto>> GetFlightDtoById (int id);
        Task<ServiceResponse<AddFlightDto>> AddFlight (AddFlightDto newFlight);
        Task<ServiceResponse<UpdateFlightDto>> UpdateFlight (UpdateFlightDto newUpdateFlight);
        Task<ServiceResponse<List<GetFlightDto>>> DeleteFlight (int id);
    }
}