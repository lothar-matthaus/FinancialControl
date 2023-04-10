using Financial.Control.Domain.Entities;

namespace Financial.Control.Application.Models.Users
{
    public class UserModel : BaseModel
    {
        #region Properties
        public string Name { get; }
        public string Email { get; }
        public string ProfilePictureUrl { get; }
        #endregion

        private UserModel(User user) : base(user.Id)
        {
            Name = user.Name;
            Email = user.Email.Value;
            ProfilePictureUrl = user.ProfilePicture.Value;
        }

        public static UserModel Create(User user) => new UserModel(user);
    }
}
