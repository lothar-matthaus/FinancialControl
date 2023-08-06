using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository;
using Financial.Control.Infra.Data.Repository.Base;

namespace Financial.Control.Infra.Data.Repository
{
    public class CategoryRepository : BaseRepository<Category, FinancialControlDbContext>, ICategoryRepository
    {
        public CategoryRepository(FinancialControlDbContext dbContext) : base(dbContext) { }
    }
}
