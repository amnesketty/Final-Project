using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.Rooms;
using lounga.Model;

namespace lounga.Services.RoomServices
{
    public interface IRoomService 
    {
        Task<ServiceResponse<GetRoomDto>> AddRoom(AddRoomDto addRoom);
    }
}