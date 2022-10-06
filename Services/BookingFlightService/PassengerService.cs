using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Data;
using lounga.Dto.BookingFlight;
using lounga.Dto.Data;
using lounga.Model;

namespace lounga.Services.BookingFlightService
{
    public class PassengerService : IPassengerService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public PassengerService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;            
        }
        public async Task<ServiceResponse<GetPassengerDto>> AddPassenger(AddPassengerDto newPassenger)
        {
            ServiceResponse<GetPassengerDto> response = new ServiceResponse<GetPassengerDto>();
            try
            {
                Passenger passenger = _mapper.Map<Passenger>(newPassenger);
                _context.Passengers.Add(passenger);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetPassengerDto>(passenger);
                response.Message = "Data Passenger succesfully added";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetPassengerDto>>> AddListPassenger(RequestData<AddPassengerDto> newPassenger)
        {
            ServiceResponse<List<GetPassengerDto>> response = new ServiceResponse<List<GetPassengerDto>>();
            try
            {
                List<Passenger> passengers = newPassenger.data.Select(p => _mapper.Map<Passenger>(p)).ToList();
                _context.Passengers.AddRange(passengers);
                await _context.SaveChangesAsync();
                response.Data = passengers.Select(p => _mapper.Map<GetPassengerDto>(p)).ToList();
                response.Message = "Data Passenger succesfully added";
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