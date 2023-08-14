using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Interfaces.Repository
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        public void Delete(Expense expense);
    }
}
