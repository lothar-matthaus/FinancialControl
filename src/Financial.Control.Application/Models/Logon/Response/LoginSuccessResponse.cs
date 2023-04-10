using Financial.Control.Domain.Entities;

namespace Financial.Control.Application.Models.Logon.Response
{
    public class LoginSuccessResponse : BaseSuccessResponse
    {
        public LoginModel Result { get; }

        private LoginSuccessResponse(User user)
        {
            Result = LoginModel.Create(user);
        }

        public static LoginSuccessResponse Create(User user) => new LoginSuccessResponse(user);
    }
}
