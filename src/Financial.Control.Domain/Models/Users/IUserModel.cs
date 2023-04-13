namespace Financial.Control.Domain.Models.Users
{
    public interface IUserModel : IBaseModel
    {
        public new long Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string ProfilePictureUrl { get; }
    }
}
