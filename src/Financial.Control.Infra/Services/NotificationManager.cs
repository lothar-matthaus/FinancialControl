using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces.Services;

namespace Financial.Control.Infra.Services
{
    public class NotificationManager : INotificationManager
    {
        public List<Notification> Notifications { get; private set; } = new List<Notification>();

        public bool IsValidState => !Notifications.Any();

        public void AddNotification(Notification notification)
        {
            Notifications ??= new List<Notification>();
            Notifications.Add(notification);
        }

        public void AddNotification(string context, string field, string message)
        {
            Notification notification = Notification.Create(context, field, new string[] { message });
            Notifications.Add(notification);

        }

        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            Notifications ??= new List<Notification>();
            Notifications.AddRange(notifications);
        }

        public IReadOnlyCollection<Notification> GetAllNotifications() => Notifications;

        public bool HasNotifications() => Notifications.Any();

        public void RemoveNotification(Notification notification)
        {
            Notifications.Remove(notification);
        }
    }
}
