using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository;
using Financial.Control.Infra.Data.Repository.Base;

namespace Financial.Control.Infra.Data.Repository
{
    public class ExpenseRepository : BaseRepository<Expense, FinancialControlDbContext>, IExpenseRepository
    {
        public ExpenseRepository(FinancialControlDbContext dbContext) : base(dbContext) { }

        public void Delete(Expense expense) => _dbContext.Remove(expense);
    }
}
