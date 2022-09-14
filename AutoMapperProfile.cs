using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Dto.FacilitiesFlight;
using lounga.Dto.Flight;
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
            CreateMap<AddFlightDto, Flight>();
            CreateMap<Flight, AddFlightDto>();
            CreateMap<AddFacilitiesFlightDto, FacilitiesFlight>();
            CreateMap<FacilitiesFlight, AddFacilitiesFlightDto>();
        }
    }
}