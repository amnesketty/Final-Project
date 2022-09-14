using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.Rooms;
using lounga.Model;
using lounga.Services.RoomServices;
using Microsoft.AspNetCore.Mvc;

namespace lounga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
           _roomService = roomService;
            
        }

        [HttpPost("addroom")]
        public async Task<ActionResult<ServiceResponse<GetRoomDto>>> AddRoom(AddRoomDto addRoom)
        {
           return Ok(await _roomService.AddRoom(addRoom));
        }
    }
}