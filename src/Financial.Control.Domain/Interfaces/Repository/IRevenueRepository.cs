using Financial.Control.Domain.Entities;
using System.Linq.Expressions;

namespace Financial.Control.Domain.Interfaces.Repository
{
    public interface IRevenueRepository
    {
        public IQueryable<Revenue> Query(Expression<Func<Revenue, bool>> expression);
        public void Update(Revenue user);
    }
}
