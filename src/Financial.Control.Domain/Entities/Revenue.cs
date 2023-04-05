using Financial.Control.Domain.Entities.Base;

namespace Financial.Control.Domain.Entities
{
    public class Revenue : BaseEntity
    {
        public decimal Value { get; }

        #region Navigation
        public long UserId { get; }
        public User User { get; set; }
        #endregion

        protected Revenue() { }
        private Revenue(decimal value, User user)
        {
            Value = value;
            User = user;
        }

        public static Revenue Create(decimal revenue, User user) => new Revenue(revenue, user);
    }
}
