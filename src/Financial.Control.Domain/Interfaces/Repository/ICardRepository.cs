using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository.Base;

namespace Financial.Control.Domain.Interfaces.Repository
{
    public interface ICardRepository : IRepository<Card>
    {
        void Delete(Card card);
        Task<bool> CardAlreadyExists(string cardNumber, CancellationToken cancellationToken);
    }
}
