using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Users;
using Financial.Control.Domain.Models.Users.Response.Get;

namespace Financial.Control.Application.Models.Users.Response.Get
{
    public class UserGetSuccessResponse : IUserGetSuccessResponse
    {
        public IUserModel Result { get; }

        private UserGetSuccessResponse(User user)
        {
            Result = UserModel.Create(user);
        }

        public static UserGetSuccessResponse Create(User user) => new UserGetSuccessResponse(user);
    }
}
