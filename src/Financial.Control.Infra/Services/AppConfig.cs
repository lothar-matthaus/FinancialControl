using Financial.Control.Domain.Interfaces.Config;
using Financial.Control.Infra.Services.Config;
using Microsoft.Extensions.Configuration;

namespace Financial.Control.Infra.Services
{
    public class AppConfig : IAppConfig
    {
        #region Private Members
        private readonly IConfiguration _configuration;
        private IDatabaseConfig _dbConfig;
        #endregion

        public AppConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Properties
        public IDatabaseConfig DbConfig => _dbConfig ?? new DatabaseConfig(_configuration);
        public string ApiVersion => _configuration.GetSection(nameof(ApiVersion)).Value ?? string.Empty;
        public string ApiName => _configuration.GetSection(nameof(ApiName)).Value ?? string.Empty;
        #endregion

    }
}
