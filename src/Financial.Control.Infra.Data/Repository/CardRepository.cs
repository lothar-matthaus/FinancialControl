using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository;
using Financial.Control.Infra.Data.Repository.Base;

namespace Financial.Control.Infra.Data.Repository
{
    public class CardRepository : BaseRepository<Card, FinancialControlDbContext>, ICardRepository
    {
        public CardRepository(FinancialControlDbContext dbContext) : base(dbContext) { }

        public bool CardAlreadyExists(string cardNumber) => _dbContext.Where(card => card.CardNumber.Equals(cardNumber)).Any();
    }
}
