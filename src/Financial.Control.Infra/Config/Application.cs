using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Config;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Repository;
using Financial.Control.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Financial.Control.Infra.Config
{
    public class Application : IApplication
    {
        #region Private Members
        private readonly IConfiguration _configuration;
        private IAppConfig _appConfig;
        private IUnitOfWork _unitOfWork;
        private IApplicationServices _services;
        private IApplicationUser _currentUser;
        private IHttpContextAccessor _httpContext;
        #endregion

        public Application(IConfiguration configuration, IUnitOfWork unitOfWork, IHttpContextAccessor httpContext)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _httpContext = httpContext;
        }

        #region Properties
        public IAppConfig AppConfig => _appConfig ?? new AppConfig(_configuration);
        public IUnitOfWork UnitOfWork => _unitOfWork;
        public IApplicationServices Services => _services ?? new ApplicationServices(AppConfig);
        public IApplicationUser CurrentUser => _currentUser ?? new ApplicationUser(_httpContext);

        #endregion
    }
}
