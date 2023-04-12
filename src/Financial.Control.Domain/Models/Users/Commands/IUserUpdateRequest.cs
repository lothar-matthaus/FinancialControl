namespace Financial.Control.Domain.Models.Users.Commands
{
    public interface IUserUpdateRequest : IBaseRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}

