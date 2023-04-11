namespace Financial.Control.Domain.Models.Users.Response.Create
{
    public interface IUserCreateSuccessResponse : IBaseSuccessResponse
    {
        public IUserModel Result { get; }
    }
}
