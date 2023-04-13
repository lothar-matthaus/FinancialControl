using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository;
using Financial.Control.Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace Financial.Control.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<FinancialControlDbContext>, IUserRepository
    {
        public UserRepository(FinancialControlDbContext dbContext) : base(dbContext) { }

        public void Add(User user) => _dbContext.Add(user);

        public bool EmailAlreadyExists(string email)
        {
            return _dbContext.Users.Where(user => user.Account.Email.Value.Equals(email)).Any();
        }

        public IQueryable<User> Query(Expression<Func<User, bool>> expression) => _dbContext.Users.Where(expression).Include(us => us.Account);
        public void Update(User user) => _dbContext.Update(user);
    }
}
