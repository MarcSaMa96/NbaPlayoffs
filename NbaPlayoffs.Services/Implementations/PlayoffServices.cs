using AutoMapper;
using NbaPlayoffs.Domain;
using NbaPlayoffs.Domain.Models;
using NbaPlayoffs.Domain.Repositories.Interfaces;
using NbaPlayoffs.Services.DTOs;
using NbaPlayoffs.Services.Interfaces;

namespace NbaPlayoffs.Services.Implementations
{
    public class PlayoffServices : IPlayoffServices
    {
        private readonly IClasificacionServices _clasificacionServices;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlayoffGuessHeaderRepository _playoffGuessHeaderRepository;
        private readonly IMapper _mapper;

        public PlayoffServices(IClasificacionServices clasificacionServices, 
            IUnitOfWork unitOfWork,
            IPlayoffGuessHeaderRepository playoffGuessHeaderRepository,
            IMapper mapper)
        {
            _clasificacionServices = clasificacionServices;
            _unitOfWork = unitOfWork;
            _playoffGuessHeaderRepository = playoffGuessHeaderRepository;
            _mapper = mapper;
        }

        #region Public Methods
        public async Task<Dictionary<string, List<PlayoffTeamDto>>> GetFirstRoundTeams()
        {
            Dictionary<string, List<PlayoffTeamDto>> result = new();

            var classification = await _clasificacionServices.GetAllByYear(DateTime.Now.Year);

            foreach (var conference in classification.Keys)
            {
                result.Add(conference, GetPlayoffTeamDto(classification[conference].OrderBy(x => x.Position).ToList(), new List<PlayoffTeamDto>()));
            }

            return result;
        }

        public async Task<ResponseDto> InsertPrediction(PlayoffPredictionDto prediction)
        {
            try
            {
                var header = _mapper.Map<PlayoffGuessHeader>(prediction);

                var dbHeader = await _playoffGuessHeaderRepository.GetByEmail(header.Email);

                if (dbHeader != null && dbHeader.Id != 0) 
                {
                    return new ResponseDto
                    {
                        Success = false,
                        Message = "Already exists a prediction for this email"
                    };
                }

                foreach (var team in prediction.Teams)
                {
                    var guess = _mapper.Map<PlayoffGuess>(team);
                    guess.PlayoffGuessHeaderId = header.Id;

                    header.PlayoffGuesses.Add(guess);
                }

                await _unitOfWork.PlayoffGuessHeaders.AddAsync(header);
                await _unitOfWork.SaveAsync();

                return new ResponseDto
                {
                    Success = true,
                    Message = "Your prediction has been succesfully saved!"
                };
            }
            catch(Exception ex)
            {
                throw;
            }

        }
        #endregion

        #region Private Methods
        private List<PlayoffTeamDto> GetPlayoffTeamDto(List<ClasificacionDto> classification, List<PlayoffTeamDto> playoff)
        {
            if (classification.Count > 0)
            { 
                PlayoffTeamDto playoffDto = new();

                // Si tenemos un numero par de equipos en clasificación obtenemos el valor del primer equipo, si no del último
                // Se re ordena la lista para que quede 1,8,2,7,3,6,4,5
                if (classification.Count % 2 == 0) 
                {
                    playoffDto.TeamName = classification.First().TeamName;
                    playoffDto.TeamRecordId = classification.First().TeamRecordId;
                    classification.RemoveAt(0);
                }
                else
                {
                    playoffDto.TeamName = classification.Last().TeamName;
                    playoffDto.TeamRecordId = classification.Last().TeamRecordId;
                    classification.RemoveAt(classification.Count - 1);
                }

                playoffDto.BracketGroup = playoff.Count == 0 ? 0 : playoff.Count / 4; // Posibles rivales proxima fase
                playoffDto.Bracket = playoff.Count == 0 ? 0 : playoff.Count / 2; // Rivales directos

                playoff.Add(playoffDto);

                return GetPlayoffTeamDto(classification, playoff);   
            }
            else
            {
                return playoff;
            }
        }
        #endregion
    }
}
