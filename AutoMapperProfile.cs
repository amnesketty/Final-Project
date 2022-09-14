using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Dto.FacilityHotelDto;
using lounga.Dto.File;
using lounga.Dto.Hotels;
using lounga.Dto.Rooms;
using lounga.Dto.User;
using lounga.Model;

namespace lounga
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserProfileDto>();
            CreateMap<AddHotelDto, Hotel>();
            CreateMap<Hotel, GetHotelDto>();
            CreateMap<AddRoomDto, Room>();
            CreateMap<Room, GetRoomDto>();
            CreateMap<AddFacilityHotelDto, FacilitiesHotel>();
            CreateMap<FacilitiesHotel, GetFacilityHotelDto>();
            CreateMap<Photo, GetPhotoDto>();
        }
    }
}