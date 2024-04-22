using AutoMapper;
using NbaPlayoffs.Domain;
using NbaPlayoffs.Domain.Models;
using NbaPlayoffs.Domain.Repositories.Interfaces;
using NbaPlayoffs.Services.DTOs;
using NbaPlayoffs.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbaPlayoffs.Services.Implementations
{
    public class FavouriteTeamServices : IFavouriteTeamServices
    {
        private IUnitOfWork _unitOfWork;
        private IFavouriteTeamRepository _favouriteTeamRepository;
        private IMapper _mapper;

        public FavouriteTeamServices(IUnitOfWork unitOfWork, IMapper mapper, IFavouriteTeamRepository favouriteTeamRepository)
        {
            _unitOfWork = unitOfWork;
            _favouriteTeamRepository = favouriteTeamRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto> Save(FavouriteTeamDto favouriteTeam)
        {
            ResponseDto response = new();

            try
            {
                var favouriteDb = await _favouriteTeamRepository.GetByEmail(favouriteTeam.Email);

                if(favouriteDb != null && favouriteDb.Id != 0)
                {
                    response.Success = false;
                    response.Message = "Already exists a favourite Team for this email";
                }
                else
                {
                    var favourite = _mapper.Map<FavouriteTeam>(favouriteTeam);
                    await _unitOfWork.FavouriteTeams.AddAsync(favourite);
                    await _unitOfWork.SaveAsync();

                    response.Success = true;
                    response.Message = "Favourite Team saved!";
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
