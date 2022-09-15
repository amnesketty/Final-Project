using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.BookingHotels;
using lounga.Model;

namespace lounga.Services.BookingHotelServices
{
    public interface IGuestService
    {
        Task<ServiceResponse<GetGuestDto>> AddGuest(AddGuestDto addGuest);
    }
}