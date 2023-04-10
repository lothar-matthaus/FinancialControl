using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Application.Models.Users.Response.Get
{
    public class UserGetErrorResponse : IBaseErrorResponse
    {
        public IReadOnlyCollection<Notification> Errors { get; }

        private UserGetErrorResponse(IReadOnlyCollection<Notification> errors)
        {
            Errors = errors;
        }

        public static UserGetErrorResponse Create(IReadOnlyCollection<Notification> errors) => new UserGetErrorResponse(errors);
    }
}
