using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Data;
using lounga.Dto.Rooms;
using lounga.Model;
using Microsoft.EntityFrameworkCore;

namespace lounga.Services.RoomServices
{
    public class RoomService : IRoomService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public RoomService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;            
        }
        public async Task<ServiceResponse<GetRoomDto>> AddRoom(AddRoomDto addRoom)
        {
            var response = new ServiceResponse<GetRoomDto>();
            var hotel = await _context.Hotels
                .FirstOrDefaultAsync(h => h.Id == addRoom.HotelId);
            Room room = _mapper.Map<Room>(addRoom);
            room.Hotel = hotel;
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            response.Data =  _mapper.Map<GetRoomDto>(room);
            response.Message = "Room has been added!";
            return response;
        }
    }
}