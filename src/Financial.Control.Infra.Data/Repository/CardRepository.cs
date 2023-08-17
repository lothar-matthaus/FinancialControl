using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository;
using Financial.Control.Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Financial.Control.Infra.Data.Repository
{
    public class CardRepository : BaseRepository<Card, FinancialControlDbContext>, ICardRepository
    {
        public CardRepository(FinancialControlDbContext dbContext) : base(dbContext) { }

        public async Task<bool> CardAlreadyExists(string cardNumber, CancellationToken cancellationToken) =>
            await _dbContext.Where(card => card.Number.Equals(cardNumber)).AnyAsync(cancellationToken);

        public void Delete(Card card) => _dbContext.Remove(card);
    }
}
