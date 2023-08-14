using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository;
using Financial.Control.Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Infra.Data.Repository
{
    public class ExpenseRepository : BaseRepository<Expense, FinancialControlDbContext>, IExpenseRepository
    {
        public ExpenseRepository(FinancialControlDbContext dbContext) : base(dbContext) { }

        public void Delete(Expense expense) => _dbContext.Remove(expense);
    }
}
