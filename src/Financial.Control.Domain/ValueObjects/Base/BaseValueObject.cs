using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces.Validation;

namespace Financial.Control.Domain.ValueObjects.Base
{
    public abstract record BaseValueObject : IValidation
    {
        protected BaseValueObject() { }

        public bool IsValid { get; private set; }

        protected List<Notification> _notifications { get; private set; } = new List<Notification>();

        public IReadOnlyCollection<Notification> GetNotifications() => _notifications;

        public void Validate(bool isInvalid, Func<Notification> ifInvalid, Action ifValid)
        {
            if (isInvalid)
            {
                _notifications ??= new List<Notification>();
                _notifications.Add(ifInvalid.Invoke());
            }
            else
            {
                ifValid.Invoke();
            }

            IsValid = !_notifications.Any();
        }
    }
}
