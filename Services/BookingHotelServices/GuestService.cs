using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Data;
using lounga.Dto.BookingHotels;
using lounga.Model;

namespace lounga.Services.BookingHotelServices
{
    public class GuestService : IGuestService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GuestService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<ServiceResponse<GetGuestDto>> AddGuest(AddGuestDto addGuest)
        {
            var response = new ServiceResponse<GetGuestDto>();
            Guest guest = _mapper.Map<Guest>(addGuest);
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
            
            response.Data = _mapper.Map<GetGuestDto>(guest);
            response.Message = "Guest has been created!";
            return response;
        }
    }
}