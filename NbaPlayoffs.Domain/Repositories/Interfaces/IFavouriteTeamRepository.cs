using NbaPlayoffs.Domain.Models;

namespace NbaPlayoffs.Domain.Repositories.Interfaces
{
    public interface IFavouriteTeamRepository
    {
        Task<FavouriteTeam> GetByEmail(string email);
    }
}
