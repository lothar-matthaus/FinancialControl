using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository;
using Financial.Control.Infra.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<FinancialControlDbContext>, IUserRepository
    {
        public UserRepository(FinancialControlDbContext dbContext) : base(dbContext) { }
        public void Add(User user)
        {
            _dbContext.Add(user);
        }

        public IQueryable<User> Query(Expression<Func<User, bool>> expression)
        {
            return _dbContext.Users.Where(expression);
        }

        public void Update(User user)
        {
            _dbContext.Update(user);
        }
    }
}
