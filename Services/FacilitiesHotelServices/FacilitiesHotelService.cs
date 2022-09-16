using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Data;
using lounga.Dto.FacilityHotelDto;
using lounga.Model;

namespace lounga.Services.FacilitiesHotelServices
{
    public class FacilitiesHotelService : IFacilitiesHotelService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        
        public FacilitiesHotelService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;            
        }        
        public async Task<ServiceResponse<GetFacilityHotelDto>> AddFacilityHotel(AddFacilityHotelDto addFacilityHotel)
        {
            var response = new ServiceResponse<GetFacilityHotelDto>();
            FacilitiesHotel facilitiesHotel = _mapper.Map<FacilitiesHotel>(addFacilityHotel);
            _context.FacilitiesHotels.Add(facilitiesHotel);
            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetFacilityHotelDto>(facilitiesHotel);
            response.Message = "Hotel facilities have been added!";
            return response;
        }
    }
}