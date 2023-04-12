namespace Financial.Control.Domain.Models.Users
{
    public interface IUserModel : IBaseModel
    {
        public string Name { get; }
        public string Email { get; }
        public string ProfilePictureUrl { get; }
    }
}
