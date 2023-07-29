using Financial.Control.Domain.Interfaces.Repository;

namespace Financial.Control.Domain.Repository
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }
        public ICardRepository Cards { get; }
        public IRevenueRepository Revenues { get; }
        public ICategoryRepository Categories { get; }

        public Task Commit(CancellationToken cancellationToken);
    }
}
