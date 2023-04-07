using Microsoft.EntityFrameworkCore;

namespace Financial.Control.Infra.Data.Repository.Base
{
    public abstract class BaseRepository<TDbContext> where TDbContext : DbContext
    {
        protected readonly TDbContext _dbContext;
        public BaseRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
