using Microsoft.EntityFrameworkCore;
using NbaPlayoffs.Domain.Models;
using NbaPlayoffs.Domain.Repositories.Interfaces;

namespace NbaPlayoffs.Domain.Repositories.Implementations
{
    public class TeamRecordRepository : Repository<TeamRecord>, ITeamRecordRepository
    {
        private NbaPlayoffContext _context;

        public TeamRecordRepository(NbaPlayoffContext context) : base(context)
        {
            _context = context;
        }

        public async Task<TeamRecord> GetTeamPlayersByYear(int idTeam, int year) => await _context.TeamRecords
            .Where(x => x.TeamId == idTeam && x.Year == year)
            .Include(t => t.Team)
            .Include(pr => pr.PlayerRecords)
            .ThenInclude(p => p.Player)
            .ThenInclude(pp => pp.PlayerPosition)
            .FirstOrDefaultAsync() ?? throw new Exception("No se encuentra");
    }
}
