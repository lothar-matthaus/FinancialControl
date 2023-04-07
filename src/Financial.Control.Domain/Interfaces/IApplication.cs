using Financial.Control.Domain.Interfaces.Config;
using Financial.Control.Domain.Repository;

namespace Financial.Control.Domain.Interfaces
{
    public interface IApplication
    {
        public IAppConfig AppConfig { get; }
        public IUnitOfWork UnitOfWork { get; }
    }
}
