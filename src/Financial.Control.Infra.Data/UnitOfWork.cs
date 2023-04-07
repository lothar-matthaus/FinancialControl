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

        public IUserRepository Users => _userRepository ?? new UserRepository(_dbContext);

        public void Commit() => _dbContext.SaveChanges();
    }
}
