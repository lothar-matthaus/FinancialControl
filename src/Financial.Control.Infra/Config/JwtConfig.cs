using Financial.Control.Domain.Interfaces.Config;
using Microsoft.Extensions.Configuration;

namespace Financial.Control.Infra.Config
{
    public class JwtConfig : IJwtConfig
    {
        private readonly IConfigurationSection _section;

        public JwtConfig(IConfiguration configuration)
        {
            _section = configuration.GetSection("Jwt");
        }

        public string Secret => _section.GetSection("Secret").Value;
        public string Issuer => _section.GetSection("Issuer").Value;
        public int ExpirationTime => int.Parse(_section.GetSection("ExpirationTime").Value ?? "0");

    }
}
