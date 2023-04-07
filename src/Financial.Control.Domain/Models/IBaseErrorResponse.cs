using Financial.Control.Domain.Entities.NotificationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Models
{
    public interface IBaseErrorResponse
    {
        public IReadOnlyCollection<Notification> Errors { get; }
    }
}
