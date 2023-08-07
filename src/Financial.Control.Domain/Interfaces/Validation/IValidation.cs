using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Entities.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
