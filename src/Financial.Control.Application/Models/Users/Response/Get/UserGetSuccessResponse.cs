using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Application.Models.Users.Response.Get
{
    public class UserGetSuccessResponse : IBaseSuccessResponse
    {
        public UserModel Result { get; }

        private UserGetSuccessResponse(User user)
        {
            Result = UserModel.Create(user);
        }

        public static UserGetSuccessResponse Create(User user) => new UserGetSuccessResponse(user);
    }
}
