﻿using Financial.Control.Domain.Entities.NotificationEntity;

namespace Financial.Control.Domain.Models.Cards.Response.Create
{
    public interface ICardCreateErrorResponse : IBaseErrorResponse
    {
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
