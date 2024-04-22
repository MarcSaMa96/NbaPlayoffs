using Microsoft.EntityFrameworkCore;
using NbaPlayoffs.Domain.Models;
using NbaPlayoffs.Domain.Repositories.Interfaces;

namespace NbaPlayoffs.Domain.Repositories.Implementations
{
    public class PlayoffGuessHeaderRepository : Repository<PlayoffGuessHeader>, IPlayoffGuessHeaderRepository
    {
        private NbaPlayoffContext _context;

        public PlayoffGuessHeaderRepository(NbaPlayoffContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PlayoffGuessHeader> GetByEmail(string email) => await _context.PlayoffGuessHeaders.Where(x => x.Email == email).FirstOrDefaultAsync();
    }
}
