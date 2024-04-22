using AutoMapper;
using NbaPlayoffs.Domain.Models;
using NbaPlayoffs.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbaPlayoffs.Services.Profiles
{
    public class FavouriteTeamDtoProfile : Profile
    {
        public FavouriteTeamDtoProfile()
        {
            CreateMap<FavouriteTeamDto, FavouriteTeam>()
                .ForMember(dest => dest.IdTeam, opt => opt.MapFrom(src => src.IdTeam))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
