namespace Financial.Control.Domain.Interfaces.Config
{
    public interface IJwtConfig
    {
        public string Secret { get; }
        public string Issuer { get; }
        public int ExpirationTime { get; }
    }
}
