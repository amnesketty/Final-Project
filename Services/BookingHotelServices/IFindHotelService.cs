using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.Hotels;
using lounga.Model;

namespace lounga.Services.BookingHotelServices
{
    public interface IFindHotelService
    {
        Task<ServiceResponse<List<FindHotelDto>>> FindHotel(string date, string city);
    }
}