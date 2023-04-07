using Financial.Control.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        public IQueryable<User> Query(Expression<Func<User, bool>> expression);
        public void Add(User user);
        public void Update(User user);
    }
}
