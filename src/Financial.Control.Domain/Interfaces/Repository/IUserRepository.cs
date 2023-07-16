using Financial.Control.Domain.Entities;
using System.Linq.Expressions;

namespace Financial.Control.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        public IQueryable<User> Query(Expression<Func<User, bool>> expression);
        public void Add(User user);
        public Task<bool> EmailAlreadyExists(string email);
        public void Update(User user);
    }
}
