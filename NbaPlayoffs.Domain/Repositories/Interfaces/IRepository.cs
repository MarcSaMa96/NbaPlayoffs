using System.Linq.Expressions;

namespace NbaPlayoffs.Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(string? include = null);
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        TEntity GetConditioned(Func<TEntity, bool> condition);
        Task SaveAsync();
    }
}
