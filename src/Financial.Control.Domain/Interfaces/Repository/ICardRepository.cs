using Financial.Control.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Interfaces.Repository
{
    public interface ICardRepository
    {
        public IQueryable<Card> Query(Expression<Func<Card, bool>> expression);
        public void Update(Card user);
    }
}
