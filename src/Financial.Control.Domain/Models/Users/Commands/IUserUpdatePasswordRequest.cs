namespace Financial.Control.Domain.Models.Users.Commands
{
    public interface IUserUpdatePasswordRequest : IBaseRequest
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
