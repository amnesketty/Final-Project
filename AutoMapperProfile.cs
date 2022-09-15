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
<<<<<<< HEAD
using lounga.Dto.BookingFlight;
=======
using lounga.Dto.BookingHotels;
>>>>>>> bf5bf55b6c371f4b17737750407c40dbbe4c3889

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
<<<<<<< HEAD
            CreateMap<FacilitiesFlight, GetFacilitiesFlightDto>();
            CreateMap<Flight, GetFlightDto>();
            CreateMap<FacilitiesFlight, GetFacilitiesFlightDto>();
            CreateMap<Flight, FindFlightDto>();
            CreateMap<FindFlightDto, Flight>();
            CreateMap<BookingFlight, AddBookingFlightDto>();
            CreateMap<AddBookingFlightDto, GetBookingFlightDto>();

=======
            CreateMap<FacilitiesFlight, AddFacilitiesFlightDto>();
            CreateMap<AddBookingHotelDto, BookingHotel>();
            CreateMap<BookingHotel, GetBookingHotelDto>();
            CreateMap<AddGuestDto, Guest>();
            CreateMap<Guest, GetGuestDto>();
            CreateMap<GetPhotoDto, Photo>();
>>>>>>> bf5bf55b6c371f4b17737750407c40dbbe4c3889
        }
    }
}