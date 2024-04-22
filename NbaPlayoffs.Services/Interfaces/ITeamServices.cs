using NbaPlayoffs.Services.DTOs;

namespace NbaPlayoffs.Services.Interfaces
{
    public interface ITeamServices
    {
        Task<TeamDto> GetByIdYear(int id, int year);
        Task<List<TeamDto>> GetAll();
    }
}
