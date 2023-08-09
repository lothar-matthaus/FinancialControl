using System.Linq.Expressions;

namespace Financial.Control.Domain.Interfaces.Repository.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression);
        public Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        public void Update(TEntity entity);
    }
}
