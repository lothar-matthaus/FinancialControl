using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Entities.Base
{
    public class BaseEntity
    {
        public long Id { get; }
        public DateTime CreationDate { get; }
        public DateTime UpdateDate { get; }

        #region Notifications
        protected List<Notification> _notifications { get; set; }
        #endregion

        protected void Validate(bool condition)
        {
            if (condition) { }
        }
        public IReadOnlyCollection<Notification> GetNotifications() => _notifications;
    }
}
