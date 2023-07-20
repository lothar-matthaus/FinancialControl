using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Users;

namespace Financial.Control.Application.Models.Users
{
    public class UserModel : BaseModel, IUserModel
    {
        #region Properties
        public string Name { get; }
        public string Email { get; }
        public string ProfilePictureUrl { get; }
        #endregion

        private UserModel(User user) : base(user.Id, user.CreationDate, user.UpdateDate)
        {
            Name = user.Name;
            Email = user.Account.Email.Value;
            ProfilePictureUrl = user.Account.ProfilePicture.Value;
        }

        public static UserModel Create(User user) => new UserModel(user);
    }
}
