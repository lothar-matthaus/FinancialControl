namespace Financial.Control.Domain.Models.Users.Response.Get
{
    public interface IUserGetSuccessResponse : IBaseSuccessResponse
    {
        public IUserModel Result { get; }
    }
}
