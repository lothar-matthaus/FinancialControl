using Financial.Control.Domain.Interfaces.Config;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Repository;

namespace Financial.Control.Domain.Interfaces
{
    public interface IApplication
    {
        public IApplicationUser CurrentUser { get; }
        public IAppConfig AppConfig { get; }
        public IUnitOfWork UnitOfWork { get; }
        public IApplicationServices Services { get; }
    }
}
