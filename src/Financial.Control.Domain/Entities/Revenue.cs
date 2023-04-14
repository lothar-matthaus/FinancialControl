using Financial.Control.Domain.Entities.Base;

namespace Financial.Control.Domain.Entities
{
    public class Revenue : BaseEntity
    {
        public string Name { get; }
        public decimal Value { get; }

        #region Navigation
        public long UserId { get; }
        public User User { get; }
        #endregion

        protected Revenue() { }
        private Revenue(string name, decimal value)
        {
            Name = name;
            Value = value;
        }

        public static Revenue Create(string name, decimal revenue) => new Revenue(name, revenue);
    }
}
