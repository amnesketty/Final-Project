using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.FacilityHotelDto;
using lounga.Model;

namespace lounga.Services.FacilitiesHotelServices
{
    public interface IFacilitiesHotelService
    {
        Task<ServiceResponse<GetFacilityHotelDto>> AddFacilityHotel(AddFacilityHotelDto addFacilityHotel);
    }
}