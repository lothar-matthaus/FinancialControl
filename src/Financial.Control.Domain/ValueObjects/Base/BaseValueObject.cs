using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces.Validation;

namespace Financial.Control.Domain.ValueObjects.Base
{
    public abstract record BaseValueObject : IValidation
    {
        protected BaseValueObject() { }
        protected List<Notification> _notifications { get; private set; } = new List<Notification>();

        public IReadOnlyCollection<Notification> GetNotifications() => _notifications;

        public void Validate(bool isInvalidIf, Func<Notification> ifInvalid, Action ifValid)
        {
            if (isInvalidIf)
            {
                _notifications ??= new List<Notification>();
                _notifications.Add(ifInvalid.Invoke());
            }
            else
            {
                ifValid.Invoke();
            }
        }

        public bool IsValid() => !_notifications.Any();
    }
}
