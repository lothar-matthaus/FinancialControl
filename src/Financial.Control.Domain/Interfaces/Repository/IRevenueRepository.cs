using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Repository.Base;

namespace Financial.Control.Domain.Interfaces.Repository
{
    public interface IRevenueRepository : IRepository<Revenue>
    {
        public void Update(Revenue revenue);
        public void Delete(Revenue revenue);
    }
}
