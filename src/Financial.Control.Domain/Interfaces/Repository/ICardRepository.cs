using Financial.Control.Domain.Entities;
using System.Linq.Expressions;

namespace Financial.Control.Domain.Interfaces.Repository
{
    public interface ICardRepository
    {
        public IQueryable<Card> Query(Expression<Func<Card, bool>> expression);
        public void Update(Card user);
    }
}
