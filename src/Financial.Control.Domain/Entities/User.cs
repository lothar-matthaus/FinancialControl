using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Records;

namespace Financial.Control.Domain.Entities
{
    public class User : BaseEntity
    {
        #region Properties
        public string Name { get; }

        public Email Email { get; }
        public ProfilePicture ProfilePicture { get; }
        public Password Password { get; }
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


        public static User Create(string name, string email, string profilePictureURL, string plainPassword) => new User(name, email, profilePictureURL, plainPassword);
    }
}
