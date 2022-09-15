using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Data;
using lounga.Model;
using lounga.Dto.FacilitiesFlight;
using Microsoft.EntityFrameworkCore;

namespace lounga.Services.FacilitiesFlightService
{
    public class FacilitiesFlightService : IFacilitiesFlightService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FacilitiesFlightService (IMapper mapper, DataContext context)
       {
            _mapper = mapper;
            _context = context;
       }

        public async Task<ServiceResponse<GetFacilitiesFlightDto>> AddFacilitiesFlight(AddFacilitiesFlightDto newFacilitiesFlight)
        {
            ServiceResponse<GetFacilitiesFlightDto> response = new ServiceResponse<GetFacilitiesFlightDto>();
            try
            {
                FacilitiesFlight facilitiesFlight = _mapper.Map<FacilitiesFlight>(newFacilitiesFlight);
                _context.FacilitiesFlights.Add(facilitiesFlight);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetFacilitiesFlightDto>(facilitiesFlight);
                response.Message = "Facilities Flight succesfully added";
                return response;
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = ex.Message;
                }
                return response;
        }

        public Task<ServiceResponse<GetFacilitiesFlightDto>> DeleteFacilitiesFlight(GetFacilitiesFlightDto deleteFlight)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UpdateFacilitiesFlightDto>> UpdateFacilitiesFlight(UpdateFacilitiesFlightDto updateFacilitiesFlight)
        {
            throw new NotImplementedException();
        }
    }
}