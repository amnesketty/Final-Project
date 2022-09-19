using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Dto.FacilityHotelDto;
using lounga.Dto.Hotels;
using lounga.Dto.Rooms;
using lounga.Model;
using lounga.Services.FacilitiesHotelServices;
using lounga.Services.HotelServices;
using lounga.Services.RoomServices;
using Microsoft.AspNetCore.Mvc;

namespace lounga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IRoomService _roomService;
        private readonly IFacilitiesHotelService _FacilitiesHotelService;
        public HotelController(IHotelService hotelService, IRoomService roomService, IFacilitiesHotelService FacilitiesHotelService)
        {
           _FacilitiesHotelService = FacilitiesHotelService;
           _roomService = roomService;
           _hotelService = hotelService;
            
        }

        [HttpPost("addhotel")]
        public async Task<ActionResult<ServiceResponse<GetHotelDto>>> AddHotel(AddHotelDto addHotel)
        {
           return Ok(await _hotelService.AddHotel(addHotel));
        }

        [HttpGet("gethotel{id}")]
        public async Task<ActionResult<ServiceResponse<GetHotelDto>>> GetSingle(int id)
        {
            return Ok(await _hotelService.GetHotelById(id));
        }

        [HttpGet("gethotel")]
        public async Task<ActionResult<ServiceResponse<List<GetHotelDto>>>> Get(string city)
        {
            return Ok(await _hotelService.GetHotelByCity(city));
        }



        [HttpPost("addroom")]
        public async Task<ActionResult<ServiceResponse<GetRoomDto>>> AddRoom(AddRoomDto addRoom)
        {
           return Ok(await _roomService.AddRoom(addRoom));
        }
        

        [HttpPost("addfacilitieshotel")]
        public async Task<ActionResult<ServiceResponse<GetFacilityHotelDto>>> AddFacilitiesHotel(AddFacilityHotelDto addFacilityHotel)
        {
           return Ok(await _FacilitiesHotelService.AddFacilityHotel(addFacilityHotel));
        }
    }
}