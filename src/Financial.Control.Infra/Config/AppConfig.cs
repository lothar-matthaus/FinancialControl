using Financial.Control.Domain.Interfaces.Config;
using Microsoft.Extensions.Configuration;

namespace Financial.Control.Infra.Config
{
    public class AppConfig : IAppConfig
    {
        #region Private Members
        private readonly IConfiguration _configuration;
        private IDatabaseConfig _dbConfig;
        private IJwtConfig _jwtConfig;
        #endregion

        public AppConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Properties
        public IDatabaseConfig DbConfig => _dbConfig ?? new DatabaseConfig(_configuration);
        public string ApiVersion => _configuration.GetSection(nameof(ApiVersion)).Value ?? string.Empty;
        public string ApiName => _configuration.GetSection(nameof(ApiName)).Value ?? string.Empty;
        public IJwtConfig JwtConfig => _jwtConfig ?? new JwtConfig(_configuration);

        #endregion

    }
}
