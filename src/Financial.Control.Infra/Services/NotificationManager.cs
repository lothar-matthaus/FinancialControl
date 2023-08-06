using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces.Services;

namespace Financial.Control.Infra.Services
{
    public class NotificationManager : INotificationManager
    {
        public List<Notification> Notifications { get; private set; }

        public bool IsValidState => !Notifications.Any();

        public void AddNotification(Notification notification)
        {
            Notifications ??= new List<Notification>();

            Notifications.Add(notification);
        }

        public IReadOnlyCollection<Notification> GetAllNotifications() => Notifications;

        public void RemoveNotification(Notification notification)
        {
            Notifications.Remove(notification);
        }
    }
}
