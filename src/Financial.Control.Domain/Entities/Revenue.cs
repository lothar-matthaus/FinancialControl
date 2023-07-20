using Financial.Control.Domain.Entities.Base;

namespace Financial.Control.Domain.Entities
{
    public class Revenue : BaseEntity
    {
        public string Name { get; }
        public decimal Value { get; }
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

        public static Revenue Create(string name, decimal revenue, DateTime date) => new Revenue(name, revenue, date);
    }
}
