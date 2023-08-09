using Financial.Control.Domain.Interfaces.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Financial.Control.Infra.Data.Repository.Base
{
    public abstract class BaseRepository<TEntity, TDbContext> : IRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {
        protected readonly DbSet<TEntity> _dbContext;
        public BaseRepository(TDbContext dbContext)
        {
            _dbContext = dbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken) => await _dbContext.AddAsync(entity, cancellationToken);
        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression) => _dbContext.Where(expression);
        public void Update(TEntity entity) => _dbContext.Update(entity);
    }
}
