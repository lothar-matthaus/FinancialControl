using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Entities
{
    public class User : BaseEntity
    {
        #region Private properties
        private string _name;
        #endregion
        #region Properties

        public string Name
        {
            get { return _name; }
            set
            {
                Validate(isInvalidIf: (string.IsNullOrWhiteSpace(value)),
                         ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Name), "O nome do usuário deve ser informado."),
                         ifValid: () => _name = value);

                Validate(isInvalidIf: (value.Length < 4),
                         ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Name), "O nome do usuário deve ter pelo menos 4 caracteres."),
                         ifValid: () => _name = value);
            }
        }

        #endregion

        #region Navigation
        public ICollection<Card> Cards { get; private set; }
        public ICollection<Expense> Expenses { get; private set; }
        public ICollection<Revenue> Revenues { get; private set; }
        public long AccountId { get; }
        public Account Account { get; }
        #endregion

        protected User() { }
        private User(string name, Account account)
        {
            Name = name;
            Account = account;

            _notifications.AddRange(Account.GetNotifications());
        }

        #region Behaviors

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            Name = name;
        }
        public void AddCard(Card card)
        {
            Cards ??= new List<Card>();
            Cards.Add(card);
        }

        public void RemoveCard(Card card)
        {
            Cards ??= new List<Card>();
            Cards.Remove(card);
        }

        public void AddExpense(Expense expense)
        {
            Expenses ??= new List<Expense>();
            Expenses.Add(expense);
        }

        public void RemoveExpense(Expense expense)
        {
            Expenses ??= new List<Expense>();
            Expenses.Remove(expense);
        }
        public void AddRevenue(Revenue revenue)
        {
            Revenues ??= new List<Revenue>();
            Revenues.Add(revenue);
        }

        public void RemoveRevenue(Revenue revenue)
        {
            Revenues ??= new List<Revenue>();
            Revenues.Remove(revenue);
        }
        #endregion

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
        #endregion

        #region Factory
        public static User Create(string name, Account account) => new User(name, account);
        #endregion
    }
}
