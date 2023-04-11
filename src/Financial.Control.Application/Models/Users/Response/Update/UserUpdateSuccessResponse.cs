using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Users.Response.Update;

namespace Financial.Control.Application.Models.Users.Response.Update
{
    public class UserUpdateSuccessResponse : IUserUpdateSuccessResponse
    {
        public UserModel Result { get; }
        private UserUpdateSuccessResponse(User user)
        {
            Result = UserModel.Create(user);
        }

        public static UserUpdateSuccessResponse Create(User user) => new UserUpdateSuccessResponse(user);
    }
}
