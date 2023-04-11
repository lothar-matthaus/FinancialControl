using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository;
using Financial.Control.Infra.Data.Repository.Base;
using System.Linq.Expressions;

namespace Financial.Control.Infra.Data.Repository
{
    public class CardRepository : BaseRepository<FinancialControlDbContext>, ICardRepository
    {
        public CardRepository(FinancialControlDbContext dbContext) : base(dbContext) { }

        public IQueryable<Card> Query(Expression<Func<Card, bool>> expression) => _dbContext.Cards.Where(expression);
        public void Update(Card card) => _dbContext.Update(card);
    }
}
