using Financial.Control.Domain.Entities;

namespace Financial.Control.Application.Models.Users.Response.Create
{
    public class UserCreateSuccessResponse : BaseSuccessResponse
    {
        public UserModel Result { get; }

        public UserCreateSuccessResponse(User user)
        {
            Result = UserModel.Create(user.Id, user.Name, user.Email.Value, user.ProfilePicture.Value);
        }

        public static UserCreateSuccessResponse Create(User user) => new UserCreateSuccessResponse(user);
    }
}