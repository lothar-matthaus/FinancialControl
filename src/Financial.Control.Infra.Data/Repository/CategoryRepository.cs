using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository;
using Financial.Control.Infra.Data.Repository.Base;
using System.Linq.Expressions;

namespace Financial.Control.Infra.Data.Repository
{
    public class CategoryRepository : BaseRepository<FinancialControlDbContext>, ICategoryRepository
    {
        public CategoryRepository(FinancialControlDbContext dbContext) : base(dbContext) { }
        public IQueryable<Category> Query(Expression<Func<Category, bool>> expression) => _dbContext.Categories.Where(expression);
    }
}
