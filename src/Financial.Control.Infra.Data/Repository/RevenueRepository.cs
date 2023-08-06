using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository;
using Financial.Control.Infra.Data.Repository.Base;

namespace Financial.Control.Infra.Data.Repository
{
    public class RevenueRepository : BaseRepository<Revenue, FinancialControlDbContext>, IRevenueRepository
    {
        public RevenueRepository(FinancialControlDbContext dbContext) : base(dbContext) { }

        public void Delete(Revenue revenue) => _dbContext.Remove(revenue);
    }
}
