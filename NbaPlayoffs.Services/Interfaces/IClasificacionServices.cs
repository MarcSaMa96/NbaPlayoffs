using NbaPlayoffs.Services.DTOs;

namespace NbaPlayoffs.Services.Interfaces
{
    public interface IClasificacionServices
    {
        Task<Dictionary<string, List<ClasificacionDto>>> GetAllByYear(int year);
    }
}
