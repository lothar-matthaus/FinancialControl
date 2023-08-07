using Financial.Control.Domain.Interfaces.Config;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Infra.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Control.Infra
{
    public class ApplicationServices : IApplicationServices
    {
        public ApplicationServices(IAuthenticationService authenticationService, INotificationManager notificationManager)
        {
            _authenticationService = authenticationService;
            _notificationManager = notificationManager;
        }

        #region Private
        private IAuthenticationService _authenticationService;
        private INotificationManager _notificationManager;
        #endregion

        public IAuthenticationService AuthenticationService => _authenticationService;
        public INotificationManager NotificationManager => _notificationManager;
    }
}
