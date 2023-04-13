namespace Financial.Control.Domain.Models.Users.Response.Update
{
    public interface IUserUpdateSuccessResponse : IBaseSuccessResponse
    {
        public IUserModel Result { get; }
    }
}
