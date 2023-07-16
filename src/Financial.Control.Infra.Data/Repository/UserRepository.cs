using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository;
using Financial.Control.Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Financial.Control.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<FinancialControlDbContext>, IUserRepository
    {
        public UserRepository(FinancialControlDbContext dbContext) : base(dbContext) { }

        public async void Add(User user) => await _dbContext.AddAsync(user);

        public async Task<bool> EmailAlreadyExists(string email)
        {
            return await _dbContext.Users.Where(user => user.Account.Email.Value.Equals(email)).AnyAsync();
        }

        public IQueryable<User> Query(Expression<Func<User, bool>> expression) => _dbContext.Users.Where(expression).Include(us => us.Account);
        public void Update(User user) => _dbContext.Update(user);
    }
}
