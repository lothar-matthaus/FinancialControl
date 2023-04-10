using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models;

namespace Financial.Control.Application.Models.Users.Response.Update
{
    public class UserUpdateSuccessResponse : IBaseSuccessResponse
    {
        public UserModel Result { get; }
        private UserUpdateSuccessResponse(User user)
        {
            Result = UserModel.Create(user);
        }

        public static UserUpdateSuccessResponse Create(User user) => new UserUpdateSuccessResponse(user);
    }
}
