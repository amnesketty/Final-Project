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

        public async Task<ServiceResponse<GetFlightDto>> AddFlight(AddFlightDto newAirline)
        {
            //throw new NotImplementedException();
            ServiceResponse<GetFlightDto> response = new ServiceResponse<GetFlightDto>();
            try
            {
                Flight flight = _mapper.Map<Flight>(newAirline);
                _context.Flights.Add(flight);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetFlightDto>(flight);
                response.Message = "Data Flight succesfully added";
                return response;
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = ex.Message;
                }
                return response;
        }


        public async Task<ServiceResponse<List<GetFlightDto>>> GetAllFlight()
        {
            var response = new ServiceResponse<List<GetFlightDto>>();
            var dbFlight = await _context.Flights
                .Include(f => f.FacilitiesFlight)              
                .ToListAsync();
            response.Data = dbFlight.Select(f => _mapper.Map<GetFlightDto>(f)).ToList();
            return response;
        }
        public async Task<ServiceResponse<GetFlightDto>> GetFlightDtoById(int id)
        {
            var response = new ServiceResponse<GetFlightDto>();
            var flight = await _context.Flights
                .Include(f => f.FacilitiesFlight)
                .FirstOrDefaultAsync(f => f.Id == id);
            response.Data = _mapper.Map<GetFlightDto>(flight);
            return response;
        }
        public Task<ServiceResponse<UpdateFlightDto>> UpdateFlight(UpdateFlightDto newUpdateFlight)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<List<GetFlightDto>>> DeleteFlight(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetFlightDto>>> FindFlight (FindFlightDto findFlightDto)
        {
            var response = new ServiceResponse<List<GetFlightDto>>();
            var flight = await _context.Flights
                .Where(f => f.SeatClass.ToLower() == findFlightDto.SeatClass.ToLower())
                .Where(f => f.DestinationFrom.ToLower() == findFlightDto.DestinationFrom.ToLower())
                .Where(f => f.DestinationTo.ToLower() == findFlightDto.DestinationTo.ToLower())
                .Include(f => f.FacilitiesFlight)
                .Include(f => f.BookingFlights.Where(b => DateOnly.FromDateTime(b.BookingDate.Date) == DateOnly.FromDateTime(findFlightDto.DepartureDate)))
                .ToListAsync();
            
            foreach (Flight plane in flight)
            {
                plane.AmountPassenger = plane.BookingFlights.Count();
            }

            response.Data = flight.Select(f => _mapper.Map<GetFlightDto>(f)).ToList();
            return response;
        }
    }
}