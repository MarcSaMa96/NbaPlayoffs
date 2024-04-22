using NbaPlayoffs.Domain.Models;
using NbaPlayoffs.Domain.Repositories.Implementations;
using NbaPlayoffs.Domain.Repositories.Interfaces;

namespace NbaPlayoffs.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private NbaPlayoffContext _context;
        private IRepository<Conference> _conferences;
        private IRepository<TeamRecord> _teamRecords;
        private IRepository<PlayoffGuessHeader> _playoffGuessHeaders;
        private IRepository<Team> _teams;
        private IRepository<FavouriteTeam> _favouriteTeams;

        #region Repositories Initializations
        public IRepository<Conference> Conferences 
        { 
            get
            {
                return _conferences ?? new Repository<Conference>(_context);
            } 
        }

        public IRepository<TeamRecord> TeamRecords
        {
            get
            {
                return _teamRecords ?? new Repository<TeamRecord>(_context);
            }
        }

        public IRepository<PlayoffGuessHeader> PlayoffGuessHeaders
        {
            get
            {
                return _playoffGuessHeaders ?? new Repository<PlayoffGuessHeader>(_context);
            }
        }

        public IRepository<Team> Teams
        {
            get
            {
                return _teams ?? new Repository<Team>(_context);
            }
        }

        public IRepository<FavouriteTeam> FavouriteTeams
        {
            get
            {
                return _favouriteTeams ?? new Repository<FavouriteTeam>(_context);
            }
        }
        #endregion

        public UnitOfWork(NbaPlayoffContext context)
        {
            _context = context;
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();

    }
}
