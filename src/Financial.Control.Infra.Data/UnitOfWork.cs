using Financial.Control.Domain.Interfaces.Repository;
using Financial.Control.Domain.Repository;

namespace Financial.Control.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FinancialControlDbContext _dbContext;

        public UnitOfWork(FinancialControlDbContext dbContext,
            IUserRepository userRepository,
            ICardRepository cardRepository,
            IRevenueRepository revenueRepository,
            ICategoryRepository categoryRepository
        )
        {
            _dbContext = dbContext;
            Users = userRepository;
            Cards = cardRepository;
            Revenues = revenueRepository;
            Categories = categoryRepository;
        }

        public IUserRepository Users { get; }
        public ICardRepository Cards { get; }
        public IRevenueRepository Revenues { get; }
        public ICategoryRepository Categories { get; }

        public async Task Commit(CancellationToken cancellationToken) => await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
