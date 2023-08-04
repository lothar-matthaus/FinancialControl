using Financial.Control.Domain.Entities;
using System.Linq.Expressions;

namespace Financial.Control.Domain.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        public IQueryable<Category> Query(Expression<Func<Category, bool>> expression);

        //public void Add(Category category);
        // public void Update(Category category);
    }
}
