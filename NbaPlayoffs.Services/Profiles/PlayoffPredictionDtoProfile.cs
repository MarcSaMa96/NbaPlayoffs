using AutoMapper;
using NbaPlayoffs.Domain.Models;
using NbaPlayoffs.Services.DTOs;

namespace NbaPlayoffs.Services.Profiles
{
    public class PlayoffPredictionDtoProfile : Profile
    {
        public PlayoffPredictionDtoProfile()
        {
            CreateMap<PlayoffPredictionDto, PlayoffGuessHeader>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(source => source.Email));

            CreateMap<PlayoffTeamDto, PlayoffGuess>()
                .ForMember(dest => dest.TeamRecordId, opt => opt.MapFrom(source => source.TeamRecordId))
                .ForMember(dest => dest.PlayoffRankId, opt => opt.MapFrom(source => source.PlayoffRank))
                .ForMember(dest => dest.PlayoffRank, opt => opt.Ignore())
                .ForMember(dest => dest.PlayoffGuessHeader, opt => opt.Ignore());
        }
    }
}
