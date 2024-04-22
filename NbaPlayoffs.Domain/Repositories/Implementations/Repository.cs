using Microsoft.EntityFrameworkCore;
using NbaPlayoffs.Domain.Models;
using NbaPlayoffs.Domain.Repositories.Interfaces;
using System.Linq.Expressions;

namespace NbaPlayoffs.Domain.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected NbaPlayoffContext _context;
        private DbSet<TEntity> _dbSet;

        public Repository(NbaPlayoffContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        
        public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync(string? include = null) => include == null 
            ? await _dbSet.ToListAsync()
            : await _dbSet.Include(include).ToListAsync();


        public async Task<TEntity> GetByIdAsync(int id) => await _dbSet.FindAsync(id) ?? throw new Exception("No encontrado");

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public TEntity GetConditioned(Func<TEntity, bool> condition) => _dbSet.Where(condition).FirstOrDefault();
    }
}
