using AutoMapper;
using NbaPlayoffs.Domain.Models;
using NbaPlayoffs.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NbaPlayoffs.Services.Profiles
{
    public class TeamDtoProfile : Profile
    {
        public TeamDtoProfile()
        {
            CreateMap<TeamRecord, TeamDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Team.Name))
                .ForMember(x => x.LogoPath, opt => opt.MapFrom(src => src.Team.ImageRoute))
                .ForMember(x => x.Players, opt => opt.MapFrom(src => src.PlayerRecords));

            CreateMap<PlayerRecord, PlayerDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Player.Name))
                .ForMember(x => x.PositionCode, opt => opt.MapFrom(src => src.Player.PlayerPosition.Code));

            CreateMap<Team, TeamDto>()
                .ForMember(x => x.IdTeam, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
