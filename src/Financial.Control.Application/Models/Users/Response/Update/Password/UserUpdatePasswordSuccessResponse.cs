using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Users;
using Financial.Control.Domain.Models.Users.Response.Update.Password;

namespace Financial.Control.Application.Models.Users.Response.Update.Password
{
    public sealed class UserUpdatePasswordSuccessResponse : BaseSuccessResponse, IUserUpdatePasswordSuccessResponse
    {
        public IUserModel Result { get; }

        private UserUpdatePasswordSuccessResponse(User user) => Result = UserModel.Create(user);

        #region MyRegion
        public static UserUpdatePasswordSuccessResponse Create(User user) => new UserUpdatePasswordSuccessResponse(user);
        #endregion
    }
}
