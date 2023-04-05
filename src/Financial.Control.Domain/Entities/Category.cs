using Financial.Control.Domain.Entities.Base;

namespace Financial.Control.Domain.Entities
{
    public class Category : BaseEntity
    {
        #region Properties
        public string Name { get; }
        #endregion

        #region Navigation
        public ICollection<Expense> Expenses { get; }
        #endregion

        private Category(string name) => Name = name;

        public static Category Create(string name) => new Category(name);
    }
}
