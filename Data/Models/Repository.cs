using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Data.Models
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _SpContextDb;
        private readonly Microsoft.EntityFrameworkCore.DbSet<TEntity> _Entity;
        private bool disposed = false;
        public Microsoft.EntityFrameworkCore.DbContext spDbContext => _SpContextDb;

        public Microsoft.EntityFrameworkCore.DbSet<TEntity> Entity => _Entity;

        public Repository(Microsoft.EntityFrameworkCore.DbContext spContextDb)
        {
            this._SpContextDb = spContextDb;
            this._Entity = spContextDb.Set<TEntity>();
        }

        public void Dispose()
        {
            if (!this.disposed)
            {
                _SpContextDb.Dispose();
            }
            this.disposed = true;
        }
        public IQueryable<TEntity> AsQueryable()
        {
            return Entity.AsQueryable<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Entity.AddAsync(entity);
            await Save();
            this.Detached(entity);
            return entity;
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            Entity.Remove(entity);
            await Save();
            return entity;
        }

        public void Detached(TEntity entity)
        {
            spDbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }



        public async Task<TEntity> Put(TEntity entity)
        {
            spDbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Entity.Update(entity);
            await Save();
            return entity;
        }

        public Task<int> Save()
        {
            return spDbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteRange(ICollection<TEntity> range)
        {
            spDbContext.RemoveRange(range);
            return true;
        }
    }
}
