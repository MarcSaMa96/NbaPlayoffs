using Microsoft.EntityFrameworkCore;
using NbaPlayoffs.Domain.Models;
using NbaPlayoffs.Domain.Repositories.Interfaces;

namespace NbaPlayoffs.Domain.Repositories.Implementations
{
    public class FavouriteTeamRepository : Repository<FavouriteTeam>, IFavouriteTeamRepository
    {
        private NbaPlayoffContext _context;

        public FavouriteTeamRepository(NbaPlayoffContext context) : base(context)
        {
            _context = context;
        }

        public async Task<FavouriteTeam> GetByEmail(string email) => await _context.FavouriteTeams.Where(x => x.Email == email).FirstOrDefaultAsync();
    }
}
