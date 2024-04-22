using NbaPlayoffs.Domain.Models;
using NbaPlayoffs.Domain.Repositories.Interfaces;

namespace NbaPlayoffs.Domain
{
    public interface IUnitOfWork
    {
        IRepository<Conference> Conferences { get; }
        IRepository<TeamRecord> TeamRecords { get; }
        IRepository<PlayoffGuessHeader> PlayoffGuessHeaders { get; }
        IRepository<Team> Teams { get; }
        IRepository<FavouriteTeam> FavouriteTeams { get; }

        public Task SaveAsync();
    }
}
