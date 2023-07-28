using Financial.Control.Domain.Entities.Base;

namespace Financial.Control.Domain.Entities
{
    public class Revenue : BaseEntity
    {
        public string Name { get; private set; }
        public decimal Value { get; private set; }
        public DateTime Date { get; }

        #region Navigation
        public long UserId { get; }
        public User User { get; }
        #endregion

        protected Revenue() { }
        private Revenue(string name, decimal value, DateTime date)
        {

            Name = name;
            Value = value;
            Date = date;
        }

        #region Behaviors
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            Name = name;
        }
        public void SetValue(decimal value)
        {
            if (value is 0)
                return;

            Value = value;
        }
        #endregion

        #region Factory
        public static Revenue Create(string name, decimal revenue, DateTime date) => new Revenue(name, revenue, date);
        #endregion
    }
}
