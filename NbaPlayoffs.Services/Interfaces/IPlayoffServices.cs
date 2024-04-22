using NbaPlayoffs.Services.DTOs;

namespace NbaPlayoffs.Services.Interfaces
{
    public interface IPlayoffServices
    {
        Task<Dictionary<string, List<PlayoffTeamDto>>> GetFirstRoundTeams();
        Task<ResponseDto> InsertPrediction(PlayoffPredictionDto prediction);
    }
}
