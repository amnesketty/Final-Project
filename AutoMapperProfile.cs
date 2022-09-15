using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Dto.FacilityHotelDto;
using lounga.Dto.File;
using lounga.Dto.Hotels;
using lounga.Dto.Rooms;
using lounga.Dto.FacilitiesFlight;
using lounga.Dto.Flight;
using lounga.Dto.User;
using lounga.Model;
using lounga.Dto.BookingFlight;

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
            CreateMap<AddFlightDto, Flight>();
            CreateMap<Flight, GetFlightDto>();
            CreateMap<AddFacilitiesFlightDto, FacilitiesFlight>();
            CreateMap<FacilitiesFlight, GetFacilitiesFlightDto>();
            CreateMap<Flight, GetFlightDto>();
            CreateMap<FacilitiesFlight, GetFacilitiesFlightDto>();
            CreateMap<Flight, FindFlightDto>();
            CreateMap<FindFlightDto, Flight>();
            CreateMap<BookingFlight, AddBookingFlightDto>();
            CreateMap<AddBookingFlightDto, GetBookingFlightDto>();

        }
    }
}