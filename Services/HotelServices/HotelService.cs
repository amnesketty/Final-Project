using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Data;
using lounga.Dto.Hotels;
using lounga.Model;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace lounga.Services.HotelServices
{
    public class HotelService : IHotelService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public HotelService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }        
        public async Task<ServiceResponse<GetHotelDto>> AddHotel(AddHotelDto addHotel)
        {
            var response = new ServiceResponse<GetHotelDto>();
            try
            {
                Hotel hotel = _mapper.Map<Hotel>(addHotel);
                _context.Hotels.Add(hotel);
                await _context.SaveChangesAsync();
                response.Data =  _mapper.Map<GetHotelDto>(hotel);
                response.Message = "Hotel has been added!";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<ServiceResponse<GetHotelDto>> GetHotelById(int id)
        {
            var response = new ServiceResponse<GetHotelDto>();
            try
            {
                var hotel = await _context.Hotels
                    .Include(h => h.Photos)
                    .Include(h => h.FacilitiesHotel)
                    .Include(h => h.Rooms)
                    .FirstOrDefaultAsync(h => h.Id == id);
                response.Data = _mapper.Map<GetHotelDto>(hotel);
                response.Message = "Data successfully retrieved!";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<ServiceResponse<List<GetHotelDto>>> GetHotelByCity(string city)
        {
            var response = new ServiceResponse<List<GetHotelDto>>();
            try
            {
                var hotel = await _context.Hotels
                    .Where(h => h.City.ToLower() == city.ToLower())
                    .Include(h => h.Photos)
                    .Include(h => h.FacilitiesHotel)
                    .Include(h => h.Rooms)
                    .ToListAsync();
                response.Data = hotel.Select(h => _mapper.Map<GetHotelDto>(h)).ToList();
                response.Message = "Data Successfully retrieved!";
            }            
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}