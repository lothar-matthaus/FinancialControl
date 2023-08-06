using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository.Base;

namespace Financial.Control.Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<bool> EmailAlreadyExists(string email);
        public void Update(User user);
    }
}
