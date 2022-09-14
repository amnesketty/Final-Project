using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Dto.Hotels;
using lounga.Model;
using lounga.Services.HotelServices;
using Microsoft.AspNetCore.Mvc;

namespace lounga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
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
    }
}