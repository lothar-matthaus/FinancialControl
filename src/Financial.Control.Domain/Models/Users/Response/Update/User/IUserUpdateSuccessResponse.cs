namespace Financial.Control.Domain.Models.Users.Response.Update.User
{
    public interface IUserUpdateSuccessResponse : IBaseSuccessResponse
    {
        public IUserModel Result { get; }
    }
}
