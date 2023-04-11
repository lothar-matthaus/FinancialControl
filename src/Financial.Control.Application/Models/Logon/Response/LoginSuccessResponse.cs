using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Logon;
using Financial.Control.Domain.Models.Logon.Response;

namespace Financial.Control.Application.Models.Logon.Response
{
    public class LoginSuccessResponse : BaseSuccessResponse, ILoginSuccessResponse
    {
        public ILoginModel Result { get; }
        private LoginSuccessResponse(User user) => Result = LoginModel.Create(user);
        public static ILoginSuccessResponse Create(User user) => new LoginSuccessResponse(user);
    }
}
