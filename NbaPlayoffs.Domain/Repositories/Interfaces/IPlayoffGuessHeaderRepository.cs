using NbaPlayoffs.Domain.Models;

namespace NbaPlayoffs.Domain.Repositories.Interfaces
{
    public interface IPlayoffGuessHeaderRepository
    {
        Task<PlayoffGuessHeader> GetByEmail(string email);
    }
}
