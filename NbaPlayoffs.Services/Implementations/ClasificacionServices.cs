using AutoMapper;
using NbaPlayoffs.Domain;
using NbaPlayoffs.Domain.Models;
using NbaPlayoffs.Services.DTOs;
using NbaPlayoffs.Services.Interfaces;

namespace NbaPlayoffs.Services.Implementations
{
    public class ClasificacionServices : IClasificacionServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClasificacionServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Public Methods
        public async Task<Dictionary<string, List<ClasificacionDto>>> GetAllByYear(int year)
        {
            Dictionary<string, List<ClasificacionDto>> result = new();

            IEnumerable<Conference> conferences = await _unitOfWork.Conferences.GetAllAsync("Teams.TeamRecords");

            // Filtramos para que en TeamRecords solo haya registros de el año seleccionado
            var filteredConferences = conferences.Select(c =>
            {
                var filteredReg = c.Teams.Select(t =>
                {
                    t.TeamRecords = t.TeamRecords.Where(tr => tr.Year == year).ToList();
                    return t;
                }).ToList();

                c.Teams = filteredReg;
                return c;

            }).ToList();

            Dictionary<string, IEnumerable<Team>> confDic = filteredConferences
                .ToDictionary(x => x.Name, x => x.Teams.Where(t => t.TeamRecords.Any(tr => tr.Year == year)));

            foreach (var conf in confDic)
            {
                result.Add(conf.Key, GetClasificacion(conf.Value, year).ToList());
            }

            return result;
        }
        #endregion

        #region Private Methods
        private IEnumerable<ClasificacionDto> GetClasificacion(IEnumerable<Team> teams, int year)
        {
            foreach(var team in teams)
            {
                ClasificacionDto clasificacion = _mapper.Map<ClasificacionDto>(team);

                clasificacion.Position = teams
                    .Where(x => 
                        x.Id != team.Id 
                        && (x.TeamRecords.First().Wins - x.TeamRecords.First().Losses) > (team.TeamRecords.First().Wins - team.TeamRecords.First().Losses)
                    )
                    .Count() + 1;

                yield return clasificacion;
            }
        }
        #endregion
    }
}
