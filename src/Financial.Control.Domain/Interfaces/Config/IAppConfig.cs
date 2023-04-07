namespace Financial.Control.Domain.Interfaces.Config
{
    public interface IAppConfig
    {
        public IDatabaseConfig DbConfig { get; }
    }
}
