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
using lounga.Dto.BookingHotels;

namespace lounga
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserProfileDto>();
            CreateMap<User, UserRegisterDto>();
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
            CreateMap<AddBookingFlightDto, BookingFlight>();
            CreateMap<BookingFlight, GetBookingFlightDto>();
            CreateMap<AddPassengerDto, Passenger>();
            CreateMap<Passenger, GetPassengerDto>();
            CreateMap<FacilitiesFlight, AddFacilitiesFlightDto>();
            CreateMap<AddBookingHotelDto, BookingHotel>();
            CreateMap<BookingHotel, GetBookingHotelDto>();
            CreateMap<AddGuestDto, Guest>();
            CreateMap<Guest, GetGuestDto>();
            CreateMap<GetPhotoDto, Photo>();
            CreateMap<Hotel, FindHotelDto>();
            CreateMap<Room, FindRoomDto>();
        }
    }
}