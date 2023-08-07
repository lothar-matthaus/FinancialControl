namespace Financial.Control.Domain.Interfaces.Services
{
    public interface IApplicationServices
    {
        public IAuthenticationService AuthenticationService { get; }
        public INotificationManager NotificationManager { get; }
    }
}
