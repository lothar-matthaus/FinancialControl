namespace Financial.Control.Domain.Models.Users.Response.Update.Password
{
    public interface IUserUpdatePasswordSuccessResponse : IBaseSuccessResponse
    {
        public IUserModel Result { get; }
    }
}
