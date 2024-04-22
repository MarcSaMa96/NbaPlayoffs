using NbaPlayoffs.Services.DTOs;

namespace NbaPlayoffs.Services.Interfaces
{
    public interface IFavouriteTeamServices
    {
        Task<ResponseDto> Save(FavouriteTeamDto favouriteTeam);
    }
}
