using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Interfaces.Validation
{
    public interface IValidation
    {
        #region Behaviors
        public IReadOnlyCollection<Notification> GetNotifications();
        void Validate(bool isInvalidIf, Func<Notification> ifInvalid, Action ifValid);
        bool IsValid();

        #endregion
    }
}
