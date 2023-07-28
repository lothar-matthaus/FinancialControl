﻿using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Models.Users.Response.Update.User
{
    public interface IUserUpdateErrorResponse : IBaseErrorResponse
    {
        public new string Message { get; }
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}