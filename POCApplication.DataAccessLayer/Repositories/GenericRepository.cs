using Microsoft.EntityFrameworkCore;
using POCApplication.DataAccessLayer.DataContext;
using POCApplication.DataAccessLayer.Repositories.Interfaces;
using System.Linq.Expressions;

namespace POCApplication.DataAccessLayer.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GenericRepository(ApplicationDbContext aspNetCoreNTierDbContext)
        {
            _applicationDbContext = aspNetCoreNTierDbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _applicationDbContext.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entity)
        {
            await _applicationDbContext.AddRangeAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            _ = _applicationDbContext.Remove(entity);
            return await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return await _applicationDbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter, cancellationToken);
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return await (filter == null ? _applicationDbContext.Set<TEntity>().ToListAsync(cancellationToken) : _applicationDbContext.Set<TEntity>().Where(filter).ToListAsync(cancellationToken));
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _ = _applicationDbContext.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entity)
        {
            _applicationDbContext.UpdateRange(entity);
            await _applicationDbContext.SaveChangesAsync();
            return entity;
        }
    }
}