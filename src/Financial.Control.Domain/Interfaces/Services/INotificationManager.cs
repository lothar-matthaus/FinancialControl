using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Interfaces.Services
{
    public interface INotificationManager
    {
        public List<Notification> Notifications { get; }
        public bool IsValidState { get; }

        #region Methods
        void AddNotification(Notification notification);
        void RemoveNotification(Notification notification);
        IReadOnlyCollection<Notification> GetAllNotifications();
        #endregion
    }
}
