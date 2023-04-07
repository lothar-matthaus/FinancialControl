using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Config;
using Financial.Control.Domain.Repository;
using Financial.Control.Infra.Data;
using Microsoft.Extensions.Configuration;

namespace Financial.Control.Infra.Services
{
    public class Application : IApplication
    {
        #region Private Members
        private readonly IConfiguration _configuration;
        private IAppConfig _appConfig;
        private IUnitOfWork _unitOfWork;
        #endregion

        public Application(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        #region Properties
        public IAppConfig AppConfig => _appConfig ?? new AppConfig(_configuration);

        public IUnitOfWork UnitOfWork => _unitOfWork;
        #endregion
    }
}
