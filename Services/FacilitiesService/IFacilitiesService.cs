using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Model;
using lounga.Dto.FacilitiesFlight;

namespace lounga.Services.FacilitiesService
{
    public interface IFacilitiesService
    {
        Task<ServiceResponse<List<GetFacilitiesFlightDto>>> GetFacilitiesFlight ();
        Task<ServiceResponse<AddFacilitiesFlightDto>> AddFacilitiesFlight (AddFacilitiesFlightDto newFacilitiesFlight);
        Task<ServiceResponse<UpdateFacilitiesFlightDto>> UpdateFacilitiesFlight (UpdateFacilitiesFlightDto updateFacilitiesFlight);
        Task<ServiceResponse<GetFacilitiesFlightDto>> DeleteFacilitiesFlight (GetFacilitiesFlightDto deleteFlight);

        // Task<ServiceResponse<GetAirlineDto>> GetAirlineById (int id);
        // Task<ServiceResponse<List<GetAirlineDto>>> DeleteAirline (int id);
    }
}