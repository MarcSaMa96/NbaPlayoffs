using AutoMapper;
using NbaPlayoffs.Domain;
using NbaPlayoffs.Domain.Models;
using NbaPlayoffs.Domain.Repositories.Interfaces;
using NbaPlayoffs.Services.DTOs;
using NbaPlayoffs.Services.Interfaces;

namespace NbaPlayoffs.Services.Implementations
{
    public class TeamServices : ITeamServices
    {
        private readonly ITeamRecordRepository _teamRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeamServices(ITeamRecordRepository teamRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _teamRepository = teamRepository;
            _unitOfWork= unitOfWork;
            _mapper = mapper;
        }

        public async Task<TeamDto> GetByIdYear(int id, int year)
        {
            TeamDto result = new();

            var teamRecord = await _teamRepository.GetTeamPlayersByYear(id, year);

            result = _mapper.Map<TeamDto>(teamRecord);

            result.Players.ForEach(x => x.PointsPerGame = x.Points == 0 || x.GamesPlayed == 0 ? 0 : (double)x.Points / x.GamesPlayed);
            result.Players.ForEach(x => x.ReboundsPerGame = x.Rebounds == 0 || x.GamesPlayed == 0 ? 0 : (double)x.Rebounds / x.GamesPlayed);

            return result;
        }

        public async Task<List<TeamDto>> GetAll()
        {
            var teams = await _unitOfWork.Teams.GetAllAsync();

            return _mapper.Map<List<TeamDto>>(teams);
        }
    }
}
