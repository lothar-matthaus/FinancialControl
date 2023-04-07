using Financial.Control.Domain.Interfaces.Repository;

namespace Financial.Control.Domain.Repository
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }

        public void Commit();
    }
}
