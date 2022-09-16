using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Model;
using lounga.Dto.FacilitiesFlight;

namespace lounga.Services.FacilitiesFlightService
{
    public interface IFacilitiesFlightService
    {
        Task<ServiceResponse<GetFacilitiesFlightDto>> AddFacilitiesFlight (AddFacilitiesFlightDto newFacilitiesFlight);
        Task<ServiceResponse<UpdateFacilitiesFlightDto>> UpdateFacilitiesFlight (UpdateFacilitiesFlightDto updateFacilitiesFlight);
        Task<ServiceResponse<GetFacilitiesFlightDto>> DeleteFacilitiesFlight (GetFacilitiesFlightDto deleteFlight);
    }
}