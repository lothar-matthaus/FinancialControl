using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Config;
using Microsoft.Extensions.Configuration;

namespace Financial.Control.Infra.Services
{
    public class Application : IApplication
    {
        #region Private Members
        private readonly IConfiguration _configuration;
        private IAppConfig _appConfig;
        #endregion

        public Application(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Properties
        public IAppConfig AppConfig => _appConfig ?? new AppConfig(_configuration);
        #endregion
    }
}
