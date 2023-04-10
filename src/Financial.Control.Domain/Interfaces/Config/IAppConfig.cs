namespace Financial.Control.Domain.Interfaces.Config
{
    public interface IAppConfig
    {
        public string ApiVersion { get; }
        public string ApiName { get; }
        public IDatabaseConfig DbConfig { get; }
        public IJwtConfig JwtConfig { get; }
    }
}
