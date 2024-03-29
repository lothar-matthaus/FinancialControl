﻿
using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Models
{
    public interface IErrorResponse
    {
        public abstract string Message { get; }
        public abstract IReadOnlyCollection<Notification> Errors { get; }
    }
}
