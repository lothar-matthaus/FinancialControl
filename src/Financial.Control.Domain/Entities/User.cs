using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Records;

namespace Financial.Control.Domain.Entities
{
    public class User : BaseEntity
    {
        #region Properties
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public ProfilePicture ProfilePicture { get; private set; }
        public Password Password { get; private set; }
        public UserToken Token { get; private set; }

        #endregion

        #region Navigation
        public ICollection<Card> Cards { get; private set; }
        public ICollection<Expense> Expenses { get; private set; }
        public ICollection<Revenue> Revenues { get; private set; }
        #endregion

        protected User() { }
        private User(string name, string email, string profilePictureURL, string plainPassword)
        {
            Name = name;
            Email = Email.Create(email);
            ProfilePicture = ProfilePicture.Create(profilePictureURL);
            Password = Password.Create(plainPassword);
        }

        #region Behaviors

        public void SetName(string name) => Name = name;
        public void SetEmail(string email) => Email = Email.Create(email);
        public void SetProfilePictureUrl(string profilePictureUrl) => ProfilePicture = ProfilePicture.Create(profilePictureUrl);

        public UserToken Login(ITokenService tokenService, string plainTextPassword)
        {
            if (!Password.IsMatchPassword(plainTextPassword))
                return null;

            Token = tokenService.GenerateAccessToken(this);

            return Token;
        }

        public void AddCard(Card card)
        {
            Cards ??= new List<Card>();
            Cards.Add(card);
        }
        public void AddExpense(Expense expense)
        {
            Expenses ??= new List<Expense>();
            Expenses.Add(expense);
        }

        #endregion


        public static User Create(string name, string email, string profilePictureURL, string plainPassword) => new User(name, email, profilePictureURL, plainPassword);
    }
}
