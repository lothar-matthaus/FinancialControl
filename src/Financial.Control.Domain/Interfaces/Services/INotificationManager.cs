using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.ValueObjects.Base;

namespace Financial.Control.Domain.Interfaces.Services
{
    public interface INotificationManager
    {
        public List<Notification> Notifications { get; }

        #region Methods
        public bool HasNotifications();
        void AddNotification(Notification notification);
        void AddNotification(string context, string field, string message);
        void AddNotifications(IReadOnlyCollection<Notification> notifications);
        void RemoveNotification(Notification notification);
        IReadOnlyCollection<Notification> GetAllNotifications();
        #endregion
    }
}
