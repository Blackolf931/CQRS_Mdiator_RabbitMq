namespace DAL.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct);
        Task<TEntity> GetByIdAsync(int id, CancellationToken ct);
        Task DeleteByIdAsync(TEntity entity, CancellationToken ct);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken ct);
        Task<TEntity> Update(TEntity entity, CancellationToken ct);
    }
}