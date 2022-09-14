using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Data;
using lounga.Dto.Flight;
using lounga.Model;
using Microsoft.EntityFrameworkCore;

namespace lounga.Services.FlightService
{
    public class FlightService : IFlightService
    {
       private readonly DataContext _context;
       private readonly IMapper _mapper;

       public FlightService (IMapper mapper, DataContext context)
       {
            _mapper = mapper;
            _context = context;
       }

        public async Task<ServiceResponse<AddFlightDto>> AddFlight(AddFlightDto newAirline)
        {
            //throw new NotImplementedException();
            ServiceResponse<AddFlightDto> response = new ServiceResponse<AddFlightDto>();
            try
            {
                Flight flight = _mapper.Map<Flight>(newAirline);
                _context.Flights.Add(flight);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<AddFlightDto>(flight);
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = ex.Message;
                }
                return response;
        }

        public Task<ServiceResponse<List<GetFlightDto>>> DeleteFlight(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetFlightDto>>> GetAllFlight()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetFlightDto>> GetFlightDtoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UpdateFlightDto>> UpdateFlight(UpdateFlightDto newUpdateFlight)
        {
            throw new NotImplementedException();
        }
    }
}