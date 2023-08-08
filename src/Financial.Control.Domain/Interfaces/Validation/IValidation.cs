using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Interfaces.Validation
{
    public interface IValidation
    {
        #region Properties
        bool IsValid { get; }
        #endregion

        #region Behaviors
        public IReadOnlyCollection<Notification> GetNotifications();
        void Validate(bool isInvalid, Func<Notification> ifInvalid, Action ifValid);
        #endregion
    }
}
