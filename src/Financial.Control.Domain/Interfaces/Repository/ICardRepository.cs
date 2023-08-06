using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository.Base;

namespace Financial.Control.Domain.Interfaces.Repository
{
    public interface ICardRepository : IRepository<Card>
    {
        public bool CardAlreadyExists(string cardNumber);
    }
}
