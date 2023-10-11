using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public interface IRepository<TEntity> where TEntity : class
    {
        DbContext spDbContext { get; }
        DbSet<TEntity> Entity { get; }
        Task<TEntity> CreateAsync(TEntity entity);
        void Detached(TEntity entity);
        Task<TEntity> Put(TEntity entity);
        Task<TEntity> Delete(TEntity entity);
        Task<bool> DeleteRange(ICollection<TEntity> range);

        IQueryable<TEntity> AsQueryable();
        Task<int> Save();
        void Dispose();
    }
}
