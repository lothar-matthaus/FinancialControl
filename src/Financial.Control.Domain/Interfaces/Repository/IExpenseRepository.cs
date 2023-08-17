using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository.Base;

namespace Financial.Control.Domain.Interfaces.Repository
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        public void Delete(Expense expense);
    }
}
