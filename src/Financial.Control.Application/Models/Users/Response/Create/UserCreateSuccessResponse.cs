using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Users;
using Financial.Control.Domain.Models.Users.Response.Create;

namespace Financial.Control.Application.Models.Users.Response.Create
{
    public class UserCreateSuccessResponse : BaseSuccessResponse, IUserCreateSuccessResponse
    {
        public IUserModel Result { get; }

        public UserCreateSuccessResponse(User user)
        {
            Result = UserModel.Create(user);
        }

        public static UserCreateSuccessResponse Create(User user) => new UserCreateSuccessResponse(user);
    }
}