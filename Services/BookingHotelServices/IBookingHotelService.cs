using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.BookingHotels;
using lounga.Dto.Hotels;
using lounga.Model;

namespace lounga.Services.BookingHotelServices
{
    public interface IBookingHotelService
    {
        Task<ServiceResponse<GetBookingHotelDto>> AddBookingHotel(AddBookingHotelDto addBookingHotel);
    }
}