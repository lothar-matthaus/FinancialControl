using Financial.Control.Domain.Entities.Base;

namespace Financial.Control.Domain.Entities
{
    public class Revenue : BaseEntity
    {
        public decimal Value { get; }

        #region Navigation
        public long UserId { get; }
        public User User { get; }
        #endregion

        protected Revenue() { }
        private Revenue(decimal value)
        {
            Value = value;
        }

        public static Revenue Create(decimal revenue) => new Revenue(revenue);
    }
}
