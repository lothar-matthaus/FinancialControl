using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository;
using Financial.Control.Infra.Data.Repository.Base;
using System.Linq.Expressions;

namespace Financial.Control.Infra.Data.Repository
{
    public class RevenueRepository : BaseRepository<FinancialControlDbContext>, IRevenueRepository
    {
        public RevenueRepository(FinancialControlDbContext dbContext) : base(dbContext) { }

        public IQueryable<Revenue> Query(Expression<Func<Revenue, bool>> expression) => _dbContext.Revenues.Where(expression);
        public void Update(Revenue revenue) => _dbContext.Update(revenue);
    }
}
