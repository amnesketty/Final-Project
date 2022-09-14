using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.Hotels;
using lounga.Model;

namespace lounga.Services.HotelServices
{
    public interface IHotelService
    {
        Task<ServiceResponse<GetHotelDto>> AddHotel(AddHotelDto addHotel);
        Task<ServiceResponse<GetHotelDto>> GetHotelById(int id);
        Task<ServiceResponse<List<GetHotelDto>>> GetHotelByCity(string city);
    }
}