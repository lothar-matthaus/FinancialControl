using Financial.Control.Domain.Interfaces.Repository;
using Financial.Control.Domain.Repository;
using Financial.Control.Infra.Data.Repository;

namespace Financial.Control.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FinancialControlDbContext _dbContext;

        public UnitOfWork(FinancialControlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IUserRepository _userRepository;
        private ICardRepository _cardRepository;
        private IRevenueRepository _revenueRepository;
        private ICategoryRepository _categoryRepository;

        public IUserRepository Users => _userRepository ?? new UserRepository(_dbContext);
        public ICardRepository Cards => _cardRepository ?? new CardRepository(_dbContext);
        public IRevenueRepository Revenues => _revenueRepository ?? new RevenueRepository(_dbContext);
        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_dbContext);

        public async Task Commit(CancellationToken cancellationToken) => await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
