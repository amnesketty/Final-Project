using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Data;
using lounga.Model;
using lounga.Dto.FacilitiesFlight;

namespace lounga.Services.FacilitiesService
{
    public class FacilitiesService : IFacilitiesService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FacilitiesService (IMapper mapper, DataContext context)
       {
            _mapper = mapper;
            _context = context;
       }

        public async Task<ServiceResponse<AddFacilitiesFlightDto>> AddFacilitiesFlight(AddFacilitiesFlightDto newFacilitiesFlight)
        {
            ServiceResponse<AddFacilitiesFlightDto> response = new ServiceResponse<AddFacilitiesFlightDto>();
            try
            {
                FacilitiesFlight facilitiesFlight = _mapper.Map<FacilitiesFlight>(newFacilitiesFlight);
                _context.FacilitiesFlights.Add(facilitiesFlight);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<AddFacilitiesFlightDto>(facilitiesFlight);
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

        public Task<ServiceResponse<List<GetFacilitiesFlightDto>>> GetFacilitiesFlight()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UpdateFacilitiesFlightDto>> UpdateFacilitiesFlight(UpdateFacilitiesFlightDto updateFacilitiesFlight)
        {
            throw new NotImplementedException();
        }
    }
}