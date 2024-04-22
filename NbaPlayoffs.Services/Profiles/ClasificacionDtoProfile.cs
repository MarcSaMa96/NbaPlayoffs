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
    public class ClasificacionDtoProfile : Profile
    {
        public ClasificacionDtoProfile()
        {
            CreateMap<Team, ClasificacionDto>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Wins, opt => opt.MapFrom(src => src.TeamRecords.FirstOrDefault().Wins))
                .ForMember(dest => dest.Losses, opt => opt.MapFrom(src => src.TeamRecords.FirstOrDefault().Losses))
                .ForMember(dest => dest.TeamImageSrc, opt => opt.MapFrom(src => src.ImageRoute))
                .ForMember(dest => dest.TeamRecordId, opt => opt.MapFrom(src => src.TeamRecords.FirstOrDefault().Id));
        }
    }
}
