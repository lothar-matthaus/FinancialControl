﻿using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Models.Revenues.Response.Update
{
    public interface IRevenueUpdateErrorResponse : IBaseErrorResponse
    {
        public new string Message { get; }
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
