using Financial.Control.Domain.Interfaces.Config;

namespace Financial.Control.Domain.Interfaces
{
    public interface IApplication
    {
        public IAppConfig AppConfig { get; }
    }
}
