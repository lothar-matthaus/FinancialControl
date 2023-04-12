using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Records;

namespace Financial.Control.Domain.Entities
{
    public class User : BaseEntity
    {
        #region Properties
        public string Name { get; private set; }
        #endregion

        #region Navigation
        public ICollection<Card> Cards { get; private set; }
        public ICollection<Expense> Expenses { get; private set; }
        public ICollection<Revenue> Revenues { get; private set; }
        public long AccountId { get; }
        public Account Account { get; }
        #endregion

        protected User() { }
        private User(string name, string email, string profilePictureURL, string plainPassword)
        {
            Name = name;
            Account = Account.Create(email, profilePictureURL, plainPassword);
        }

        #region Behaviors

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            Name = name;
        }
        #region Account Behaviors
        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return;

            Account.SetEmail(email);
        }

        public void SetProfilePicture(string profilePictureUrl)
        {
            if (string.IsNullOrWhiteSpace(profilePictureUrl))
                return;

            Account.SetProfilePicture(profilePictureUrl);
        }

        public UserToken Login(ITokenService tokenService, string plainTextPassword)
        {
            if (!Account.Password.IsMatchPassword(plainTextPassword))
                return null;

            UserToken token = tokenService.GenerateAccessToken(this);

            Account?.SetToken(token);

            return Account.Token;
        }
        #endregion


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
