using NbaPlayoffs.Domain.Models;

namespace NbaPlayoffs.Domain.Repositories.Interfaces
{
    public interface ITeamRecordRepository
    {
        Task<TeamRecord> GetTeamPlayersByYear(int idTeam, int year);
    }
}
