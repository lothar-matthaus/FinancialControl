using Financial.Control.Application.Models.Users.Response.Update.Password;
using Financial.Control.Domain.Models.Users.Commands;

namespace Financial.Control.Application.Models.Users.Commands
{
    public sealed class UserUpdatePasswordRequest : BaseRequest<UserUpdatePasswordResponse>, IUserUpdatePasswordRequest
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
