using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DataBaseContext _dataBaseContext;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
            _dbSet = _dataBaseContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken ct)
        {
            await _dbSet.AddAsync(entity, ct);
            await _dataBaseContext.SaveChangesAsync(ct);
            return entity;
        }

        public async Task DeleteByIdAsync(TEntity entity, CancellationToken ct)
        {
            _dbSet.Remove(entity);
            await _dataBaseContext.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().ToListAsync(ct);
        }

        public async Task<TEntity> GetByIdAsync(int id, CancellationToken ct)
        {
            return await _dbSet.FindAsync(new object[] { id }, ct);
        }

        public async Task<TEntity> Update(TEntity entity, CancellationToken ct)
        {
            _dbSet.Update(entity);
            await _dataBaseContext.SaveChangesAsync(ct);
            return entity;
        }
    }
}
