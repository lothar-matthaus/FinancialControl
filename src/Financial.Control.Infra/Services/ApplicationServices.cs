using Financial.Control.Domain.Interfaces.Config;
using Financial.Control.Domain.Interfaces.Services;

namespace Financial.Control.Infra.Services
{
    public class ApplicationServices : IApplicationServices
    {
        public ApplicationServices(IAppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        #region Private
        private readonly IAppConfig _appConfig;
        private IAuthenticationService _authenticationService;
        #endregion

        public IAuthenticationService AuthenticationService => _authenticationService ?? new AuthenticationService(_appConfig);
    }
}
