using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository;
using Financial.Control.Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Financial.Control.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<User, FinancialControlDbContext>, IUserRepository
    {
        public UserRepository(FinancialControlDbContext dbContext) : base(dbContext) { }

        public async Task<bool> EmailAlreadyExists(string email) => await _dbContext.Where(user => user.Account.Email.Value.Equals(email)).AnyAsync();
    }
}
