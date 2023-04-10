using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository;
using Financial.Control.Infra.Data.Repository.Base;
using System.Linq.Expressions;

namespace Financial.Control.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<FinancialControlDbContext>, IUserRepository
    {
        public UserRepository(FinancialControlDbContext dbContext) : base(dbContext) { }

        public void Add(User user) => _dbContext.Add(user);
        public IQueryable<User> Query(Expression<Func<User, bool>> expression) => _dbContext.Users.Where(expression);
        public void Update(User user) => _dbContext.Update(user);
    }
}
