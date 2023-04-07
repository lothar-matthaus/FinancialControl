namespace Financial.Control.Application.Models.Users
{
    public class UserModel : BaseModel
    {
        #region Properties
        public string Name { get; }
        public string Email { get; }
        public string ProfilePictureUrl { get; }
        #endregion
        private UserModel(long id, string nome, string email, string profilePictureUrl) : base(id)
        {
            Name = nome;
            Email = email;
            ProfilePictureUrl = profilePictureUrl;
        }

        public static UserModel Create(long id, string nome, string email, string profilePictureUrl) => new UserModel(id, nome, email, profilePictureUrl);
    }
}
